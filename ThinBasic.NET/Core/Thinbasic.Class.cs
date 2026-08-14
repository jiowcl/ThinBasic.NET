// ThinBasic.NET - ThinBasic Programming Language for .NET
// Copyright (c) 2019-2026 Jiowcl. All rights reserved.

using System;
using System.Runtime.InteropServices;

namespace ThinBasic.NET.Core
{
    /// <summary>
    /// Module-class registration (dotted <c>obj.Method</c> host classes).
    /// Call after <see cref="Init"/> and before <see cref="Run"/>.
    /// Class / method / property callbacks are rooted until <see cref="ClearSymbolCallbacks"/>.
    /// Register <c>_Create</c> / <c>_Destroy</c> for constructor and destructor.
    /// </summary>
    public partial class Thinbasic
    {
        /// <summary>
        /// Special method name invoked by the <c>NEW</c> operator.
        /// </summary>
        public const string ClassMethodCreate = "_Create";

        /// <summary>
        /// Special method name invoked when a class variable is destroyed.
        /// </summary>
        public const string ClassMethodDestroy = "_Destroy";

        /// <summary>
        /// Add a class to the class table.
        /// </summary>
        /// <param name="sClassName">The name of the class.</param>
        /// <param name="ptrToClassFunction">The pointer to the class function.</param>
        /// <param name="ptrToUnknownFunction">The pointer to the unknown function.</param>
        /// <param name="unknownOnly">Whether to only add the unknown function.</param>
        /// <returns>The result of the operation.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Class_Add", CallingConvention = CallingConvention.StdCall)]
        private static extern int ClassAddNative(IntPtr sClassName, IntPtr ptrToClassFunction, IntPtr ptrToUnknownFunction, int unknownOnly);

        /// <summary>
        /// Add a method to a class created with <see cref="ClassAdd"/>.
        /// </summary>
        /// <param name="pClass">The class handle.</param>
        /// <param name="sMethodName">The name of the method.</param>
        /// <param name="methodReturnType">The return type of the method.</param>
        /// <param name="pMethodFunc">The pointer to the method function.</param>
        /// <returns>The result of the operation.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Class_AddMethod", CallingConvention = CallingConvention.StdCall)]
        private static extern int ClassAddMethodNative(int pClass, IntPtr sMethodName, int methodReturnType, IntPtr pMethodFunc);

        /// <summary>
        /// Add a property to a class created with <see cref="ClassAdd"/>.
        /// Get / set are dispatched with <see cref="Enums.ClassAction.Get"/> / <see cref="Enums.ClassAction.Set"/>.
        /// </summary>
        /// <param name="pClass">The class handle.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="propertyReturnType">The return type of the property.</param>
        /// <param name="ptrToPropertyFunction">The pointer to the property function.</param>
        /// <returns>The result of the operation.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Class_AddProperty", CallingConvention = CallingConvention.StdCall)]
        private static extern int ClassAddPropertyNative(int pClass, IntPtr sPropertyName, int propertyReturnType, IntPtr ptrToPropertyFunction);

        /// <summary>
        /// Parse the current class instance (use inside method callbacks). Returns the instance pointer, or 0.
        /// </summary>
        /// <returns>The instance pointer, or 0.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ParseClass", CallingConvention = CallingConvention.StdCall)]
        private static extern int ParseClassNative();

        /// <summary>
        /// Inspect class instance data (class-defined). Returns a string, or null.
        /// </summary>
        /// <param name="pClass">The class handle.</param>
        /// <param name="pVar">The instance pointer.</param>
        /// <param name="lLinearPos">The linear position to inspect.</param>
        /// <returns>The inspected data as a string, or null.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Class_Inspect", CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr ClassInspectNative(int pClass, int pVar, int lLinearPos);

