# ThinBasic.NET

.Net Wrapper for ThinBasic Programming Language.

![GitHub](https://img.shields.io/github/license/jiowcl/ThinBasic.NET.svg)
![Nuget](https://img.shields.io/nuget/v/ThinBasic.NET)
![Travis-Ci](https://travis-ci.com/jiowcl/ThinBasic.NET.svg?branch=master)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/c5cd6aeb809142018010cca36f2ea46c)](https://www.codacy.com/gh/jiowcl/ThinBasic.NET/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=jiowcl/ThinBasic.NET&amp;utm_campaign=Badge_Grade)

## Environment

- Windows 7 above (recommend)  
- ThinBasic 1.14  
- .NET 9

## NuGet Installation

```powershell
PM> Install-Package ThinBasic.NET
```

## How to Build

Building requires [Visual Studio 2022 Community](https://visualstudio.microsoft.com/vs/community/) and test under Windows 10.

## Example

```csharp
string scriptPath = @"Sample\test.tbasic";
string scriptBuffer = File.ReadAllText(scriptPath, Encoding.UTF8);

int bufferType = (int)Enums.BufferType.IsScript;
int callingProgram = (int)Enums.CallingProgram.GUI;

int hThinbasic = Thinbasic.Init(0, 0, "thinbasic");
int result = Thinbasic.Run(hThinbasic, scriptBuffer, bufferType, 0, 0, 0, 0, callingProgram, 0);
Thinbasic.Release(0);
```

## License

Copyright (c) 2017-2026 Ji-Feng Tsai.  
ThinBasic Copyright (c) Eros Olmi [ThinBASIC Interpreter](https://github.com/ThinBASIC).  
Code released under the MIT license.  

## TODO

- More Functions defined in thinCore.dll  
- More examples  

## Donation

If this application help you reduce time to coding, you can give me a cup of coffee :)

[![paypal](https://www.paypalobjects.com/en_US/TW/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=3RNMD6Q3B495N&source=url)

[Paypal Me](https://paypal.me/jiowcl?locale.x=zh_TW)
