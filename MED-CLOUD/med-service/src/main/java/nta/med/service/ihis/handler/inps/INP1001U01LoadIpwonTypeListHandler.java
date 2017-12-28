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
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.inps.INP1001U01LoadIpwonTypeListInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01LoadIpwonTypeListRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01LoadIpwonTypeListResponse;

@Service
@Scope("prototype")
public class INP1001U01LoadIpwonTypeListHandler extends
		ScreenHandler<InpsServiceProto.INP1001U01LoadIpwonTypeListRequest, InpsServiceProto.INP1001U01LoadIpwonTypeListResponse> {

	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public INP1001U01LoadIpwonTypeListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1001U01LoadIpwonTypeListRequest request) throws Exception {
		
		InpsServiceProto.INP1001U01LoadIpwonTypeListResponse.Builder response = InpsServiceProto.INP1001U01LoadIpwonTypeListResponse.newBuilder();
		List<INP1001U01LoadIpwonTypeListInfo> lstResult = inp1001Repository.getINP1001U01LoadIpwonTypeListInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho());
		if(CollectionUtils.isEmpty(lstResult)){
			return response.build();
		}
		
		for (INP1001U01LoadIpwonTypeListInfo info : lstResult) {
			InpsModelProto.INP1001U01LoadIpwonTypeListInfo.Builder protoInfo = InpsModelProto.INP1001U01LoadIpwonTypeListInfo.newBuilder();
			BeanUtils.copyProperties(info, protoInfo, getLanguage(vertx, sessionId));
			response.addLayList(protoInfo);
		}
		
		return response.build();
	}

}
