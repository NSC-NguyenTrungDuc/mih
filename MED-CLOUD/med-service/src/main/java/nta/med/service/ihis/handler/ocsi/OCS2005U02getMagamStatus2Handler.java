package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02getMagamStatus2Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02getMagamStatus2Response;

@Service
@Scope("prototype")
public class OCS2005U02getMagamStatus2Handler extends
		ScreenHandler<OcsiServiceProto.OCS2005U02getMagamStatus2Request, OcsiServiceProto.OCS2005U02getMagamStatus2Response> {
	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Override
	@Transactional
	public OCS2005U02getMagamStatus2Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U02getMagamStatus2Request request) throws Exception {

		OcsiServiceProto.OCS2005U02getMagamStatus2Response.Builder response = OcsiServiceProto.OCS2005U02getMagamStatus2Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<String> result = ocs0132Repository.getOCS0132CodeNameList(hospCode, language, "NUT_FINAL_MAGAM_ACTION", request.getCode(), false);
		
		if(!CollectionUtils.isEmpty(result)){
			for(String item : result){
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
				info.setDataValue(item);
				response.setLayItem(info);
			}
		}
		
		return response.build();
	}

}
