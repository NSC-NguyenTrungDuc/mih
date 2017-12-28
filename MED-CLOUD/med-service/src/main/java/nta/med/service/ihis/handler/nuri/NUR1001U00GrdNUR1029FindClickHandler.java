package nta.med.service.ihis.handler.nuri;

import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0102Repository;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1001U00GrdNUR1029FindClickHandler extends ScreenHandler<NuriServiceProto.NUR1001U00GrdNUR1029FindClickRequest, NuriServiceProto.NUR1001U00GrdNUR1029FindClickResponse> {

	@Resource
	private Nur0102Repository nur0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1001U00GrdNUR1029FindClickResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1001U00GrdNUR1029FindClickRequest request) throws Exception {
				
		NuriServiceProto.NUR1001U00GrdNUR1029FindClickResponse.Builder response = NuriServiceProto.NUR1001U00GrdNUR1029FindClickResponse.newBuilder();
		
		List<String> result = nur0102Repository.getNUR1001U00GrdNUR1029FindClick(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getCodeType());
		
		if(!CollectionUtils.isEmpty(result) && result.size() > 0){
			for(String item : result){
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
				info.setDataValue(item);
				response.addCodeName(info);
			}
		}
		
		return response.build();
	}
}
