package nta.med.kcck.api.adapter.impl;

import java.util.ArrayList;
import java.util.List;

import nta.med.kcck.api.rpc.proto.PatientModelProto;
import org.springframework.stereotype.Component;
import org.springframework.util.CollectionUtils;

import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.adapter.AbstractAdapter;
import nta.med.core.utils.BeanUtils;
import nta.med.kcck.api.adapter.SystemAdapter;
import nta.med.kcck.api.rpc.RpcApiSession;
import nta.med.kcck.api.rpc.proto.HospitalModelProto;
import nta.med.kcck.api.rpc.proto.HospitalServiceProto;
import nta.med.kcck.api.rpc.proto.PatientServiceProto;
import nta.med.kcck.api.rpc.proto.PatientServiceProto.VerifyPatientAccountRequest;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.KcckVefiryAccountRequest;

/**
 * @author dainguyen.
 */
@Component("systemAdapter")
public class SystemAdapterImpl extends AbstractAdapter implements SystemAdapter {

    public SystemAdapterImpl() {
        super(SystemServiceProto.class, SystemServiceProto.getDescriptor());
    }

    @Override
    public nta.med.kcck.api.rpc.proto.SystemServiceProto.LoginResponse authenticate(RpcApiSession session, nta.med.kcck.api.rpc.proto.SystemServiceProto.LoginRequest request) {
        final SystemServiceProto.AdmLoginFormCheckLoginUserRequest.Builder builder = SystemServiceProto.AdmLoginFormCheckLoginUserRequest.newBuilder()
                .setUser(request.getLoginId()).setPassword(request.getPassword()).setHospCode(request.getHospCode());
        SystemServiceProto.AdmLoginFormCheckLoginUserRequest req = builder.build();
        final SystemServiceProto.AdmLoginFormCheckLoginUserResponse response = submit(null, req, 10000L);

        nta.med.kcck.api.rpc.proto.SystemServiceProto.LoginResponse.Builder r = nta.med.kcck.api.rpc.proto.SystemServiceProto.LoginResponse.newBuilder();
        r.setResult(response != null && response.getUserInfoItemCount() > 0 ? nta.med.kcck.api.rpc.proto.SystemServiceProto.LoginResponse.Result.SUCCESS : nta.med.kcck.api.rpc.proto.SystemServiceProto.LoginResponse.Result.RESTRICTED)
        .setToken(response.getSessionId());
		if(r.getResult() == nta.med.kcck.api.rpc.proto.SystemServiceProto.LoginResponse.Result.SUCCESS && response.getUserInfoItemCount() > 0) {
			SystemModelProto.AdmLoginFormCheckLoginUserInfo item = response.getUserInfoItem(0);
			session.login(request.getLoginId(), request.getHospCode(), item.getLanguage(), item.getUserGroup(), item.getClisSmoId(), request.getCapabilityList());
		}
        return r.build();
    }

	@Override
	public nta.med.kcck.api.rpc.proto.SystemServiceProto.GetIntegratedSystemResponse getIntegratedEnvironments(RpcApiSession session, nta.med.kcck.api.rpc.proto.SystemServiceProto.GetIntegratedSystemRequest request) {
		final SystemServiceProto.GetIntegratedSystemRequest.Builder builder = SystemServiceProto.GetIntegratedSystemRequest.newBuilder();
		builder.setHospCode(request.getHospCode());
		builder.setCodeType(request.getCodeType());
		builder.addAllCodeName(request.getCodeNameList());
		
		if(nta.med.kcck.api.rpc.proto.SystemServiceProto.GetIntegratedSystemRequest.System.ORCA_VALUE == request.getSystem().getNumber()){
			builder.setSystem(SystemServiceProto.GetIntegratedSystemRequest.System.ORCA);
		} else if(nta.med.kcck.api.rpc.proto.SystemServiceProto.GetIntegratedSystemRequest.System.MISA_VALUE == request.getSystem().getNumber()){
			builder.setSystem(SystemServiceProto.GetIntegratedSystemRequest.System.MISA);
		} else{
			builder.setSystem(SystemServiceProto.GetIntegratedSystemRequest.System.OTHER);
		}
		
		SystemServiceProto.GetIntegratedSystemRequest req = builder.build();
		final SystemServiceProto.GetIntegratedSystemResponse response = submit(session, req, 10000L);
		
		nta.med.kcck.api.rpc.proto.SystemServiceProto.GetIntegratedSystemResponse.Builder rp = nta.med.kcck.api.rpc.proto.SystemServiceProto.GetIntegratedSystemResponse.newBuilder();
		List<SystemModelProto.IntegratedEnvironment> sysList = response.getSystemList();
		if(response != null && !CollectionUtils.isEmpty(sysList)){
			for (SystemModelProto.IntegratedEnvironment info : sysList) {
				nta.med.kcck.api.rpc.proto.SystemModelProto.IntegratedEnvironment.Builder item = nta.med.kcck.api.rpc.proto.SystemModelProto.IntegratedEnvironment.newBuilder();
				item.setHospCode(info.getHospCode());
				
				List<nta.med.service.ihis.proto.SystemModelProto.IntegratedInfo> integratedInfos = info.getIntegratedInfoList();
				for (nta.med.service.ihis.proto.SystemModelProto.IntegratedInfo integratedInfo : integratedInfos) {
					nta.med.kcck.api.rpc.proto.SystemModelProto.IntegratedInfo.Builder integratedItem = nta.med.kcck.api.rpc.proto.SystemModelProto.IntegratedInfo.newBuilder();
					BeanUtils.copyProperties(integratedInfo, integratedItem, Language.JAPANESE.toString());
					item.addIntegratedInfo(integratedItem);
				}
				
				rp.addSystem(item);
			}
		}
		
		return rp.build();
	}

