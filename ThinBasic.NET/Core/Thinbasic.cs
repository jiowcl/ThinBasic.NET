using System.Runtime.InteropServices;

namespace ThinBasic.NET.Core
{
    /// <summary>
    /// Thinbasic
    /// </summary>
    public class Thinbasic
    {
        /// <summary>
        /// Init
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="cInstance"></param>
        /// <param name="sKey"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Init", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Init(int hWnd, int cInstance, [MarshalAs(UnmanagedType.LPWStr)] string sKey);

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
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Run", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Run(int hScript, [MarshalAs(UnmanagedType.BStr)] string sBuffer, int bufferType, int options, int debugMode, int logMode, int obfuscateMode, int callingProgram, int dependancyMode);

        /// <summary>
        /// Release
        /// </summary>
        /// <param name="hScript"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_Release", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int Release(int hScript);

        /// <summary>
        /// AddIncludePath
        /// </summary>
        /// <param name="sNewIncludeDir"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_AddIncludePath", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int AddIncludePath([MarshalAs(UnmanagedType.LPWStr)] string sNewIncludeDir);

        /// <summary>
        /// GetLastError
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_GetLastError", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetLastError();

        /// <summary>
        /// ErrorFlag
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ErrorFlag", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ErrorFlag();

        /// <summary>
        /// ErrorFree
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ErrorFree", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ErrorFree();

        /// <summary>
        /// ErrorUserConfirmed
        /// </summary>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_ErrorUserConfirmed", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int ErrorUserConfirmed();

        /// <summary>
        /// RunTimeError
        /// </summary>
        /// <param name="errorCode"></param>
        /// <param name="sAdditionalInfo"></param>
        /// <returns>Returns int.</returns>
        [DllImport("thinCore.dll", EntryPoint = "thinBasic_RunTimeError", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        public static extern int RunTimeError(int errorCode, [MarshalAs(UnmanagedType.LPWStr)] string sAdditionalInfo);
    }
}
