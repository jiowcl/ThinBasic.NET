// ThinBasic.NET - ThinBasic Programming Language for .NET
// Copyright (c) 2019 Jiowcl. All rights reserved.

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

            Assert.IsTrue(hThin == 0);

            Thinbasic.Release(0);
        }

        [TestMethod()]
        public void RunTest()
        {
            string scriptPath = @"Sample\test.tbasic";
            string scriptBuffer = File.ReadAllText(scriptPath, Encoding.UTF8);

            int bufferType = (int)Enums.BufferType.IsScript;
            int callingProgram = (int)Enums.CallingProgram.Console;

            int hThin = Thinbasic.Init(0, 0, "thinbasic");
            int result = Thinbasic.Run(hThin, scriptBuffer, bufferType, 0, 0, 0, 0, callingProgram, 0);

            Assert.IsTrue(result == 0);

            Thinbasic.Release(0);
        }

        [TestMethod()]
        public void ReleaseTest()
        {
            Thinbasic.Init(0, 0, "thinbasic");
            int result = Thinbasic.Release(0);

            Assert.IsTrue(result == 0);
        }
    }
}