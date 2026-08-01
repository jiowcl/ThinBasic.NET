// ThinBasic.NET - ThinBasic Programming Language for .NET
// Copyright (c) 2019-2026 Jiowcl. All rights reserved.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;

namespace ThinBasic.NET.Core.Tests
{
    [TestClass]
    [DoNotParallelize]
    public class ThinbasicTests
    {
        [TestCleanup]
        public void Cleanup()
        {
            Thinbasic.ClearSymbolCallbacks();
        }

        [TestMethod]
        public void Init_Succeeds_And_ReleaseUsesHandle()
        {
            int hThin = Thinbasic.Init(0, 0, "thinbasic");

            Assert.AreEqual(0, hThin);
            Assert.AreEqual(0, Thinbasic.GetLastError());
            Assert.AreEqual(0, Thinbasic.Release(hThin));
        }

        [TestMethod]
        public void Run_ExecutesScript_WithoutRuntimeError()
        {
            string scriptBuffer = "DIM n AS LONG\r\nn = 42\r\n";
            string scriptPath = @"Sample\test.tbasic";
            if (File.Exists(scriptPath))
            {
                scriptBuffer = File.ReadAllText(scriptPath, Encoding.UTF8);
            }

            int hThin = Thinbasic.Init(0, 0, "thinbasic");
            Assert.AreEqual(0, hThin);

            int result = Thinbasic.Run(
                hThin,
                scriptBuffer,
                (int)Enums.BufferType.IsScript,
                0, 0, 0, 0,
                (int)Enums.CallingProgram.Console,
                0);

            int lastError = Thinbasic.GetLastError();
            Thinbasic.Release(hThin);

            Assert.AreEqual(0, result);
            Assert.AreEqual(0, lastError);
        }

        [TestMethod]
        public void HostApi_Equate_Variable_And_FunctionSimpleCall()
        {
            int hThin = Thinbasic.Init(0, 0, "thinbasic");
            Assert.AreEqual(0, hThin);

            Assert.AreEqual(1, Thinbasic.AddEquate("%HOST_EQ", string.Empty, 7, (int)Enums.EquateType.Number));

            string script =
                "DIM n AS EXT\r\n" +
                "DIM s AS STRING\r\n" +
                "n = %HOST_EQ\r\n" +
                "s = \"a\"\r\n" +
                "FUNCTION Ping() AS STRING\r\n" +
                "  FUNCTION = \"pong\"\r\n" +
                "END FUNCTION\r\n";

            int run = Thinbasic.Run(
                hThin,
                script,
                (int)Enums.BufferType.IsScript,
                0, 0, 0, 0,
                (int)Enums.CallingProgram.Console,
                0);

            Assert.AreEqual(0, run);
            Assert.AreEqual(0, Thinbasic.GetLastError());

            Assert.AreEqual(7.0, Thinbasic.VariableGetValueNum("n"), 0.0001);
            Assert.AreEqual(0, Thinbasic.ChangeVariableNumber("n", 100.25));
            Assert.AreEqual(100.25, Thinbasic.VariableGetValueNum("n"), 0.0001);

            Thinbasic.ChangeVariableString("s", "xyz");

            int mainType, subType, isArray, dataPtr, nElements;
            int info = Thinbasic.VariableGetInfoEx("n", out mainType, out subType, out isArray, out dataPtr, out nElements);
            Assert.AreNotEqual(0, info);
            Assert.AreEqual((int)Enums.VarMainType.IsNumber, mainType);
            Assert.AreEqual(1, nElements);

            double num;
            string str;
            Assert.AreEqual(0, Thinbasic.FunctionSimpleCall("Ping", out num, out str));
            Assert.AreEqual("pong", str);

            Thinbasic.Release(hThin);
        }

