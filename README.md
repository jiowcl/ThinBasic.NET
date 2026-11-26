# ThinBasic.NET

.NET wrapper for the [ThinBasic](https://github.com/ThinBASIC) scripting engine (`thinCore.dll`).  
Embed ThinBasic scripts in .NET apps, inject host constants/keywords, and parse callback arguments.

![GitHub](https://img.shields.io/github/license/jiowcl/ThinBasic.NET.svg)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![thinBasic](https://img.shields.io/badge/Language-thinBasic-104E8B?style=flat-square)
![Nuget](https://img.shields.io/nuget/v/ThinBasic.NET)
![CI](https://github.com/jiowcl/ThinBasic.NET/actions/workflows/ci.yml/badge.svg)

## Requirements

| Item | Detail |
|------|--------|
| OS | Windows 10+ |
| Architecture | **x86 only** (`PlatformTarget=x86`) |
| .NET | **net8.0-windows / net9.0-windows / net10.0-windows / net11.0-windows** |
| Native | Ships `thinCore.dll` + `thinBasic_UI.dll` (ThinBasic 1.14 era) |

x64 / Arm64 processes cannot load the bundled 32-bit native DLLs.

## NuGet

```powershell
PM> Install-Package ThinBasic.NET
```

Consumer projects must target **Windows x86** (or Prefer 32-bit) so `thinCore.dll` can load.

## Important notes

### Strings (ANSI BSTR)

thinCore string parameters/returns use **ANSI BSTRs** (`SysAllocStringByteLen`), not Unicode `BStr` / `LPStr`.  
This package marshals them manually. Prefer ASCII / system-ANSI-safe text for symbol names and paths.

For `ThinBasicStringCallback` return values, allocate with:

```csharp
return Thinbasic.AllocReturnString("hello");
```

Ownership of that BSTR is transferred to thinCore — do not free it yourself.

### Callbacks and GC

`LoadSymbol` / `LoadSymbolEx` accept managed delegates and keep them rooted until:

```csharp
Thinbasic.ClearSymbolCallbacks();
```

Call `ClearSymbolCallbacks` only when no script may still invoke those keywords.

### Direct variable / array pointers

`GetVariableNumberDirect` / `ChangeVariable*Direct` need the **return value** of `VariableGetInfoEx` (variable structure pointer), **not** the `DataPtr` out-parameter.

### Runtime errors

Script runtime errors may show a thinBasic error dialog and leave process-wide engine state dirty.  
Prefer validating scripts; avoid relying on failed `Run` calls inside long-lived hosts.  
`GetLastError` can remain sticky across `Release` / next `Init` in some failure paths.

### Isolation

`InitIsolated` / `InitCheckScript` take an isolation directory for extracted modules/DLLs.  
After `InitIsolated`, `IsIsolated()` is non-zero and `IsolationPath()` returns that path.  
Isolation flags may remain set for the process after `Release` (thinCore global state).

### Hash tables

`HashNew` / `HashSet` / `HashGet` / `HashFree` use thinCore’s internal string hash storage.  
`Init` is not required. Keys are case-sensitive; always `HashFree` handles you create (including clones).

### Module classes

`ClassAdd` / `ClassAddMethod` / `ClassAddProperty` register a dotted host class after `Init`.  
Register `_Create` (`Thinbasic.ClassMethodCreate`) so `obj = NEW ClassName` runs your constructor callback.  
Inside methods, `ParseClass()` returns the current instance pointer.  
Class / method / property delegates stay rooted until `ClearSymbolCallbacks`.

This bundled thinCore invokes `_Create` on `NEW`. Instance method calls (`o.GetN`) can still raise runtime **5030** if the engine never marks the variable initialized (the class dispatcher / `ClassAction.Constructor` path is not always invoked).

## Quick start

```csharp
using ThinBasic.NET.Core;

int h = Thinbasic.Init(0, 0, "thinbasic");
if (h != 0)
{
    Console.WriteLine("Init failed: " + Thinbasic.GetLastError());
    return;
}

Thinbasic.AddEquate("%HOST_EQ", string.Empty, 7, (int)Enums.EquateType.Number);

int hostCalls = 0;
Thinbasic.LoadSymbol("HostFlag", () => hostCalls++, Enums.ForceOverWrite);
Thinbasic.LoadSymbol("HostNum", () => 123.5, Enums.ForceOverWrite);
Thinbasic.LoadSymbol("HostStr$", () => Thinbasic.AllocReturnString("hello"), Enums.ForceOverWrite);

string script = File.ReadAllText(@"Sample\test.tbasic", Encoding.UTF8);
int result = Thinbasic.Run(
    h,
    script,
    (int)Enums.BufferType.IsScript,
    0, 0, 0, 0,
    (int)Enums.CallingProgram.Console,
    0);

int lastError = Thinbasic.GetLastError();
Thinbasic.Release(h);
Thinbasic.ClearSymbolCallbacks();

if (lastError != 0)
{
    Console.WriteLine("Script error: " + lastError);
}
```

### Parser callbacks

```csharp
Thinbasic.LoadSymbol("HostAdd", () =>
{
    if (Thinbasic.CheckOpenParensMandatory() == 0) return 0;
    Thinbasic.ParseNumber(out double a);
    if (Thinbasic.CheckCommaMandatory() == 0) return 0;
    Thinbasic.ParseNumber(out double b);
    if (Thinbasic.CheckCloseParensMandatory() == 0) return 0;
    return a + b;
}, Enums.ForceOverWrite);
```

### Isolation  

```csharp
string iso = Path.Combine(Path.GetTempPath(), "my-iso");
Directory.CreateDirectory(iso);

int h = Thinbasic.InitIsolated(0, 0, "thinbasic", iso);
// Thinbasic.IsIsolated() != 0
// Thinbasic.IsolationPath() ~= iso

Thinbasic.Run(h, "DIM n AS LONG\r\nn = 1\r\n",
    (int)Enums.BufferType.IsScript, 0, 0, 0, 0,
    (int)Enums.CallingProgram.Console, 0);

Thinbasic.Release(h);
```

## Examples project

```powershell
dotnet run --project ThinBasic.Example -c Release -p:Platform=x86 -- embed
dotnet run --project ThinBasic.Example -c Release -p:Platform=x86 -- host
dotnet run --project ThinBasic.Example -c Release -p:Platform=x86 -- parser
dotnet run --project ThinBasic.Example -c Release -p:Platform=x86 -- array
dotnet run --project ThinBasic.Example -c Release -p:Platform=x86 -- isolated
dotnet run --project ThinBasic.Example -c Release -p:Platform=x86 -- hash
dotnet run --project ThinBasic.Example -c Release -p:Platform=x86 -- class
```

## Build & test

Requires Visual Studio 2022/2026 (or .NET SDK 8+) on Windows.

```powershell
dotnet build ThinBasic.NET\ThinBasic.NET.csproj -c Release -p:Platform=x86
dotnet test ThinBasic.NETTests\ThinBasic.NETTests.csproj -c Release -p:Platform=x86
```

## API surface (summary)

| Area | Highlights |
|------|------------|
| Lifecycle | `Init`, `InitIsolated`, `InitCheckScript`, `Run`, `Release`, `AddIncludePath` |
| Host data | `AddEquate`, `AddVariable`, `ChangeVariable*`, `VariableGet*`, `FunctionSimpleCall` |
| Keywords | `LoadSymbol` / `LoadSymbolEx` (+ delegate overloads), `AllocReturnString`, `ClearSymbolCallbacks` |
| Parser | `CheckOpen/CloseParens*`, `CheckComma*`, `ParseNumber` / `ParseString`, `PutBack`, `GetToken*` |
| Arrays | `VariableIsArray`, `ArrayGetElements` / `Ptr` / `Info`, `VariableRedim`, `*Direct` |
| Isolation | `IsIsolated`, `IsolationPath`, `IsBundled`, `ResourcesCount` / `GetFile` / `GetBuffer` |
| Hash | `HashNew` / `Free` / `Set` / `Add` / `Get` / `GetDefault` / `Exists` / `Del` / `Count` / `Clone` / `Clear` / `GetKeys` / `ToString` / `Cap*` / `Validate` |
| Classes | `ClassAdd`, `ClassAddMethod`, `ClassAddProperty`, `ParseClass`, `ClassInspect`, `ClassOperations` |

## License

Copyright (c) 2017-2026 Ji-Feng Tsai.  
ThinBasic Copyright (c) Eros Olmi [ThinBASIC Interpreter](https://github.com/ThinBASIC).  
Code released under the MIT license.

## TODO

- More thinCore.dll APIs (file / unicode / lib helpers)  


## Donation

If this application help you reduce time to coding, you can give me a cup of coffee :)

[![paypal](https://www.paypalobjects.com/en_US/TW/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=3RNMD6Q3B495N&source=url)

[Paypal Me](https://paypal.me/jiowcl?locale.x=zh_TW)
