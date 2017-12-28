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
import nta.med.data.dao.medi.nur.Nur0112Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02AutoMaLoadComboRequest;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2005U02AutoMaLoadComboResponse;

@Service
@Scope("prototype")
public class OCS2005U02AutoMaLoadComboHandler extends ScreenHandler<OcsiServiceProto.OCS2005U02AutoMaLoadComboRequest, OcsiServiceProto.OCS2005U02AutoMaLoadComboResponse>{

	@Resource
	private Nur0112Repository nur0112Repository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2005U02AutoMaLoadComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2005U02AutoMaLoadComboRequest request) throws Exception{
		OcsiServiceProto.OCS2005U02AutoMaLoadComboResponse.Builder response = OcsiServiceProto.OCS2005U02AutoMaLoadComboResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		
		List<ComboListItemInfo> result = nur0112Repository.getOCS2005U02AutoMaSetCombo(hospCode, request.getCode());
		
		if(!CollectionUtils.isEmpty(result)){
			for(ComboListItemInfo item : result){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLoadcomboItem(info);
			}
		}
		
		return response.build();
	}
}
