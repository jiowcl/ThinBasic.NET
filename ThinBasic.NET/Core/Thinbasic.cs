// ThinBasic.NET - ThinBasic Programming Language for .NET
// Copyright (c) 2019-2026 Jiowcl. All rights reserved.

using System;
using System.Runtime.InteropServices;

namespace ThinBasic.NET.Core
{
    /// <summary>
    /// Thinbasic
    /// </summary>
    /// <remarks>
    /// thinCore.dll string parameters/returns use ANSI BSTRs (SysAllocStringByteLen).
    /// Numeric EXT values use Ext80 by-value; EXT function returns are read as double (ST0).
    /// </remarks>
    public class Thinbasic
    {
        /// <summary>
        /// Init
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="cInstance"></param>
        /// <param name="sKey"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Init", CallingConvention = CallingConvention.StdCall)]
        private static extern int InitNative(
            int hWnd, 
            int cInstance, 
            IntPtr sKey);

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
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Run", CallingConvention = CallingConvention.StdCall)]
        private static extern int RunNative(
            int hScript,
            IntPtr sBuffer,
            int bufferType,
            int options,
            int debugMode,
            int logMode,
            int obfuscateMode,
            int callingProgram,
            int dependancyMode);

        /// <summary>
        /// Release
        /// </summary>
        /// <param name="hScript"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Release", CallingConvention = CallingConvention.StdCall)]
        private static extern int ReleaseNative(
            int hScript);

        /// <summary>
        /// AddIncludePath
        /// </summary>
        /// <param name="sNewIncludeDir"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_AddIncludePath", CallingConvention = CallingConvention.StdCall)]
        private static extern int AddIncludePathNative(
            IntPtr sNewIncludeDir);

        /// <summary>
        /// LoadSymbol
        /// </summary>
        /// <param name="sSymbolName"></param>
        /// <param name="returnCode"></param>
        /// <param name="aFunctionOrSubPointer"></param>
        /// <param name="rorceOverWrite"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_LoadSymbol", CallingConvention = CallingConvention.StdCall)]
        private static extern int LoadSymbolNative(
            IntPtr sSymbolName, 
            int returnCode, 
            IntPtr aFunctionOrSubPointer, 
            int rorceOverWrite);

        /// <summary>
        /// LoadSymbolEX
        /// </summary>
        /// <param name="sSymbolName"></param>
        /// <param name="returnCode"></param>
        /// <param name="aFunctionOrSubPointer"></param>
        /// <param name="rorceOverWrite"></param>
        /// <param name="sSyntax"></param>
        /// <param name="sHelp"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_LoadSymbolEX", CallingConvention = CallingConvention.StdCall)]
        private static extern int LoadSymbolExNative(
            IntPtr sSymbolName,
            int returnCode,
            IntPtr aFunctionOrSubPointer,
            int rorceOverWrite,
            IntPtr sSyntax,
            IntPtr sHelp);

        /// <summary>
        /// AddEquate
        /// </summary>
        /// <param name="vName"></param>
        /// <param name="lValString"></param>
        /// <param name="lValNumber"></param>
        /// <param name="forceType"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_AddEquate", CallingConvention = CallingConvention.StdCall)]
        private static extern int AddEquateNative(
            IntPtr vName, 
            IntPtr lValString, 
            Ext80 lValNumber, 
            int forceType);

        /// <summary>
        /// AddVariable
        /// </summary>
        /// <param name="vName"></param>
        /// <param name="lValString"></param>
        /// <param name="lValNumber"></param>
        /// <param name="forceType"></param>
        /// <param name="varMemPtr"></param>
        /// <param name="reserved1"></param>
        /// <param name="reserved2"></param>
        /// <param name="reserved3"></param>
        /// <param name="reserved4"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_AddVariable", CallingConvention = CallingConvention.StdCall)]
        private static extern int AddVariableNative(
            IntPtr vName,
            IntPtr lValString,
            Ext80 lValNumber,
            int forceType,
            int varMemPtr,
            int reserved1,
            int reserved2,
            int reserved3,
            int reserved4);

