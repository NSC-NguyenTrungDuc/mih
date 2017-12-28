package nta.med.service.ihis.handler.nuri;

import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1004Repository;
import nta.med.data.model.ihis.nuri.NUR1001U00GrdINP1004Info;

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
public class NUR1001U00GrdINP1004Handler extends ScreenHandler<NuriServiceProto.NUR1001U00GrdINP1004Request, NuriServiceProto.NUR1001U00GrdINP1004Response> {
	
	@Resource
	private Inp1004Repository inp1004Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1001U00GrdINP1004Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1001U00GrdINP1004Request request) throws Exception {
				
		NuriServiceProto.NUR1001U00GrdINP1004Response.Builder response = NuriServiceProto.NUR1001U00GrdINP1004Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<NUR1001U00GrdINP1004Info> result = inp1004Repository.getNUR1001U00GrdINP1004Info(hospCode, language, request.getBunho(), startNum, offset);
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR1001U00GrdINP1004Info item : result){
				NuriModelProto.NUR1001U00GrdINP1004Info.Builder info = NuriModelProto.NUR1001U00GrdINP1004Info.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addGrdList(info);
			}
		}
		
		return response.build();
	}
}
