# ThinBasic.NET

.Net Wrapper for ThinBasic Programming Language.

![GitHub](https://img.shields.io/github/license/jiowcl/ThinBasic.NET.svg)
![Nuget](https://img.shields.io/nuget/v/ThinBasic.NET)
![Travis-Ci](https://travis-ci.com/jiowcl/ThinBasic.NET.svg?branch=master)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/c5cd6aeb809142018010cca36f2ea46c)](https://www.codacy.com/gh/jiowcl/ThinBasic.NET/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=jiowcl/ThinBasic.NET&amp;utm_campaign=Badge_Grade)

## Environment

- Windows 10 above (recommend)  
- ThinBasic 1.14  
- .NET 8 / 9 / 10 (Windows x86)

## NuGet Installation

```powershell
PM> Install-Package ThinBasic.NET
```

## How to Build

Building requires [Visual Studio 2026 Community](https://visualstudio.microsoft.com/vs/community/) and test under Windows 11.

## Example

```csharp
string scriptPath = @"Sample\test.tbasic";
string scriptBuffer = File.ReadAllText(scriptPath, Encoding.UTF8);

int bufferType = (int)Enums.BufferType.IsScript;
int callingProgram = (int)Enums.CallingProgram.GUI;

int hThinbasic = Thinbasic.Init(0, 0, "thinbasic");

if (hThinbasic != 0)
{
    Console.WriteLine("Init failed: " + Thinbasic.GetLastError());

    return;
}

// Optional: inject host constants / keywords before Run
Thinbasic.AddEquate("%HOST_EQ", string.Empty, 7, (int)Enums.EquateType.Number);

int hostCalls = 0;
Thinbasic.LoadSymbol("HostFlag", () => hostCalls++, Enums.ForceOverWrite);
Thinbasic.LoadSymbol("HostNum", () => 123.5, Enums.ForceOverWrite);
Thinbasic.LoadSymbol("HostStr$", () => Thinbasic.AllocReturnString("hello"), Enums.ForceOverWrite);

int result = Thinbasic.Run(hThinbasic, scriptBuffer, bufferType, 0, 0, 0, 0, callingProgram, 0);
int lastError = Thinbasic.GetLastError();
Thinbasic.Release(hThinbasic);
Thinbasic.ClearSymbolCallbacks();

if (lastError != 0)
{
    Console.WriteLine("Script error: " + lastError);
}
```

`LoadSymbol` / `LoadSymbolEx` accept managed delegates (`ThinBasicSubCallback`, `ThinBasicNumberCallback`, `ThinBasicStringCallback`, or any `Delegate`). Callbacks are kept rooted until `ClearSymbolCallbacks()`.

Inside a keyword callback, use parser helpers to read script arguments:

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

## License

Copyright (c) 2017-2026 Ji-Feng Tsai.  
ThinBasic Copyright (c) Eros Olmi [ThinBASIC Interpreter](https://github.com/ThinBASIC).  
Code released under the MIT license.  

## TODO

- More thinCore.dll APIs (arrays / class / hash)  
- More examples  


## Donation

If this application help you reduce time to coding, you can give me a cup of coffee :)

[![paypal](https://www.paypalobjects.com/en_US/TW/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=3RNMD6Q3B495N&source=url)

[Paypal Me](https://paypal.me/jiowcl?locale.x=zh_TW)
