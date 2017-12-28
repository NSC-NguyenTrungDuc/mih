package nta.med.service.ihis.handler.nuts;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.ocs.Ocs2005Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NutsServiceProto;
import nta.med.service.ihis.proto.NutsServiceProto.NUT9001Q01createHoDongRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class NUT9001Q01createHoDongHandler
		extends ScreenHandler<NutsServiceProto.NUT9001Q01createHoDongRequest, SystemServiceProto.ComboResponse> {

	@Resource
	private Ocs2005Repository ocs2005Repository;
	
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUT9001Q01createHoDongRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<ComboListItemInfo> infos = ocs2005Repository.getOCS2005U02createHoDongNut(hospCode, language);
		
//		CommonModelProto.ComboListItemInfo.Builder firstInfo = CommonModelProto.ComboListItemInfo.newBuilder().setCode("%").setCodeName(""); 
//		response.addComboItem(firstInfo);
		
		if(!CollectionUtils.isEmpty(infos)){
			for (ComboListItemInfo info : infos) {
				CommonModelProto.ComboListItemInfo.Builder pInfo = CommonModelProto.ComboListItemInfo.newBuilder()
						.setCode(info.getCode())
						.setCodeName(info.getCodeName()); 
				response.addComboItem(pInfo);
			}
		}
		
		return response.build();
	}

}
