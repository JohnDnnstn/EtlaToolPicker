::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
:: Pre-Compilation command to generate AssemblyInfo.cs 
:: If possible, this will include version numbering based on git info
:: To use this git information, the following assumptions are made:
:: * The solution is in git
:: * TortoiseGit is installed in the default location - this provides the gitwcrev application to extract info usefully
:: * This command file is in the Properties sub-directory of the project
:: * The project's prebuild property is:
::        $(solutionDir)/Properties/Prebuild.cmd $(SolutionDir)
:: N.B.
:: The .csproj project should contain the line 
::        <GenerateAssemblyInfo>false</GenerateAssemblyInfo>
::

SET thisDir=%~dp0
SET solutionDir=%~1
SET assemblyDefinitions="%thisDir%AssemblyDefinitions.cs"
SET assembly_cs="%thisDir%AssemblyInfo.cs"
SET assembly_gitwcrev="%thisDir%AssemblyInfo.gitwcrev"

IF NOT EXIST %solutionDir%.git GOTO ifAssumptionsWrong1

SET TGitDir=C:\Program Files\TortoiseGit\bin\
SET gitWCRev=%TGitDir%GitWCRev.exe

IF NOT EXIST "%gitWCRev%" GOTO ifAssumptionsWrong2
IF NOT EXIST "%thisDir%AssemblyInfo.gitwcrev" GOTO ifAssumptionsWrong3

SET cmdToRun="%gitWCRev%" "%thisDir%.." %assembly_gitwcrev% %assembly_cs%
ECHO %cmdToRun%
@%cmdToRun%

EXIT /B

:ifAssumptionsWrong1
ECHO Solution Git missing: %solutionDir%\.git
GOTO ifAssumptionsWrong

:ifAssumptionsWrong2
ECHO gitwcrev application missing: "%gitWCRev%"
GOTO ifAssumptionsWrong

:ifAssumptionsWrong3
ECHO the .gitwcrev file missing: %assembly_gitwcrev%
GOTO ifAssumptionsWrong

::Create an empty AssemblyInfo.cs file if we cannot do it properly for some reason
::
:ifAssumptionsWrong

@ECHO Failed to generate AssemblyInfo.cs from AssemblyInfo.gitwcrev
@ECHO Generating property files

@FOR /f %%i IN ('"powershell (Get-Date).ToString(\"yyyy\")"') DO SET year=%%i
@FOR /f %%i IN ('"powershell (New-Guid).ToString()"') DO SET guid=%%i
@FOR /f %%i IN ('powershell Split-Path %solutionDir% -leaf') DO SET myNamespace=%%i

CALL :generateAssemblyDefinitions 
@IF NOT EXIST %assembly_cs%         CALL :generateAssemblyInfo %assembly_cs%
@IF NOT EXIST %assembly_gitwcrev%   CALL :generateAssemblyInfo %assembly_gitwcrev%

EXIT /B

:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
:: subroutines
::

:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
:: Generate either an AssemblyInfo.cs or an AssemblyInfo.wcrev
:: The latter is used to generate an AssemblyInfo.cs if this is under git version control
::
:generateAssemblyInfo
@SETLOCAL
 
@SET outFile=%1
@SET ext=%~x1

@ECHO Generating %outFile%

@ECHO using %myNamespace%.Properties;>%outfile%
@ECHO using System.Reflection;>>%outfile%
@ECHO using System.Runtime.InteropServices;>>%outfile%
@ECHO using System.Runtime.Versioning;>>%outfile%

