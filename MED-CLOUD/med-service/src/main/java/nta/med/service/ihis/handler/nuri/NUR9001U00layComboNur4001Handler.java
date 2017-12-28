package nta.med.service.ihis.handler.nuri;

import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nur.Nur4001Repository;
import nta.med.data.model.ihis.nuri.NUR9001U00layComboNur4001Info;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR9001U00layComboNur4001Handler extends ScreenHandler<NuriServiceProto.NUR9001U00layComboNur4001Request, NuriServiceProto.NUR9001U00layComboNur4001Response> {
	
	@Resource
	private Nur4001Repository nur4001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR9001U00layComboNur4001Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR9001U00layComboNur4001Request request) throws Exception {
				
		NuriServiceProto.NUR9001U00layComboNur4001Response.Builder response = NuriServiceProto.NUR9001U00layComboNur4001Response.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<NUR9001U00layComboNur4001Info> result = nur4001Repository.getNUR9001U00layComboNur4001Info(hospCode, CommonUtils.parseDouble(request.getFkinp1001()));
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR9001U00layComboNur4001Info item : result){
				NuriModelProto.NUR9001U00layComboNur4001Info.Builder info = NuriModelProto.NUR9001U00layComboNur4001Info.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				if (item.getPknur4001() != null) {
					info.setPknur4001(String.format("%.0f",item.getPknur4001()));
				}
				response.addLayCombonur4001(info);
			}
		}
		
		return response.build();
	}
}