        [TestMethod]
        public void LoadSymbol_DelegateCallbacks_AreInvokedFromScript()
        {
            int calls = 0;
            ThinBasicSubCallback sub = () => calls++;
            ThinBasicNumberCallback number = () => 123.5;
            ThinBasicStringCallback text = () => Thinbasic.AllocReturnString("hello");

            int hThin = Thinbasic.Init(0, 0, "thinbasic");
            Assert.AreEqual(0, hThin);

            Assert.IsTrue(Thinbasic.LoadSymbol("HostFlag", sub, Enums.ForceOverWrite) > 0);
            Assert.IsTrue(Thinbasic.LoadSymbol("HostNum", number, Enums.ForceOverWrite) > 0);
            Assert.IsTrue(Thinbasic.LoadSymbolEx(
                "HostStr$",
                (int)Enums.ReturnType.String,
                text,
                Enums.ForceOverWrite,
                "HostStr$",
                "test") > 0);

            string script =
                "HostFlag\r\n" +
                "DIM n AS EXT\r\n" +
                "DIM s AS STRING\r\n" +
                "n = HostNum\r\n" +
                "s = HostStr$\r\n" +
                "FUNCTION GetS() AS STRING\r\n" +
                "  FUNCTION = s\r\n" +
                "END FUNCTION\r\n";

            int run = Thinbasic.Run(
                hThin,
                script,
                (int)Enums.BufferType.IsScript,
                0, 0, 0, 0,
                (int)Enums.CallingProgram.Console,
                0);

            Assert.AreEqual(0, run);
            Assert.AreEqual(0, Thinbasic.GetLastError());
            Assert.AreEqual(1, calls);
            Assert.AreEqual(123.5, Thinbasic.VariableGetValueNum("n"), 0.0001);

            double num;
            string str;
            Assert.AreEqual(0, Thinbasic.FunctionSimpleCall("GetS", out num, out str));
            Assert.AreEqual("hello", str);

            Thinbasic.Release(hThin);
        }

        [TestMethod]
        public void ParserApi_HostKeywords_ParseNumberAndStringArgs()
        {
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

            int hThin = Thinbasic.Init(0, 0, "thinbasic");
            Assert.AreEqual(0, hThin);
            Assert.IsTrue(Thinbasic.LoadSymbol("HostAdd", hostAdd, Enums.ForceOverWrite) > 0);
            Assert.IsTrue(Thinbasic.LoadSymbol("HostJoin$", hostJoin, Enums.ForceOverWrite) > 0);

            string script =
                "DIM n AS EXT\r\n" +
                "DIM s AS STRING\r\n" +
                "n = HostAdd(10, 32.5)\r\n" +
                "s = HostJoin$(\"hel\", \"lo\")\r\n" +
                "FUNCTION GetS() AS STRING\r\n" +
                "  FUNCTION = s\r\n" +
                "END FUNCTION\r\n";

            int run = Thinbasic.Run(
                hThin,
                script,
                (int)Enums.BufferType.IsScript,
                0, 0, 0, 0,
                (int)Enums.CallingProgram.Console,
                0);

            Assert.AreEqual(0, run);
            Assert.AreEqual(0, Thinbasic.GetLastError());
            Assert.AreEqual(42.5, Thinbasic.VariableGetValueNum("n"), 0.0001);

            double num;
            string str;
            Assert.AreEqual(0, Thinbasic.FunctionSimpleCall("GetS", out num, out str));
            Assert.AreEqual("hello", str);

            Thinbasic.Release(hThin);
        }

        [TestMethod]
        public void LoadSymbol_NullFunctionPointer_DoesNotThrow()
        {
            int hThin = Thinbasic.Init(0, 0, "thinbasic");
            Assert.AreEqual(0, hThin);

            // SDK documents -3 for invalid pointers; some thinCore builds still accept null at registration.
            int result = Thinbasic.LoadSymbol("BadPtr", (int)Enums.ReturnType.None, IntPtr.Zero, Enums.ForceOverWrite);
            Thinbasic.Release(hThin);

            Assert.IsTrue(result == -3 || result > 0, "Unexpected LoadSymbol result: " + result);
        }

        [TestMethod]
        public void LoadSymbol_EmptyName_ReturnsEmptyNameError()
        {
            int hThin = Thinbasic.Init(0, 0, "thinbasic");
            Assert.AreEqual(0, hThin);

            ThinBasicSubCallback sub = () => { };
            int result = Thinbasic.LoadSymbol(string.Empty, sub, Enums.ForceOverWrite);
            Thinbasic.Release(hThin);

            // SDK: -1 = empty SymbolName
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void LoadSymbol_DelegateNull_Throws()
        {
            try
            {
                Thinbasic.LoadSymbol("X", (int)Enums.ReturnType.None, (Delegate)null, 0);
                Assert.Fail("Expected ArgumentNullException.");
            }
            catch (ArgumentNullException)
            {
            }
        }
    }
}
