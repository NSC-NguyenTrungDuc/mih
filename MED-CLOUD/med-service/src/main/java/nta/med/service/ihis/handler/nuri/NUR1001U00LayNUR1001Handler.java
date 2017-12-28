package nta.med.service.ihis.handler.nuri;

import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur1001Repository;
import nta.med.data.model.ihis.nuri.NUR1001U00LayNUR1001Info;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1001U00LayNUR1001Handler extends ScreenHandler<NuriServiceProto.NUR1001U00LayNUR1001Request, NuriServiceProto.NUR1001U00LayNUR1001Response> {
	
	@Resource
	private Nur1001Repository nur1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1001U00LayNUR1001Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1001U00LayNUR1001Request request) throws Exception {
				
		NuriServiceProto.NUR1001U00LayNUR1001Response.Builder response = NuriServiceProto.NUR1001U00LayNUR1001Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR1001U00LayNUR1001Info> result = nur1001Repository.getNUR1001U00LayNUR1001Info(hospCode, request.getBunho(), request.getIpwonDate(), CommonUtils.parseDouble(request.getFkinp1001()));
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR1001U00LayNUR1001Info item : result){
				NuriModelProto.NUR1001U00LayNUR1001Info.Builder info = NuriModelProto.NUR1001U00LayNUR1001Info.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				if (item.getFkinp1001() != null) {
					info.setFkinp1001(String.format("%.0f",CommonUtils.parseDouble(item.getFkinp1001())));
				}
				response.addLayList(info);
			}
		}
		
		return response.build();
	}
}
