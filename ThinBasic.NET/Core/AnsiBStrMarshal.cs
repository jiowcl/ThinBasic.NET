// ThinBasic.NET - ThinBasic Programming Language for .NET
// Copyright (c) 2019-2026 Jiowcl. All rights reserved.

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ThinBasic.NET.Core
{
    /// <summary>
    /// Manual marshalling for thinCore.dll PowerBASIC-style ANSI BSTRs
    /// (length-prefixed single-byte strings allocated with SysAllocStringByteLen).
    /// Replaces obsolete <see cref="UnmanagedType.AnsiBStr"/>.
    /// </summary>
    internal static class AnsiBStrMarshal
    {
        // Thincore.dll string parameters/returns use ANSI BSTRs (SysAllocStringByteLen),
        // verified against SDK usage and runtime probes. UnmanagedType.AnsiBStr is obsolete,
        // so strings are marshalled manually via AnsiBStrMarshal.

        private static readonly Encoding AnsiEncoding = Encoding.GetEncoding(0);

        /// <summary>
        /// SysAllocStringByteLen
        /// </summary>
        /// <param name="psz">The string to allocate.</param>
        /// <param name="len">The length of the string.</param>
        /// <returns>The allocated BSTR.</returns>
        [DllImport("oleaut32.dll")]
        private static extern IntPtr SysAllocStringByteLen(IntPtr psz, uint len);

        /// <summary>
        /// SysStringByteLen
        /// </summary>
        /// <param name="bstr">The BSTR to get the length of.</param>
        /// <returns>The length of the BSTR.</returns>
        [DllImport("oleaut32.dll")]
        private static extern uint SysStringByteLen(IntPtr bstr);

        /// <summary>
        /// SysFreeString
        /// </summary>
        /// <param name="bstr">The BSTR to free.</param>
        /// <returns>Returns void.</returns>
        [DllImport("oleaut32.dll")]
        private static extern void SysFreeString(IntPtr bstr);

        /// <summary>
        /// Alloc
        /// </summary>
        /// <param name="value">The string to allocate.</param>
        /// <returns>The allocated BSTR.</returns>
        public static IntPtr Alloc(string value)
        {
            if (value == null)
            {
                return IntPtr.Zero;
            }

            if (value.Length == 0)
            {
                return SysAllocStringByteLen(IntPtr.Zero, 0);
            }

            byte[] bytes = AnsiEncoding.GetBytes(value);
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                return SysAllocStringByteLen(handle.AddrOfPinnedObject(), (uint)bytes.Length);
            }
            finally
            {
                handle.Free();
            }
        }

        /// <summary>
        /// Free
        /// </summary>
        /// <param name="bstr">The BSTR to free.</param>
        /// <returns>Returns void.</returns>
        public static void Free(IntPtr bstr)
        {
            if (bstr != IntPtr.Zero)
            {
                SysFreeString(bstr);
            }
        }

        /// <summary>
        /// PtrToStringAndFree
        /// </summary>
        /// <param name="bstr">The BSTR to convert to a string.</param>
        /// <returns>The string representation of the BSTR.</returns>
        public static string PtrToStringAndFree(IntPtr bstr)
        {
            if (bstr == IntPtr.Zero)
            {
                return null;
            }

            try
            {
                uint byteLen = SysStringByteLen(bstr);
                if (byteLen == 0)
                {
                    return string.Empty;
                }

                byte[] bytes = new byte[byteLen];
                Marshal.Copy(bstr, bytes, 0, (int)byteLen);
                return AnsiEncoding.GetString(bytes);
            }
            finally
            {
                SysFreeString(bstr);
            }
        }
    }
}
