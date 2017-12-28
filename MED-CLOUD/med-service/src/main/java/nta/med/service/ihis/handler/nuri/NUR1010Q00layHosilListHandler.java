package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0250Repository;
import nta.med.data.model.ihis.nuri.NUR1010Q00layHosilListInfo;
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
public class NUR1010Q00layHosilListHandler extends ScreenHandler<NuriServiceProto.NUR1010Q00layHosilListRequest, NuriServiceProto.NUR1010Q00layHosilListResponse> {   
	
	@Resource                                   
	private Bas0250Repository bas0250Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1010Q00layHosilListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1010Q00layHosilListRequest request) throws Exception {
				
		NuriServiceProto.NUR1010Q00layHosilListResponse.Builder response = NuriServiceProto.NUR1010Q00layHosilListResponse.newBuilder();
		
		List<NUR1010Q00layHosilListInfo> result = bas0250Repository.getNUR1010Q00layHosilListInfo(getHospitalCode(vertx, sessionId), request.getHoDong());
		if(!CollectionUtils.isEmpty(result)){
			for(NUR1010Q00layHosilListInfo item : result){
				NuriModelProto.NUR1010Q00layHosilListInfo.Builder info = NuriModelProto.NUR1010Q00layHosilListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayHosillist(info);
			}
		}
		
		return response.build();
	}
}
