// ThinBasic.NET - ThinBasic Programming Language for .NET
// Copyright (c) 2019-2026 Jiowcl. All rights reserved.

using System;
using System.IO;
using System.Text;
using ThinBasic.NET.Core;

namespace ThinBasic.Example
{
    /// <summary>
    /// Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        static void Main(
            string[] args)
        {
            string scriptPath = @"Sample\test_gui.tbasic";

            if (!File.Exists(scriptPath))
            {
                scriptPath = @"Sample\test_fib.tbasic";
            }

            if (!File.Exists(scriptPath))
            {
                // Fallback inline script when sample files are missing.
                RunBuffer("DIM n AS LONG\r\nn = 1\r\n", Enums.CallingProgram.Console);
            }
            else
            {
                string scriptBuffer = File.ReadAllText(scriptPath, Encoding.UTF8);
                Console.WriteLine("Script: " + scriptBuffer);
                RunBuffer(scriptBuffer, Enums.CallingProgram.GUI);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// RunBuffer
        /// </summary>
        /// <param name="scriptBuffer"></param>
        /// <param name="callingProgram"></param>
        /// <returns>Returns void.</returns>
        static void RunBuffer(
            string scriptBuffer, 
            Enums.CallingProgram callingProgram)
        {
            int bufferType = (int)Enums.BufferType.IsScript;

            try
            {
                int hThin = Thinbasic.Init(0, 0, "thinbasic");
                
                if (hThin != 0)
                {
                    Console.WriteLine("Init failed: " + hThin + ", GetLastError=" + Thinbasic.GetLastError());
                    return;
                }

                int result = Thinbasic.Run(hThin, scriptBuffer, bufferType, 0, 0, 0, 0, (int)callingProgram, 0);
                int lastError = Thinbasic.GetLastError();
                Thinbasic.Release(hThin);

                Console.WriteLine("Run result: " + result);
                Console.WriteLine("GetLastError: " + lastError);

                if (Thinbasic.ErrorFree() == 0)
                {
                    Console.WriteLine("ErrorFlag: " + Thinbasic.ErrorFlag());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
