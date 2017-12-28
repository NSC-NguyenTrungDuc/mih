package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0250Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1010Q00SelectMancntHandler extends ScreenHandler<NuriServiceProto.NUR1010Q00SelectMancntRequest, NuriServiceProto.NUR1010Q00SelectMancntResponse> {   
	
	@Resource                                   
	private Bas0250Repository bas0250Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1010Q00SelectMancntResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1010Q00SelectMancntRequest request) throws Exception {
				
		NuriServiceProto.NUR1010Q00SelectMancntResponse.Builder response = NuriServiceProto.NUR1010Q00SelectMancntResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		
		List<ComboListItemInfo> result = bas0250Repository.getNUR1010Q00SelectMancnt(hospCode, request.getHoDong());
		
		if(!CollectionUtils.isEmpty(result)){
			for(ComboListItemInfo item : result){
				NuriModelProto.NUR1010Q00SelectMancntInfo.Builder info = NuriModelProto.NUR1010Q00SelectMancntInfo.newBuilder();
				info.setManCnt(item.getCode());
				info.setWomanCnt(item.getCodeName());
				response.addListMancnt(info);
			}
		}
		
		return response.build();
	}
}
