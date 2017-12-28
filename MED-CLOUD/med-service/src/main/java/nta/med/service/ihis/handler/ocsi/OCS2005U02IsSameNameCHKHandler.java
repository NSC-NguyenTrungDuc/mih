package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02IsSameNameCHKRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02IsSameNameCHKResponse;

@Service
@Scope("prototype")
public class OCS2005U02IsSameNameCHKHandler extends
		ScreenHandler<OcsiServiceProto.OCS2005U02IsSameNameCHKRequest, OcsiServiceProto.OCS2005U02IsSameNameCHKResponse> {
	@Resource
	private Out0101Repository out0101Repository;
	
	@Override
	public OCS2005U02IsSameNameCHKResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U02IsSameNameCHKRequest request) throws Exception {
		
		OcsiServiceProto.OCS2005U02IsSameNameCHKResponse.Builder response = OcsiServiceProto.OCS2005U02IsSameNameCHKResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		String result = out0101Repository.OCS2005U02IsSameNameCHK(hospCode, request.getBunho());
		
		if(result!=""){
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
			info.setDataValue(result);
			response.setIssameItem(info);
		}
		
		return response.build();
	}

	
}
