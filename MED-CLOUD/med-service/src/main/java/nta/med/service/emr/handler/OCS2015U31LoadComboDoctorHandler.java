package nta.med.service.emr.handler;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.model.ihis.nuro.NuroOUT1101Q01FwkDoctorInfo;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U31LoadComboDoctorRequest;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U31LoadComboDoctorResponse;
import nta.med.service.ihis.proto.CommonModelProto;

@Service
@Scope("prototype")
public class OCS2015U31LoadComboDoctorHandler extends
		ScreenHandler<EmrServiceProto.OCS2015U31LoadComboDoctorRequest, EmrServiceProto.OCS2015U31LoadComboDoctorResponse> {

	@Resource
	private Bas0270Repository bas0270Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS2015U31LoadComboDoctorResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2015U31LoadComboDoctorRequest request) throws Exception {
		
		EmrServiceProto.OCS2015U31LoadComboDoctorResponse.Builder response = EmrServiceProto.OCS2015U31LoadComboDoctorResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String deptCode = request.getDepartCode();
		
		CommonModelProto.ComboListItemInfo.Builder firstItem = CommonModelProto.ComboListItemInfo.newBuilder();
		firstItem.setCode("ADM");
		
		if(Language.JAPANESE.toString().equalsIgnoreCase(language)){
			firstItem.setCodeName("全体");
		} else if(Language.ENGLISH.toString().equalsIgnoreCase(language)){
			firstItem.setCodeName("All");
		}  else if(Language.VIETNAMESE.toString().equalsIgnoreCase(language)){
			firstItem.setCodeName("Toàn Bộ");
		}
		
		response.addDoctorInfo(firstItem);
		
		List<NuroOUT1101Q01FwkDoctorInfo> doctors = bas0270Repository.getNuroOUT1101Q01FwkDoctorInfo(hospCode, deptCode, "");
		if(CollectionUtils.isEmpty(doctors)){
			return response.build();
		}
		
		for (NuroOUT1101Q01FwkDoctorInfo doctor : doctors) {
			CommonModelProto.ComboListItemInfo item = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(doctor.getSabun()).setCodeName(doctor.getDoctorName()).build();
			response.addDoctorInfo(item);
		}
		
		return response.build();
	}

}
