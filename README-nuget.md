# ColorizedConsole
ColorizedConsole is a simple, lightweight wrapper for `System.Console` that adds basic, configurable coloring functionality to your console apps.

## Features
* Complete wrapper for `System.Console`, so it can be used as a replacement and you can use the same class for all of your console output.

* Multiplatform -- uses no `DllImport` or other external calls.  Basically, it has the same platform limitations as `System.Console`.

* Lightweight -- uses no external libraries or NuGet packages.

Configuration functionality is available via a separate NuGet package: [`ColorizedConsole.Configuration`](https://www.github.com/merovech/ColorizedConsole.Configuration).

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

**WriteInfo**  
By default, this text is <code style="color: Green">green</code>.
```csharp
ColorizedConsole.ConsoleEx.WriteInfo("some_text");
ColorizedConsole.ConsoleEx.WriteInfoLine("some_text");
```

**WriteError**  
By default, this text is <code style="color: Red">red</code>.
```csharp
ColorizedConsole.ConsoleEx.WriteError("some_text");
ColorizedConsole.ConsoleEx.WriteErrorLine("some_text");
```

In addition, every overload for `Console.Write` and `Console.WriteLine` has a version that supports color.  For example:

```csharp
ColorizedConsole.ConsoleEx.WriteLine(ConsoleColor.Purple, 6);
```

## Contributions
Want to contribute?  Fantastic!  I'd be happy for the help to make this even more useful, provided the following project goals are maintained:

1. Complete `System.Console` wrapper including all overloads to allow `ColorizedConsole.ConsoleEx` to be a drop-in replacement.

2. Multiplatform (as much as the system version is) by not using platform-specific calls such as `DllImport`.

3. Standalone and lightweight by not being dependent on anything other than the base CLR itself.

You're welcome to request access to the project or fork it and create a PR.  Or just contact [Merovech](https://github.com/Merovech). Whatever works for you.

## Changelog
### 1.1.0
Changes necessary to move configuration to the [`ColorizedConsole.Configuration`](https://www.github.com/merovech/ColorizedConsole.Configuration) package.  Please see that package to learn more about configuring `ColorizedConsole`.

* Made `ConsoleEx` non-static to support extension methods (all existing methods there are still static, though)
* Removed all file-based configuration functionality
* Gave `DebugColor`, `InfoColor`, and `ErrorColor` public setters so that developers can change them without needing separate configuration code if they choose
  * These still default to Yellow, Green, and Red respectively


### 1.0.0
Initial release