package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.inp.Inp2004Repository;
import nta.med.data.model.ihis.nuri.NUR1010Q00layConfirmDataInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1010Q00layConfirmDataHandler extends ScreenHandler<NuriServiceProto.NUR1010Q00layConfirmDataRequest, NuriServiceProto.NUR1010Q00layConfirmDataResponse> {   
	
	@Resource                                   
	private Inp2004Repository inp2004Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1010Q00layConfirmDataResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1010Q00layConfirmDataRequest request) throws Exception {
				
		NuriServiceProto.NUR1010Q00layConfirmDataResponse.Builder response = NuriServiceProto.NUR1010Q00layConfirmDataResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		List<NUR1010Q00layConfirmDataInfo> result = inp2004Repository.getNUR1010Q00layConfirmDataInfo(hospCode, CommonUtils.parseDouble(request.getFkinp1001()),
				CommonUtils.parseDouble(request.getTransCnt()));
		if(!CollectionUtils.isEmpty(result)){
			for(NUR1010Q00layConfirmDataInfo item : result){
				NuriModelProto.NUR1010Q00layConfirmDataInfo.Builder info = NuriModelProto.NUR1010Q00layConfirmDataInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayConfirmdata(info);
			}
		}
		return response.build();
	}
}
