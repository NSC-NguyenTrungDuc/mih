@echo off
REM
REM Contents batch build
REM   Parameter 1 : build PRE or POST event
REM   Parameter 2 : $(SolutionDir)          // solution directory
REM   Parameter 3 : $(TargetDir)            // project output directory
REM   Parameter 4 : $(SolutionName)         // solution name = system name
REM   Parameter 5 : $(TargetName)           // project name = dll name
REM
REM PRE  event : $(SolutionDir)..\IHISContentsBuild.bat PRE  $(SolutionDir)..\ $(TargetDir) $(SolutionName) $(TargetFileName)
REM POST event : $(SolutionDir)..\IHISContentsBuild.bat POST $(SolutionDir)..\ $(TargetDir) $(SolutionName) $(TargetFileName)
REM
REM
set IHIS_HOME=C:\IHIS
set IHIS_OUT_DIR=IHIS_LIB
REM
set LAN_IDS=ja-JP,en,vi-VN
REM
set PRE_OR_POST=%1%
set SOLUTION_DIR=%2%
set TARGET_DIR=%3%
set SOLUTION_NAME=%4%
set TARGET_NAME=%5%
REM
set RESOURCE_NAME=%~n5.resources.dll
REM
REM Main
REM 
if "%PRE_OR_POST%" == "PRE" (
  call :PRE_RTN %SOLUTION_DIR% %TARGET_DIR% %SOLUTION_NAME% %TARGET_NAME%
) else (
  call :POST_RTN %SOLUTION_DIR% %TARGET_DIR% %SOLUTION_NAME% %TARGET_NAME%
)
goto :eof
REM
REM Functions
REM
REM
REM Function PRE_RTN
REM
:PRE_RTN
set SOL_DIR=%1%
set PGM_DIR=%2%
set SYS_ID=%3%
set PGM_ID=%4%
REM sub directory & quite delete
if exist "%SOL_DIR%..\%IHIS_OUT_DIR%\%SYS_ID%\%PGM_ID%" del /S /Q "%SOL_DIR%..\%IHIS_OUT_DIR%\%SYS_ID%\%PGM_ID%"
if exist "%IHIS_HOME%\%SYS_ID%\%PGM_ID%" del /S /Q "%IHIS_HOME%\%SYS_ID%\%PGM_ID%"
REM
goto :eof
REM
REM Function POST_RTN
REM
:POST_RTN
set SOL_DIR=%1%
set PGM_DIR=%2%
set SYS_ID=%3%
set PGM_ID=%4%
REM
MKDIR "%SOL_DIR%..\%IHIS_OUT_DIR%\%SYS_ID%" 2> nul
copy "%PGM_DIR%%PGM_ID%" "%SOL_DIR%..\%IHIS_OUT_DIR%\%SYS_ID%\."
copy "%PGM_DIR%*.dll"    "%SOL_DIR%..\%IHIS_OUT_DIR%\%SYS_ID%\."
REM
for %%L in (%LAN_IDS%) do ( 
	MKDIR "%SOL_DIR%..\%IHIS_OUT_DIR%\%SYS_ID%\%%L" 2> nul
	if exist "%PGM_DIR%%%L\%RESOURCE_NAME%" copy "%PGM_DIR%%%L\%RESOURCE_NAME%" "%SOL_DIR%..\%IHIS_OUT_DIR%\%SYS_ID%\%%L\."
)
REM
MKDIR %IHIS_HOME%\%SYS_ID% 2> nul
copy "%PGM_DIR%%PGM_ID%" "%IHIS_HOME%\%SYS_ID%\."
copy "%PGM_DIR%*.dll"    "%IHIS_HOME%\%SYS_ID%\."
for %%L in (%LAN_IDS%) do ( 
	MKDIR "%IHIS_HOME%\%SYS_ID%\%%L" 2> nul
	if exist "%PGM_DIR%%%L\%RESOURCE_NAME%" copy "%PGM_DIR%%%L\%RESOURCE_NAME%" "%IHIS_HOME%\%SYS_ID%\%%L\."
)
REM
goto :eof