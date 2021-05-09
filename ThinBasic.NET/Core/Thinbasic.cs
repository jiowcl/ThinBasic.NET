// ThinBasic.NET - ThinBasic Programming Language for .NET
// Copyright (c) 2019 Jiowcl. All rights reserved.

using System;
using System.Runtime.InteropServices;

namespace ThinBasic.NET.Core
{
    /// <summary>
    /// Thinbasic
    /// </summary>
    public class Thinbasic
    {
        /// <summary>
        /// InitNative
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="cInstance"></param>
        /// <param name="sKey"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Init", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int InitNative(int hWnd, int cInstance, [MarshalAs(UnmanagedType.AnsiBStr)] string sKey);

        /// <summary>
        /// RunNative
        /// </summary>
        /// <param name="hScript"></param>
        /// <param name="sBuffer"></param>
        /// <param name="bufferType"></param>
        /// <param name="options"></param>
        /// <param name="debugMode"></param>
        /// <param name="logMode"></param>
        /// <param name="obfuscateMode"></param>
        /// <param name="callingProgram"></param>
        /// <param name="dependancyMode"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Run", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int RunNative(int hScript,
                                     [MarshalAs(UnmanagedType.BStr)] string sBuffer,
                                     int bufferType,
                                     int options,
                                     int debugMode,
                                     int logMode,
                                     int obfuscateMode,
                                     int callingProgram,
                                     int dependancyMode);

        /// <summary>
        /// ReleaseNative
        /// </summary>
        /// <param name="hScript"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Release", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int ReleaseNative(int hScript);

        /// <summary>
        /// AddIncludePathNative
        /// </summary>
        /// <param name="sNewIncludeDir"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_AddIncludePath", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int AddIncludePathNative([MarshalAs(UnmanagedType.AnsiBStr)] string sNewIncludeDir);

        /// <summary>
        /// LoadSymbolNative
        /// </summary>
        /// <param name="sSymbolName"></param>
        /// <param name="returnCode"></param>
        /// <param name="aFunctionOrSubPointer"></param>
        /// <param name="rorceOverWrite"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_LoadSymbol", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int LoadSymbolNative([MarshalAs(UnmanagedType.AnsiBStr)] string sSymbolName, int returnCode, IntPtr aFunctionOrSubPointer, int rorceOverWrite);

