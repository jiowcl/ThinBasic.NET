// ThinBasic.NET - ThinBasic Programming Language for .NET
// Copyright (c) 2019 Jiowcl. All rights reserved.

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

        // RunTimeError
        public enum RunTimeError : int
        {
            Parens = 1,
            Noexp = 2,
            DivZero = 3,
            EqualExp = 4,
            NotVar = 5,
            LabTabFull = 6,
            DupLab = 7,
            UndefLab = 8,
            ThenExpected = 9,
            ToExpected = 10,
            TooManyFor = 11,
            NextWithoutFor = 12,
            MissingSemicolon = 13,
            CommandRetNoneInExpression = 14,
            MissQuote = 15,
            BadFile = 16,
            StrExpected = 17,
            UnknownKeyword = 18,
            MissingOpenparens = 19,
            MissingCloseparens = 20,
            MissingComma = 21,
            MissingSquarecloseparens = 22,
            EolIncorrect = 23,
            DoubleConcatenation = 24,
            CommandUnknownReturnedParameter = 25,
            PrimitiveStr = 26,
            PrimitiveNum = 27,
            PrintError = 28,
            PrintErrorNoendofline = 29,
            VariableNotDefined = 30,
            AtomTokenTypeNumeric = 31,
            AtomNum = 31,
            IfWithoutEndif = 32,
            IfEndifWithoutIf = 33,
            TooManyWhile = 34,
            WhileWithoutWend = 35,
            DimTypeNotDefined = 36,
            ExitNoKeyFound = 37,
            NoEndFunctionFound = 38,
            FunctionNameDuplicate = 39,
            FunctionNameIsKey = 40,
            FunctionNameIsVar = 41,
            FunctionNameIsUdt = 42,
            EndNoKeyFound = 43,
            DimMissingAs = 44,
            UndefinedToken = 45,
            UnsupportedChar = 46,
            FunctionDeclareMissingAs = 47,
            DeclareFunctionOrSubExpected = 48,
            DoloopWrongCondition = 49,
            MissingAlias = 50,
            MissingLib = 51,
            UndefinedVarType = 52,
            ParameterByrefIncorrectPtr = 53,
            LoopExpectedWhileOrUntil = 55,
            EndFunctionWithoutFunction = 58,
            EndFunctionFound = 59,
            IterateNoKeyFound = 60,
            WithEndwithError = 64,
            TooNestedDoloop = 65,
            DoloopMissingDoOrLoop = 66,
            VariableNotDimensioned = 70,
            VariableIsnotArray = 71,
            VariableMustbeStringType = 72,
            RedimNewTypeNotSupported = 73,
            RedimPreserveNotvalidAbsolute = 74,
            VariableMustbeUdtType = 75,
            KeywordNotExpected = 76,
            TokenNotExpected = 77,
            IncludeFileNotFound = 80,
            IncludeFileNotFoundInetGeneric = 81,
            IncludeFileNotFoundInetConnection = 82,
            IncludeFileNotFoundInetOpenurl = 83,
            IncludeFileNotFoundInet404 = 84,
            DimUnexpectedKeyword = 85,
            FunctionNotSupported = 90,
            ArrayFunctionNotSupported = 91,
            UdtElementNotFound = 100,
            UdtExpected = 101,
            UdtEquOrElementExpected = 102,
            AssignmentNotSupported = 110,
            RelationalExpected = 115,
            ApiLibNotFound = 120,
            ApiFunctionNotFoundInLib = 121,
            ApiGeneralAddressNotPresent = 122,
            CallNotSupportedStatement = 130,
            CallFunctionnotFound = 131,
            FunctionnotFound = 133,
            FunctionExpectedCallback = 134,
            EquateAlreadyDefined = 135,
            EquateAlreadyDefinedDifferent = 136,
            VariableNameDuplicateGlobal = 142,
            VariableNameDuplicateFunction = 144,
            VariableNameDuplicateLocal = 145,
            VariableNameDuplicate = 146,
            ForStepshouldbenegative = 150,
            ForStepshouldbepositive = 151,
            ForExpectedavariable = 152,
            ForStepiszero = 153,
            ForVarmustbenumeric = 154,
            AliasCommandnameexpected = 160,
            AliasAsexpected = 161,
            AliasUndefnotundef = 162,
            TypeMissingEndUnion = 169,
            TypeMissingEndType = 170,
            TypeMissingEndClass = 171,
            TypeTypeNotDefined = 172,
            TypeMissingAs = 173,
            TypeNameMustbeUndefined = 174,
            TypeArrayMustbeDimensioned = 175,
            TypeStringsMustHaveSize = 176,
            TypeElementAlreadyPresent = 177,
            TypeElementAlreadyPresentInherit = 178,
            TypeDynstringInsideUnion = 179,
            NoEndRawtextFound = 180,
            BeginBlockUnsuported = 190,
            BeginConstMissingEnd = 191,
            FunctionParamUnrecognizedType = 220,
            DoWithoutLoop = 245,
            FunctionMissingAs = 246,
            RegexprMissingTo = 247,
            RegexprMissingIn = 248,
            SelectWithoutEndselect = 249,
            DuplicateSymbol = 250,
            Invalidnumericchar = 251,
            Invaliddelimiter = 252,
            Invaliddatatype = 253,
            VariableExpected = 254,
            VariableVariantExpected = 255,
            SelectMissingCase = 270,
            SelectErrorKindofOperation = 271,
            SelectCodeBetweenSelectCase = 272,
            StrptrVariableNotADynstringNum = 280,
            StrptrVariableNotADynstringVar = 281,
            StrptrVariableNotADynstringUdt = 282,
            ApicallRefExpected = 300,
            ArrayOutOfBound = 400,
            ModuleSpecific = 500,
            PreparserDirectivenotsupported = 800,
            PreparserScriptversionrequest = 820,
            InternalReturnmaintype = 900,
            InternalDecription = 910,
            InternalUdtbufferShort = 915,
            InternalReturnnoneNocodeptr = 921,
            InternalReturnnumberNocodeptr = 922,
            InternalReturnstringNocodeptr = 923,
            ClassNewNoindexallowed = 5010,
            ClassNewDifferentclass = 5015,
            ClassNewNoclass = 5020,
            ClassNewExpectedNew = 5025,
            ClassNotInitWithNew = 5030,
            ClassSetNowAllowed = 5035,
            ClassMethodpropertyNotfound = 5100,
            ClassExpected = 5110,
            TraceStopByUser = 11000,
            ObfuscationFilenotvalid = 12000,
            ComGeneric = 30000,
            Generic = 62000
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