        /// <summary>
        /// ChangeVariableNumber
        /// </summary>
        /// <param name="vName"></param>
        /// <param name="lValNumber"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ChangeVariableNumber", CallingConvention = CallingConvention.StdCall)]
        private static extern int ChangeVariableNumberNative(
            IntPtr vName, 
            Ext80 lValNumber);

        /// <summary>
        /// ChangeVariableString
        /// </summary>
        /// <param name="vName"></param>
        /// <param name="lValString"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ChangeVariableString", CallingConvention = CallingConvention.StdCall)]
        private static extern int ChangeVariableStringNative(
            IntPtr vName, 
            IntPtr lValString);

        /// <summary>
        /// VariableExists
        /// </summary>
        /// <param name="vName"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_VariableExists", CallingConvention = CallingConvention.StdCall)]
        private static extern int VariableExistsNative(
            IntPtr vName);

        /// <summary>
        /// VariableGetList
        /// </summary>
        /// <param name="lStackLevel"></param>
        /// <param name="sSep"></param>
        /// <returns>Returns IntPtr.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_VariableGetList", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr VariableGetListNative(
            int lStackLevel, 
            IntPtr sSep);

        /// <summary>
        /// VariableGetInfo
        /// </summary>
        /// <param name="sSearchKey"></param>
        /// <param name="iMainType"></param>
        /// <param name="iSubType"></param>
        /// <param name="iIsArray"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_VariableGetInfo", CallingConvention = CallingConvention.StdCall)]
        private static extern int VariableGetInfoNative(
            IntPtr sSearchKey, 
            out int iMainType, 
            out int iSubType, 
            out int iIsArray);

        /// <summary>
        /// VariableGetInfoEx
        /// </summary>
        /// <param name="sSearchKey"></param>
        /// <param name="iMainType"></param>
        /// <param name="iSubType"></param>
        /// <param name="iIsArray"></param>
        /// <param name="iDataPtr"></param>
        /// <param name="nElements"></param>
        /// <param name="whichLevel"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_VariableGetInfoEX", CallingConvention = CallingConvention.StdCall)]
        private static extern int VariableGetInfoExNative(
            IntPtr sSearchKey,
            out int iMainType,
            out int iSubType,
            out int iIsArray,
            out int iDataPtr,
            out int nElements,
            int whichLevel);

        /// <summary>
        /// VariableGetInfoPtr
        /// </summary>
        /// <param name="pVariable"></param>
        /// <param name="iMainType"></param>
        /// <param name="iSubType"></param>
        /// <param name="iIsArray"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_VariableGetInfoPtr", CallingConvention = CallingConvention.StdCall)]
        private static extern int VariableGetInfoPtrNative(
            int pVariable, 
            out int iMainType, 
            out int iSubType, 
            out int iIsArray);

        /// <summary>
        /// VariableGetValueNum
        /// </summary>
        /// <param name="sSearchKey"></param>
        /// <param name="lIndex"></param>
        /// <returns>Returns double.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_VariableGetValueNum", CallingConvention = CallingConvention.StdCall)]
        private static extern double VariableGetValueNumNative(
            IntPtr sSearchKey, 
            int lIndex);

        /// <summary>
        /// FunctionExists
        /// </summary>
        /// <param name="fName"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_FunctionExists", CallingConvention = CallingConvention.StdCall)]
        private static extern int FunctionExistsNative(
            IntPtr fName);

        /// <summary>
        /// FunctionSimpleCall
        /// </summary>
        /// <param name="functionName"></param>
        /// <param name="ptrExt"></param>
        /// <param name="ptrStr"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_FunctionSimpleCall", CallingConvention = CallingConvention.StdCall)]
        private static extern int FunctionSimpleCallNative(
            IntPtr functionName, 
            IntPtr ptrExt, 
            IntPtr ptrStr);

        /// <summary>
        /// GetLastError
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_GetLastError", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetLastErrorNative();

        /// <summary>
        /// ErrorFlag
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ErrorFlag", CallingConvention = CallingConvention.StdCall)]
        private static extern int ErrorFlagNative();

