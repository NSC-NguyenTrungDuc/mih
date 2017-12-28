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
import nta.med.data.dao.medi.inp.Inp2001Repository;
import nta.med.data.model.ihis.inps.INP2001U02layNuGroupInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP2001U02layNuGroupRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP2001U02layNuGroupResponse;

@Service
@Scope("prototype")
public class INP2001U02layNuGroupHandler extends
		ScreenHandler<InpsServiceProto.INP2001U02layNuGroupRequest, InpsServiceProto.INP2001U02layNuGroupResponse> {

	@Resource
	private Inp2001Repository inp2001Repository;
	
//	@Override
//	public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId,
//			INP2001U02layNuGroupRequest request) throws Exception {
//		
//		super.preHandle(vertx, clientId, sessionId, contextId, request);
//	}
	
	@Override
	@Transactional(readOnly=true)
	public INP2001U02layNuGroupResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP2001U02layNuGroupRequest request) throws Exception {
		
		InpsServiceProto.INP2001U02layNuGroupResponse.Builder response = InpsServiceProto.INP2001U02layNuGroupResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<INP2001U02layNuGroupInfo> listInfo = inp2001Repository.getListINP2001U02layNuGroupInfo(hospCode, language, request.getBunHo(), request.getIpwonDate());
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		for (INP2001U02layNuGroupInfo info : listInfo) {
			InpsModelProto.INP2001U02layNuGroupInfo.Builder infoBuilder = InpsModelProto.INP2001U02layNuGroupInfo.newBuilder();
			BeanUtils.copyProperties(info, infoBuilder, language);
			response.addLayNugroup(infoBuilder);
		}
		
		return response.build();
	}

}
