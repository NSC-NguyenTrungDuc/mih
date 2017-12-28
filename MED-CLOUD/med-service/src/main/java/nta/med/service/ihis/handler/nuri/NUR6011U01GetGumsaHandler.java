package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl3020Repository;
import nta.med.data.model.ihis.system.TripleListItemInfo;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR6011U01GetGumsaHandler extends ScreenHandler<NuriServiceProto.NUR6011U01GetGumsaRequest, NuriServiceProto.NUR6011U01GetGumsaResponse> {   
	
	@Resource                                   
	private Cpl3020Repository cpl3020Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR6011U01GetGumsaResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR6011U01GetGumsaRequest request) throws Exception {
				
		NuriServiceProto.NUR6011U01GetGumsaResponse.Builder response = NuriServiceProto.NUR6011U01GetGumsaResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		String hbResult = "";
		String albResult = "";
		String tpResult = "";
		
		List<TripleListItemInfo> result = cpl3020Repository.getNUR6011U01GetGumsa(hospCode, language, request.getDate(), request.getBunho());
		if(!CollectionUtils.isEmpty(result)){
			hbResult = result.get(0).getItem1();
			albResult = result.get(0).getItem2();
			tpResult = result.get(0).getItem3();
		}
		
		response.setHbResult(hbResult);
		response.setAlbResult(albResult);
		response.setTpResult(tpResult);
		
		return response.build();
	}
}
