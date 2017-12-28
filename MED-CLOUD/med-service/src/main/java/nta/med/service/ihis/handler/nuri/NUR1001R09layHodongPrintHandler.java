package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0102Repository;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR1001R09layHodongPrintHandler extends ScreenHandler<NuriServiceProto.NUR1001R09layHodongPrintRequest, NuriServiceProto.NUR1001R09layHodongPrintResponse> {   
	
	@Resource
	private Nur0102Repository nur0102Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR1001R09layHodongPrintResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR1001R09layHodongPrintRequest request) throws Exception {
				
		NuriServiceProto.NUR1001R09layHodongPrintResponse.Builder response = NuriServiceProto.NUR1001R09layHodongPrintResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<String> result = nur0102Repository.getNUR1001R09layHodongPrint(hospCode, language, request.getHoDong());
		if(!CollectionUtils.isEmpty(result) && result.size() > 0){
			for(String item : result){
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
				info.setDataValue(item);
				response.addLayHodong(info);
			}
		}
		
		return response.build();
	}
}
