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
import nta.med.data.model.ihis.inps.INP1001U01ChangeGubunGrdHistoryInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01ChangeGubunGrdHistoryRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INP1001U01ChangeGubunGrdHistoryResponse;

@Service
@Scope("prototype")
public class INP1001U01ChangeGubunGrdHistoryHandler extends
		ScreenHandler<InpsServiceProto.INP1001U01ChangeGubunGrdHistoryRequest, InpsServiceProto.INP1001U01ChangeGubunGrdHistoryResponse> {

	@Resource
	private Inp1002Repository inp1002Repository;
	
	@Override
	@Transactional(readOnly = true)
	public INP1001U01ChangeGubunGrdHistoryResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, INP1001U01ChangeGubunGrdHistoryRequest request) throws Exception {
		
		InpsServiceProto.INP1001U01ChangeGubunGrdHistoryResponse.Builder response = InpsServiceProto.INP1001U01ChangeGubunGrdHistoryResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<INP1001U01ChangeGubunGrdHistoryInfo> lstInfo = inp1002Repository.getINP1001U01ChangeGubunGrdHistoryInfo(
				hospCode, CommonUtils.parseDouble(request.getFkinp1001()));
		
		if(CollectionUtils.isEmpty(lstInfo)){
			return response.build();
		}
		
		for (INP1001U01ChangeGubunGrdHistoryInfo info : lstInfo) {
			InpsModelProto.INP1001U01ChangeGubunGrdHistoryInfo.Builder protoInfo = InpsModelProto.INP1001U01ChangeGubunGrdHistoryInfo
					.newBuilder(); 
			BeanUtils.copyProperties(info, protoInfo, language);
			response.addGrdList(protoInfo);
		}
		
		return response.build();
	}

	
}