        /// <summary>
        /// LoadSymbolExNative
        /// </summary>
        /// <param name="sSymbolName"></param>
        /// <param name="returnCode"></param>
        /// <param name="aFunctionOrSubPointer"></param>
        /// <param name="rorceOverWrite"></param>
        /// <param name="sSyntax"></param>
        /// <param name="sHelp"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_LoadSymbolEX", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int LoadSymbolExNative([MarshalAs(UnmanagedType.AnsiBStr)] string sSymbolName,
                                                     int returnCode,
                                                     IntPtr aFunctionOrSubPointer,
                                                     int rorceOverWrite,
                                                     [MarshalAs(UnmanagedType.AnsiBStr)] string sSyntax,
                                                     [MarshalAs(UnmanagedType.AnsiBStr)] string sHelp);

        /// <summary>
        /// VariableExistsNative
        /// </summary>
        /// <param name="vName"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_VariableExists", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int VariableExistsNative([MarshalAs(UnmanagedType.AnsiBStr)] string vName);

        /// <summary>
        /// VariableGetListNative
        /// </summary>
        /// <param name="lStackLevel"></param>
        /// <param name="sSep"></param>
        /// <returns>Returns string.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_VariableGetList", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.AnsiBStr)]
        private static extern string VariableGetListNative(int lStackLevel, [MarshalAs(UnmanagedType.AnsiBStr)] string sSep);

        /// <summary>
        /// VariableGetInfoNative
        /// </summary>
        /// <param name="sSearchKey"></param>
        /// <param name="iMainType"></param>
        /// <param name="iSubType"></param>
        /// <param name="iIsArray"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_VariableGetInfo", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int VariableGetInfoNative([MarshalAs(UnmanagedType.AnsiBStr)] string sSearchKey, out int iMainType, out int iSubType, out int iIsArray);

        /// <summary>
        /// VariableGetInfoPtrNative
        /// </summary>
        /// <param name="pVariable"></param>
        /// <param name="iMainType"></param>
        /// <param name="iSubType"></param>
        /// <param name="iIsArray"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_VariableGetInfoPtr", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int VariableGetInfoPtrNative(int pVariable, out int iMainType, out int iSubType, out int iIsArray);

        /// <summary>
        /// VariableGetValueNumNative
        /// </summary>
        /// <param name="sSearchKey"></param>
        /// <param name="lIndex"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_VariableGetValueNum", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int VariableGetValueNumNative([MarshalAs(UnmanagedType.AnsiBStr)] string sSearchKey, int lIndex = 0);

        /// <summary>
        /// FunctionExistsNative
        /// </summary>
        /// <param name="fName"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_FunctionExists", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int FunctionExistsNative([MarshalAs(UnmanagedType.AnsiBStr)] string fName);

        /// <summary>
        /// GetLastErrorNative
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_GetLastError", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int GetLastErrorNative();

        /// <summary>
        /// ErrorFlagNative
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ErrorFlag", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int ErrorFlagNative();

        /// <summary>
        /// ErrorFreeNative
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ErrorFree", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int ErrorFreeNative();

        /// <summary>
        /// ErrorUserConfirmedNative
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ErrorUserConfirmed", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int ErrorUserConfirmedNative();

        /// <summary>
        /// RunTimeErrorNative
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="sAdditionalInfo"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_RunTimeError", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int RunTimeErrorNative(int errorCode, [MarshalAs(UnmanagedType.AnsiBStr)] string sAdditionalInfo);

        /// <summary>
        /// GetRunTimeInfoNative
        /// </summary>
        /// <param name="sInfoName"></param>
        /// <returns>Returns string.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_GetRunTimeInfo", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.AnsiBStr)]
        private static extern string GetRunTimeInfoNative([MarshalAs(UnmanagedType.AnsiBStr)] string sInfoName);

        /// <summary>
        /// CheckEqualTypeMandatoryNative
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_CheckEqualType_Mandatory", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int CheckEqualTypeMandatoryNative();

        /// <summary>
        /// DetermineTypeNative
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_DetermineType", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int DetermineTypeNative();

        /// <summary>
        /// ScriptIsObfuscatedNative
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ScriptIsObfuscated", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int ScriptIsObfuscatedNative();

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="cInstance"></param>
        /// <param name="sKey"></param>
        /// <returns>Returns int.</returns>
        public static int Init(int hWnd, int cInstance, [MarshalAs(UnmanagedType.AnsiBStr)] string sKey)
        {
            return InitNative(hWnd, cInstance, sKey);
        }

        /// <summary>
        /// Run
        /// </summary>
        /// <param name="hScript"></param>
        /// <param name="sBuffer"></param>
        /// <param name="bufferType"></param>
        /// <param name="options"></param>
        /// <param name="debugMode"></param>
        /// <param name="logMode"></param>
        /// <param name="obfuscateMode"></param>
        /// <param name="callingProgram"></param>
        /// <param name="dependancyMode"></param>
        /// <returns>Returns int.</returns>
        public static int Run(int hScript,
                                     [MarshalAs(UnmanagedType.BStr)] string sBuffer,
                                     int bufferType,
                                     int options,
                                     int debugMode,
                                     int logMode,
                                     int obfuscateMode,
                                     int callingProgram,
                                     int dependancyMode)
        {
            return RunNative(hScript, sBuffer, bufferType, options, debugMode, logMode, obfuscateMode, callingProgram, dependancyMode);
        }

        /// <summary>
        /// Release
        /// </summary>
        /// <param name="hScript"></param>
        /// <returns>Returns int.</returns>
        public static int Release(int hScript)
        {
            return ReleaseNative(hScript);
        }

        /// <summary>
        /// AddIncludePath
        /// </summary>
        /// <param name="sNewIncludeDir"></param>
        /// <returns>Returns int.</returns>
        public static int AddIncludePath([MarshalAs(UnmanagedType.AnsiBStr)] string sNewIncludeDir)
        {
            return AddIncludePathNative(sNewIncludeDir);
        }

        /// <summary>
        /// LoadSymbol
        /// </summary>
        /// <param name="sSymbolName"></param>
        /// <param name="returnCode"></param>
        /// <param name="aFunctionOrSubPointer"></param>
        /// <param name="rorceOverWrite"></param>
        /// <returns>Returns int.</returns>
        public static int LoadSymbol([MarshalAs(UnmanagedType.AnsiBStr)] string sSymbolName, int returnCode, IntPtr aFunctionOrSubPointer, int rorceOverWrite)
        {
            return LoadSymbolNative(sSymbolName, returnCode, aFunctionOrSubPointer, rorceOverWrite);
        }

        /// <summary>
        /// LoadSymbolExNative
        /// </summary>
        /// <param name="sSymbolName"></param>
        /// <param name="returnCode"></param>
        /// <param name="aFunctionOrSubPointer"></param>
        /// <param name="rorceOverWrite"></param>
        /// <param name="sSyntax"></param>
        /// <param name="sHelp"></param>
        /// <returns>Returns int.</returns>
        public static int LoadSymbolEx([MarshalAs(UnmanagedType.AnsiBStr)] string sSymbolName,
                                                     int returnCode,
                                                     IntPtr aFunctionOrSubPointer,
                                                     int rorceOverWrite,
                                                     [MarshalAs(UnmanagedType.AnsiBStr)] string sSyntax,
                                                     [MarshalAs(UnmanagedType.AnsiBStr)] string sHelp)
        {
            return LoadSymbolExNative(sSymbolName, returnCode, aFunctionOrSubPointer, rorceOverWrite, sSyntax, sHelp);
        }

        /// <summary>
        /// VariableExists
        /// </summary>
        /// <param name="vName"></param>
        /// <returns>Returns int.</returns>
        public static int VariableExists([MarshalAs(UnmanagedType.AnsiBStr)] string vName)
        {
            return VariableExistsNative(vName);
        }

        /// <summary>
        /// VariableGetList
        /// </summary>
        /// <param name="lStackLevel"></param>
        /// <param name="sSep"></param>
        /// <returns>Returns string.</returns>
        public static string VariableGetList(int lStackLevel, [MarshalAs(UnmanagedType.AnsiBStr)] string sSep)
        {
            return VariableGetListNative(lStackLevel, sSep);
        }

        /// <summary>
        /// VariableGetInfo
        /// </summary>
        /// <param name="sSearchKey"></param>
        /// <param name="iMainType"></param>
        /// <param name="iSubType"></param>
        /// <param name="iIsArray"></param>
        /// <returns>Returns int.</returns>
        public static int VariableGetInfo([MarshalAs(UnmanagedType.AnsiBStr)] string sSearchKey, out int iMainType, out int iSubType, out int iIsArray)
        {
            return VariableGetInfoNative(sSearchKey, out iMainType, out iSubType, out iIsArray);
        }

        /// <summary>
        /// VariableGetInfoPtr
        /// </summary>
        /// <param name="pVariable"></param>
        /// <param name="iMainType"></param>
        /// <param name="iSubType"></param>
        /// <param name="iIsArray"></param>
        /// <returns>Returns int.</returns>
        public static int VariableGetInfoPtr(int pVariable, out int iMainType, out int iSubType, out int iIsArray)
        {
            return VariableGetInfoPtrNative(pVariable, out iMainType, out iSubType, out iIsArray);
        }

        /// <summary>
        /// VariableGetValueNum
        /// </summary>
        /// <param name="sSearchKey"></param>
        /// <param name="lIndex"></param>
        /// <returns>Returns int.</returns>
        public static int VariableGetValueNum([MarshalAs(UnmanagedType.AnsiBStr)] string sSearchKey, int lIndex = 0)
        {
            return VariableGetValueNumNative(sSearchKey, lIndex);
        }

        /// <summary>
        /// FunctionExists
        /// </summary>
        /// <param name="fName"></param>
        /// <returns>Returns int.</returns>
        public static int FunctionExists([MarshalAs(UnmanagedType.AnsiBStr)] string fName)
        {
            return FunctionExistsNative(fName);
        }

        /// <summary>
        /// GetLastError
        /// </summary>
        /// <returns>Returns int.</returns>
        public static int GetLastError()
        {
            return GetLastErrorNative();
        }

        /// <summary>
        /// ErrorFlag
        /// </summary>
        /// <returns>Returns int.</returns>
        public static int ErrorFlag()
        {
            return ErrorFlagNative();
        }

        /// <summary>
        /// ErrorFree
        /// </summary>
        /// <returns>Returns int.</returns>
        public static int ErrorFree()
        {
            return ErrorFreeNative();
        }

        /// <summary>
        /// ErrorUserConfirmed
        /// </summary>
        /// <returns>Returns int.</returns>
        public static int ErrorUserConfirmed()
        {
            return ErrorUserConfirmedNative();
        }

        /// <summary>
        /// RunTimeError
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="sAdditionalInfo"></param>
        /// <returns>Returns int.</returns>
        public static int RunTimeError(int errorCode, [MarshalAs(UnmanagedType.AnsiBStr)] string sAdditionalInfo)
        {
            return RunTimeErrorNative(errorCode, sAdditionalInfo);
        }

        /// <summary>
        /// GetRunTimeInfo
        /// </summary>
        /// <param name="sInfoName"></param>
        /// <returns>Returns string.</returns>
        [return: MarshalAs(UnmanagedType.AnsiBStr)]
        public static string GetRunTimeInfo([MarshalAs(UnmanagedType.AnsiBStr)] string sInfoName)
        {
            return GetRunTimeInfoNative(sInfoName);
        }

        /// <summary>
        /// CheckEqualTypeMandatory
        /// </summary>
        /// <returns>Returns int.</returns>
        public static int CheckEqualTypeMandatory()
        {
            return CheckEqualTypeMandatoryNative();
        }

        /// <summary>
        /// DetermineType
        /// </summary>
        /// <returns>Returns int.</returns>
        public static int DetermineType()
        {
            return DetermineTypeNative();
        }

        /// <summary>
        /// ScriptIsObfuscated
        /// </summary>
        /// <returns>Returns int.</returns>
        public static int ScriptIsObfuscated()
        {
            return ScriptIsObfuscatedNative();
        }
    }
}
