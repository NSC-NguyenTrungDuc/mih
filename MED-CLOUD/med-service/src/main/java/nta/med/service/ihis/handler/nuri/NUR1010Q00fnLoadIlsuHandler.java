package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur1010Repository;
import nta.med.data.model.ihis.nuri.NUR1010Q00fnLoadIlsuInfo;
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
public class NUR1010Q00fnLoadIlsuHandler extends ScreenHandler<NuriServiceProto.NUR1010Q00fnLoadIlsuRequest, NuriServiceProto.NUR1010Q00fnLoadIlsuResponse> {   
	
	@Resource                                   
	private Nur1010Repository nur1010Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1010Q00fnLoadIlsuResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1010Q00fnLoadIlsuRequest request) throws Exception {
				
		NuriServiceProto.NUR1010Q00fnLoadIlsuResponse.Builder response = NuriServiceProto.NUR1010Q00fnLoadIlsuResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR1010Q00fnLoadIlsuInfo> result = nur1010Repository.getNUR1010Q00fnLoadIlsuInfo(hospCode, request.getHoDong());
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR1010Q00fnLoadIlsuInfo item : result){
				NuriModelProto.NUR1010Q00fnLoadIlsuInfo.Builder info = NuriModelProto.NUR1010Q00fnLoadIlsuInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addListLoadilsu(info);
			}
		}		
		
		return response.build();
	}
}
