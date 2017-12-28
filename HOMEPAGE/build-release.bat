rem svn checkout https://10.2.1.10/svn/pts/src/user/dainv/assembly assembly
if "%1" == "" (
	echo 'Usage: build-release.bat releaseVerion'		
	goto :eof			
) 
call svn update
set releaseVersion=%~1
set username=%~2
set password=%~3
for /f "delims=" %%i in ('svn info ^|find "Repository Root" ') do set repoRoot=%%i
for /f "delims=" %%i in ('svn info ^|find "Revision" ') do set revision=%%i
for /f "delims=" %%i in ('svn info ^|find "Relative URL" ') do set relativeUrl=%%i
SET repoRoot=%repoRoot:Repository Root: =%
SET revision=%revision:Revision: =%
SET relativeUrl=%relativeUrl:Relative URL: =%
SET url=%repoRoot%%relativeUrl%
set tagUrl=%repoRoot%/src/03.tags/homepage/%releaseVersion%
echo 'revision = %revision%'			
echo 'sourceURL = %url%'			
echo 'tagURL = %tagUrl%'
set home=.\
call svn copy -r %revision% -m "Tagging %releaseVersion% from %relativeUrl%, revision %revision%" %url% %tagUrl%
call mvn versions:set -DnewVersion=%~1
call mvn versions:commit
call mvn clean install -Pbinzip -f pom.xml -DinitialMemorySize=512m -DmaxMemorySize=6144m -DxxNewSize=64m -DxxMaxNewSize=512m -DrunAsUser=med -DtemplatePath=../assembly -DconfigurationSourceDirectory=src/main/conf -DskipDefaultProfile=true -Dmaven.test.skip=true
call mvn versions:set -DnewVersion=1.0.0-SNAPSHOT
call mvn versions:commit