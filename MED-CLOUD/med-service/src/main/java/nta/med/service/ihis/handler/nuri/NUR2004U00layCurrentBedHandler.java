package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.nuri.NUR2004U00layCurrentBedInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00layCurrentBedRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2004U00layCurrentBedResponse;

@Service
@Scope("prototype")
public class NUR2004U00layCurrentBedHandler extends ScreenHandler<NuriServiceProto.NUR2004U00layCurrentBedRequest, NuriServiceProto.NUR2004U00layCurrentBedResponse> {
	
	@Resource
	Out0101Repository out0101Repository;
	
	@Override
	@Transactional(readOnly=true)
	public NUR2004U00layCurrentBedResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2004U00layCurrentBedRequest request) throws Exception {
		NuriServiceProto.NUR2004U00layCurrentBedResponse.Builder response = NuriServiceProto.NUR2004U00layCurrentBedResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String bunho = request.getBunho();
		
		List<NUR2004U00layCurrentBedInfo> listInfo = out0101Repository.getNUR2004U00layCurrentBedInfo(hospCode, bunho, language);
		if(!CollectionUtils.isEmpty(listInfo)){
			for(NUR2004U00layCurrentBedInfo item : listInfo){
				NuriModelProto.NUR2004U00layCurrentBedInfo.Builder info = NuriModelProto.NUR2004U00layCurrentBedInfo.newBuilder();
				BeanUtils.copyProperties(item, info, language);
				response.addLayCurrentbed(info);
			}
		}
		
		return response.build();
	}

}
