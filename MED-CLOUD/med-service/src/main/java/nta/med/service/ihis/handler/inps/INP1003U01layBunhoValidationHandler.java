package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.inps.INP1003U01layBunhoValidationInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U01layBunhoValidationRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U01layBunhoValidationResponse;

@Service
@Scope("prototype")
public class INP1003U01layBunhoValidationHandler extends ScreenHandler<InpsServiceProto.INP1003U01layBunhoValidationRequest, InpsServiceProto.INP1003U01layBunhoValidationResponse> {	
	@Resource
	private Out0101Repository out0101Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP1003U01layBunhoValidationResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003U01layBunhoValidationRequest request) throws Exception {
		InpsServiceProto.INP1003U01layBunhoValidationResponse.Builder response = InpsServiceProto.INP1003U01layBunhoValidationResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<INP1003U01layBunhoValidationInfo> listInfo = out0101Repository.getINP1003U01layBunhoValidationInfo(hospCode, request.getBunho());
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		for (INP1003U01layBunhoValidationInfo info : listInfo) {
			InpsModelProto.INP1003U01layBunhoValidationInfo.Builder infoProto = InpsModelProto.INP1003U01layBunhoValidationInfo.newBuilder();
			BeanUtils.copyProperties(info, infoProto, language);
			response.addLayBunhoVa(infoProto);
		}
		
		return response.build();
	}

}
