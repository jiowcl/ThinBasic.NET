// ThinBasic.NET - ThinBasic Programming Language for .NET
// Copyright (c) 2019-2026 Jiowcl. All rights reserved.

using System;
using System.Runtime.InteropServices;

namespace ThinBasic.NET.Core
{
    /// <summary>
    /// thinCore string-key / string-value hash table helpers.
    /// Same storage used internally by thinBasic; does not require <see cref="Init"/>.
    /// Call <see cref="HashFree"/> when finished (caller owns the handle).
    /// </summary>
    public partial class Thinbasic
    {
        /// <summary>
        /// Hash_New
        /// </summary>
        /// <param name="lCount">Expected key count (thinCore clamps small values; typically use ≥ 100).</param>
        /// <returns>Hash handle (pointer-sized value); free with <see cref="HashFree"/>.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Hash_New", CallingConvention = CallingConvention.StdCall)]
        private static extern int HashNewNative(
            int lCount);

        /// <summary>
        /// Hash_Free
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <returns>0 on success, non-zero on error.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Hash_Free", CallingConvention = CallingConvention.StdCall)]
        private static extern int HashFreeNative(
            int pHash);

        /// <summary>
        /// Hash_Count
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <returns>Number of key/value pairs in the table.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Hash_Count", CallingConvention = CallingConvention.StdCall)]
        private static extern int HashCountNative(
            int pHash);

        /// <summary>
        /// Hash_Clone
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <returns>Hash handle (pointer-sized value); free with <see cref="HashFree"/>.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Hash_Clone", CallingConvention = CallingConvention.StdCall)]
        private static extern int HashCloneNative(
            int pHash);

        /// <summary>
        /// Hash_Clear
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <returns>0 on success, non-zero on error.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Hash_Clear", CallingConvention = CallingConvention.StdCall)]
        private static extern int HashClearNative(
            int pHash);

        /// <summary>
        /// Hash_Validate
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <returns>0 on success, non-zero on error.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Hash_Validate", CallingConvention = CallingConvention.StdCall)]
        private static extern int HashValidateNative(
            int pHash);

        /// <summary>
        /// Hash_CapGet
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <returns>Current capacity of the table.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Hash_CapGet", CallingConvention = CallingConvention.StdCall)]
        private static extern int HashCapGetNative(
            int pHash);

        /// <summary>
        /// Hash_CapSet
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <param name="lCap">New capacity.</param>
        /// <returns>Previous capacity.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Hash_CapSet", CallingConvention = CallingConvention.StdCall)]
        private static extern int HashCapSetNative(
            int pHash, 
            int lCap);

        /// <summary>
        /// Hash_GetKeys
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <param name="sSep">Separator string.</param>
        /// <returns>Keys joined by <paramref name="sSep"/>.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Hash_GetKeys", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr HashGetKeysNative(
            int pHash, 
            IntPtr sSep);

        /// <summary>
        /// Hash_Set
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <param name="sKey">Key string.</param>
        /// <param name="sData">Data string.</param>
        /// <returns>0 on success, non-zero on error.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Hash_Set", CallingConvention = CallingConvention.StdCall)]
        private static extern int HashSetNative(
            int pHash, 
            IntPtr sKey, 
            IntPtr sData);

        /// <summary>
        /// Hash_Add
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <param name="sKey">Key string.</param>
        /// <param name="sData">Data string.</param>
        /// <returns>0 on success, non-zero on error.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Hash_Add", CallingConvention = CallingConvention.StdCall)]
        private static extern int HashAddNative(
            int pHash, 
            IntPtr sKey, 
            IntPtr sData);

