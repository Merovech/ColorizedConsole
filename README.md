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
Configuration is supported in three ways: in code, via JSON file, and via environment variables.  You may call `ConsoleEx.ApplySettings()` to reapply configuration, and that method is also called in the static constructor of `ConsoleEx`.

There is an order of precedence to how settings are applied:

1. If environment variables are set, they are used.
2. If no environment variables are set, the JSON file is used.
3. If no environment variables are set and there is no JSON file, default values are used and are saved as a JSON file.

> [!NOTE]
Mixing and matching JSON and Environment variables is currently not supported.  (It *may* work, but I haven't tested it.) It may be in a future release if there's a need for it.  Set everything in one or the other, and any you don't set will fall back to default values.

### Code
`ConsoleEx` exposes three static variables that can be set in your program.

* `DebugColor`: Used automatically whenever you call `WriteDebug` methods, or may be used in your own code.

* `ErrorColor`: Used automatically whenever you call `WriteError` methods, or may be used in your own code.

* `InfoColor`: Used automatically whenever you call `WriteInfo` methods, or may be used in your own code.

### JSON
`ConsoleEx` looks for a JSON file in the same directory called `cc.config.json` and attempts to parse it to set the three variables mentioned above.  The expected format is as follows:

``` json
{
  "colors": {
    "debugColor": "some_ConsoleColor_ToString()",
    "errorColor": "some_ConsoleColor_ToString()",
    "infoColor": "some_ConsoleColor_ToString()"
  }
}
```
If any errors are encountered -- for example, invalid color values or incorrect property values -- the default values of Yellow, Red, and Green are used.

Any values missing from the JSON (not incorrect, just missing) will revert to the default values.

> [!NOTE]
JSON parsing is all or nothing at the moment -- either it succeeds and every value is set, or it fails and every value gets a default value.

### Environment Variables
`ConsoleEx` also looks for three environment variables (called `"CCDEBUGCOLOR"`, `"CCERRORCOLOR"`, and `"CCINFOCOLOR"`) in the environment variables and attempts to use the color values there.  As with JSON, colors need to match a color in the `ConsoleColors` enum provided by Microsoft.

If any errors are encountered while parsing the values, default values for the respective variable is used.

> [!NOTE]
You don't have to remember the environment variable names if you're setting them in code.  The `Settings` class provides readonly constants you can use.

> [!NOTE]
Environment variables are parsed one at a time, unlike JSON.  Therefore, if one of the three values fails or doesn't exist, it will use the defaults, but the others will work fine.

## Contributions
Want to contribute?  Fantastic!  I'd be happy for the help to make this even more useful, provided the following project goals are maintained:

1. Complete `System.Console` wrapper including all overloads to allow `ColorizedConsole.ConsoleEx` to be a drop-in replacement.

2. Multiplatform (as much as the system version is) by not using platform-specific calls such as `DllImport`.

3. Standalone and lightweight by not being dependent on anything other than the base CLR itself.

You're welcome to request access to the project or fork it and create a PR.  Or just contact [Merovech](https://github.com/Merovech). Whatever works for you.

## Changelog
### 1.1.0
Improvements
* Made `ConsoleEx` non-static to support extension methods (all existing methods there are still static, though)
* Configuration overhaul
  * Replaced file-based configuration via INI file with standard JSON parsing
  * Added environment variable support for configuration
  * Exposed `ConsoleEx.ApplySettings()` so developers can reapply settings outside of the constructor.
* Gave `DebugColor`, `InfoColor`, and `ErrorColor` public setters so that developers can change them without needing separate configuration code if they choose
  * These still default to Yellow, Green, and Red respectively
* Additional unit tests created

Bug Fixes
* Fixed a bug where foreground color didn't revert correctly in some cases


### 1.0.0
Initial release

## Current Roadmap (updated monthly - last, February 2025)
:arrow_forward:= In Progress
:white_check_mark:= Complete
:x:= Incomplete
:grey_question:= Idea (needs investigation)

* :arrow_forward: 1.1.0.0 Release
  * :arrow_forward: Implement updated configuration
    * :white_check_mark: JSON config file
    * :white_check_mark: Environment variables
    * :white_check_mark: Unit tests for new config functionality
    * :white_check_mark: Update Readme documentation
    * :x: Update Readme-nuget documentation
    * :white_check_mark: Update XML documentation
    * :x: Push to Nuget.org
* :x: Add a wiki
  * :x: Description of the project
  * :x: Usage examples
  * :x: API documentation
    * :grey_question: Maybe some sort of autodoc
  * :x: Configuration guidelines and examples
* :white_check_mark: Change the NuGet README to a changelog
* :x: Create a GitHub project so that I don't have to keep maintaining this file
* :grey_question: Investigate code generation for v2.0
* :grey_question: Investigate .NET roadmap regarding support for extension methods on static classes