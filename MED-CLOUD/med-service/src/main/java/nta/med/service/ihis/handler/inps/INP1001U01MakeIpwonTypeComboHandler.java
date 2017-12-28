package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01MakeIpwonTypeComboRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class INP1001U01MakeIpwonTypeComboHandler
		extends ScreenHandler<InpsServiceProto.INP1001U01MakeIpwonTypeComboRequest, SystemServiceProto.ComboResponse> {

	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001U01MakeIpwonTypeComboRequest request) throws Exception {
		
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		String codeType = "1".equals(request.getComboGubun()) ? "IPWON_TYPE2" : "IPWON_TYPE";  
		List<ComboListItemInfo> lstInfo = bas0102Repository.getCodeNameListItem(getHospitalCode(vertx, sessionId), codeType, "1", getLanguage(vertx, sessionId));
		if(CollectionUtils.isEmpty(lstInfo)){
			return response.build();
		}
		
		for (ComboListItemInfo info : lstInfo) {
			CommonModelProto.ComboListItemInfo.Builder protoInfo = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(info.getCode())
					.setCodeName(info.getCodeName() == null ? "" : info.getCodeName());
			
			response.addComboItem(protoInfo);
		}
		
		return response.build();
	}

}
