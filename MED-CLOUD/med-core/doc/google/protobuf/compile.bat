set home=..\..\..\..\
set common_path=%home%\med-core\doc\google\protobuf\common
set google_path=..\..\
set ihis_service_path=%home%\med-proto\src\main\java\nta\med\service\ihis\proto\
set orca_service_path=%home%\med-proto\src\main\java\nta\med\service\orca\proto\
set emr_service_path=%home%\med-proto\src\main\java\nta\med\service\emr\proto\
set ext_support_path=%home%\med-ext\med-ext-support\src\main\java\nta\med\ext\support\proto\
set kcck_api_path=%home%\med-api\src\main\java\nta\med\kcck\api\rpc\proto\
set java_service_out=%home%\med-proto\src\main\java
set java_core_out=%home%\med-core\src\main\java
set java_ext_out=%home%\med-ext\med-ext-support\src\main\java
set java_api_out=%home%\med-api\src\main\java

xcopy /f /y %kcck_api_path%\*.proto %ext_support_path%
powershell -Command "(gc %ext_support_path%\booking_model.proto) -replace 'nta.med.kcck.api.rpc.proto', 'nta.med.ext.support.proto' | Out-File -encoding ASCII %ext_support_path%\booking_model.proto"
powershell -Command "(gc %ext_support_path%\booking_service.proto) -replace 'nta.med.kcck.api.rpc.proto', 'nta.med.ext.support.proto' | Out-File -encoding ASCII %ext_support_path%\booking_service.proto"
powershell -Command "(gc %ext_support_path%\hospital_model.proto) -replace 'nta.med.kcck.api.rpc.proto', 'nta.med.ext.support.proto' | Out-File -encoding ASCII %ext_support_path%\hospital_model.proto"
powershell -Command "(gc %ext_support_path%\hospital_service.proto) -replace 'nta.med.kcck.api.rpc.proto', 'nta.med.ext.support.proto' | Out-File -encoding ASCII %ext_support_path%\hospital_service.proto"
powershell -Command "(gc %ext_support_path%\patient_model.proto) -replace 'nta.med.kcck.api.rpc.proto', 'nta.med.ext.support.proto' | Out-File -encoding ASCII %ext_support_path%\patient_model.proto"
powershell -Command "(gc %ext_support_path%\patient_service.proto) -replace 'nta.med.kcck.api.rpc.proto', 'nta.med.ext.support.proto' | Out-File -encoding ASCII %ext_support_path%\patient_service.proto"
powershell -Command "(gc %ext_support_path%\system_model.proto) -replace 'nta.med.kcck.api.rpc.proto', 'nta.med.ext.support.proto' | Out-File -encoding ASCII %ext_support_path%\system_model.proto"
powershell -Command "(gc %ext_support_path%\system_service.proto) -replace 'nta.med.kcck.api.rpc.proto', 'nta.med.ext.support.proto' | Out-File -encoding ASCII %ext_support_path%\system_service.proto"
powershell -Command "(gc %ext_support_path%\order_model.proto) -replace 'nta.med.kcck.api.rpc.proto', 'nta.med.ext.support.proto' | Out-File -encoding ASCII %ext_support_path%\order_model.proto"
powershell -Command "(gc %ext_support_path%\order_service.proto) -replace 'nta.med.kcck.api.rpc.proto', 'nta.med.ext.support.proto' | Out-File -encoding ASCII %ext_support_path%\order_service.proto"
rem protoc.exe  --proto_path=%common_path%  --proto_path=%google_path%  --java_out=%java_core_out%   %common_path%\rpc.proto
rem protoc.exe  --proto_path=%common_path%  --proto_path=%google_path%  --java_out=%java_core_out%   %common_path%\heartbeat.proto

protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\common_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\nuro_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\nuro_service.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\ocso_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\ocso_service.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\system_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\system_service.proto
protoc.exe --proto_path=%orca_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %orca_service_path%\shunou_model.proto
protoc.exe --proto_path=%orca_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %orca_service_path%\shunou_service.proto

protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\nuri_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\nuri_service.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\injs_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\injs_service.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\schs_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\schs_service.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\ocsa_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\ocsa_service.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\drgs_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\drgs_service.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\drug_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\drug_service.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\cpls_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\cpls_service.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\xrts_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\xrts_service.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\bass_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\bass_service.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\chts_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\chts_service.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\emr_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\emr_service.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\pfes_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\pfes_service.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\adma_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\adma_service.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\nuts_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\nuts_service.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\phys_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\phys_service.proto

protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\endo_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\endo_service.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\clis_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\clis_service.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\orca_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\orca_service.proto

protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\emrapi_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\emrapi_service.proto

protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\bill_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\bill_service.proto

protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\invs_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\invs_service.proto

protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\inps_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\inps_service.proto

protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\ocsi_model.proto
protoc.exe --proto_path=%ihis_service_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_service_out%   %ihis_service_path%\ocsi_service.proto


protoc.exe --proto_path=%ext_support_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_ext_out%   %ext_support_path%\system_model.proto
protoc.exe --proto_path=%ext_support_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_ext_out%   %ext_support_path%\system_service.proto
protoc.exe --proto_path=%ext_support_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_ext_out%   %ext_support_path%\patient_model.proto
protoc.exe --proto_path=%ext_support_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_ext_out%   %ext_support_path%\patient_service.proto
protoc.exe --proto_path=%ext_support_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_ext_out%   %ext_support_path%\hospital_model.proto
protoc.exe --proto_path=%ext_support_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_ext_out%   %ext_support_path%\hospital_service.proto
protoc.exe --proto_path=%ext_support_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_ext_out%   %ext_support_path%\booking_model.proto
protoc.exe --proto_path=%ext_support_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_ext_out%   %ext_support_path%\booking_service.proto
protoc.exe --proto_path=%ext_support_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_ext_out%   %ext_support_path%\order_model.proto
protoc.exe --proto_path=%ext_support_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_ext_out%   %ext_support_path%\order_service.proto

protoc.exe --proto_path=%kcck_api_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_api_out%   %kcck_api_path%\system_model.proto
protoc.exe --proto_path=%kcck_api_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_api_out%   %kcck_api_path%\system_service.proto
protoc.exe --proto_path=%kcck_api_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_api_out%   %kcck_api_path%\patient_model.proto
protoc.exe --proto_path=%kcck_api_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_api_out%   %kcck_api_path%\patient_service.proto
protoc.exe --proto_path=%kcck_api_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_api_out%   %kcck_api_path%\hospital_model.proto
protoc.exe --proto_path=%kcck_api_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_api_out%   %kcck_api_path%\hospital_service.proto
protoc.exe --proto_path=%kcck_api_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_api_out%   %kcck_api_path%\booking_model.proto
protoc.exe --proto_path=%kcck_api_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_api_out%   %kcck_api_path%\booking_service.proto
protoc.exe --proto_path=%kcck_api_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_api_out%   %kcck_api_path%\order_model.proto
protoc.exe --proto_path=%kcck_api_path%  --proto_path=%common_path% --proto_path=%google_path% --java_out=%java_api_out%   %kcck_api_path%\order_service.proto
@pause