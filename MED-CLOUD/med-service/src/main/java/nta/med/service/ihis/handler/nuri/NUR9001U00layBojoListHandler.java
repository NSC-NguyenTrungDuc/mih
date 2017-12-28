package nta.med.service.ihis.handler.nuri;

import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.nur.Nur0901Repository;
import nta.med.data.model.ihis.nuri.NUR9001U00layBojoListInfo;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR9001U00layBojoListHandler extends ScreenHandler<NuriServiceProto.NUR9001U00layBojoListRequest, NuriServiceProto.NUR9001U00layBojoListResponse> {
	
	@Resource
	private Nur0901Repository nur0901Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR9001U00layBojoListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR9001U00layBojoListRequest request) throws Exception {
				
		NuriServiceProto.NUR9001U00layBojoListResponse.Builder response = NuriServiceProto.NUR9001U00layBojoListResponse.newBuilder();
		
		List<NUR9001U00layBojoListInfo> result = nur0901Repository.getNUR9001U00layBojoListInfo(getHospitalCode(vertx, sessionId), request.getSoapGubun(), request.getHoDong());
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR9001U00layBojoListInfo item : result){
				NuriModelProto.NUR9001U00layBojoListInfo.Builder info = NuriModelProto.NUR9001U00layBojoListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayBojo(info);
			}
		}
		
		return response.build();
	}
}
