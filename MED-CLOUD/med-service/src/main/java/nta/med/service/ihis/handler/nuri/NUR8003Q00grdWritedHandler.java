package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.nur.Nur8003Repository;
import nta.med.data.model.ihis.nuri.NUR8003Q00grdWritedInfo;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR8003Q00grdWritedHandler extends ScreenHandler<NuriServiceProto.NUR8003Q00grdWritedRequest, NuriServiceProto.NUR8003Q00grdWritedResponse> {   
	
	@Resource
	private Nur8003Repository nur8003Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR8003Q00grdWritedResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR8003Q00grdWritedRequest request) throws Exception {
				
		NuriServiceProto.NUR8003Q00grdWritedResponse.Builder response = NuriServiceProto.NUR8003Q00grdWritedResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR8003Q00grdWritedInfo> result;
		
		if(request.getNameControl().equals("laywrited")){
			result = nur8003Repository.getNUR8003Q00grdWritedInfo1(hospCode, request.getDate(), request.getHoDong());
		}else{
			result = nur8003Repository.getNUR8003Q00grdWritedInfo2(hospCode, request.getDate(), request.getHoDong());
		}
		if(!CollectionUtils.isEmpty(result)){
			for(NUR8003Q00grdWritedInfo item : result){
				NuriModelProto.NUR8003Q00grdWritedInfo.Builder info = NuriModelProto.NUR8003Q00grdWritedInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addGrdWrite(info);
			}
		}
		
		return response.build();
	}
}
