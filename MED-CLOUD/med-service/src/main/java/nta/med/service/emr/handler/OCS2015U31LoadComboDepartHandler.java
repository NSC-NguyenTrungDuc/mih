package nta.med.service.emr.handler;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.bas.Bas0260;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U31LoadComboDepartRequest;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U31LoadComboDepartResponse;
import nta.med.service.ihis.proto.CommonModelProto;

@Service
@Scope("prototype")
public class OCS2015U31LoadComboDepartHandler extends
		ScreenHandler<EmrServiceProto.OCS2015U31LoadComboDepartRequest, EmrServiceProto.OCS2015U31LoadComboDepartResponse> {

	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OCS2015U31LoadComboDepartResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2015U31LoadComboDepartRequest request) throws Exception {
		
		EmrServiceProto.OCS2015U31LoadComboDepartResponse.Builder response = EmrServiceProto.OCS2015U31LoadComboDepartResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		CommonModelProto.ComboListItemInfo firstItem = CommonModelProto.ComboListItemInfo.newBuilder()
				.setCode("ADM")
				.setCodeName("ADM")
				.build(); 
		response.addDepartInfo(firstItem);
		
		List<Bas0260> deptList = bas0260Repository.findByHospCodeBuseoGubun(hospCode, language, "1");
		if(CollectionUtils.isEmpty(deptList)){
			return response.build();
		}
		
		for (Bas0260 dept : deptList) {
			CommonModelProto.ComboListItemInfo item = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(dept.getGwa())
					.setCodeName(dept.getGwaName())
					.build(); 
			response.addDepartInfo(item);
		}
		
		return response.build();
	}

}
