package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp2004Repository;
import nta.med.data.model.ihis.nuri.NUR2004U01GetConfirmDataInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U01GetConfirmDataRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U01GetConfirmDataResponse;

@Service
@Scope("prototype")
public class NUR2004U01GetConfirmDataHandler extends
		ScreenHandler<NuriServiceProto.NUR2004U01GetConfirmDataRequest, NuriServiceProto.NUR2004U01GetConfirmDataResponse> {
	
	@Resource
	private Inp2004Repository inp2004Repository;

	@Override
	@Transactional
	public NUR2004U01GetConfirmDataResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U01GetConfirmDataRequest request) throws Exception {

		NuriServiceProto.NUR2004U01GetConfirmDataResponse.Builder response = NuriServiceProto.NUR2004U01GetConfirmDataResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		List<NUR2004U01GetConfirmDataInfo> result = inp2004Repository.getNUR2004U01GetConfirmDataInfo(hospCode, CommonUtils.parseDouble(request.getFkinp1001()), 
				CommonUtils.parseDouble(request.getTransCnt()));
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR2004U01GetConfirmDataInfo item : result){
				NuriModelProto.NUR2004U01GetConfirmDataInfo.Builder info = NuriModelProto.NUR2004U01GetConfirmDataInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDtconfirmItem(info);
			}
		}
		
		return response.build();
	}

	
}
