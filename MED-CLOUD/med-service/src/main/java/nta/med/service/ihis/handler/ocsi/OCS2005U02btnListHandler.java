package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.inp.Inp5001Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02btnListRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02btnListResponse;

@Service
@Scope("prototype")
public class OCS2005U02btnListHandler
		extends ScreenHandler<OcsiServiceProto.OCS2005U02btnListRequest, OcsiServiceProto.OCS2005U02btnListResponse> {
	@Resource
	private Inp5001Repository inp5001Repository;
		
	@Override
	public OCS2005U02btnListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U02btnListRequest request) throws Exception {
		
		OcsiServiceProto.OCS2005U02btnListResponse.Builder response = OcsiServiceProto.OCS2005U02btnListResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		String result = inp5001Repository.getNutIsSiksaMagamYn(hospCode);
		CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
		info.setDataValue(result);
		response.setBtnItem(info);
		
		return response.build();
	}

	
}
