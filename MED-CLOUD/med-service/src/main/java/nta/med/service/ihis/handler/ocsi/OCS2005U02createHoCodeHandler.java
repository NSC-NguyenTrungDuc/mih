package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.beans.BeanUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02createHoCodeRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02createHoCodeResponse;

@Service
@Scope("prototype")
public class OCS2005U02createHoCodeHandler extends ScreenHandler<OcsiServiceProto.OCS2005U02createHoCodeRequest, OcsiServiceProto.OCS2005U02createHoCodeResponse>{
	@Resource
	private Ocs2005Repository ocs2005Repository;
	
	public OCS2005U02createHoCodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U02createHoCodeRequest request){
		OcsiServiceProto.OCS2005U02createHoCodeResponse.Builder response = OcsiServiceProto.OCS2005U02createHoCodeResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<ComboListItemInfo> result = ocs2005Repository.getOCS2005U02createHoCode(hospCode, language, request.getHoDong(), request.getOrderDate());
		
		if(!CollectionUtils.isEmpty(result)){
			for(ComboListItemInfo item : result){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addCboItem(info);
			}
		}
		
		return response.build();
	}

}
