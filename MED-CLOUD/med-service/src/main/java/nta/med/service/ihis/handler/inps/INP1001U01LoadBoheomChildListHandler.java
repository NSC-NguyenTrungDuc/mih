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
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1002Repository;
import nta.med.data.model.ihis.inps.INP1001U01LoadBoheomChildListInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01LoadBoheomChildListRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01LoadBoheomChildListResponse;

@Service
@Scope("prototype")
public class INP1001U01LoadBoheomChildListHandler extends
		ScreenHandler<InpsServiceProto.INP1001U01LoadBoheomChildListRequest, InpsServiceProto.INP1001U01LoadBoheomChildListResponse> {

	@Resource
	private Inp1002Repository inp1002Repository;
	
	@Override
	@Transactional(readOnly = true)
	public INP1001U01LoadBoheomChildListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001U01LoadBoheomChildListRequest request) throws Exception {
		
		InpsServiceProto.INP1001U01LoadBoheomChildListResponse.Builder response = InpsServiceProto.INP1001U01LoadBoheomChildListResponse
				.newBuilder();
		
		List<INP1001U01LoadBoheomChildListInfo> lstInfo = inp1002Repository.getINP1001U01LoadBoheomChildListInfo(
				getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				CommonUtils.parseDouble(request.getFkinp1001()));
		
		if(CollectionUtils.isEmpty(lstInfo)){
			return response.build();
		}
		
		for (INP1001U01LoadBoheomChildListInfo info : lstInfo) {
			InpsModelProto.INP1001U01LoadBoheomChildListInfo.Builder protoInfo = InpsModelProto.INP1001U01LoadBoheomChildListInfo.newBuilder();
			BeanUtils.copyProperties(info, protoInfo, getLanguage(vertx, sessionId));
			response.addLayList(protoInfo);
		}
		
		return response.build();
	}

}
