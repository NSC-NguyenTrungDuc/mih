



rem signtool sign /t http://timestamp.digicert.com /f "D:\certificate\SofiaMedix Co.,Ltd.pfx" /p qWe!23qwer!@#$ "$(TargetDir)\$(TargetName).publish\$(TargetName)_1_0_0_615\$(TargetFileName)"
rem copy $(TargetDir) $(SolutionDir)\LIB
rem copy $(TargetPath) C:\IHIS\bin
copy $(TargetPath) C:\IHIS
rem copy $(TargetPath) D:\Source\IHIS\IHIS\IHIS\IHIS\OCSO
copy "$(TargetDir)\vi-VN\$(TargetName).*"  c:\IHIS\vi-VN\.
copy "$(TargetDir)\en\$(TargetName).*"  c:\IHIS\en\.
copy "$(TargetDir)\ja-JP\$(TargetName).*"  c:\IHIS\ja-JP\.

rem copy "$(TargetDir)\vi-VN\$(TargetName).*"   $(SolutionDir)\IHIS\vi-VN\.
rem copy "$(TargetDir)\en\$(TargetName).*" $(SolutionDir)\IHIS\en\.
rem copy "$(TargetDir)\ja-JP\$(TargetName).*"  $(SolutionDir)\IHIS\ja-JP\.
rem signtool sign /t http://timestamp.digicert.com /f "D:\certificate\SofiaMedix Co.,Ltd.pfx" /p qWe!23qwer!@#$ "$(ProjectDir)\obj\$(PlatformName)\$(ConfigurationName)\$(TargetFileName)"