	@Override
	public nta.med.kcck.api.rpc.proto.PatientServiceProto.VerifyPatientAccountResponse verifyPatientAccount(RpcApiSession session,VerifyPatientAccountRequest request) {
		final SystemServiceProto.VerifyPatientAccountRequest.Builder builder = SystemServiceProto.VerifyPatientAccountRequest.newBuilder();
		builder.setHospCode(request.getHospCode());
		builder.setUsername(request.getUsername());
		builder.setPassword(request.getPassword());
		
		SystemServiceProto.VerifyPatientAccountRequest req = builder.build();
		final SystemServiceProto.VerifyPatientAccountResponse response = submit(session, req, 10000L);
		
		nta.med.kcck.api.rpc.proto.PatientServiceProto.VerifyPatientAccountResponse.Builder rp = nta.med.kcck.api.rpc.proto.PatientServiceProto.VerifyPatientAccountResponse.newBuilder();
		if(response != null){
			BeanUtils.copyProperties(response, rp, Language.JAPANESE.toString());
		}
		
		return rp.build();
	}

	@Override
	public HospitalServiceProto.SearchHospitalResponse searchHospitals(RpcApiSession session, HospitalServiceProto.SearchHospitalRequest request) {
		SystemServiceProto.GetHospitalListRequest req = SystemServiceProto.GetHospitalListRequest.newBuilder()
				.setHospName(request.getHospName())
				.setAddress(request.getAddress())
				.setTel(request.getTel())
				.setCountryCode(request.getCountryCode())
				.build();
		
		SystemServiceProto.GetHospitalListResponse response = submit(session, req, 10000L);
		HospitalServiceProto.SearchHospitalResponse.Builder rp = HospitalServiceProto.SearchHospitalResponse.newBuilder();
		if(response != null){
			List<SystemModelProto.HospitalDetailInfo> hospListInfo = response.getItemInfoList();
			if(!CollectionUtils.isEmpty(hospListInfo)){
				List<HospitalModelProto.HospitalDetailInfo> hospList = new ArrayList<>();
				for (SystemModelProto.HospitalDetailInfo info : hospListInfo) {
					HospitalModelProto.HospitalDetailInfo.Builder item = HospitalModelProto.HospitalDetailInfo.newBuilder();
					BeanUtils.copyProperties(info, item, Language.JAPANESE.toString());
					hospList.add(item.build());
				}
				
				rp.addAllItemInfo(hospList);
			}
		}
		
		return rp.build();
	}

	@Override
	public HospitalServiceProto.SearchHospitalInfoByHospCodeResponse searchHospitalByHospCode(RpcApiSession session,
			HospitalServiceProto.SearchHospitalInfoByHospCodeRequest request) {
		SystemServiceProto.GetHospitalInfoByHospCodeRequest req = SystemServiceProto.GetHospitalInfoByHospCodeRequest.newBuilder()
				.setHospCode(request.getHospCode())
				.build();
		SystemServiceProto.GetHospitalInfoByHospCodeResponse response = submit(session, req, 10000L);
		HospitalServiceProto.SearchHospitalInfoByHospCodeResponse.Builder rp = HospitalServiceProto.SearchHospitalInfoByHospCodeResponse.newBuilder();
		if(response != null){
			SystemModelProto.HospitalInfomation hospInfo = response.getHospInfo();
			HospitalModelProto.HospitalInfomation.Builder item = HospitalModelProto.HospitalInfomation.newBuilder();
			if(hospInfo != null){
				BeanUtils.copyProperties(hospInfo, item, Language.JAPANESE.toString());
			}
			rp.setHospInfo(item.build());
		}
		return rp.build();
	}

