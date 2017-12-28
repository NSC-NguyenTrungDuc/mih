@echo off
REM
REM Start Exe(cution) batch build
REM   Parameter 1 : build PRE or POST event
REM   Parameter 2 : $(SolutionDir)          // Solution directory
REM   Parameter 3 : $(TargetDir)            // project output directory
REM   Parameter 4 : $(SolutionName)         // not use
REM   Parameter 5 : $(TargetName)           // project name = exe name
REM
REM PRE  event : $(SolutionDir)IHISFrameworkBuild.bat PRE  $(SolutionDir) $(TargetDir) $(SolutionName) $(TargetFileName)
REM POST event : $(SolutionDir)IHISFrameworkBuild.bat POST $(SolutionDir) $(TargetDir) $(SolutionName) $(TargetFileName)
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
REM  call :PRE_RTN %SOLUTION_DIR% %TARGET_DIR% %SOLUTION_NAME% %TARGET_NAME%
  call :PRE_RTN %SOLUTION_DIR% %TARGET_DIR% bin %TARGET_NAME%
) else (
REM  call :POST_RTN %SOLUTION_DIR% %TARGET_DIR% %SOLUTION_NAME% %TARGET_NAME%
  call :POST_RTN %SOLUTION_DIR% %TARGET_DIR% bin %TARGET_NAME%
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
REM if exist "%SOL_DIR%..\%IHIS_OUT_DIR%\%SYS_ID%\%PGM_ID%" del /S /Q "%SOL_DIR%..\%IHIS_OUT_DIR%\%SYS_ID%\%PGM_ID%"
if exist "%SOL_DIR%..\%IHIS_OUT_DIR%\%PGM_ID%" del /S /Q "%SOL_DIR%..\%IHIS_OUT_DIR%\%PGM_ID%"
REM if exist "%IHIS_HOME%\%SYS_ID%\%PGM_ID%" del /S /Q "%IHIS_HOME%\%SYS_ID%\%PGM_ID%"
if exist "%IHIS_HOME%\%PGM_ID%" del /S /Q "%IHIS_HOME%\%PGM_ID%"
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
MKDIR "%SOL_DIR%..\%IHIS_OUT_DIR%" 2> nul
copy "%PGM_DIR%%PGM_ID%" "%SOL_DIR%..\%IHIS_OUT_DIR%\."
copy "%PGM_DIR%*.dll"    "%SOL_DIR%..\%IHIS_OUT_DIR%\."
REM
for %%L in (%LAN_IDS%) do ( 
	MKDIR "%SOL_DIR%..\%IHIS_OUT_DIR%\%%L" 2> nul
	if exist "%PGM_DIR%%%L\%RESOURCE_NAME%" copy "%PGM_DIR%%%L\%RESOURCE_NAME%" "%SOL_DIR%..\%IHIS_OUT_DIR%\%%L\."
)
REM
REM MKDIR "%SOL_DIR%..\%IHIS_OUT_DIR%\%SYS_ID%" 2> nul
REM copy "%PGM_DIR%%PGM_ID%" "%SOL_DIR%..\%IHIS_OUT_DIR%\%SYS_ID%\."
REM copy "%PGM_DIR%*.dll"    "%SOL_DIR%..\%IHIS_OUT_DIR%\%SYS_ID%\."
REM REM
REM for %%L in (%LAN_IDS%) do ( 
REM 	MKDIR "%SOL_DIR%..\%IHIS_OUT_DIR%\%SYS_ID%\%%L" 2> nul
REM 	if exist "%PGM_DIR%%%L\%RESOURCE_NAME%" copy "%PGM_DIR%%%L\%RESOURCE_NAME%" "%SOL_DIR%..\%IHIS_OUT_DIR%\%SYS_ID%\%%L\."
REM )
REM
MKDIR %IHIS_HOME% 2> nul
copy "%PGM_DIR%%PGM_ID%" "%IHIS_HOME%\."
copy "%PGM_DIR%*.dll"    "%IHIS_HOME%\."
for %%L in (%LAN_IDS%) do ( 
	MKDIR "%IHIS_HOME%\%%L" 2> nul
	if exist "%PGM_DIR%%%L\%RESOURCE_NAME%" copy "%PGM_DIR%%%L\%RESOURCE_NAME%" "%IHIS_HOME%\%%L\."
)
REM
REM MKDIR %IHIS_HOME%\%SYS_ID% 2> nul
REM copy "%PGM_DIR%%PGM_ID%" "%IHIS_HOME%\%SYS_ID%\."
REM copy "%PGM_DIR%*.dll"    "%IHIS_HOME%\%SYS_ID%\."
REM for %%L in (%LAN_IDS%) do ( 
REM 	MKDIR "%IHIS_HOME%\%SYS_ID%\%%L" 2> nul
REM 	if exist "%PGM_DIR%%%L\%RESOURCE_NAME%" copy "%PGM_DIR%%%L\%RESOURCE_NAME%" "%IHIS_HOME%\%SYS_ID%\%%L\."
REM )
REM
goto :eof