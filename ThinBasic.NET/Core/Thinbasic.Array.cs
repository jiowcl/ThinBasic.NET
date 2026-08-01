// ThinBasic.NET - ThinBasic Programming Language for .NET
// Copyright (c) 2019-2026 Jiowcl. All rights reserved.

using System;
using System.Runtime.InteropServices;

namespace ThinBasic.NET.Core
{
    /// <summary>
    /// Array and direct variable access helpers.
    /// </summary>
    /// <remarks>
    /// Array and direct variable access helpers.
    /// </remarks>
    public partial class Thinbasic
    {
        /// <summary>
        /// thinBasic_VariableIsArray
        /// </summary>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_VariableIsArray", CallingConvention = CallingConvention.StdCall)]
        private static extern int VariableIsArrayNative(
            IntPtr vName);

        /// <summary>
        /// thinBasic_VariableRedim
        /// </summary>
        /// <param name="pVar">The pointer to the variable.</param>
        /// <param name="lPreserve">The preserve flag.</param>
        /// <param name="varDim1">The first dimension.</param>
        /// <param name="varDim2">The second dimension.</param>
        /// <param name="varDim3">The third dimension.</param>
        /// <returns>The result of the variable redim.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_VariableRedim", CallingConvention = CallingConvention.StdCall)]
        private static extern int VariableRedimNative(
            int pVar, 
            int lPreserve, 
            int varDim1, 
            int varDim2, 
            int varDim3);


        /// <summary>
        /// thinBasic_ArrayGetElements
        /// </summary>
        /// <param name="vName">The name of the variable.</param>
        /// <returns>The result of the array get elements.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ArrayGetElements", CallingConvention = CallingConvention.StdCall)]
        private static extern int ArrayGetElementsNative(
            IntPtr vName);

        /// <summary>
        /// thinBasic_ArrayGetPtr
        /// </summary>
        /// <param name="vName">The name of the variable.</param>
        /// <returns>The result of the array get ptr.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ArrayGetPtr", CallingConvention = CallingConvention.StdCall)]
        private static extern int ArrayGetPtrNative(
            IntPtr vName);

        /// <summary>
        /// thinBasic_ArrayGetInfo
        /// </summary>
        /// <param name="arrayPtr">The pointer to the array.</param>
        /// <param name="infoType">The type of information to get.</param>
        /// <returns>The result of the array get info.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ArrayGetInfo", CallingConvention = CallingConvention.StdCall)]
        private static extern int ArrayGetInfoNative(
            int arrayPtr, 
            int infoType);

        /// <summary>
        /// thinBasic_VariableParse
        /// </summary>
        /// <param name="variablePtr">The pointer to the variable.</param>
        /// <param name="variableAbsPos">The absolute position of the variable.</param>
        /// <returns>The result of the variable parse.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_VariableParse", CallingConvention = CallingConvention.StdCall)]
        private static extern int VariableParseNative(
            out int variablePtr, 
            out int variableAbsPos);

        /// <summary>
        /// thinBasic_VariableParsePtr
        /// </summary>
        /// <param name="variablePtr">The pointer to the variable.</param>
        /// <returns>The result of the variable parse ptr.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_VariableParsePtr", CallingConvention = CallingConvention.StdCall)]
        private static extern int VariableParsePtrNative(
            out int variablePtr);


        /// <summary>
        /// thinBasic_ChangeVariableNumberDirect
        /// </summary>
        /// <param name="variablePtr">The pointer to the variable.</param>
        /// <param name="variableAbsPos">The absolute position of the variable.</param>
        /// <param name="lValNumber">The value of the number.</param>
        /// <returns>The result of the change variable number direct.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ChangeVariableNumberDirect", CallingConvention = CallingConvention.StdCall)]
        private static extern int ChangeVariableNumberDirectNative(
            int variablePtr, 
            int variableAbsPos, 
            Ext80 lValNumber);


