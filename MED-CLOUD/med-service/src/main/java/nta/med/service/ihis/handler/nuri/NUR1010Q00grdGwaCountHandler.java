package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.nuri.NUR1010Q00grdGwaCountInfo;
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
public class NUR1010Q00grdGwaCountHandler extends ScreenHandler<NuriServiceProto.NUR1010Q00grdGwaCountRequest, NuriServiceProto.NUR1010Q00grdGwaCountResponse> {   
	
	@Resource                                   
	private Inp1001Repository inp1001Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1010Q00grdGwaCountResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1010Q00grdGwaCountRequest request) throws Exception {
				
		NuriServiceProto.NUR1010Q00grdGwaCountResponse.Builder response = NuriServiceProto.NUR1010Q00grdGwaCountResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR1010Q00grdGwaCountInfo> result = inp1001Repository.getNUR1010Q00grdGwaCountInfo(hospCode, request.getHoDong());
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR1010Q00grdGwaCountInfo item : result){
				NuriModelProto.NUR1010Q00grdGwaCountInfo.Builder info = NuriModelProto.NUR1010Q00grdGwaCountInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addGrdGwacount(info);
			}
		}
		
		return response.build();
	}
}
