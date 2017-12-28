package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.nur.Nur0111Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02AutoMaSetComboRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02AutoMaSetComboResponse;

@Service
@Scope("prototype")
public class OCS2005U02AutoMaSetComboHandler extends ScreenHandler<OcsiServiceProto.OCS2005U02AutoMaSetComboRequest
					, OcsiServiceProto.OCS2005U02AutoMaSetComboResponse>{
	@Resource
	private Nur0111Repository nur0111Repository;
	
	@Override
	@Transactional(readOnly=true)
	
	public OCS2005U02AutoMaSetComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U02AutoMaSetComboRequest request) throws Exception{
		OcsiServiceProto.OCS2005U02AutoMaSetComboResponse.Builder response = OcsiServiceProto.OCS2005U02AutoMaSetComboResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		List<ComboListItemInfo> result = nur0111Repository.getOCS2005U02AutoMaSetCombo(hospCode, request.getSikGubun());
		
		if(!CollectionUtils.isEmpty(result)){
			for(ComboListItemInfo item : result){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addAutomaItem(info);
			}
		}
		return response.build();
	}

}