        /// <summary>
        /// ErrorFree
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ErrorFree", CallingConvention = CallingConvention.StdCall)]
        private static extern int ErrorFreeNative();

        /// <summary>
        /// ErrorUserConfirmed
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ErrorUserConfirmed", CallingConvention = CallingConvention.StdCall)]
        private static extern int ErrorUserConfirmedNative();

        /// <summary>
        /// RunTimeError
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="sAdditionalInfo"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_RunTimeError", CallingConvention = CallingConvention.StdCall)]
        private static extern int RunTimeErrorNative(
            int errorCode, 
            IntPtr sAdditionalInfo);

        /// <summary>
        /// GetRunTimeInfo
        /// </summary>
        /// <param name="sInfoName"></param>
        /// <returns>Returns IntPtr.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_GetRunTimeInfo", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr GetRunTimeInfoNative(
            IntPtr sInfoName);

        /// <summary>
        /// CheckEqualTypeMandatory
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_CheckEqualType_Mandatory", CallingConvention = CallingConvention.StdCall)]
        private static extern int CheckEqualTypeMandatoryNative();

        /// <summary>
        /// DetermineType
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_DetermineType", CallingConvention = CallingConvention.StdCall)]
        private static extern int DetermineTypeNative();

        /// <summary>
        /// ScriptIsObfuscated
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
        public static int Init(
            int hWnd, 
            int cInstance, 
            string sKey)
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
        public static int Run(
            int hScript,
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
        public static int Release(
            int hScript)
        {
            return ReleaseNative(hScript);
        }

        /// <summary>
        /// AddIncludePath
        /// </summary>
        /// <param name="sNewIncludeDir"></param>
        /// <returns>Returns int.</returns>
        public static int AddIncludePath(
            string sNewIncludeDir)
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
        public static int LoadSymbol(
            string sSymbolName, 
            int returnCode, 
            IntPtr aFunctionOrSubPointer, 
            int rorceOverWrite)
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
        /// Register a managed callback as a thinBasic keyword. The delegate is kept rooted until
        /// <see cref="ClearSymbolCallbacks"/> is called.
        /// </summary>
        /// <param name="sSymbolName"></param>
        /// <param name="returnCode"></param>
        /// <param name="callback"></param>
        /// <param name="forceOverWrite"></param>
        /// <returns>Returns int.</returns>
        public static int LoadSymbol(
            string sSymbolName, 
            int returnCode, 
            Delegate callback, 
            int forceOverWrite)
        {
            IntPtr ptr = SymbolCallbackTable.Add(callback);

            return LoadSymbol(sSymbolName, returnCode, ptr, forceOverWrite);
        }

        /// <summary>
        /// Register a SUB / ReturnNone keyword callback.
        /// </summary>
        /// <param name="sSymbolName"></param>
        /// <param name="callback"></param>
        /// <param name="forceOverWrite"></param>
        /// <returns>Returns int.</returns>
        public static int LoadSymbol(
            string sSymbolName, 
            ThinBasicSubCallback callback, 
            int forceOverWrite = 0)
        {
            return LoadSymbol(sSymbolName, (int)Enums.ReturnType.None, callback, forceOverWrite);
        }

        /// <summary>
        /// Register a numeric ReturnNumber keyword callback.
        /// </summary>
        /// <param name="sSymbolName"></param>
        /// <param name="callback"></param>
        /// <param name="forceOverWrite"></param>
        /// <returns>Returns int.</returns>
        public static int LoadSymbol(
            string sSymbolName, 
            ThinBasicNumberCallback callback, 
            int forceOverWrite = 0)
        {
            return LoadSymbol(sSymbolName, (int)Enums.ReturnType.Number, callback, forceOverWrite);
        }

        /// <summary>
        /// Register a string ReturnString keyword callback.
        /// </summary>
        /// <param name="sSymbolName"></param>
        /// <param name="callback"></param>
        /// <param name="forceOverWrite"></param>
        /// <returns>Returns int.</returns>
        public static int LoadSymbol(
            string sSymbolName, 
            ThinBasicStringCallback callback, 
            int forceOverWrite = 0)
        {
            return LoadSymbol(sSymbolName, (int)Enums.ReturnType.String, callback, forceOverWrite);
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
        public static int LoadSymbolEx(
            string sSymbolName,
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
        /// Register a managed callback as a thinBasic keyword with syntax/help metadata.
        /// </summary>
        public static int LoadSymbolEx(
            string sSymbolName,
            int returnCode,
            Delegate callback,
            int forceOverWrite,
            string sSyntax,
            string sHelp)
        {
            IntPtr ptr = SymbolCallbackTable.Add(callback);

            return LoadSymbolEx(sSymbolName, returnCode, ptr, forceOverWrite, sSyntax, sHelp);
        }

        /// <summary>
        /// Allocate an ANSI BSTR for a <see cref="ThinBasicStringCallback"/> return value.
        /// Ownership is transferred to thinCore; do not free the pointer.
        /// </summary>
        public static IntPtr AllocReturnString(string value)
        {
            return AnsiBStrMarshal.Alloc(value);
        }

        /// <summary>
        /// Drop rooted managed symbol callbacks. Call only when no script may still invoke them.
        /// </summary>
        public static void ClearSymbolCallbacks()
        {
            SymbolCallbackTable.Clear();
        }

        /// <summary>
        /// Add a numeric or string equate (constant). Prefer names starting with % or $.
        /// Call after <see cref="Init"/> and before <see cref="Run"/>.
        /// </summary>
        /// <param name="vName"></param>
        /// <param name="lValString"></param>
        /// <param name="lValNumber"></param>
        /// <param name="forceType"></param>
        /// <returns>Returns int.</returns>
        public static int AddEquate(
            string vName, 
            string lValString, 
            double lValNumber, 
            int forceType = 0)
        {
            IntPtr pName = AnsiBStrMarshal.Alloc(vName);
            IntPtr pString = AnsiBStrMarshal.Alloc(lValString ?? string.Empty);

            try
            {
                return AddEquateNative(pName, pString, Ext80.FromDouble(lValNumber), forceType);
            }
            finally
            {
                AnsiBStrMarshal.Free(pName);
                AnsiBStrMarshal.Free(pString);
            }
        }

        /// <summary>
        /// Add a variable to the current stack level.
        /// Typically used from module callbacks; may not be visible if called only between Init and Run.
        /// </summary>
        /// <param name="vName"></param>
        /// <param name="lValString"></param>
        /// <param name="lValNumber"></param>
        /// <param name="forceType"></param>
        /// <returns>Returns int.</returns>
        public static int AddVariable(
            string vName, 
            string lValString, 
            double lValNumber, 
            int forceType)
        {
            IntPtr pName = AnsiBStrMarshal.Alloc(vName);
            IntPtr pString = AnsiBStrMarshal.Alloc(lValString ?? string.Empty);

            try
            {
                return AddVariableNative(pName, pString, Ext80.FromDouble(lValNumber), forceType, 0, 0, 0, 0, 0);
            }
            finally
            {
                AnsiBStrMarshal.Free(pName);
                AnsiBStrMarshal.Free(pString);
            }
        }

        /// <summary>
        /// Change the value of a numeric script variable.
        /// </summary>
        /// <param name="vName"></param>
        /// <param name="lValNumber"></param>
        /// <returns>Returns int.</returns>
        public static int ChangeVariableNumber(
            string vName, 
            double lValNumber)
        {
            IntPtr pName = AnsiBStrMarshal.Alloc(vName);

            try
            {
                return ChangeVariableNumberNative(pName, Ext80.FromDouble(lValNumber));
            }
            finally
            {
                AnsiBStrMarshal.Free(pName);
            }
        }

        /// <summary>
        /// Change the value of a string script variable.
        /// </summary>
        /// <param name="vName"></param>
        /// <param name="lValString"></param>
        /// <returns>Returns int.</returns>
        public static int ChangeVariableString(
            string vName, 
            string lValString)
        {
            IntPtr pName = AnsiBStrMarshal.Alloc(vName);
            IntPtr pValue = AnsiBStrMarshal.Alloc(lValString);

            try
            {
                return ChangeVariableStringNative(pName, pValue);
            }
            finally
            {
                AnsiBStrMarshal.Free(pName);
                AnsiBStrMarshal.Free(pValue);
            }
        }

        /// <summary>
        /// VariableExists
        /// </summary>
        /// <param name="vName"></param>
        /// <returns>Returns int.</returns>
        public static int VariableExists(
            string vName)
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
        public static string VariableGetList(
            int lStackLevel, 
            string sSep)
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
        public static int VariableGetInfo(
            string sSearchKey, 
            out int iMainType, 
            out int iSubType, 
            out int iIsArray)
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
        /// VariableGetInfoEX
        /// </summary>
        /// <param name="sSearchKey"></param>
        /// <param name="iMainType"></param>
        /// <param name="iSubType"></param>
        /// <param name="iIsArray"></param>
        /// <param name="iDataPtr"></param>
        /// <param name="nElements"></param>
        /// <param name="whichLevel"></param>
        /// <returns>Returns int.</returns>
        public static int VariableGetInfoEx(
            string sSearchKey,
            out int iMainType,
            out int iSubType,
            out int iIsArray,
            out int iDataPtr,
            out int nElements,
            int whichLevel = 0)
        {
            IntPtr pKey = AnsiBStrMarshal.Alloc(sSearchKey);

            try
            {
                return VariableGetInfoExNative(pKey, out iMainType, out iSubType, out iIsArray, out iDataPtr, out nElements, whichLevel);
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
        public static int VariableGetInfoPtr(
            int pVariable, 
            out int iMainType, 
            out int iSubType, 
            out int iIsArray)
        {
            return VariableGetInfoPtrNative(pVariable, out iMainType, out iSubType, out iIsArray);
        }

        /// <summary>
        /// VariableGetValueNum
        /// </summary>
        /// <param name="sSearchKey"></param>
        /// <returns>Returns double.</returns>
        public static double VariableGetValueNum(
            string sSearchKey)
        {
            return VariableGetValueNum(sSearchKey, 0);
        }

        /// <summary>
        /// VariableGetValueNum
        /// </summary>
        /// <param name="sSearchKey"></param>
        /// <param name="lIndex"></param>
        /// <returns>Returns double.</returns>
        public static double VariableGetValueNum(
            string sSearchKey, 
            int lIndex)
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
        public static int FunctionExists(
            string fName)
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
        /// Call a script function by name.
        /// </summary>
        /// <param name="functionName"></param>
        /// <returns>Returns int.</returns>
        public static int FunctionSimpleCall(
            string functionName)
        {
            return FunctionSimpleCall(functionName, out _, out _);
        }

        /// <summary>
        /// Call a script function by name and capture numeric / string return values.
        /// </summary>
        /// <param name="functionName"></param>
        /// <param name="numericResult"></param>
        /// <param name="stringResult"></param>
        /// <returns>Returns int.</returns>
        public static int FunctionSimpleCall(
            string functionName, 
            out double numericResult, 
            out string stringResult)
        {
            numericResult = 0;
            stringResult = null;

            IntPtr pName = AnsiBStrMarshal.Alloc(functionName);
            IntPtr pExt = Marshal.AllocHGlobal(10);
            IntPtr pStr = Marshal.AllocHGlobal(IntPtr.Size);
            Marshal.WriteIntPtr(pStr, IntPtr.Zero);

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Marshal.WriteByte(pExt, i, 0);
                }

                int result = FunctionSimpleCallNative(pName, pExt, pStr);
                numericResult = Marshal.PtrToStructure<Ext80>(pExt).ToDouble();
                stringResult = AnsiBStrMarshal.PtrToStringAndFree(Marshal.ReadIntPtr(pStr));
                Marshal.WriteIntPtr(pStr, IntPtr.Zero);

                return result;
            }
            finally
            {
                AnsiBStrMarshal.Free(pName);
                Marshal.FreeHGlobal(pExt);
                Marshal.FreeHGlobal(pStr);
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
        public static int RunTimeError(
            int errorCode, 
            string sAdditionalInfo)
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
        public static string GetRunTimeInfo(
            string sInfoName)
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
