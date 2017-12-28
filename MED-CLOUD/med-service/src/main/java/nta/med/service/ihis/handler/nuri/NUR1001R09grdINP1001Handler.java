package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.nuri.NUR1001R09grdINP1001Info;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1001R09grdINP1001Handler extends ScreenHandler<NuriServiceProto.NUR1001R09grdINP1001Request, NuriServiceProto.NUR1001R09grdINP1001Response> {   
	
	@Resource  
	private Inp1001Repository inp1001Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1001R09grdINP1001Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1001R09grdINP1001Request request) throws Exception {
				
		NuriServiceProto.NUR1001R09grdINP1001Response.Builder response = NuriServiceProto.NUR1001R09grdINP1001Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<NUR1001R09grdINP1001Info> result = inp1001Repository.getNUR1001R09grdINP1001Info(hospCode, language, request.getHoDong(), request.getGwa(), startNum, offset);
		
		if(!CollectionUtils.isEmpty(result)){
			for (NUR1001R09grdINP1001Info item : result){
				NuriModelProto.NUR1001R09grdINP1001Info.Builder info = NuriModelProto.NUR1001R09grdINP1001Info.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addGrdInp1001(info);
			}
		}
		
		return response.build();
	}
}
