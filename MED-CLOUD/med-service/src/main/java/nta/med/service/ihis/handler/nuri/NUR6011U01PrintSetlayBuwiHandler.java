package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur6011Repository;
import nta.med.data.model.ihis.nuri.NUR6011U01PrintSetlayBuwiInfo;
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
public class NUR6011U01PrintSetlayBuwiHandler extends ScreenHandler<NuriServiceProto.NUR6011U01PrintSetlayBuwiRequest, NuriServiceProto.NUR6011U01PrintSetlayBuwiResponse> {   
	
	@Resource                                   
	private Nur6011Repository nur6011Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR6011U01PrintSetlayBuwiResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR6011U01PrintSetlayBuwiRequest request) throws Exception {
				
		NuriServiceProto.NUR6011U01PrintSetlayBuwiResponse.Builder response = NuriServiceProto.NUR6011U01PrintSetlayBuwiResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR6011U01PrintSetlayBuwiInfo> result = nur6011Repository.getNUR6011U01PrintSetlayBuwiInfo(hospCode, language, request.getBunho(), request.getFromDate());
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR6011U01PrintSetlayBuwiInfo item : result){
				NuriModelProto.NUR6011U01PrintSetlayBuwiInfo.Builder info = NuriModelProto.NUR6011U01PrintSetlayBuwiInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addItems(info);
			}
		}
		
		return response.build();
	}
}
