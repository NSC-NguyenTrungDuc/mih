package nta.med.service.emr.handler;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.emr.EmrTemplateRepository;
import nta.med.data.model.ihis.emr.DepartAndDoctorInfo;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U31LoadGridDepartAndDoctorRequest;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U31LoadGridDepartAndDoctorResponse;
import nta.med.service.ihis.proto.CommonModelProto;

@Service
@Scope("prototype")
public class OCS2015U31LoadGridDepartAndDoctorHandler extends
		ScreenHandler<EmrServiceProto.OCS2015U31LoadGridDepartAndDoctorRequest, EmrServiceProto.OCS2015U31LoadGridDepartAndDoctorResponse> {

	@Resource
	private EmrTemplateRepository emrTemplateRepository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS2015U31LoadGridDepartAndDoctorResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, OCS2015U31LoadGridDepartAndDoctorRequest request) throws Exception {
		
		EmrServiceProto.OCS2015U31LoadGridDepartAndDoctorResponse.Builder response = EmrServiceProto.OCS2015U31LoadGridDepartAndDoctorResponse.newBuilder();
		List<DepartAndDoctorInfo> listData = emrTemplateRepository.getDepartAndDoctorInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "1");
		if(CollectionUtils.isEmpty(listData)){
			return response.build();
		}
		
		for (DepartAndDoctorInfo info : listData) {
			EmrModelProto.OCS2015U31LoadGridDepartAndDoctorInfo.Builder ddInfo = EmrModelProto.OCS2015U31LoadGridDepartAndDoctorInfo.newBuilder();
			CommonModelProto.ComboListItemInfo dept = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(info.getDeptCode())
					.setCodeName(info.getDeptName())
					.build();
			ddInfo.setDepartInfo(dept);
			
			CommonModelProto.ComboListItemInfo doctor = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(info.getDoctorCode())
					.setCodeName(info.getDoctorName())
					.build();
			
			ddInfo.setDoctorInfo(doctor);
			response.addDepartAndDoctor(ddInfo);
		}
		
		return response.build();
	}
	
	
}
