// ThinBasic.NET - ThinBasic Programming Language for .NET
// Copyright (c) 2019-2026 Jiowcl. All rights reserved.

using System;
using System.Runtime.InteropServices;

namespace ThinBasic.NET.Core
{
    /// <summary>
    /// Module / parser helpers used inside <see cref="LoadSymbol"/> callbacks.
    /// </summary>
    public partial class Thinbasic
    {
        /// <summary>
        /// CheckOpenParens
        /// </summary>
        /// <param name="hideError"></param>
        /// <param name="autoPutBack"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_CheckOpenParens", CallingConvention = CallingConvention.StdCall)]
        private static extern int CheckOpenParensNative(
            int hideError, 
            int autoPutBack);

        /// <summary>
        /// CheckOpenParens_Mandatory
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_CheckOpenParens_Mandatory", CallingConvention = CallingConvention.StdCall)]
        private static extern int CheckOpenParensMandatoryNative();

        /// <summary>
        /// CheckOpenParens_Optional
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_CheckOpenParens_Optional", CallingConvention = CallingConvention.StdCall)]
        private static extern int CheckOpenParensOptionalNative();

        /// <summary>
        /// CheckCloseParens
        /// </summary>
        /// <param name="hideError"></param>
        /// <param name="autoPutBack"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_CheckCloseParens", CallingConvention = CallingConvention.StdCall)]
        private static extern int CheckCloseParensNative(
            int hideError, 
            int autoPutBack);

        /// <summary>
        /// CheckCloseParens_Mandatory
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_CheckCloseParens_Mandatory", CallingConvention = CallingConvention.StdCall)]
        private static extern int CheckCloseParensMandatoryNative();

        /// <summary>
        /// CheckCloseParens_Optional
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_CheckCloseParens_Optional", CallingConvention = CallingConvention.StdCall)]
        private static extern int CheckCloseParensOptionalNative();

        /// <summary>
        /// CheckComma
        /// </summary>
        /// <param name="hideError"></param>
        /// <param name="autoPutBack"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_CheckComma", CallingConvention = CallingConvention.StdCall)]
        private static extern int CheckCommaNative(
            int hideError, 
            int autoPutBack);

        /// <summary>
        /// CheckComma_Mandatory
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_CheckComma_Mandatory", CallingConvention = CallingConvention.StdCall)]
        private static extern int CheckCommaMandatoryNative();

        /// <summary>
        /// CheckComma_Optional
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_CheckComma_Optional", CallingConvention = CallingConvention.StdCall)]
        private static extern int CheckCommaOptionalNative();

        /// <summary>
        /// CheckEqual_Mandatory
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_CheckEqual_Mandatory", CallingConvention = CallingConvention.StdCall)]
        private static extern int CheckEqualMandatoryNative();

        /// <summary>
        /// CheckEqual_Optional
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_CheckEqual_Optional", CallingConvention = CallingConvention.StdCall)]
        private static extern int CheckEqualOptionalNative();

        /// <summary>
        /// PutBack
        /// </summary>
        /// <param name="lPtr"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_PutBack", CallingConvention = CallingConvention.StdCall)]
        private static extern int PutBackNative(
            int lPtr);

        /// <summary>
        /// GetToken
        /// </summary>
        /// <param name="autoPutBack"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_GetToken", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetTokenNative(
            int autoPutBack);

        /// <summary>
        /// GetTokenId
        /// </summary>
        /// <param name="tokenName"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_GetTokenID", CallingConvention = CallingConvention.StdCall)]
        private static extern int GetTokenIdNative(
            IntPtr tokenName);

