rem svn checkout https://10.2.1.10/svn/pts/src/user/dainv/assembly assembly
xcopy /f /y assembly med-ext\assembly\
mvn clean install -Pbinzip -f pom.xml -DinitialMemorySize=512m -DmaxMemorySize=6144m -DxxNewSize=64m -DxxMaxNewSize=512m -DrunAsUser=med -DtemplatePath=../assembly -DconfigurationSourceDirectory=src/main/conf -DskipDefaultProfile=true -Dmaven.test.skip=true
