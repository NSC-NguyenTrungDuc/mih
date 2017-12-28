package nta.med.service.ihis.handler.nuri;

import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.inp.Inp1003Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1001U00LayReserInfoHandler extends ScreenHandler<NuriServiceProto.NUR1001U00LayReserInfoRequest, NuriServiceProto.NUR1001U00LayReserInfoResponse> {
	
	@Resource
	private Inp1003Repository inp1003Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1001U00LayReserInfoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1001U00LayReserInfoRequest request) throws Exception {
				
		NuriServiceProto.NUR1001U00LayReserInfoResponse.Builder response = NuriServiceProto.NUR1001U00LayReserInfoResponse.newBuilder();
		
		List<ComboListItemInfo> result = inp1003Repository.getNUR1001U00LayReserInfo(getHospitalCode(vertx, sessionId), request.getBunho());
		
		if(!CollectionUtils.isEmpty(result)){
			for(ComboListItemInfo item : result){
				NuriModelProto.NUR1001U00LayReserInfoInfo.Builder info = NuriModelProto.NUR1001U00LayReserInfoInfo.newBuilder();
				info.setReserFkinp1001(item.getCode());
				info.setReserDate(item.getCodeName());
				response.addLayList(info);
			}
		}
		
		return response.build();
	}
}