        /// <summary>
        /// GetTokenName
        /// </summary>
        /// <param name="autoPutBack"></param>
        /// <returns>Returns IntPtr.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_GetTokenName", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr GetTokenNameNative(
            int autoPutBack);

        /// <summary>
        /// ParseNumber
        /// </summary>
        /// <param name="result"></param>
        /// <returns>Returns void.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ParseNumber", CallingConvention = CallingConvention.StdCall)]
        private static extern void ParseNumberNative(
            ref Ext80 result);

        /// <summary>
        /// ParseExt
        /// </summary>
        /// <param name="result"></param>
        /// <returns>Returns void.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ParseExt", CallingConvention = CallingConvention.StdCall)]
        private static extern void ParseExtNative(
            ref Ext80 result);

        /// <summary>
        /// ParseDouble
        /// </summary>
        /// <param name="result"></param>
        /// <returns>Returns void.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ParseDouble", CallingConvention = CallingConvention.StdCall)]
        private static extern void ParseDoubleNative(
            out double result);

        /// <summary>
        /// ParseLong
        /// </summary>
        /// <param name="result"></param>
        /// <returns>Returns void.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ParseLong", CallingConvention = CallingConvention.StdCall)]
        private static extern void ParseLongNative(
            out int result);

        /// <summary>
        /// Parse1Number
        /// </summary>
        /// <returns>Returns double.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Parse1Number", CallingConvention = CallingConvention.StdCall)]
        private static extern double Parse1NumberNative();

        /// <summary>
        /// Parse1String
        /// </summary>
        /// <returns>Returns string.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Parse1String", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr Parse1StringNative();

        /// <summary>
        /// ParseString
        /// </summary>
        /// <param name="sResult"></param>
        /// <returns>Returns double.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ParseString", CallingConvention = CallingConvention.StdCall)]
        private static extern double ParseStringNative(
            ref IntPtr sResult);

        /// <summary>
        /// ParseStr
        /// </summary>
        /// <param name="sResult"></param>
        /// <returns>Returns void.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ParseStr", CallingConvention = CallingConvention.StdCall)]
        private static extern void ParseStrNative(
            ref IntPtr sResult);

        /// <summary>
        /// CheckOpenParens
        /// </summary>
        /// <param name="hideError"></param>
        /// <param name="autoPutBack"></param>
        /// <returns>Returns int.</returns>
        public static int CheckOpenParens(
            int hideError = 0, 
            int autoPutBack = 0)
        {
            return CheckOpenParensNative(hideError, autoPutBack);
        }

        /// <summary>
        /// CheckOpenParens_Mandatory
        /// </summary>
        /// <returns>Returns int.</returns>
        public static int CheckOpenParensMandatory()
        {
            return CheckOpenParensMandatoryNative();
        }

        /// <summary>
        /// CheckOpenParens_Optional
        /// </summary>
        /// <returns>Returns int.</returns>
        public static int CheckOpenParensOptional()
        {
            return CheckOpenParensOptionalNative();
        }

        /// <summary>
        /// CheckCloseParens
        /// </summary>
        /// <param name="hideError"></param>
        /// <param name="autoPutBack"></param>
        /// <returns>Returns int.</returns>
        public static int CheckCloseParens(
            int hideError = 0, 
            int autoPutBack = 0)
        {
            return CheckCloseParensNative(hideError, autoPutBack);
        }

        /// <summary>
        /// CheckCloseParens_Mandatory
        /// </summary>
        /// <returns>Returns int.</returns>
        public static int CheckCloseParensMandatory()
        {
            return CheckCloseParensMandatoryNative();
        }

        /// <summary>
        /// CheckCloseParens_Optional
        /// </summary>
        /// <returns>Returns int.</returns>
        public static int CheckCloseParensOptional()
        {
            return CheckCloseParensOptionalNative();
        }

        /// <summary>
        /// CheckComma
        /// </summary>
        /// <param name="hideError"></param>
        /// <param name="autoPutBack"></param>
        /// <returns>Returns int.</returns>
        public static int CheckComma(
            int hideError = 0, 
            int autoPutBack = 0)
        {
            return CheckCommaNative(hideError, autoPutBack);
        }

        /// <summary>
        /// CheckComma_Mandatory
        /// </summary>
        /// <returns>Returns int.</returns>
        public static int CheckCommaMandatory()
        {
            return CheckCommaMandatoryNative();
        }

        /// <summary>
        /// CheckComma_Optional
        /// </summary>
        /// <returns>Returns int.</returns>
        public static int CheckCommaOptional()
        {
            return CheckCommaOptionalNative();
        }

        /// <summary>
        /// CheckEqual_Mandatory
        /// </summary>
        /// <returns>Returns int.</returns>
        public static int CheckEqualMandatory()
        {
            return CheckEqualMandatoryNative();
        }

        /// <summary>
        /// CheckEqual_Optional
        /// </summary>
        /// <returns>Returns int.</returns>
        public static int CheckEqualOptional()
        {
            return CheckEqualOptionalNative();
        }

        /// <summary>
        /// PutBack
        /// </summary>
        /// <param name="lPtr"></param>
        /// <returns>Returns int.</returns>
        public static int PutBack(int lPtr = 0)
        {
            return PutBackNative(lPtr);
        }

        /// <summary>
        /// GetToken
        /// </summary>
        /// <param name="autoPutBack"></param>
        /// <returns>Returns int.</returns>
        public static int GetToken(int autoPutBack = 0)
        {
            return GetTokenNative(autoPutBack);
        }

        /// <summary>
        /// GetTokenID
        /// </summary>
        /// <param name="tokenName"></param>
        /// <returns>Returns int.</returns>
        public static int GetTokenId(
            string tokenName)
        {
            IntPtr pName = AnsiBStrMarshal.Alloc(tokenName);

            try
            {
                return GetTokenIdNative(pName);
            }
            finally
            {
                AnsiBStrMarshal.Free(pName);
            }
        }

        /// <summary>
        /// GetTokenName
        /// </summary>
        /// <param name="autoPutBack"></param>
        /// <returns>Returns string.</returns>
        public static string GetTokenName(
            int autoPutBack = 0)
        {
            return AnsiBStrMarshal.PtrToStringAndFree(GetTokenNameNative(autoPutBack));
        }

        /// <summary>
        /// ParseNumber (EXT expression) into a double.
        /// </summary>
        /// <param name="result"></param>
        /// <returns>Returns void.</returns>
        public static void ParseNumber(
            out double result)
        {
            Ext80 ext = default;
            ParseNumberNative(ref ext);
            result = ext.ToDouble();
        }

        /// <summary>
        /// ParseExt into a double.
        /// </summary>
        /// <param name="result"></param>
        /// <returns>Returns void.</returns>
        public static void ParseExt(
            out double result)
        {
            Ext80 ext = default;
            ParseExtNative(ref ext);
            result = ext.ToDouble();
        }

        /// <summary>
        /// ParseDouble
        /// </summary>
        /// <param name="result"></param>
        /// <returns>Returns void.</returns>
        public static void ParseDouble(
            out double result)
        {
            ParseDoubleNative(out result);
        }

        /// <summary>
        /// ParseLong
        /// </summary>
        /// <param name="result"></param>
        /// <returns>Returns void.</returns>
        public static void ParseLong(
            out int result)
        {
            ParseLongNative(out result);
        }

        /// <summary>
        /// Parse1Number — parse one numeric expression (with optional surrounding parentheses).
        /// </summary>
        /// <returns>Returns double.</returns>
        public static double Parse1Number()
        {
            return Parse1NumberNative();
        }

        /// <summary>
        /// Parse1String — parse one string expression (with optional surrounding parentheses).
        /// </summary>
        /// <returns>Returns string.</returns>
        public static string Parse1String()
        {
            return AnsiBStrMarshal.PtrToStringAndFree(Parse1StringNative());
        }

        /// <summary>
        /// ParseString — parse one string expression and return its numeric representation when applicable.
        /// </summary>
        /// <param name="result"></param>
        /// <returns>Returns double.</returns>
        public static double ParseString(
            out string result)
        {
            IntPtr bstr = IntPtr.Zero;
            double value = ParseStringNative(ref bstr);
            result = AnsiBStrMarshal.PtrToStringAndFree(bstr) ?? string.Empty;

            return value;
        }

        /// <summary>
        /// ParseStr — parse one string expression.
        /// </summary>
        /// <param name="result"></param>
        /// <returns>Returns void.</returns>
        public static void ParseStr(
            out string result)
        {
            IntPtr bstr = IntPtr.Zero;
            ParseStrNative(ref bstr);

            result = AnsiBStrMarshal.PtrToStringAndFree(bstr) ?? string.Empty;
        }
    }
}
