@echo off
REM
REM Common exe batch build
REM   Parameter 1 : build PRE or POST event
REM   Parameter 2 : $(SolutionDir)          // framework directory
REM   Parameter 3 : $(TargetDir)            // project output directory
REM   Parameter 4 : $(SolutionName)         // not use
REM   Parameter 5 : $(TargetName)           // project name = exe name
REM
REM PRE  event : $(SolutionDir)IHISCommonBuild.bat PRE  $(SolutionDir) $(TargetDir) $(SolutionName) $(TargetFileName)
REM POST event : $(SolutionDir)IHISCommonBuild.bat POST $(SolutionDir) $(TargetDir) $(SolutionName) $(TargetFileName)
REM
set IHIS_HOME=C:\IHIS
set IHIS_OUT_DIR=IHIS_LIB
REM
set LAN_IDS=ja-JP,en,vi-VN
REM
set SYS_IDS=ADMA,ADMS,BASS,CHTS,CLIS,CPLS,DOCS,DRGS,ENDO,INJS,INSO,INVS,NURI,NURO,NUTS,OCSA,OCSI,OCSO,OPRS,ORCA,OUTS,PFES,PHYS,SCHS,TSTS,XRTS
REM
set PRE_OR_POST=%1%
set SOLUTION_DIR=%2%
set PROJECT_DIR=%3%
set SOLUTION_NAME=%4%
set TARGET_NAME=%5%
REM
set COMMON_PGM_ID=%TARGET_NAME%
set COMMON_PGM_NAME=%~n5
set RESOURCE_EXT_NAME=resources.dll
REM
REM Main
REM 
for %%S in (%SYS_IDS%) do ( 
	if "%PRE_OR_POST%" == "PRE" (
	  call :PRE_RTN %SOLUTION_DIR% %PROJECT_DIR% %%S %%S.exe
	) else (
	  call :POST_RTN %SOLUTION_DIR% %PROJECT_DIR% %%S %%S.exe
	)
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
copy "%PGM_DIR%%COMMON_PGM_ID%" "%SOL_DIR%..\%IHIS_OUT_DIR%\%SYS_ID%\%PGM_ID%"
copy "%PGM_DIR%*.dll"           "%SOL_DIR%..\%IHIS_OUT_DIR%\%SYS_ID%\."
REM
for %%L in (%LAN_IDS%) do ( 
	MKDIR "%SOL_DIR%..\%IHIS_OUT_DIR%\%SYS_ID%\%%L"
	if exist "%PGM_DIR%%%L\%COMMON_PGM_NAME%.%RESOURCE_EXT_NAME%" copy "%PGM_DIR%%%L\%COMMON_PGM_NAME%.%RESOURCE_EXT_NAME%" "%SOL_DIR%..\%IHIS_OUT_DIR%\%SYS_ID%\%%L\%SYS_ID%.%RESOURCE_EXT_NAME%"
)
REM
MKDIR %IHIS_HOME%\%SYS_ID% 2> nul
copy "%PGM_DIR%%COMMON_PGM_ID%" "%IHIS_HOME%\%SYS_ID%\%PGM_ID%"
copy "%PGM_DIR%*.dll"           "%IHIS_HOME%\%SYS_ID%\."
for %%L in (%LAN_IDS%) do ( 
	MKDIR "%IHIS_HOME%\%SYS_ID%\%%L" 2> nul
	if exist "%PGM_DIR%%%L\%COMMON_PGM_NAME%.%RESOURCE_EXT_NAME%" copy "%PGM_DIR%%%L\%COMMON_PGM_NAME%.%RESOURCE_EXT_NAME%" "%IHIS_HOME%\%SYS_ID%\%%L\%SYS_ID%.%RESOURCE_EXT_NAME%"
)
REM
goto :eof