        /// <summary>
        /// Hash_Get
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <param name="sKey">Key string.</param>
        /// <returns>Value for <paramref name="sKey"/>, or <c>null</c> when missing.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Hash_Get", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr HashGetNative(
            int pHash, 
            IntPtr sKey);

        /// <summary>
        /// Hash_Get_Default
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <param name="sKey">Key string.</param>
        /// <param name="sDefault">Default value string.</param>
        /// <returns>Value for <paramref name="sKey"/>, or <paramref name="sDefault"/> when missing.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Hash_Get_Default", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr HashGetDefaultNative(
            int pHash, 
            IntPtr sKey, 
            IntPtr sDefault);

        /// <summary>
        /// Hash_GetPtr
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <param name="sKey">Key string.</param>
        /// <returns>Native pointer to the stored value for <paramref name="sKey"/>, or 0 when missing.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Hash_GetPtr", CallingConvention = CallingConvention.StdCall)]
        private static extern int HashGetPtrNative(
            int pHash, 
            IntPtr sKey);

        /// <summary>
        /// Hash_Del
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <param name="sKey">Key string.</param>
        /// <returns>0 on success, non-zero on error.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Hash_Del", CallingConvention = CallingConvention.StdCall)]
        private static extern int HashDelNative(
            int pHash, 
            IntPtr sKey);

        /// <summary>
        /// Hash_Exists
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <param name="sKey">Key string.</param>
        /// <returns>Non-zero when <paramref name="sKey"/> exists (case-sensitive).</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Hash_Exists", CallingConvention = CallingConvention.StdCall)]
        private static extern int HashExistsNative(
            int pHash, 
            IntPtr sKey);

        /// <summary>
        /// Hash_ToString
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <param name="lType">Format selector; 0 is the default thinCore layout.</param>
        /// <returns>Serialized table string.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Hash_ToString", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr HashToStringNative(
            int pHash, 
            int lType);

        /// <summary>
        /// Create a new string/string hash table.
        /// </summary>
        /// <param name="initialCapacity">Expected key count (thinCore clamps small values; typically use ≥ 100).</param>
        /// <returns>Hash handle (pointer-sized value); free with <see cref="HashFree"/>.</returns>
        public static int HashNew(
            int initialCapacity = 100)
        {
            return HashNewNative(initialCapacity);
        }

        /// <summary>
        /// Free a hash table and all of its entries. Caller must not use <paramref name="pHash"/> afterward.
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <returns>0 on success, non-zero on error.</returns>
        public static int HashFree(
            int pHash)
        {
            return HashFreeNative(pHash);
        }

        /// <summary>
        /// Number of key/value pairs in the table.
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <returns>Number of key/value pairs in the table.</returns>
        public static int HashCount(
            int pHash)
        {
            return HashCountNative(pHash);
        }

        /// <summary>
        /// Deep-clone a hash table. Caller owns the returned handle and must <see cref="HashFree"/> it.
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <returns>Hash handle (pointer-sized value); free with <see cref="HashFree"/>.</returns>
        public static int HashClone(
            int pHash)
        {
            return HashCloneNative(pHash);
        }

        /// <summary>
        /// Remove all entries; the handle remains valid.
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <returns>0 on success, non-zero on error.</returns>
        public static int HashClear(
            int pHash)
        {
            return HashClearNative(pHash);
        }

        /// <summary>
        /// Non-zero when <paramref name="pHash"/> appears to be a valid hash handle.
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <returns>0 on success, non-zero on error.</returns>
        public static int HashValidate(
            int pHash)
        {
            return HashValidateNative(pHash);
        }

        /// <summary>
        /// Current capacity of the table.
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <returns>Current capacity of the table.</returns>
        public static int HashCapGet(
            int pHash)
        {
            return HashCapGetNative(pHash);
        }

        /// <summary>
        /// Set table capacity. Returns the previous capacity.
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <param name="capacity">New capacity.</param>
        /// <returns>Previous capacity.</returns>
        public static int HashCapSet(
            int pHash, 
            int capacity)
        {
            return HashCapSetNative(pHash, capacity);
        }

        /// <summary>
        /// Return all keys joined by <paramref name="separator"/> (default <c>|</c>).
        /// Keys are case-sensitive and must not contain null bytes.
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <param name="separator">Separator string.</param>
        /// <returns>Keys joined by <paramref name="separator"/>.</returns>
        public static string HashGetKeys(
            int pHash, 
            string separator = "|")
        {
            IntPtr pSep = AnsiBStrMarshal.Alloc(separator ?? "|");
            try
            {
                return AnsiBStrMarshal.PtrToStringAndFree(HashGetKeysNative(pHash, pSep));
            }
            finally
            {
                AnsiBStrMarshal.Free(pSep);
            }
        }

        /// <summary>
        /// Insert or update <paramref name="key"/> → <paramref name="data"/>.
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <param name="key">Key string.</param>
        /// <param name="data">Data string.</param>
        /// <returns>0 on success, non-zero on error.</returns>
        public static int HashSet(
            int pHash, 
            string key, 
            string data)
        {
            IntPtr pKey = AnsiBStrMarshal.Alloc(key);
            IntPtr pData = AnsiBStrMarshal.Alloc(data);

            try
            {
                return HashSetNative(pHash, pKey, pData);
            }
            finally
            {
                AnsiBStrMarshal.Free(pKey);
                AnsiBStrMarshal.Free(pData);
            }
        }

        /// <summary>
        /// Add or update <paramref name="key"/> → <paramref name="data"/> (thinCore upsert semantics).
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <param name="key">Key string.</param>
        /// <param name="data">Data string.</param>
        /// <returns>0 on success, non-zero on error.</returns>
        public static int HashAdd(
            int pHash, 
            string key, 
            string data)
        {
            IntPtr pKey = AnsiBStrMarshal.Alloc(key);
            IntPtr pData = AnsiBStrMarshal.Alloc(data);

            try
            {
                return HashAddNative(pHash, pKey, pData);
            }
            finally
            {
                AnsiBStrMarshal.Free(pKey);
                AnsiBStrMarshal.Free(pData);
            }
        }

        /// <summary>
        /// Value for <paramref name="key"/>, or <c>null</c> when missing.
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <param name="key">Key string.</param>
        /// <returns>Value for <paramref name="key"/>, or <c>null</c> when missing.</returns>
        public static string HashGet(
            int pHash, 
            string key)
        {
            IntPtr pKey = AnsiBStrMarshal.Alloc(key);

            try
            {
                return AnsiBStrMarshal.PtrToStringAndFree(HashGetNative(pHash, pKey));
            }
            finally
            {
                AnsiBStrMarshal.Free(pKey);
            }
        }

        /// <summary>
        /// Value for <paramref name="key"/>, or <paramref name="defaultValue"/> when missing.
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <param name="key">Key string.</param>
        /// <param name="defaultValue">Default value string.</param>
        /// <returns>Value for <paramref name="key"/>, or <paramref name="defaultValue"/> when missing.</returns>
        public static string HashGetDefault(
            int pHash, 
            string key, 
            string defaultValue = "")
        {
            IntPtr pKey = AnsiBStrMarshal.Alloc(key);
            IntPtr pDefault = AnsiBStrMarshal.Alloc(defaultValue ?? string.Empty);

            try
            {
                return AnsiBStrMarshal.PtrToStringAndFree(HashGetDefaultNative(pHash, pKey, pDefault))
                    ?? string.Empty;
            }
            finally
            {
                AnsiBStrMarshal.Free(pKey);
                AnsiBStrMarshal.Free(pDefault);
            }
        }

        /// <summary>
        /// Native pointer to the stored value for <paramref name="key"/>, or 0 when missing.
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <param name="key">Key string.</param>
        /// <returns>Native pointer to the stored value for <paramref name="key"/>, or 0 when missing.</returns>
        public static int HashGetPtr(
            int pHash, 
            string key)
        {
            IntPtr pKey = AnsiBStrMarshal.Alloc(key);
            try
            {
                return HashGetPtrNative(pHash, pKey);
            }
            finally
            {
                AnsiBStrMarshal.Free(pKey);
            }
        }

        /// <summary>
        /// Delete the entry for <paramref name="key"/>.
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <param name="key">Key string.</param>
        /// <returns>0 on success, non-zero on error.</returns>
        public static int HashDel(
            int pHash, 
            string key)
        {
            IntPtr pKey = AnsiBStrMarshal.Alloc(key);
            try
            {
                return HashDelNative(pHash, pKey);
            }
            finally
            {
                AnsiBStrMarshal.Free(pKey);
            }
        }

        /// <summary>
        /// Non-zero when <paramref name="key"/> exists (case-sensitive).
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <param name="key">Key string.</param>
        /// <returns>Non-zero when <paramref name="key"/> exists (case-sensitive).</returns>
        public static int HashExists(
            int pHash, 
            string key)
        {
            IntPtr pKey = AnsiBStrMarshal.Alloc(key);
            try
            {
                return HashExistsNative(pHash, pKey);
            }
            finally
            {
                AnsiBStrMarshal.Free(pKey);
            }
        }

        /// <summary>
        /// Serialize the table (default format is JSON-like text).
        /// </summary>
        /// <param name="pHash">Hash handle.</param>
        /// <param name="type">Format selector; 0 is the default thinCore layout.</param>
        public static string HashToString(
            int pHash, 
            int type = 0)
        {
            return AnsiBStrMarshal.PtrToStringAndFree(HashToStringNative(pHash, type));
        }
    }
}
