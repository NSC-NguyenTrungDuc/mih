svn checkout https://10.2.1.10/svn/pts/src/user/dainv/assembly assembly
mvn clean install -Pbinzip -f pom.xml -DinitialMemorySize=512m -DaddressPort=2048 -DmaxMemorySize=2048m -DxxNewSize=64m -DxxMaxNewSize=512m -DrunAsUser=med -DtemplatePath=../assembly -DconfigurationSourceDirectory=src/main/conf -DskipDefaultProfile=true
