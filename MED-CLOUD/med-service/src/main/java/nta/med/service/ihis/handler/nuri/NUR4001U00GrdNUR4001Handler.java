package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur4001Repository;
import nta.med.data.model.ihis.nuri.NUR4001U00GrdNUR4001Info;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR4001U00GrdNUR4001Handler extends ScreenHandler<NuriServiceProto.NUR4001U00GrdNUR4001Request, NuriServiceProto.NUR4001U00GrdNUR4001Response> {   
	
	@Resource
	private Nur4001Repository nur4001Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR4001U00GrdNUR4001Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR4001U00GrdNUR4001Request request) throws Exception {
				
		NuriServiceProto.NUR4001U00GrdNUR4001Response.Builder response = NuriServiceProto.NUR4001U00GrdNUR4001Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<NUR4001U00GrdNUR4001Info> result = nur4001Repository.getNUR4001U00GrdNUR4001Info(hospCode, CommonUtils.parseDouble(request.getFkinp1001()), startNum, offset);
		if(!CollectionUtils.isEmpty(result)){
			for(NUR4001U00GrdNUR4001Info item : result){
				NuriModelProto.NUR4001U00GrdNUR4001Info.Builder info = NuriModelProto.NUR4001U00GrdNUR4001Info.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				if (item.getFkinp1001() != null) {
					info.setFkinp1001(String.format("%.0f",item.getFkinp1001()));
				}
				if (item.getPknur4001() != null) {
					info.setPknur4001(String.format("%.0f",item.getPknur4001()));
				}
				response.addGrdList(info);
			}
		}
		
		return response.build();
	}
}
