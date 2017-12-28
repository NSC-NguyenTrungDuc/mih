package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur1014Repository;
import nta.med.data.model.ihis.nuri.NUR1014U00grdNur1014Info;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1014U00grdNur1014Handler extends ScreenHandler<NuriServiceProto.NUR1014U00grdNur1014Request, NuriServiceProto.NUR1014U00grdNur1014Response> {   
	
	@Resource
	private Nur1014Repository nur1014Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1014U00grdNur1014Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1014U00grdNur1014Request request) throws Exception {
				
		NuriServiceProto.NUR1014U00grdNur1014Response.Builder response = NuriServiceProto.NUR1014U00grdNur1014Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<NUR1014U00grdNur1014Info> result = nur1014Repository.getNUR1014U00grdNur1014Info(hospCode, request.getBunho(), startNum, offset);
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR1014U00grdNur1014Info item : result){
				NuriModelProto.NUR1014U00grdNur1014Info.Builder info = NuriModelProto.NUR1014U00grdNur1014Info.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				if (item.getFkinp1001() != null) {
					info.setFkinp1001(String.format("%.0f",item.getFkinp1001()));
				}
				response.addItems(info);
			}
		}
		
		return response.build();
	}
}
