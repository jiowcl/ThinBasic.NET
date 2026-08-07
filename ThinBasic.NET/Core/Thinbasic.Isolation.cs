// ThinBasic.NET - ThinBasic Programming Language for .NET
// Copyright (c) 2019-2026 Jiowcl. All rights reserved.

using System;
using System.Runtime.InteropServices;

namespace ThinBasic.NET.Core
{
    /// <summary>
    /// Isolation / bundled-execution helpers.
    /// </summary>
    public partial class Thinbasic
    {
        /// <summary>
        /// InitIsolated
        /// </summary>
        /// <param name="hWnd">Handle to the window to use for messages.</param>
        /// <param name="cInstance">Number of instances to create.</param>
        /// <param name="sKey">The key to use for the isolated path.</param>
        /// <param name="isolatedPath">The path to the isolated resources.</param>
        /// <returns>The handle to the isolated instance.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Init_Isolated", CallingConvention = CallingConvention.StdCall)]
        private static extern int InitIsolatedNative(int hWnd, int cInstance, IntPtr sKey, IntPtr isolatedPath);

        /// <summary>
        /// InitCheckScript
        /// </summary>
        /// <param name="hWnd">Handle to the window to use for messages.</param>
        /// <param name="cInstance">Number of instances to create.</param>
        /// <param name="sKey">The key to use for the isolated path.</param>
        /// <param name="isolatedPath">The path to the isolated resources.</param>
        /// <returns>The handle to the isolated instance.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Init_CheckScript", CallingConvention = CallingConvention.StdCall)]
        private static extern int InitCheckScriptNative(int hWnd, int cInstance, IntPtr sKey, IntPtr isolatedPath);

        /// <summary>
        /// IsIsolated
        /// </summary>
        /// <returns>Non-zero when isolation mode is active.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_IsIsolated", CallingConvention = CallingConvention.StdCall)]
        private static extern int IsIsolatedNative();

        /// <summary>
        /// IsolationPath
        /// </summary>
        /// <returns>The current isolation path, or null/empty when not isolated.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_IsolationPath", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr IsolationPathNative();

        /// <summary>
        /// IsBundled
        /// </summary>
        /// <returns>Non-zero when execution comes from a bundled executable.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_IsBundled", CallingConvention = CallingConvention.StdCall)]
        private static extern int IsBundledNative();

        /// <summary>
        /// Resources_Count
        /// </summary>
        /// <returns>The number of resources.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Resources_Count", CallingConvention = CallingConvention.StdCall)]
        private static extern int ResourcesCountNative();

        /// <summary>
        /// Resources_GetFile
        /// </summary>
        /// <param name="lIndex">Index of the resource to get.</param>
        /// <returns>The resource as a string.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Resources_GetFile", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr ResourcesGetFileNative(int lIndex);

        /// <summary>
        /// Resources_GetBuffer
        /// </summary>
        /// <param name="lIndex">Index of the resource to get.</param>
        /// <returns>The resource as a string.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Resources_GetBuffer", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr ResourcesGetBufferNative(int lIndex);

        /// <summary>
        /// Initialize thinCore in isolation mode using <paramref name="isolatedPath"/> for extracted modules/DLLs.
        /// </summary>
        /// <param name="hWnd">Handle to the window to use for messages.</param>
        /// <param name="cInstance">Number of instances to create.</param>
        /// <param name="sKey">The key to use for the isolated path.</param>
        /// <param name="isolatedPath">The path to the isolated resources.</param>
        /// <returns>The handle to the isolated instance.</returns>
        public static int InitIsolated(int hWnd, int cInstance, string sKey, string isolatedPath)
        {
            IntPtr pKey = AnsiBStrMarshal.Alloc(sKey);
            IntPtr pPath = AnsiBStrMarshal.Alloc(isolatedPath);

            try
            {
                return InitIsolatedNative(hWnd, cInstance, pKey, pPath);
            }
            finally
            {
                AnsiBStrMarshal.Free(pKey);
                AnsiBStrMarshal.Free(pPath);
            }
        }

        /// <summary>
        /// Initialize thinCore for script checking under an isolation path.
        /// </summary>
        /// <param name="hWnd">Handle to the window to use for messages.</param>
        /// <param name="cInstance">Number of instances to create.</param>
        /// <param name="sKey">The key to use for the isolated path.</param>
        /// <param name="isolatedPath">The path to the isolated resources.</param>
        /// <returns>The handle to the isolated instance.</returns>
        public static int InitCheckScript(int hWnd, int cInstance, string sKey, string isolatedPath)
        {
            IntPtr pKey = AnsiBStrMarshal.Alloc(sKey);
            IntPtr pPath = AnsiBStrMarshal.Alloc(isolatedPath);

            try
            {
                return InitCheckScriptNative(hWnd, cInstance, pKey, pPath);
            }
            finally
            {
                AnsiBStrMarshal.Free(pKey);
                AnsiBStrMarshal.Free(pPath);
            }
        }

        /// <summary>
        /// Returns non-zero when isolation mode is active.
        /// </summary>
        /// <returns>Non-zero when isolation mode is active.</returns>
        public static int IsIsolated()
        {
            return IsIsolatedNative();
        }

        /// <summary>
        /// Returns the current isolation path, or null/empty when not isolated.
        /// </summary>
        /// <returns>The current isolation path, or null/empty when not isolated.</returns>
        public static string IsolationPath()
        {
            return AnsiBStrMarshal.PtrToStringAndFree(IsolationPathNative());
        }

        /// <summary>
        /// Returns non-zero when execution comes from a bundled executable.
        /// </summary>
        /// <returns>Non-zero when execution comes from a bundled executable.</returns>
        public static int IsBundled()
        {
            return IsBundledNative();
        }

        /// <summary>
        /// Resources_Count
        /// </summary>
        /// <returns>The number of resources.</returns>
        public static int ResourcesCount()
        {
            return ResourcesCountNative();
        }

        /// <summary>
        /// Resources_GetFile
        /// </summary>
        /// <param name="lIndex">Index of the resource to get.</param>
        /// <returns>The resource as a string.</returns>
        public static string ResourcesGetFile(int lIndex)
        {
            return AnsiBStrMarshal.PtrToStringAndFree(ResourcesGetFileNative(lIndex));
        }

        /// <summary>
        /// Resources_GetBuffer
        /// </summary>
        /// <param name="lIndex">Index of the resource to get.</param>
        /// <returns>The resource as a string.</returns>
        public static string ResourcesGetBuffer(int lIndex)
        {
            return AnsiBStrMarshal.PtrToStringAndFree(ResourcesGetBufferNative(lIndex));
        }
    }
}
