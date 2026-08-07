// ThinBasic.NET - ThinBasic Programming Language for .NET
// Copyright (c) 2019-2026 Jiowcl. All rights reserved.

using System;
using System.IO;
using System.Text;
using ThinBasic.NET.Core;

namespace ThinBasic.Example
{
    /// <summary>
    /// Runnable demos: embed | host | parser | array | isolated
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point for the program.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        /// <returns>0 for success, 1 for failure.</returns>
        static int Main(
            string[] args)
        {
            string mode = args.Length > 0 ? args[0].Trim().ToLowerInvariant() : "embed";

            try
            {
                switch (mode)
                {
                    case "embed":
                        RunEmbed();
                        break;
                    case "host":
                        RunHost();
                        break;
                    case "parser":
                        RunParser();
                        break;
                    case "array":
                        RunArray();
                        break;
                    case "isolated":
                        RunIsolated();
                        break;
                    case "help":
                    case "-h":
                    case "--help":
                        PrintUsage();
                        return 0;
                    default:
                        Console.WriteLine("Unknown mode: " + mode);
                        PrintUsage();
                        return 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                Thinbasic.ClearSymbolCallbacks();
            }

            if (args.Length == 0)
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }

            return 0;
        }

        /// <summary>
        /// Print the usage instructions for the program.
        /// </summary>
        static void PrintUsage()
        {
            Console.WriteLine("ThinBasic.Example modes:");
            Console.WriteLine("  embed     Run an embedded script (default)");
            Console.WriteLine("  host      Inject equate + host keywords");
            Console.WriteLine("  parser    HostAdd / HostJoin$ with parser APIs");
            Console.WriteLine("  array     Array inspect / direct element update");
            Console.WriteLine("  isolated  InitIsolated + IsolationPath");
        }

        /// <summary>
        /// Run the embed mode.
        /// </summary>
        static void RunEmbed()
        {
            string scriptPath = Path.Combine(AppContext.BaseDirectory, "Sample", "test_embed.tbasic");
            string script = File.Exists(scriptPath)
                ? File.ReadAllText(scriptPath, Encoding.UTF8)
                : "DIM n AS LONG\r\nn = 42\r\n";

            Console.WriteLine("=== embed ===");
            Console.WriteLine(script);

            using (var session = EngineSession.Start())
            {
                int result = session.Run(script, Enums.CallingProgram.Console);
                Console.WriteLine("Run result: " + result);
                Console.WriteLine("GetLastError: " + Thinbasic.GetLastError());
                Console.WriteLine("n = " + Thinbasic.VariableGetValueNum("n"));
            }
        }

        /// <summary>
        /// Run the host mode.
        /// </summary>
        static void RunHost()
        {
            Console.WriteLine("=== host ===");

            int hostCalls = 0;
            ThinBasicSubCallback hostFlag = () => hostCalls++;
            ThinBasicNumberCallback hostNum = () => 123.5;
            ThinBasicStringCallback hostStr = () => Thinbasic.AllocReturnString("hello");

            using (var session = EngineSession.Start())
            {
                Thinbasic.AddEquate("%HOST_EQ", string.Empty, 7, (int)Enums.EquateType.Number);
                Thinbasic.LoadSymbol("HostFlag", hostFlag, Enums.ForceOverWrite);
                Thinbasic.LoadSymbol("HostNum", hostNum, Enums.ForceOverWrite);
                Thinbasic.LoadSymbol("HostStr$", hostStr, Enums.ForceOverWrite);

                string script =
                    "HostFlag\r\n" +
                    "DIM n AS EXT\r\n" +
                    "DIM s AS STRING\r\n" +
                    "n = HostNum + %HOST_EQ\r\n" +
                    "s = HostStr$\r\n" +
                    "FUNCTION GetS() AS STRING\r\n" +
                    "  FUNCTION = s\r\n" +
                    "END FUNCTION\r\n";

                session.Run(script, Enums.CallingProgram.Console);
                Console.WriteLine("hostCalls = " + hostCalls);
                Console.WriteLine("n = " + Thinbasic.VariableGetValueNum("n"));

                double num;
                string str;
                Thinbasic.FunctionSimpleCall("GetS", out num, out str);
                Console.WriteLine("s = " + str);
            }
        }

        /// <summary>
        /// Run the parser mode.
        /// </summary>
        static void RunParser()
        {
            Console.WriteLine("=== parser ===");

            ThinBasicNumberCallback hostAdd = () =>
            {
                if (Thinbasic.CheckOpenParensMandatory() == 0)
                {
                    return 0;
                }

                Thinbasic.ParseNumber(out double a);
                if (Thinbasic.CheckCommaMandatory() == 0)
                {
                    return 0;
                }

                Thinbasic.ParseNumber(out double b);
                if (Thinbasic.CheckCloseParensMandatory() == 0)
                {
                    return 0;
                }

                return a + b;
            };

            ThinBasicStringCallback hostJoin = () =>
            {
                if (Thinbasic.CheckOpenParensMandatory() == 0)
                {
                    return Thinbasic.AllocReturnString(string.Empty);
                }

                Thinbasic.ParseString(out string a);
                if (Thinbasic.CheckCommaMandatory() == 0)
                {
                    return Thinbasic.AllocReturnString(string.Empty);
                }

                Thinbasic.ParseString(out string b);
                if (Thinbasic.CheckCloseParensMandatory() == 0)
                {
                    return Thinbasic.AllocReturnString(string.Empty);
                }

                return Thinbasic.AllocReturnString(a + b);
            };

            using (var session = EngineSession.Start())
            {
                Thinbasic.LoadSymbol("HostAdd", hostAdd, Enums.ForceOverWrite);
                Thinbasic.LoadSymbol("HostJoin$", hostJoin, Enums.ForceOverWrite);

                string script =
                    "DIM n AS EXT\r\n" +
                    "DIM s AS STRING\r\n" +
                    "n = HostAdd(10, 32.5)\r\n" +
                    "s = HostJoin$(\"hel\", \"lo\")\r\n" +
                    "FUNCTION GetS() AS STRING\r\n" +
                    "  FUNCTION = s\r\n" +
                    "END FUNCTION\r\n";

                session.Run(script, Enums.CallingProgram.Console);
                Console.WriteLine("HostAdd(10, 32.5) => " + Thinbasic.VariableGetValueNum("n"));

                double num;
                string str;
                Thinbasic.FunctionSimpleCall("GetS", out num, out str);
                
                Console.WriteLine("HostJoin$ => " + str);
            }
        }

