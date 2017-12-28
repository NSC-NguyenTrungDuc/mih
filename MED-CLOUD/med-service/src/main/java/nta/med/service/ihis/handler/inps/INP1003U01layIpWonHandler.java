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
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.data.model.ihis.inps.INP1003U01layIpWonInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U01layIpWonRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1003U01layIpWonResponse;

@Service
@Scope("prototype")
public class INP1003U01layIpWonHandler extends ScreenHandler<InpsServiceProto.INP1003U01layIpWonRequest, InpsServiceProto.INP1003U01layIpWonResponse>{
	@Resource
	private Inp1003Repository inp1003Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INP1003U01layIpWonResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP1003U01layIpWonRequest request) throws Exception {
		InpsServiceProto.INP1003U01layIpWonResponse.Builder response = InpsServiceProto.INP1003U01layIpWonResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<INP1003U01layIpWonInfo> listInfo = inp1003Repository.getINP1003U01layIpWonInfo(hospCode, CommonUtils.parseDouble(request.getPkinp1003()));
		if(CollectionUtils.isEmpty(listInfo)){
			return response.build();
		}
		
		for (INP1003U01layIpWonInfo info : listInfo) {
			InpsModelProto.INP1003U01layIpWonInfo.Builder infoProto = InpsModelProto.INP1003U01layIpWonInfo.newBuilder();
			BeanUtils.copyProperties(info, infoProto, language);
			response.addLayIpWon(infoProto);
		}
	
	return response.build();
	}
}
