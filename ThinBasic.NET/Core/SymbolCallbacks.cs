// ThinBasic.NET - ThinBasic Programming Language for .NET
// Copyright (c) 2019-2026 Jiowcl. All rights reserved.

using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace ThinBasic.NET.Core
{
    /// <summary>
    /// thinBasic keyword callback with no return value (SUB / ReturnNone).
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void ThinBasicSubCallback();

    /// <summary>
    /// thinBasic keyword callback returning a numeric value (ReturnNumber).
    /// Value is returned as double (marshalled via FPU ST0 compatible with EXT).
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate double ThinBasicNumberCallback();

    /// <summary>
    /// thinBasic keyword callback returning a string (ReturnString).
    /// Return an ANSI BSTR from <see cref="Thinbasic.AllocReturnString"/>;
    /// ownership is transferred to thinCore.
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate IntPtr ThinBasicStringCallback();

    /// <summary>
    /// Module-class dispatcher (constructor / destructor / property get-set).
    /// <paramref name="pClass"/> is the handle from <see cref="Thinbasic.ClassAdd"/>;
    /// <paramref name="pVar"/> is the class variable pointer; <paramref name="lAction"/> is <see cref="Enums.ClassAction"/>.
    /// </summary>
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int ThinBasicClassCallback(int pClass, int pVar, int lAction);

    /// <summary>
    /// Keeps managed delegates rooted so GC cannot collect callbacks registered with thinCore.
    /// </summary>
    internal static class SymbolCallbackTable
    {
        /// <summary>
        /// Roots of the callback table.
        /// </summary>
        private static readonly ConcurrentDictionary<IntPtr, Delegate> Roots =
            new ConcurrentDictionary<IntPtr, Delegate>();

        /// <summary>
        /// Adds a delegate to the callback table.
        /// </summary>
        /// <param name="callback"></param>
        /// <returns>Returns IntPtr.</returns>
        public static IntPtr Add(
            Delegate callback)
        {
            if (callback == null)
            {
                throw new ArgumentNullException(nameof(callback));
            }

            IntPtr ptr = Marshal.GetFunctionPointerForDelegate(callback);
            Roots[ptr] = callback;

            return ptr;
        }

        /// <summary>
        /// Clears the callback table.
        /// </summary>
        public static void Clear()
        {
            Roots.Clear();
        }
    }
}