        /// <summary>
        /// thinBasic_ChangeVariableStringDirect
        /// </summary>
        /// <param name="variablePtr">The pointer to the variable.</param>
        /// <param name="variableAbsPos">The absolute position of the variable.</param>
        /// <param name="lValString">The value of the string.</param>
        /// <returns>The result of the change variable string direct.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ChangeVariableStringDirect", CallingConvention = CallingConvention.StdCall)]
        private static extern int ChangeVariableStringDirectNative(
            int variablePtr, 
            int variableAbsPos, 
            IntPtr lValString);

        /// <summary>
        /// thinBasic_ChangeVariableUDTDirect
        /// </summary>
        /// <param name="variablePtr">The pointer to the variable.</param>
        /// <param name="variableAbsPos">The absolute position of the variable.</param>
        /// <param name="lValString">The value of the string.</param>
        /// <returns>The result of the change variable udt direct.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ChangeVariableUDTDirect", CallingConvention = CallingConvention.StdCall)]
        private static extern int ChangeVariableUdtDirectNative(
            int variablePtr, 
            int variableAbsPos, 
            IntPtr lValString);


        /// <summary>
        /// thinBasic_GetVariableNumberDirect
        /// </summary>
        /// <param name="variablePtr">The pointer to the variable.</param>
        /// <param name="variableAbsPos">The absolute position of the variable.</param>
        /// <returns>The result of the get variable number direct.</returns>    
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_GetVariableNumberDirect", CallingConvention = CallingConvention.StdCall)]
        private static extern double GetVariableNumberDirectNative(
            int variablePtr, 
            int variableAbsPos);

        /// <summary>
        /// VariableIsArray
        /// </summary>
        public static int VariableIsArray(string vName)
        {
            IntPtr pName = AnsiBStrMarshal.Alloc(vName);

            try
            {
                return VariableIsArrayNative(pName);
            }
            finally
            {
                AnsiBStrMarshal.Free(pName);
            }
        }

        /// <summary>
        /// VariableRedim
        /// </summary>
        /// <param name="pVar">The pointer to the variable.</param>
        /// <param name="lPreserve">The preserve flag.</param>
        /// <param name="varDim1">The first dimension.</param>
        /// <param name="varDim2">The second dimension.</param>
        /// <param name="varDim3">The third dimension.</param>
        /// <returns>The result of the variable redim.</returns>
        public static int VariableRedim(
            int pVar, 
            int lPreserve, 
            int varDim1, 
            int varDim2 = 0, 
            int varDim3 = 0)
        {
            return VariableRedimNative(pVar, lPreserve, varDim1, varDim2, varDim3);
        }

        /// <summary>
        /// ArrayGetElements
        /// </summary>
        /// <param name="vName">The name of the variable.</param>
        /// <returns>The result of the array get elements.</returns>
        public static int ArrayGetElements(
            string vName)
        {
            IntPtr pName = AnsiBStrMarshal.Alloc(vName);

            try
            {
                return ArrayGetElementsNative(pName);
            }
            finally
            {
                AnsiBStrMarshal.Free(pName);
            }
        }

        /// <summary>
        /// ArrayGetPtr
        /// </summary>
        /// <param name="vName">The name of the variable.</param>
        /// <returns>The result of the array get ptr.</returns>
        public static int ArrayGetPtr(
            string vName)
        {
            IntPtr pName = AnsiBStrMarshal.Alloc(vName);

            try
            {
                return ArrayGetPtrNative(pName);
            }
            finally
            {
                AnsiBStrMarshal.Free(pName);
            }
        }

        /// <summary>
        /// ArrayGetInfo. Prefer <see cref="ArrayGetElements"/> / <see cref="VariableGetInfoEx"/> when possible;
        /// InfoType semantics can vary across thinCore builds.
        /// </summary>
        /// <param name="arrayPtr">The pointer to the array.</param>
        /// <param name="infoType">The type of information to get.</param>
        /// <returns>The result of the array get info.</returns>
        public static int ArrayGetInfo(
            int arrayPtr, 
            int infoType)
        {
            return ArrayGetInfoNative(arrayPtr, infoType);
        }

