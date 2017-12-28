package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0212Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00cboCategoryGubunRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U00cboCategoryGubunResponse;

/**
 * @author vnc.tuyen
 */
@Service
@Scope("prototype")
public class INP1003U00cboCategoryGubunHandler extends ScreenHandler<InpsServiceProto.INP1003U00cboCategoryGubunRequest, InpsServiceProto.INP1003U00cboCategoryGubunResponse> {

	@Resource
	private Bas0212Repository bas0212Repository;
	
	@Override
	public INP1003U00cboCategoryGubunResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003U00cboCategoryGubunRequest request) throws Exception {
		
		InpsServiceProto.INP1003U00cboCategoryGubunResponse.Builder response = InpsServiceProto.INP1003U00cboCategoryGubunResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		
		List<ComboListItemInfo> listInfo = bas0212Repository.findByHospCodeCodeType(hospCode);
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		for (ComboListItemInfo info : listInfo) {
			CommonModelProto.ComboListItemInfo.Builder infoBuilder = CommonModelProto.ComboListItemInfo.newBuilder();
			BeanUtils.copyProperties(info, infoBuilder, getLanguage(vertx, sessionId));
			response.addCboItem(infoBuilder);
		}

		return response.build();
	}

}