	@Override
	public PatientServiceProto.GetPatientResponse getPatient(RpcApiSession session, PatientServiceProto.GetPatientRequest request)
	{
		PatientServiceProto.GetPatientResponse.Builder patientResponse = PatientServiceProto.GetPatientResponse.newBuilder();

		SystemServiceProto.GetPatientByCodeRequest.Builder builder = SystemServiceProto.
				GetPatientByCodeRequest.newBuilder().setHospCode(request.getHospCode()).setPatientCode(request.getPatientCode());

		final SystemServiceProto.GetPatientByCodeResponse response = submit(session, builder.build(), 10000L);
		if (response != null && !org.apache.commons.collections.CollectionUtils.isEmpty(response.getPatientInfoList())) {
			SystemModelProto.PatientInfo patientInfo = response.getPatientInfoList().get(0);
			patientResponse.setPatientCode(request.getPatientCode());
			patientResponse.setPatientNameKana(patientInfo.getPatientName2());
			patientResponse.setPatientNameKanji(patientInfo.getPatientName1());
			patientResponse.setPatientTel(patientInfo.getTel());
			patientResponse.setPatientEmail(patientInfo.getEmail());
			patientResponse.setPatientSex(patientInfo.getSex());
			patientResponse.setPatientBirthday(patientInfo.getBirth());
			patientResponse.setPatientPwd(patientInfo.getPwd());

		}
		return patientResponse.build();
	}
	@Override
	public PatientServiceProto.GetWaitingPatientResponse getWaitingPatient(RpcApiSession session, PatientServiceProto.GetWaitingPatientRequest request)
	{
		PatientServiceProto.GetWaitingPatientResponse.Builder waitingPatientResponse = PatientServiceProto.GetWaitingPatientResponse.newBuilder();

		SystemServiceProto.GetWaitingPatientRequest.Builder waitingPatientRequest = SystemServiceProto.
				GetWaitingPatientRequest.newBuilder().setHospCode(request.getHospCode()).addAllPatientCode(request.getPatientCodeList()).
				setDoctorCode(request.getDoctorCode()).setExaminationDate(request.getExaminationDate()).
				setDepartmentCode(request.getDepartmentCode()).setLocale(request.getLocale()).setExaminationSituation(request.getExaminationSituation());

		final SystemServiceProto.GetWaitingPatientResponse response = submit(session, waitingPatientRequest.build(), 10000L);
		if (response != null) {
			for(SystemModelProto.WaitingPatientInfo waitingPatientInfo : response.getWaitingPatientsList())
			{
				PatientModelProto.WaitingPatientInfo.Builder item =  PatientModelProto.WaitingPatientInfo.newBuilder();
				BeanUtils.copyProperties(waitingPatientInfo, item, Language.JAPANESE.toString());
				waitingPatientResponse.addWaitingPatients(item.build());
			}
		}
		return waitingPatientResponse.build();
	}
	@Override
	public HospitalServiceProto.VefiryAccountResponse vefiryAccount(RpcApiSession session, HospitalServiceProto.VefiryAccountRequest request) {
		HospitalServiceProto.VefiryAccountResponse.Builder accountResponse = HospitalServiceProto.VefiryAccountResponse.newBuilder();

		SystemServiceProto.KcckVefiryAccountRequest.Builder builder = 
				KcckVefiryAccountRequest.newBuilder()
				.setHospCode(request.getHospCode())
				.setLoginId(request.getLoginId())
				.setPassword(request.getPassword());
		
		if(HospitalServiceProto.VefiryAccountRequest.AccountType.MBS == request.getAccountType()){
			builder.setAccountType(SystemServiceProto.KcckVefiryAccountRequest.AccountType.MBS);
		} else if(HospitalServiceProto.VefiryAccountRequest.AccountType.MIS == request.getAccountType()){
			builder.setAccountType(SystemServiceProto.KcckVefiryAccountRequest.AccountType.MIS);
		} else if(HospitalServiceProto.VefiryAccountRequest.AccountType.MED_GATEWAY == request.getAccountType()){
			builder.setAccountType(SystemServiceProto.KcckVefiryAccountRequest.AccountType.MED_GATEWAY);
		}
		
		SystemServiceProto.KcckVefiryAccountResponse response = submit(session, builder.build(), 10000L);
		if (response != null && response.getResult() && response.getSysAccountInfo() != null) {
			HospitalModelProto.AccountInfo.Builder account = HospitalModelProto.AccountInfo.newBuilder();
			SystemModelProto.SysAccountInfo accountInfo = response.getSysAccountInfo();
			BeanUtils.copyProperties(accountInfo, account, Language.JAPANESE.toString());
			accountResponse.setAccountInfo(account);
			accountResponse.setResult(true);
			return accountResponse.build();
		}
		accountResponse.setResult(false);
		return accountResponse.build();
	}
}
