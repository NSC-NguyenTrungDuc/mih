package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur6014Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR6011U01PrintSetlayImageHandler extends ScreenHandler<NuriServiceProto.NUR6011U01PrintSetlayImageRequest, NuriServiceProto.NUR6011U01PrintSetlayImageResponse> {   
	
	@Resource                                   
	private Nur6014Repository nur6014Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR6011U01PrintSetlayImageResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR6011U01PrintSetlayImageRequest request) throws Exception {
				
		NuriServiceProto.NUR6011U01PrintSetlayImageResponse.Builder response = NuriServiceProto.NUR6011U01PrintSetlayImageResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		List<String> result = nur6014Repository.getNUR6011U01PrintSetlayImage(hospCode, request.getBunho(), request.getBuwi(), request.getFromDate(), request.getAssessorDate());
		
		if(!CollectionUtils.isEmpty(result)){
			for(String item : result){
				response.addItems(item);
			}
		}
		
		return response.build();
	}
}
