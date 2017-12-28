package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0250Repository;
import nta.med.data.model.ihis.nuri.NUR1010Q00layBedListInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1010Q00layBedListHandler extends ScreenHandler<NuriServiceProto.NUR1010Q00layBedListRequest, NuriServiceProto.NUR1010Q00layBedListResponse> {   
	
	@Resource                                   
	private Bas0250Repository bas0250Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1010Q00layBedListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1010Q00layBedListRequest request) throws Exception {
				
		NuriServiceProto.NUR1010Q00layBedListResponse.Builder response = NuriServiceProto.NUR1010Q00layBedListResponse.newBuilder();
		
		List<NUR1010Q00layBedListInfo> result = bas0250Repository.getNUR1010Q00layBedListInfo(getHospitalCode(vertx, sessionId), request.getHoDong());
		
		if(!CollectionUtils.isEmpty(result)){
			for(NUR1010Q00layBedListInfo item : result){
				NuriModelProto.NUR1010Q00layBedListInfo.Builder info = NuriModelProto.NUR1010Q00layBedListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayBedlist(info);
			}
		}
		
		return response.build();
	}
}
