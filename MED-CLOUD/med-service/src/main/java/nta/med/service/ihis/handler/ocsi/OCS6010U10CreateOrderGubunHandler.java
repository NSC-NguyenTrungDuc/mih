package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.ocs.Ocs0132;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS6010U10CreateOrderGubunRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class OCS6010U10CreateOrderGubunHandler
		extends ScreenHandler<OcsiServiceProto.OCS6010U10CreateOrderGubunRequest, SystemServiceProto.ComboResponse> {

	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Override
	@Transactional
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS6010U10CreateOrderGubunRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<Ocs0132> listOcs = ocs0132Repository.findByHospCodeCodeTypeValuePoint(hospCode, language, request.getCodeType(), CommonUtils.parseDouble(request.getValueType()));
		if(CollectionUtils.isEmpty(listOcs)){
			return response.build();
		}
		
		for (Ocs0132 ocs0132 : listOcs) {
			CommonModelProto.ComboListItemInfo.Builder pInfo = CommonModelProto.ComboListItemInfo.newBuilder()
					.setCode(ocs0132.getCode())
					.setCodeName(ocs0132.getCodeName());
			
			response.addComboItem(pInfo);
		}
		
		return response.build();
	}

}
