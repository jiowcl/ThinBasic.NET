// ThinBasic.NET - ThinBasic Programming Language for .NET
// Copyright (c) 2019-2026 Jiowcl. All rights reserved.

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace ThinBasic.NET.Core.Tests
{
    [TestClass()]
    public class ThinbasicTests
    {
        [TestMethod()]
        public void InitTest()
        {
            int hThin = Thinbasic.Init(0, 0, "thinbasic");

            Assert.AreEqual(0, hThin);
            Assert.AreEqual(0, Thinbasic.GetLastError());

            Assert.AreEqual(0, Thinbasic.Release(hThin));
        }

        [TestMethod()]
        public void RunTest()
        {
            string scriptBuffer = "DIM n AS LONG\r\nn = 42\r\n";
            string scriptPath = @"Sample\test.tbasic";
            if (File.Exists(scriptPath))
            {
                scriptBuffer = File.ReadAllText(scriptPath, Encoding.UTF8);
            }

            int bufferType = (int)Enums.BufferType.IsScript;
            int callingProgram = (int)Enums.CallingProgram.Console;

            int hThin = Thinbasic.Init(0, 0, "thinbasic");
            Assert.AreEqual(0, hThin);

            int result = Thinbasic.Run(hThin, scriptBuffer, bufferType, 0, 0, 0, 0, callingProgram, 0);
            int lastError = Thinbasic.GetLastError();
            Thinbasic.Release(hThin);

            Assert.AreEqual(0, result);
            Assert.AreEqual(0, lastError);
        }

        [TestMethod()]
        public void ReleaseTest()
        {
            int hThin = Thinbasic.Init(0, 0, "thinbasic");
            int result = Thinbasic.Release(hThin);

            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void HostApiTest()
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

            int run = Thinbasic.Run(hThin, script, (int)Enums.BufferType.IsScript, 0, 0, 0, 0, (int)Enums.CallingProgram.Console, 0);
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
            int call = Thinbasic.FunctionSimpleCall("Ping", out num, out str);
            Assert.AreEqual(0, call);
            Assert.AreEqual("pong", str);

            Thinbasic.Release(hThin);
        }
    }
}
