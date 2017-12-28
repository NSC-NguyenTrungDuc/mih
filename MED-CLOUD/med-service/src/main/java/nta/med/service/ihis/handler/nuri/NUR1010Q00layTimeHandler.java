package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.data.model.ihis.nuri.NUR1010Q00layTimeInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1010Q00layTimeHandler extends ScreenHandler<NuriServiceProto.NUR1010Q00layTimeRequest, NuriServiceProto.NUR1010Q00layTimeResponse> {   
	
	@Resource                                   
	private Nur0102Repository nur0102Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1010Q00layTimeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1010Q00layTimeRequest request) throws Exception {
				
		NuriServiceProto.NUR1010Q00layTimeResponse.Builder response = NuriServiceProto.NUR1010Q00layTimeResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR1010Q00layTimeInfo> result = nur0102Repository.getNUR1010Q00layTimeInfo(hospCode, language);
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR1010Q00layTimeInfo item : result){
				NuriModelProto.NUR1010Q00layTimeInfo.Builder info = NuriModelProto.NUR1010Q00layTimeInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addLayTime(info);
			}
		}
		
		return response.build();
	}
}
