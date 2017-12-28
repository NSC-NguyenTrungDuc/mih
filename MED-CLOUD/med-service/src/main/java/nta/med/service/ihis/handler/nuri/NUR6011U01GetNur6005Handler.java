package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR6011U01GetNur6005Handler extends ScreenHandler<NuriServiceProto.NUR6011U01GetNur6005Request, NuriServiceProto.NUR6011U01GetNur6005Response> {   
	
	@Resource                                   
	private Nur0102Repository nur0102Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR6011U01GetNur6005Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR6011U01GetNur6005Request request) throws Exception {
				
		NuriServiceProto.NUR6011U01GetNur6005Response.Builder response = NuriServiceProto.NUR6011U01GetNur6005Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<String> result = nur0102Repository.getNUR6011U01GetNur6005(hospCode, language, request.getBunho());
		
		if(!CollectionUtils.isEmpty(result)){
			for(String item : result){
				response.addItems(item);
			}
		}
		
		return response.build();
	}
}
