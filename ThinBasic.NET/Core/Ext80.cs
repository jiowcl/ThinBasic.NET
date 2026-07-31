// ThinBasic.NET - ThinBasic Programming Language for .NET
// Copyright (c) 2019-2026 Jiowcl. All rights reserved.

using System;
using System.Runtime.InteropServices;

namespace ThinBasic.NET.Core
{
    /// <summary>
    /// PowerBASIC / thinBasic EXT (80-bit x87 extended precision) passed by value.
    /// </summary>
    /// <remarks>
    /// EXT values are passed by value; EXT function returns are read as double (ST0).
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 10)]
    internal struct Ext80
    {
        // Low 64 bits
        public ulong Lo;

        // High 16 bits
        public ushort Hi;

        /// <summary>
        /// FromDouble
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns Ext80.</returns>
        public static Ext80 FromDouble(double value)
        {
            Ext80 ext;

            unsafe
            {
                DoubleToExt(value, (byte*)&ext);
            }

            return ext;
        }

        /// <summary>
        /// ToDouble
        /// </summary>
        /// <returns>Returns double.</returns>
        public double ToDouble()
        {
            Ext80 copy = this;

            unsafe
            {
                return ExtToDouble((byte*)&copy);
            }
        }

        /// <summary>
        /// DoubleToExt
        /// </summary>
        /// <param name="d"></param>
        /// <param name="ext"></param>
        /// <returns>Returns void.</returns>
        private static unsafe void DoubleToExt(double d, byte* ext)
        {
            ulong bits = (ulong)BitConverter.DoubleToInt64Bits(d);
            int sign = (int)(bits >> 63);
            int exp = (int)((bits >> 52) & 0x7FF);
            ulong frac = bits & 0xFFFFFFFFFFFFFUL;
            ulong mant;
            int e;

            if (exp == 0)
            {
                if (frac == 0)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        ext[i] = 0;
                    }

                    if (sign != 0)
                    {
                        ext[9] = 0x80;
                    }

                    return;
                }

                e = -1022;
                mant = frac;

                while ((mant & (1UL << 52)) == 0)
                {
                    mant <<= 1;
                    e--;
                }

                mant = ((mant & ~(1UL << 52)) << 11) | (1UL << 63);
                e += 16383;
            }
            else if (exp == 0x7FF)
            {
                mant = (frac == 0) ? 0x8000000000000000UL : (0xC000000000000000UL | (frac << 11));
                e = 0x7FFF;

                if (sign != 0)
                {
                    e |= 0x8000;
                }

                Write(ext, mant, e);

                return;
            }
            else
            {
                e = exp - 1023 + 16383;
                mant = (1UL << 63) | (frac << 11);
            }

            if (sign != 0)
            {
                e |= 0x8000;
            }

            Write(ext, mant, e);
        }

        /// <summary>
        /// ExtToDouble
        /// </summary>
        /// <param name="ext"></param>
        /// <returns>Returns double.</returns>
        private static unsafe double ExtToDouble(byte* ext)
        {
            ulong mant = 0;

            for (int i = 0; i < 8; i++)
            {
                mant |= ((ulong)ext[i]) << (8 * i);
            }

            int e = ext[8] | (ext[9] << 8);
            int sign = (e >> 15) & 1;
            e &= 0x7FFF;

            if (e == 0)
            {
                return sign != 0 ? -0.0 : 0.0;
            }

            if (e == 0x7FFF)
            {
                bool nan = (mant & 0x7FFFFFFFFFFFFFFFUL) != 0;

                if (nan)
                {
                    return double.NaN;
                }

                return sign != 0 ? double.NegativeInfinity : double.PositiveInfinity;
            }

            int exp = e - 16383 + 1023;
            ulong frac = (mant >> 11) & 0xFFFFFFFFFFFFFUL;

            if (exp <= 0)
            {
                return 0.0;
            }

            if (exp >= 0x7FF)
            {
                return sign != 0 ? double.NegativeInfinity : double.PositiveInfinity;
            }

            ulong bits = ((ulong)sign << 63) | ((ulong)exp << 52) | frac;

            return BitConverter.Int64BitsToDouble((long)bits);
        }

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="ext"></param>
        /// <param name="mant"></param>
        /// <param name="e"></param>
        /// <returns>Returns void.</returns>
        private static unsafe void Write(byte* ext, ulong mant, int e)
        {
            for (int i = 0; i < 8; i++)
            {
                ext[i] = (byte)(mant >> (8 * i));
            }

            ext[8] = (byte)e;
            ext[9] = (byte)(e >> 8);
        }
    }
}
