package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.nur.Nur8003Repository;
import nta.med.data.model.ihis.nuri.NUR8003Q00grdNur8003Info;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR8003Q00grdNur8003Handler extends ScreenHandler<NuriServiceProto.NUR8003Q00grdNur8003Request, NuriServiceProto.NUR8003Q00grdNur8003Response> {   
	
	@Resource
	private Nur8003Repository nur8003Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR8003Q00grdNur8003Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR8003Q00grdNur8003Request request) throws Exception {
				
		NuriServiceProto.NUR8003Q00grdNur8003Response.Builder response = NuriServiceProto.NUR8003Q00grdNur8003Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR8003Q00grdNur8003Info> result = nur8003Repository.getNUR8003Q00grdNur8003Info(hospCode, request.getQueryDate(), request.getHoDong());
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR8003Q00grdNur8003Info item : result){
				NuriModelProto.NUR8003Q00grdNur8003Info.Builder info = NuriModelProto.NUR8003Q00grdNur8003Info.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addGrdNur8003(info);
			}
		}
		
		return response.build();
	}
}
