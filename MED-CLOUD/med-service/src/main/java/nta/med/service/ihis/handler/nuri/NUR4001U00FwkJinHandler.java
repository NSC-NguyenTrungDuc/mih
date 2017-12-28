package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.nur.Nur0401Repository;
import nta.med.data.model.ihis.nuri.NUR4001U00FwkJinInfo;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR4001U00FwkJinHandler extends ScreenHandler<NuriServiceProto.NUR4001U00FwkJinRequest, NuriServiceProto.NUR4001U00FwkJinResponse> {   
	
	@Resource
	private Nur0401Repository nur0401Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR4001U00FwkJinResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR4001U00FwkJinRequest request) throws Exception {
				
		NuriServiceProto.NUR4001U00FwkJinResponse.Builder response = NuriServiceProto.NUR4001U00FwkJinResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		List<NUR4001U00FwkJinInfo> result = nur0401Repository.getNUR4001U00FwkJinInfo(hospCode, request.getNurPlanBunryu());
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR4001U00FwkJinInfo item : result){
				NuriModelProto.NUR4001U00FwkJinInfo.Builder info = NuriModelProto.NUR4001U00FwkJinInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addFwkList(info);
			}
		}
		
		return response.build();
	}
}
