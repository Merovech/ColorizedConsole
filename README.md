# ColorizedConsole
![CI Debug](https://github.com/Merovech/ColorizedConsole/actions/workflows/ci-build-debug.yml/badge.svg) ![CI Release](https://github.com/Merovech/ColorizedConsole/actions/workflows/ci-build-release.yml/badge.svg)

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

ColorizedConsole is a simple, lightweight wrapper for `System.Console` that adds basic, configurable coloring functionality to your console apps.

![image](https://github.com/user-attachments/assets/a86d434d-c1ec-43ba-af5d-62743ecf3cea)

## Features
* Complete wrapper for `System.Console`, so it can be used as a replacement and you can use the same class for all of your console output.

* Multiplatform -- uses no `DllImport` or other external calls.  Basically, it has the same platform limitations as `System.Console`.

* Lightweight -- uses no external libraries or NuGet packages.  Even the configuration system was custom-built since it's so simple (see below).

## Installation
ColorizedConsole is available via NuGet.
``` powershell
# Using powershell
Install-Package ColorizedConsole
```
... or...
```ps
# Using the .NET CLI
dotnet add package ColorizedConsole
```
... or any of the other ways you can get a NuGet package.

## Usage
There is one class in the package: `ColorEx`.  It provides three types of colorized text: Debug, Info, and Error.  Each is provided in a `Write` and `WriteLine` form, and all of them have the same parameters and overloads as the standard `Console.Write` and `Console.WriteLine` methods.  The colors for all three types are customizable (see below).

**WriteDebug**  
By default, this text is <code style="color: Yellow">yellow</code>.
```csharp
ColorizedConsole.ConsoleEx.WriteDebug("some_text");
ColorizedConsole.ConsoleEx.WriteDebugLine("some_text");
```
Example Output:  
![image](https://github.com/user-attachments/assets/c853592a-7305-4730-ad62-1c7b5c40cccc)

**WriteInfo**  
By default, this text is <code style="color: Green">green</code>.
```csharp
ColorizedConsole.ConsoleEx.WriteInfo("some_text");
ColorizedConsole.ConsoleEx.WriteInfoLine("some_text");
```
Example Output:  
![image](https://github.com/user-attachments/assets/8e936dc1-dbd4-43f7-9f11-2a3f9a5af0d1)

**WriteError**  
By default, this text is <code style="color: Red">red</code>.
```csharp
ColorizedConsole.ConsoleEx.WriteError("some_text");
ColorizedConsole.ConsoleEx.WriteErrorLine("some_text");
```
Example Output:  
![image](https://github.com/user-attachments/assets/bd1c13d1-c772-4c43-a712-aad2903abbf6)

In addition, every overload for `Console.Write` and `Console.WriteLine` has a version that supports color.  For example:

```csharp
ColorizedConsole.ConsoleEx.WriteLine(ConsoleColor.Purple, 6);
```

## Configuration
Configuration is done using a file called `.colorcrc`.  This was done to avoid the need for other dependencies or NuGet packages like `Microsoft.Extensions.Configuration`.

The format of this file is very simple:
```
Info=[value]
Debug=[value]
Error=[value]
```

`value` must be a valid member of the [`ConsoleColor`](https://learn.microsoft.com/en-us/dotnet/api/system.consolecolor?view=net-8.0) enumeration.  If it is not, `ConsoleEx` will fall back to whatever the system's default colors are for the console.

Put that file in the same location as your .exe, and away you go!

## Contributions
Want to contribute?  Fantastic!  I'd be happy for the help to make this even more useful, provided the following project goals are maintained:

1. Complete `System.Console` wrapper including all overloads to allow `ColorizedConsole.ConsoleEx` to be a drop-in replacement.

2. Multiplatform (as much as the system version is) by not using platform-specific calls such as `DllImport`.

3. Standalone and lightweight by not being dependent on anything other than the base CLR itself.

You're welcome to request access to the project or fork it and create a PR.  Or just contact [Merovech](https://github.com/Merovech). Whatever works for you.

## Current Roadmap (updated monthly - last, September 2024)
:arrow_forward:= In Progress
:white_check_mark:= Complete
:x:= Incomplete
:grey_question:= Idea (needs investigation)

* :arrow_forward: Implement updated configuration
  * :white_check_mark: JSON config file
  * :white_check_mark: Environment variables
  * :x: Extension methods to make config optional
  * :x: Unit tests for new config functionality
* :x: Add a wiki
  * :x: Description of the project
  * :x: Usage examples
  * :x: API documentation
    * :grey_question: Maybe some sort of autodoc
  * :x: Configuration guidelines and examples
* :x: Change the NuGet README to a changelog
* :x: Create a GitHub project so that I don't have to keep maintaining this file