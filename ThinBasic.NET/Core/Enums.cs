namespace ThinBasic.NET.Core
{
    /// <summary>
    /// Enums
    /// </summary>
    public static class Enums
    {
        // DoNotForceOverWrite
        public const int DoNotForceOverWrite = 0;

        // ForceOverWrite
        public const int ForceOverWrite = 1;

        // VarMainType
        public enum VarMainType : int
        {
            IsNumber = 20,
            IsString = 30,
            IsAsciiZ = 25,
            IsVariant = 50
        }

        // VarSubType
        public enum VarSubType : int
        {
            Byte = 1,
            Integer = 2,
            Word = 3,
            DWord = 4,
            Long = 5,
            Quad = 6,
            Single = 7,
            Double = 8,
            Currency = 9,
            Ext = 10,
            Variant = 50
        }

        // ReturnType
        public enum ReturnType : int
        {
            None = 0,
            CodeNone = None,
            Number = 20,
            CodeNumber = Number,
            String = 30,
            CodeString = String,
            CodeByte = 1,
            CodeInteger = 2,
            CodeWord = 3,
            CodeDWord = 4,
            CodeLong = 5,
            CodeQuad = 6,
            CodeSingle = 7,
            CodeDouble = 8,
            CodeCurrency = 9,
            CodeExt = 10
        }

        // BufferType
        public enum BufferType : int
        {
            IsFile = 0,
            IsScript
        }

        // CallingProgram
        public enum CallingProgram : int
        {
            GUI = 1,
            Console = 2
        }
    }
}
