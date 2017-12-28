package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur1035Repository;
import nta.med.data.model.ihis.nuri.NUR1035U00grdNUR1035Info;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1035U00grdNUR1035Handler extends ScreenHandler<NuriServiceProto.NUR1035U00grdNUR1035Request, NuriServiceProto.NUR1035U00grdNUR1035Response> {   
	
	@Resource
	private Nur1035Repository nur1035Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1035U00grdNUR1035Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1035U00grdNUR1035Request request) throws Exception {
				
		NuriServiceProto.NUR1035U00grdNUR1035Response.Builder response = NuriServiceProto.NUR1035U00grdNUR1035Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		Integer offset = StringUtils.isEmpty(request.getOffset()) ? null : CommonUtils.parseInteger(request.getOffset());
		Integer startNum = StringUtils.isEmpty(request.getOffset()) || StringUtils.isEmpty(request.getPageNumber()) ? null
				: CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		
		List<NUR1035U00grdNUR1035Info> result = nur1035Repository.getNUR1035U00grdNUR1035Info(hospCode, CommonUtils.parseDouble(request.getFkinp1001()), startNum, offset);
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR1035U00grdNUR1035Info item : result){
				NuriModelProto.NUR1035U00grdNUR1035Info.Builder info = NuriModelProto.NUR1035U00grdNUR1035Info.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				if (item.getFkinp1001() != null) {
					info.setFkinp1001(String.format("%.0f",item.getFkinp1001()));
				}
				response.addGrdMasterItem(info);
			}
		}		
		
		return response.build();
	}
}