        /// <summary>
        /// Class operations helper exported as <c>thinBasic_Class_Oprations</c> (thinCore spelling).
        /// Pass the class handle, instance pointer, and <see cref="Enums.ClassAction"/>.
        /// </summary>
        /// <param name="pClass">The class handle.</param>
        /// <param name="pVar">The instance pointer.</param>
        /// <param name="lAction">The action to perform.</param>
        /// <returns>The result of the operation.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Class_Oprations", CallingConvention = CallingConvention.StdCall)]
        private static extern int ClassOperationsNative(int pClass, int pVar, int lAction);

        /// <summary>
        /// Register a module class. Returns a class handle (0 on failure).
        /// </summary>
        /// <param name="className">The name of the class.</param>
        /// <param name="ptrToClassFunction">The pointer to the class function.</param>
        /// <param name="ptrToUnknownFunction">The pointer to the unknown function.</param>
        /// <param name="unknownOnly">Whether to only add the unknown function.</param>
        /// <returns>The result of the operation.</returns>
        public static int ClassAdd(
            string className, 
            IntPtr ptrToClassFunction, 
            IntPtr ptrToUnknownFunction = default, 
            int unknownOnly = 0)
        {
            IntPtr pName = AnsiBStrMarshal.Alloc(className);

            try
            {
                return ClassAddNative(pName, ptrToClassFunction, ptrToUnknownFunction, unknownOnly);
            }
            finally
            {
                AnsiBStrMarshal.Free(pName);
            }
        }

        /// <summary>
        /// Register a module class with a rooted managed dispatcher.
        /// Use <see cref="ThinBasicClassCallback"/> (pClass, pVar, action) or a parameterless callback
        /// depending on the thinCore build.
        /// </summary>
        /// <param name="className">The name of the class.</param>
        /// <param name="classFunction">The class function.</param>
        /// <param name="unknownFunction">The unknown function.</param>
        /// <param name="unknownOnly">Whether to only add the unknown function.</param>
        /// <returns>The result of the operation.</returns>
        public static int ClassAdd(
            string className, 
            Delegate classFunction, 
            Delegate unknownFunction = null, 
            int unknownOnly = 0)
        {
            IntPtr pClassFn = classFunction != null ? SymbolCallbackTable.Add(classFunction) : IntPtr.Zero;
            IntPtr pUnknown = unknownFunction != null ? SymbolCallbackTable.Add(unknownFunction) : IntPtr.Zero;

            return ClassAdd(className, pClassFn, pUnknown, unknownOnly);
        }

        /// <summary>
        /// Add a method to a class created with <see cref="ClassAdd"/>.
        /// </summary>
        /// <param name="pClass">The class handle.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="methodReturnType">The return type of the method.</param>
        /// <param name="pMethodFunc">The pointer to the method function.</param>
        /// <returns>The result of the operation.</returns>
        public static int ClassAddMethod(
            int pClass, 
            string methodName, 
            int methodReturnType, 
            IntPtr pMethodFunc)
        {
            IntPtr pName = AnsiBStrMarshal.Alloc(methodName);

            try
            {
                return ClassAddMethodNative(pClass, pName, methodReturnType, pMethodFunc);
            }
            finally
            {
                AnsiBStrMarshal.Free(pName);
            }
        }

        /// <summary>
        /// Add a method with a rooted managed callback.
        /// </summary>
        /// <param name="pClass">The class handle.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="methodReturnType">The return type of the method.</param>
        /// <param name="callback">The callback to add.</param>
        /// <returns>The result of the operation.</returns>
        public static int ClassAddMethod(
            int pClass, 
            string methodName, 
            int methodReturnType, 
            Delegate callback)
        {
            return ClassAddMethod(pClass, methodName, methodReturnType, SymbolCallbackTable.Add(callback));
        }

        /// <summary>
        /// Add a SUB / ReturnNone method.
        /// </summary>
        /// <param name="pClass">The class handle.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to add.</param>
        /// <returns>The result of the operation.</returns>
        public static int ClassAddMethod(
            int pClass, 
            string methodName, 
            ThinBasicSubCallback callback)
        {
            return ClassAddMethod(pClass, methodName, (int)Enums.ReturnType.None, callback);
        }