@ECHO.>>%outfile%
ECHO // General Information about an assembly.>>%outfile%
@ECHO // Change these attribute values to modify the information associated with an assembly.>>%outfile%
@ECHO // Note:>>%outfile%
@ECHO // * AssemblyCompany: Used to define directory for user.config (in VS?) and also define common, localuser and use AppData directory>>%outfile%
@ECHO // * AssemblyProduct: Used to define common, localuser and use AppData directory>>%outfile%
@ECHO //>>%outfile%
@ECHO [assembly: AssemblyTitle("")]>>%outfile%
@ECHO [assembly: AssemblyDescription("")]>>%outfile%
@ECHO [assembly: AssemblyConfiguration("")]>>%outfile%
@ECHO [assembly: AssemblyCompany(AssemblyDefinitions.CompanyFullName)] >>%outfile%
@ECHO [assembly: AssemblyProduct(AssemblyDefinitions.ApplicationName)] >>%outfile%
if [%ext%] == [.cs] @ECHO [assembly: AssemblyCopyright(AssemblyDefinitions.Copyright+"%year%")] >>%outfile%
if NOT [%ext%] == [.cs] @ECHO [assembly: AssemblyCopyright(AssemblyDefinitions.Copyright+"$WCNOW=%%Y$")]>>%outfile%
@ECHO [assembly: AssemblyTrademark("")]>>%outfile%
@ECHO [assembly: AssemblyCulture("")]>>%outfile%

@ECHO.>>%outfile%
@ECHO // Setting ComVisible to false makes the types in this assembly not visible to COM components.>>%outfile%
@ECHO // If you need to access a type in this assembly from COM, set the ComVisible attribute to true on that type.>>%outfile%
@ECHO // >>%outfile%
@ECHO [assembly: ComVisible(false)]>>%outfile%

@ECHO.>>%outfile%
@ECHO // The following GUID is for the ID of the typelib if this project is exposed to COM>>%outfile%
@ECHO //>>%outfile%
@ECHO [assembly: Guid("%guid%")]>>%outfile%

@ECHO.>>%outfile%
@ECHO // Version numbers>>%outfile%
@ECHO // * AssemblyVersion: Used to define directory for user.config and by CLR for any referencing assemblies>>%outfile%
@ECHO // * AssemblyFileVersion: Displayed in windows explorer as File Version - Use the last place to ensure all source is checked in and up-to-date>>%outfile%
@ECHO // * AssemblyInformationalVersion: Displayed in windows explorer as Product Version - Use third place to hold git revision>>%outfile%
@ECHO //>>%outfile%
@ECHO [assembly: AssemblyVersion(AssemblyDefinitions.Version)]>>%outfile%
if [%ext%] == [.cs] @ECHO [assembly: AssemblyFileVersion(AssemblyDefinitions.Version+".0.12")]>>%outfile%
if [%ext%] == [.cs] @ECHO [assembly: AssemblyInformationalVersion(AssemblyDefinitions.Version+".0")]>>%outfile%
if NOT [%ext%] == [.cs] @ECHO [assembly: AssemblyFileVersion(AssemblyDefinitions.Version+".$WCLOGCOUNT$.$WCUNVER?1:0$$WCMODS?2:0$")]>>%outfile%
if NOT [%ext%] == [.cs] @ECHO [assembly: AssemblyInformationalVersion(AssemblyDefinitions.Version+".$WCLOGCOUNT$+$WCREV$")]>>%outfile%

@ECHO.>>%outfile%
@ECHO // Specify we will only run on Windows to save all the warnings>>%outfile%
@ECHO //>>%outfile%
@ECHO [assembly: SupportedOSPlatform("windows6.1")]>>%outfile%

@ENDLOCAL
@EXIT /B

:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
:: Generates an AssemblyDefinitions.cs file which defines attributes such as major version, minor version etc.

:generateAssemblyDefinitions
@SETLOCAL
 
@SET outFile=%assemblyDefinitions%

@ECHO namespace %myNamespace%.Properties;>>%outfile%
@ECHO.>>%outfile%
@ECHO public static class AssemblyDefinitions>>%outfile%
@ECHO {>>%outfile%
@ECHO   public const string MajorVersion = "0";>>%outfile%
@ECHO   public const string MinorVersion = "1";>>%outfile%
@ECHO   public const string Version = MajorVersion + "." + MinorVersion;>>%outfile%
@ECHO.>>%outfile%
@ECHO   public const string ApplicationName = "ETLA Toolbox Picker";>>%outfile%
@ECHO   public const string StartYear = "2019";>>%outfile%
@ECHO   public const string Company = "ETLA Services Ltd";>>%outfile%
@ECHO   public const string CompanyFullName = "ETLA Services Ltd";>>%outfile%
@ECHO   public const string Copyright = Company + " " + StartYear + "-";>>%outfile%
@ECHO }>>%outfile%

@ENDLOCAL
@EXIT /B
