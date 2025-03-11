# ColorizedConsole
ColorizedConsole is a simple, lightweight wrapper for `System.Console` that adds basic, configurable coloring functionality to your console apps.

## Documentation
Documentation is available at [the github page](https://github.com/Merovech/ColorizedConsole).

## Features
* Complete wrapper for `System.Console`, so it can be used as a replacement and you can use the same class for all of your console output.

* Multiplatform -- uses no `DllImport` or other external calls.  Basically, it has the same platform limitations as `System.Console`.

* Lightweight -- uses no external libraries or NuGet packages.

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