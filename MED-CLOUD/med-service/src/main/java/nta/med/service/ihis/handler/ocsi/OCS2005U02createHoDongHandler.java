package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.beans.BeanUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02createHoDongRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02createHoDongResponse;

@Service
@Scope("prototype")
public class OCS2005U02createHoDongHandler extends ScreenHandler<OcsiServiceProto.OCS2005U02createHoDongRequest, OcsiServiceProto.OCS2005U02createHoDongResponse>{
	@Resource
	private Ocs2005Repository ocs2005Repository;

	@Override
	@Transactional(readOnly=true)
	public OCS2005U02createHoDongResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U02createHoDongRequest request) throws Exception{
		OcsiServiceProto.OCS2005U02createHoDongResponse.Builder response = OcsiServiceProto.OCS2005U02createHoDongResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<ComboListItemInfo> result = ocs2005Repository.getOCS2005U02createHoDong(hospCode, language);
		
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
