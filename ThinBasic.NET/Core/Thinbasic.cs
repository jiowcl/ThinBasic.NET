﻿using System;
using System.Runtime.InteropServices;

namespace ThinBasic.NET.Core
{
    /// <summary>
    /// Thinbasic
    /// </summary>
    public class Thinbasic
    {
        /// <summary>
        /// Init
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="cInstance"></param>
        /// <param name="sKey"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Init", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Init(int hWnd, int cInstance, [MarshalAs(UnmanagedType.LPWStr)] string sKey);

        /// <summary>
        /// Run
        /// </summary>
        /// <param name="hScript"></param>
        /// <param name="sBuffer"></param>
        /// <param name="BufferType"></param>
        /// <param name="Options"></param>
        /// <param name="DebugMode"></param>
        /// <param name="LogMode"></param>
        /// <param name="ObfuscateMode"></param>
        /// <param name="CallingProgram"></param>
        /// <param name="DependancyMode"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Run", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Run(int hScript, [MarshalAs(UnmanagedType.BStr)] string sBuffer, int BufferType, int Options, int DebugMode, int LogMode, int ObfuscateMode, int CallingProgram, int DependancyMode);

        /// <summary>
        /// Release
        /// </summary>
        /// <param name="hScript"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Release", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Release(int hScript);

        /// <summary>
        /// AddIncludePath
        /// </summary>
        /// <param name="sNewIncludeDir"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_AddIncludePath", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int AddIncludePath([MarshalAs(UnmanagedType.LPWStr)] string sNewIncludeDir);



        /// <summary>
        /// GetLastError
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_GetLastError", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetLastError();

        /// <summary>
        /// ErrorFlag
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ErrorFlag", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ErrorFlag();

        /// <summary>
        /// ErrorFree
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ErrorFree", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ErrorFree();

        /// <summary>
        /// ErrorUserConfirmed
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ErrorUserConfirmed", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ErrorUserConfirmed();

        /// <summary>
        /// RunTimeError
        /// </summary>
        /// <param name="ErrorCode"></param>
        /// <param name="AdditionalInfo"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_RunTimeError", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int RunTimeError(int ErrorCode, [MarshalAs(UnmanagedType.LPWStr)] string AdditionalInfo);
    }
}
