package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur6012Repository;
import nta.med.data.model.ihis.nuri.NUR6011U01PrintSetgrdPrintInfo;
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
public class NUR6011U01PrintSetgrdPrintHandler extends ScreenHandler<NuriServiceProto.NUR6011U01PrintSetgrdPrintRequest, NuriServiceProto.NUR6011U01PrintSetgrdPrintResponse> {   
	
	@Resource                                   
	private Nur6012Repository nur6012Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR6011U01PrintSetgrdPrintResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR6011U01PrintSetgrdPrintRequest request) throws Exception {
				
		NuriServiceProto.NUR6011U01PrintSetgrdPrintResponse.Builder response = NuriServiceProto.NUR6011U01PrintSetgrdPrintResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR6011U01PrintSetgrdPrintInfo> result = nur6012Repository.getNUR6011U01PrintSetgrdPrintInfo(hospCode, language, request.getBunho(), request.getFromDate(),
				request.getBuwi1(), request.getBuwi2(), request.getBuwi3(), request.getBuwi4(), request.getBuwi5(), request.getBuwi6(), request.getAssessorStartDate(),
				request.getAssessorEndDate());
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR6011U01PrintSetgrdPrintInfo item : result){
				NuriModelProto.NUR6011U01PrintSetgrdPrintInfo.Builder info = NuriModelProto.NUR6011U01PrintSetgrdPrintInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addItems(info);
			}
		}
		
		return response.build();
	}
}