        /// <summary>
        /// Add a numeric method.
        /// </summary>
        /// <param name="pClass">The class handle.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to add.</param>
        /// <returns>The result of the operation.</returns>
        public static int ClassAddMethod(
            int pClass, 
            string methodName, 
            ThinBasicNumberCallback callback)
        {
            return ClassAddMethod(pClass, methodName, (int)Enums.ReturnType.Number, callback);
        }

        /// <summary>
        /// Add a string method. Return <see cref="AllocReturnString"/> from the callback.
        /// </summary>
        /// <param name="pClass">The class handle.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="callback">The callback to add.</param>
        /// <returns>The result of the operation.</returns>
        public static int ClassAddMethod(
            int pClass, 
            string methodName, 
            ThinBasicStringCallback callback)
        {
            return ClassAddMethod(pClass, methodName, (int)Enums.ReturnType.String, callback);
        }

        /// <summary>
        /// Add a property to a class created with <see cref="ClassAdd"/>.
        /// Get / set are dispatched with <see cref="Enums.ClassAction.Get"/> / <see cref="Enums.ClassAction.Set"/>.
        /// </summary>
        /// <param name="pClass">The class handle.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="propertyReturnType">The return type of the property.</param>
        /// <param name="ptrToPropertyFunction">The pointer to the property function.</param>
        /// <returns>The result of the operation.</returns>
        public static int ClassAddProperty(
            int pClass, 
            string propertyName, 
            int propertyReturnType, 
            IntPtr ptrToPropertyFunction)
        {
            IntPtr pName = AnsiBStrMarshal.Alloc(propertyName);

            try
            {
                return ClassAddPropertyNative(pClass, pName, propertyReturnType, ptrToPropertyFunction);
            }
            finally
            {
                AnsiBStrMarshal.Free(pName);
            }
        }

        /// <summary>
        /// Add a property with a rooted managed callback.
        /// </summary>
        /// <param name="pClass">The class handle.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="propertyReturnType">The return type of the property.</param>
        /// <param name="callback">The callback to add.</param>
        /// <returns>The result of the operation.</returns>
        public static int ClassAddProperty(
            int pClass, 
            string propertyName, 
            int propertyReturnType, 
            Delegate callback)
        {
            return ClassAddProperty(pClass, propertyName, propertyReturnType, SymbolCallbackTable.Add(callback));
        }

        /// <summary>
        /// Parse the current class instance (use inside method callbacks). Returns the instance pointer, or 0.
        /// </summary>
        /// <returns>The instance pointer, or 0.</returns>
        public static int ParseClass()
        {
            return ParseClassNative();
        }

        /// <summary>
        /// Inspect class instance data (class-defined). Returns a string, or null.
        /// </summary>
        /// <param name="pClass">The class handle.</param>
        /// <param name="pVar">The instance pointer.</param>
        /// <param name="linearPos">The linear position to inspect.</param>
        /// <returns>The inspected data as a string, or null.</returns>
        public static string ClassInspect(
            int pClass, 
            int pVar, 
            int linearPos = 0)
        {
            return AnsiBStrMarshal.PtrToStringAndFree(ClassInspectNative(pClass, pVar, linearPos));
        }

        /// <summary>
        /// Class operations helper exported as <c>thinBasic_Class_Oprations</c> (thinCore spelling).
        /// Pass the class handle, instance pointer, and <see cref="Enums.ClassAction"/>.
        /// </summary>
        /// <param name="pClass">The class handle.</param>
        /// <param name="pVar">The instance pointer.</param>
        /// <param name="lAction">The action to perform.</param>
        /// <returns>The result of the operation.</returns>
        public static int ClassOperations(
            int pClass, 
            int pVar, 
            int lAction)
        {
            return ClassOperationsNative(pClass, pVar, lAction);
        }
    }
}
