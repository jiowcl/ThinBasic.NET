using System;
using System.IO;
using System.Text;
using ThinBasic.NET.Core;

namespace ThinBasic.Example
{
    /// <summary>
    /// Program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        static void Main(string[] args)
        {
            string scriptPath = @"Sample\test_fib.tbasic";
            string scriptBuffer = File.ReadAllText(scriptPath, Encoding.UTF8);

            Console.WriteLine("Script: " + scriptBuffer);

            int bufferType = (int)Enums.BufferType.IsScript;
            int callingProgram = (int)Enums.CallingProgram.GUI;

            try
            {
                int hThin = Thinbasic.Init(0, 0, "thinbasic");
                int result = Thinbasic.Run(hThin, scriptBuffer, bufferType, 0, 0, 0, 0, callingProgram, 0);
                Thinbasic.Release(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
