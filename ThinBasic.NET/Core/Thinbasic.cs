// ThinBasic.NET - ThinBasic Programming Language for .NET
// Copyright (c) 2019-2026 Jiowcl. All rights reserved.

using System;
using System.Runtime.InteropServices;

namespace ThinBasic.NET.Core
{
    /// <summary>
    /// Thinbasic
    /// </summary>
    public class Thinbasic
    {
        // thinCore.dll string parameters/returns use ANSI BSTRs (SysAllocStringByteLen),
        // UnmanagedType.AnsiBStr is obsolete,
        // so strings are marshalled manually via AnsiBStrMarshal.

        /// <summary>
        /// InitNative
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="cInstance"></param>
        /// <param name="sKey"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Init", CallingConvention = CallingConvention.StdCall)]
        private static extern int InitNative(int hWnd, int cInstance, IntPtr sKey);

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
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Run", CallingConvention = CallingConvention.StdCall)]
        private static extern int RunNative(int hScript,
                                     IntPtr sBuffer,
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
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Release", CallingConvention = CallingConvention.StdCall)]
        private static extern int ReleaseNative(int hScript);

        /// <summary>
        /// AddIncludePathNative
        /// </summary>
        /// <param name="sNewIncludeDir"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_AddIncludePath", CallingConvention = CallingConvention.StdCall)]
        private static extern int AddIncludePathNative(IntPtr sNewIncludeDir);

        /// <summary>
        /// LoadSymbolNative
        /// </summary>
        /// <param name="sSymbolName"></param>
        /// <param name="returnCode"></param>
        /// <param name="aFunctionOrSubPointer"></param>
        /// <param name="rorceOverWrite"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_LoadSymbol", CallingConvention = CallingConvention.StdCall)]
        private static extern int LoadSymbolNative(IntPtr sSymbolName, int returnCode, IntPtr aFunctionOrSubPointer, int rorceOverWrite);

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
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_LoadSymbolEX", CallingConvention = CallingConvention.StdCall)]
        private static extern int LoadSymbolExNative(IntPtr sSymbolName,
                                                     int returnCode,
                                                     IntPtr aFunctionOrSubPointer,
                                                     int rorceOverWrite,
                                                     IntPtr sSyntax,
                                                     IntPtr sHelp);

        /// <summary>
        /// VariableExistsNative
        /// </summary>
        /// <param name="vName"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_VariableExists", CallingConvention = CallingConvention.StdCall)]
        private static extern int VariableExistsNative(IntPtr vName);

        /// <summary>
        /// VariableGetListNative
        /// </summary>
        /// <param name="lStackLevel"></param>
        /// <param name="sSep"></param>
        /// <returns>Returns IntPtr.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_VariableGetList", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr VariableGetListNative(int lStackLevel, IntPtr sSep);

        /// <summary>
        /// VariableGetInfoNative
        /// </summary>
        /// <param name="sSearchKey"></param>
        /// <param name="iMainType"></param>
        /// <param name="iSubType"></param>
        /// <param name="iIsArray"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_VariableGetInfo", CallingConvention = CallingConvention.StdCall)]
        private static extern int VariableGetInfoNative(IntPtr sSearchKey, out int iMainType, out int iSubType, out int iIsArray);

        /// <summary>
        /// VariableGetInfoPtrNative
        /// </summary>
        /// <param name="pVariable"></param>
        /// <param name="iMainType"></param>
        /// <param name="iSubType"></param>
        /// <param name="iIsArray"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_VariableGetInfoPtr", CallingConvention = CallingConvention.StdCall)]
        private static extern int VariableGetInfoPtrNative(int pVariable, out int iMainType, out int iSubType, out int iIsArray);

        /// <summary>
        /// VariableGetValueNumNative
        /// </summary>
        /// <param name="sSearchKey"></param>
        /// <param name="lIndex"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_VariableGetValueNum", CallingConvention = CallingConvention.StdCall)]
        private static extern int VariableGetValueNumNative(IntPtr sSearchKey, int lIndex = 0);

        /// <summary>
        /// FunctionExistsNative
        /// </summary>
        /// <param name="fName"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_FunctionExists", CallingConvention = CallingConvention.StdCall)]
        private static extern int FunctionExistsNative(IntPtr fName);

        /// <summary>
        /// GetLastErrorNative
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_GetLastError", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetLastErrorNative();

        /// <summary>
        /// ErrorFlagNative
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ErrorFlag", CallingConvention = CallingConvention.StdCall)]
        private static extern int ErrorFlagNative();

        /// <summary>
        /// ErrorFreeNative
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ErrorFree", CallingConvention = CallingConvention.StdCall)]
        private static extern int ErrorFreeNative();

        /// <summary>
        /// ErrorUserConfirmedNative
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ErrorUserConfirmed", CallingConvention = CallingConvention.StdCall)]
        private static extern int ErrorUserConfirmedNative();

        /// <summary>
        /// RunTimeErrorNative
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="sAdditionalInfo"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_RunTimeError", CallingConvention = CallingConvention.StdCall)]
        private static extern int RunTimeErrorNative(int errorCode, IntPtr sAdditionalInfo);

        /// <summary>
        /// GetRunTimeInfoNative
        /// </summary>
        /// <param name="sInfoName"></param>
        /// <returns>Returns IntPtr.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_GetRunTimeInfo", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr GetRunTimeInfoNative(IntPtr sInfoName);

        /// <summary>
        /// CheckEqualTypeMandatoryNative
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_CheckEqualType_Mandatory", CallingConvention = CallingConvention.StdCall)]
        private static extern int CheckEqualTypeMandatoryNative();

        /// <summary>
        /// DetermineTypeNative
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_DetermineType", CallingConvention = CallingConvention.StdCall)]
        private static extern int DetermineTypeNative();

        /// <summary>
        /// ScriptIsObfuscatedNative
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ScriptIsObfuscated", CallingConvention = CallingConvention.StdCall)]
        private static extern int ScriptIsObfuscatedNative();

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="cInstance"></param>
        /// <param name="sKey"></param>
        /// <returns>Returns int.</returns>
        public static int Init(int hWnd, int cInstance, string sKey)
        {
            IntPtr pKey = AnsiBStrMarshal.Alloc(sKey);
            try
            {
                return InitNative(hWnd, cInstance, pKey);
            }
            finally
            {
                AnsiBStrMarshal.Free(pKey);
            }
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
                                     string sBuffer,
                                     int bufferType,
                                     int options,
                                     int debugMode,
                                     int logMode,
                                     int obfuscateMode,
                                     int callingProgram,
                                     int dependancyMode)
        {
            IntPtr pBuffer = AnsiBStrMarshal.Alloc(sBuffer);
            try
            {
                return RunNative(hScript, pBuffer, bufferType, options, debugMode, logMode, obfuscateMode, callingProgram, dependancyMode);
            }
            finally
            {
                AnsiBStrMarshal.Free(pBuffer);
            }
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
        public static int AddIncludePath(string sNewIncludeDir)
        {
            IntPtr pDir = AnsiBStrMarshal.Alloc(sNewIncludeDir);
            try
            {
                return AddIncludePathNative(pDir);
            }
            finally
            {
                AnsiBStrMarshal.Free(pDir);
            }
        }

        /// <summary>
        /// LoadSymbol
        /// </summary>
        /// <param name="sSymbolName"></param>
        /// <param name="returnCode"></param>
        /// <param name="aFunctionOrSubPointer"></param>
        /// <param name="rorceOverWrite"></param>
        /// <returns>Returns int.</returns>
        public static int LoadSymbol(string sSymbolName, int returnCode, IntPtr aFunctionOrSubPointer, int rorceOverWrite)
        {
            IntPtr pName = AnsiBStrMarshal.Alloc(sSymbolName);
            try
            {
                return LoadSymbolNative(pName, returnCode, aFunctionOrSubPointer, rorceOverWrite);
            }
            finally
            {
                AnsiBStrMarshal.Free(pName);
            }
        }

        /// <summary>
        /// LoadSymbolEx
        /// </summary>
        /// <param name="sSymbolName"></param>
        /// <param name="returnCode"></param>
        /// <param name="aFunctionOrSubPointer"></param>
        /// <param name="rorceOverWrite"></param>
        /// <param name="sSyntax"></param>
        /// <param name="sHelp"></param>
        /// <returns>Returns int.</returns>
        public static int LoadSymbolEx(string sSymbolName,
                                                     int returnCode,
                                                     IntPtr aFunctionOrSubPointer,
                                                     int rorceOverWrite,
                                                     string sSyntax,
                                                     string sHelp)
        {
            IntPtr pName = AnsiBStrMarshal.Alloc(sSymbolName);
            IntPtr pSyntax = AnsiBStrMarshal.Alloc(sSyntax);
            IntPtr pHelp = AnsiBStrMarshal.Alloc(sHelp);
            try
            {
                return LoadSymbolExNative(pName, returnCode, aFunctionOrSubPointer, rorceOverWrite, pSyntax, pHelp);
            }
            finally
            {
                AnsiBStrMarshal.Free(pName);
                AnsiBStrMarshal.Free(pSyntax);
                AnsiBStrMarshal.Free(pHelp);
            }
        }

        /// <summary>
        /// VariableExists
        /// </summary>
        /// <param name="vName"></param>
        /// <returns>Returns int.</returns>
        public static int VariableExists(string vName)
        {
            IntPtr pName = AnsiBStrMarshal.Alloc(vName);
            try
            {
                return VariableExistsNative(pName);
            }
            finally
            {
                AnsiBStrMarshal.Free(pName);
            }
        }

        /// <summary>
        /// VariableGetList
        /// </summary>
        /// <param name="lStackLevel"></param>
        /// <param name="sSep"></param>
        /// <returns>Returns string.</returns>
        public static string VariableGetList(int lStackLevel, string sSep)
        {
            IntPtr pSep = AnsiBStrMarshal.Alloc(sSep);
            try
            {
                return AnsiBStrMarshal.PtrToStringAndFree(VariableGetListNative(lStackLevel, pSep));
            }
            finally
            {
                AnsiBStrMarshal.Free(pSep);
            }
        }

        /// <summary>
        /// VariableGetInfo
        /// </summary>
        /// <param name="sSearchKey"></param>
        /// <param name="iMainType"></param>
        /// <param name="iSubType"></param>
        /// <param name="iIsArray"></param>
        /// <returns>Returns int.</returns>
        public static int VariableGetInfo(string sSearchKey, out int iMainType, out int iSubType, out int iIsArray)
        {
            IntPtr pKey = AnsiBStrMarshal.Alloc(sSearchKey);
            try
            {
                return VariableGetInfoNative(pKey, out iMainType, out iSubType, out iIsArray);
            }
            finally
            {
                AnsiBStrMarshal.Free(pKey);
            }
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
        /// <returns>Returns int.</returns>
        public static int VariableGetValueNum(string sSearchKey)
        {
            return VariableGetValueNum(sSearchKey, 0);
        }

        /// <summary>
        /// VariableGetValueNum
        /// </summary>
        /// <param name="sSearchKey"></param>
        /// <param name="lIndex"></param>
        /// <returns>Returns int.</returns>
        public static int VariableGetValueNum(string sSearchKey, int lIndex)
        {
            IntPtr pKey = AnsiBStrMarshal.Alloc(sSearchKey);
            try
            {
                return VariableGetValueNumNative(pKey, lIndex);
            }
            finally
            {
                AnsiBStrMarshal.Free(pKey);
            }
        }

        /// <summary>
        /// FunctionExists
        /// </summary>
        /// <param name="fName"></param>
        /// <returns>Returns int.</returns>
        public static int FunctionExists(string fName)
        {
            IntPtr pName = AnsiBStrMarshal.Alloc(fName);
            try
            {
                return FunctionExistsNative(pName);
            }
            finally
            {
                AnsiBStrMarshal.Free(pName);
            }
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
        public static int RunTimeError(int errorCode, string sAdditionalInfo)
        {
            IntPtr pInfo = AnsiBStrMarshal.Alloc(sAdditionalInfo);
            try
            {
                return RunTimeErrorNative(errorCode, pInfo);
            }
            finally
            {
                AnsiBStrMarshal.Free(pInfo);
            }
        }

        /// <summary>
        /// GetRunTimeInfo
        /// </summary>
        /// <param name="sInfoName"></param>
        /// <returns>Returns string.</returns>
        public static string GetRunTimeInfo(string sInfoName)
        {
            IntPtr pName = AnsiBStrMarshal.Alloc(sInfoName);
            try
            {
                return AnsiBStrMarshal.PtrToStringAndFree(GetRunTimeInfoNative(pName));
            }
            finally
            {
                AnsiBStrMarshal.Free(pName);
            }
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
