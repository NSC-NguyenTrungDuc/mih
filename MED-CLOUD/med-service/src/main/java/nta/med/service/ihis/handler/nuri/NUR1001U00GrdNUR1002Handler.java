package nta.med.service.ihis.handler.nuri;

import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur1002Repository;
import nta.med.data.model.ihis.nuri.NUR1001U00GrdNUR1002Info;

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
public class NUR1001U00GrdNUR1002Handler extends ScreenHandler<NuriServiceProto.NUR1001U00GrdNUR1002Request, NuriServiceProto.NUR1001U00GrdNUR1002Response> {

	@Resource
	private Nur1002Repository nur1002Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1001U00GrdNUR1002Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1001U00GrdNUR1002Request request) throws Exception {
				
		NuriServiceProto.NUR1001U00GrdNUR1002Response.Builder response = NuriServiceProto.NUR1001U00GrdNUR1002Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<NUR1001U00GrdNUR1002Info> result = nur1002Repository.getNUR1001U00GrdNUR1002Info(hospCode, request.getBunho(), CommonUtils.parseDouble(request.getFkinp1001()), startNum, offset);
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR1001U00GrdNUR1002Info item : result){
				NuriModelProto.NUR1001U00GrdNUR1002Info.Builder info = NuriModelProto.NUR1001U00GrdNUR1002Info.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				if (item.getFkinp1001() != null) {
					info.setFkinp1001(String.format("%.0f",item.getFkinp1001()));
				}
				response.addGrdList(info);
			}
		}
		
		return response.build();
	}
}