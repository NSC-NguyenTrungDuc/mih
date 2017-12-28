package nta.med.service.ihis.handler.ocsi;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02paBoxPatientSelectedRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02paBoxPatientSelectedResponse;

@Service
@Scope("prototype")
public class OCS2005U02paBoxPatientSelectedHandler extends
		ScreenHandler<OcsiServiceProto.OCS2005U02paBoxPatientSelectedRequest, OcsiServiceProto.OCS2005U02paBoxPatientSelectedResponse> {
    @Resource
    private Inp1001Repository inp1001Repository;
	
	@Override
	public OCS2005U02paBoxPatientSelectedResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U02paBoxPatientSelectedRequest request) throws Exception {

		OcsiServiceProto.OCS2005U02paBoxPatientSelectedResponse.Builder response = OcsiServiceProto.OCS2005U02paBoxPatientSelectedResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		String result = inp1001Repository.OCS2005U02GetToiwonDate(hospCode, CommonUtils.parseDouble(request.getPkinp1001()));
		
		if(!StringUtils.isEmpty(result)){
			CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
			info.setDataValue(result);
			response.setPalboxItem(info);
		}
		
		return response.build();
	}

}