        /// <summary>
        /// ArrayGetInfo using <see cref="Enums.ArrayInfoType"/>.
        /// </summary>
        /// <param name="arrayPtr">The pointer to the array.</param>
        /// <param name="infoType">The type of information to get.</param>
        /// <returns>The result of the array get info.</returns>
        public static int ArrayGetInfo(
            int arrayPtr, 
            Enums.ArrayInfoType infoType)
        {
            return ArrayGetInfoNative(arrayPtr, (int)infoType);
        }

        /// <summary>
        /// VariableParse — used inside keyword callbacks to resolve the next variable token.
        /// </summary>
        /// <param name="variablePtr">The pointer to the variable.</param>
        /// <param name="variableAbsPos">The absolute position of the variable.</param>
        /// <returns>The result of the variable parse.</returns>
        public static int VariableParse(
            out int variablePtr, 
            out int variableAbsPos)
        {
            return VariableParseNative(out variablePtr, out variableAbsPos);
        }

        /// <summary>
        /// VariableParsePtr
        /// </summary>
        /// <param name="variablePtr">The pointer to the variable.</param>
        /// <returns>The result of the variable parse ptr.</returns>
        public static int VariableParsePtr(
            out int variablePtr)
        {
            return VariableParsePtrNative(out variablePtr);
        }

        /// <summary>
        /// ChangeVariableNumberDirect.
        /// Use the pointer returned by <see cref="VariableGetInfoEx"/> (not its DataPtr out-parameter).
        /// </summary>
        /// <param name="variablePtr">The pointer to the variable.</param>
        /// <param name="variableAbsPos">The absolute position of the variable.</param>
        /// <param name="lValNumber">The value of the number.</param>
        /// <returns>The result of the change variable number direct.</returns>
        public static int ChangeVariableNumberDirect(
            int variablePtr, 
            int variableAbsPos, 
            double lValNumber)
        {
            return ChangeVariableNumberDirectNative(variablePtr, variableAbsPos, Ext80.FromDouble(lValNumber));
        }

        /// <summary>
        /// ChangeVariableStringDirect.
        /// Use the pointer returned by <see cref="VariableGetInfoEx"/> (not its DataPtr out-parameter).
        /// </summary>
        /// <param name="variablePtr">The pointer to the variable.</param>
        /// <param name="variableAbsPos">The absolute position of the variable.</param>
        /// <param name="lValString">The value of the string.</param>
        /// <returns>The result of the change variable string direct.</returns>
        public static int ChangeVariableStringDirect(
            int variablePtr, 
            int variableAbsPos, 
            string lValString)
        {
            IntPtr pValue = AnsiBStrMarshal.Alloc(lValString);

            try
            {
                return ChangeVariableStringDirectNative(variablePtr, variableAbsPos, pValue);
            }
            finally
            {
                AnsiBStrMarshal.Free(pValue);
            }
        }

        /// <summary>
        /// ChangeVariableUDTDirect — binary/UDT buffer as ANSI BSTR payload.
        /// </summary>
        /// <param name="variablePtr">The pointer to the variable.</param>
        /// <param name="variableAbsPos">The absolute position of the variable.</param>
        /// <param name="lValString">The value of the string.</param>
        /// <returns>The result of the change variable udt direct.</returns>
        public static int ChangeVariableUdtDirect(
            int variablePtr, 
            int variableAbsPos, 
            string lValString)
        {
            IntPtr pValue = AnsiBStrMarshal.Alloc(lValString);

            try
            {
                return ChangeVariableUdtDirectNative(variablePtr, variableAbsPos, pValue);
            }
            finally
            {
                AnsiBStrMarshal.Free(pValue);
            }
        }

        /// <summary>
        /// GetVariableNumberDirect.
        /// Use the pointer returned by <see cref="VariableGetInfoEx"/> (not its DataPtr out-parameter).
        /// </summary>
        /// <param name="variablePtr">The pointer to the variable.</param>
        /// <param name="variableAbsPos">The absolute position of the variable.</param>
        /// <returns>The result of the get variable number direct.</returns>
        public static double GetVariableNumberDirect(
            int variablePtr, 
            int variableAbsPos)
        {
            return GetVariableNumberDirectNative(variablePtr, variableAbsPos);
        }
    }
}
