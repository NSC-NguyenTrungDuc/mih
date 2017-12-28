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
import nta.med.data.dao.medi.out.Out0102Repository;
import nta.med.data.model.ihis.inps.INP1001U01FwkGubunInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01FwkGubunRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01FwkGubunResponse;

@Service
@Scope("prototype")
public class INP1001U01FwkGubunHandler
		extends ScreenHandler<InpsServiceProto.INP1001U01FwkGubunRequest, InpsServiceProto.INP1001U01FwkGubunResponse> {

	@Resource
	private Out0102Repository out0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public INP1001U01FwkGubunResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001U01FwkGubunRequest request) throws Exception {

		InpsServiceProto.INP1001U01FwkGubunResponse.Builder response = InpsServiceProto.INP1001U01FwkGubunResponse.newBuilder();
		List<INP1001U01FwkGubunInfo> lstInfo = out0102Repository.getINP1001U01FwkGubunInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId)
				, request.getBunho(), request.getNaewonDate(), request.getFind1());
		
		if(CollectionUtils.isEmpty(lstInfo)){
			return response.build();
		}
		
		for (INP1001U01FwkGubunInfo info : lstInfo) {
			InpsModelProto.INP1001U01FwkGubunInfo.Builder protoInfo = InpsModelProto.INP1001U01FwkGubunInfo.newBuilder();
			BeanUtils.copyProperties(info, protoInfo, getLanguage(vertx, sessionId));
			response.addFwkList(protoInfo);
		}
		
		return response.build();
	}

}
