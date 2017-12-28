package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur6012Repository;
import nta.med.data.model.ihis.nuri.NUR6011U01layCalendarInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR6011U01layCalendarHandler extends ScreenHandler<NuriServiceProto.NUR6011U01layCalendarRequest, NuriServiceProto.NUR6011U01layCalendarResponse> {   
	
	@Resource                                   
	private Nur6012Repository nur6012Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR6011U01layCalendarResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR6011U01layCalendarRequest request) throws Exception {
				
		NuriServiceProto.NUR6011U01layCalendarResponse.Builder response = NuriServiceProto.NUR6011U01layCalendarResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<NUR6011U01layCalendarInfo> result = nur6012Repository.getNUR6011U01layCalendarInfo(hospCode, request.getBunho(),
					request.getFromDate(), request.getFromMonth(), startNum, offset);
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR6011U01layCalendarInfo item : result){
				NuriModelProto.NUR6011U01layCalendarInfo.Builder info = NuriModelProto.NUR6011U01layCalendarInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addItems(info);
			}
		}
		
		return response.build();
	}
}
