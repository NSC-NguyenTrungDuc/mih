
package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur1010Repository;
import nta.med.data.model.ihis.nuri.NUR1010U00grdNur1010Info;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1010U00grdNur1010Handler extends ScreenHandler<NuriServiceProto.NUR1010U00grdNur1010Request, NuriServiceProto.NUR1010U00grdNur1010Response> {   
	
	@Resource
	private Nur1010Repository nur1010Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1010U00grdNur1010Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1010U00grdNur1010Request request) throws Exception {
				
		NuriServiceProto.NUR1010U00grdNur1010Response.Builder response = NuriServiceProto.NUR1010U00grdNur1010Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<NUR1010U00grdNur1010Info> result = nur1010Repository.getNUR1010U00grdNur1010Info(hospCode, CommonUtils.parseDouble(request.getFkinp1001()), startNum, offset);
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR1010U00grdNur1010Info item : result){
				NuriModelProto.NUR1010U00grdNur1010Info.Builder info = NuriModelProto.NUR1010U00grdNur1010Info.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				if (item.getFkinp1001() != null) {
					info.setFkinp1001(String.format("%.0f",item.getFkinp1001()));
				}
				response.addGrdNur1010(info);
			}
		}
		
		return response.build();
	}
}
