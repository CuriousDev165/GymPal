# GymPal<br>
*This is a portfolio project intended to demonstrate the repository owner's abilities to prospective employers. Please do not fork or submit pull requests.*<br><br>
## Project Structure<br>
The solution contains three projects: GymPal, GymPal.Core, and GymPal.UnitTests. The GymPal.Core project contains the application logic, while GymPal is the UI project. GymPal.Tests contains unit tests for the GymPal.Core project. The reasoning for this design is to separate the components of the application so that there aren't target framework compatibility issues between the projects and so that the UI and logic components are cleanly separated.<br>

##Known-Safe Waring Suppressions<br>
*NETSDK1206: Found version-specific or distribution-specific runtime identifier(s): alpine-arm, alpine-arm64, alpine-x64. Affected libraries: SQLitePCLRaw.lib.e_sqlite3. In .NET 8.0 and higher, assets for version-specific and distribution-specific runtime identifiers will not be found by default. See https://aka.ms/dotnet/rid-usage for details.*<br>
This warning is a reference to the GymPal.Core package detecting distributin-specific runtime identifiers for Linux. Since this project is not intended to target any version of Linux, this warning can be safely suppressed. The project file includes a suppression for this warning. If Linux support is added in the future, this warning should be removed.
