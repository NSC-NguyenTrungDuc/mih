package nta.med.service.ihis.handler.nuri;

import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur1016Repository;
import nta.med.data.model.ihis.nuri.NUR1001U00GrdNUR1016Info;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1001U00GrdNUR1016Handler extends ScreenHandler<NuriServiceProto.NUR1001U00GrdNUR1016Request, NuriServiceProto.NUR1001U00GrdNUR1016Response> {
	
	@Resource
	private Nur1016Repository nur1016Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1001U00GrdNUR1016Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1001U00GrdNUR1016Request request) throws Exception {
				
		NuriServiceProto.NUR1001U00GrdNUR1016Response.Builder response = NuriServiceProto.NUR1001U00GrdNUR1016Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<NUR1001U00GrdNUR1016Info> result = nur1016Repository.getNUR1001U00GrdNUR1016Info(hospCode, request.getBunho(), language, request.getSysDate(), startNum, offset);
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR1001U00GrdNUR1016Info item : result){
				NuriModelProto.NUR1001U00GrdNUR1016Info.Builder info = NuriModelProto.NUR1001U00GrdNUR1016Info.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addGrdList(info);
			}
		}
		
		return response.build();
	}
}