        /// <summary>
        /// Run the array mode.
        /// </summary>
        static void RunArray()
        {
            Console.WriteLine("=== array ===");

            using (var session = EngineSession.Start())
            {
                string script =
                    "DIM a(3) AS EXT\r\n" +
                    "a(1) = 10\r\n" +
                    "a(2) = 20\r\n" +
                    "a(3) = 30\r\n";

                session.Run(script, Enums.CallingProgram.Console);

                Console.WriteLine("IsArray(a) = " + Thinbasic.VariableIsArray("a"));
                Console.WriteLine("Elements(a) = " + Thinbasic.ArrayGetElements("a"));
                Console.WriteLine("a(1..3) = {0}, {1}, {2}",
                    Thinbasic.VariableGetValueNum("a", 1),
                    Thinbasic.VariableGetValueNum("a", 2),
                    Thinbasic.VariableGetValueNum("a", 3));

                int mainType, subType, isArray, dataPtr, nElements;
                int varPtr = Thinbasic.VariableGetInfoEx("a", out mainType, out subType, out isArray, out dataPtr, out nElements);
                Console.WriteLine("varPtr = " + varPtr + ", nElements = " + nElements);

                Thinbasic.ChangeVariableNumberDirect(varPtr, 2, 99.5);
                Console.WriteLine("a(2) after Direct = " + Thinbasic.VariableGetValueNum("a", 2));
                Console.WriteLine("GetDirect(2) = " + Thinbasic.GetVariableNumberDirect(varPtr, 2));

                Thinbasic.VariableRedim(varPtr, Enums.True, 5, 0, 0);
                Console.WriteLine("Elements after Redim = " + Thinbasic.ArrayGetElements("a"));
            }
        }

        /// <summary>
        /// Run the isolated mode.
        /// </summary>
        /// <returns>0 for success, 1 for failure.</returns>
        static void RunIsolated()
        {
            Console.WriteLine("=== isolated ===");

            string isoPath = Path.Combine(Path.GetTempPath(), "ThinBasicNET_ExampleIso_" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(isoPath);

            try
            {
                using (var session = EngineSession.StartIsolated(isoPath))
                {
                    Console.WriteLine("IsIsolated = " + Thinbasic.IsIsolated());
                    Console.WriteLine("IsolationPath = " + Thinbasic.IsolationPath());
                    Console.WriteLine("IsBundled = " + Thinbasic.IsBundled());
                    Console.WriteLine("ResourcesCount = " + Thinbasic.ResourcesCount());

                    session.Run("DIM n AS LONG\r\nn = 7\r\n", Enums.CallingProgram.Console);
                    Console.WriteLine("n = " + Thinbasic.VariableGetValueNum("n"));
                }
            }
            finally
            {
                try
                {
                    Directory.Delete(isoPath, true);
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// Small Init/Release helper for demos.
        /// </summary>
        sealed class EngineSession : IDisposable
        {
            public int Handle { get; }

            /// <summary>
            /// Constructor for the EngineSession class.
            /// </summary>
            /// <param name="handle">The handle to the engine session.</param>
            private EngineSession(
                int handle)
            {
                Handle = handle;
            }

            /// <summary>
            /// Start a new engine session.
            /// </summary>
            /// <returns>A new EngineSession instance.</returns>
            public static EngineSession Start()
            {
                int h = Thinbasic.Init(0, 0, "thinbasic");

                if (h != 0)
                {
                    throw new InvalidOperationException("Init failed: " + h + ", GetLastError=" + Thinbasic.GetLastError());
                }

                return new EngineSession(h);
            }

            /// <summary>
            /// Start a new isolated engine session.
            /// </summary>
            public static EngineSession StartIsolated(string isolatedPath)
            {
                int h = Thinbasic.InitIsolated(0, 0, "thinbasic", isolatedPath);

                if (h != 0)
                {
                    throw new InvalidOperationException("InitIsolated failed: " + h + ", GetLastError=" + Thinbasic.GetLastError());
                }

                return new EngineSession(h);
            }

            /// <summary>
            /// Run a script in the engine session.
            /// </summary>
            /// <param name="script">The script to run.</param>
            /// <param name="callingProgram">The calling program.</param>
            /// <returns>The result of the script execution.</returns>
            public int Run(
                string script, 
                Enums.CallingProgram callingProgram)
            {
                return Thinbasic.Run(
                    Handle,
                    script,
                    (int)Enums.BufferType.IsScript,
                    0, 0, 0, 0,
                    (int)callingProgram,
                    0);
            }

            /// <summary>
            /// Dispose of the engine session.
            /// </summary>
            public void Dispose()
            {
                Thinbasic.Release(Handle);
            }
        }
    }
}
