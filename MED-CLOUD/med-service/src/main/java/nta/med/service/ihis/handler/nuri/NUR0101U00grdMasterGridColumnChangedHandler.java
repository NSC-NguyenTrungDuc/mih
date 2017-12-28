package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur0101Repository;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR0101U00grdMasterGridColumnChangedHandler extends ScreenHandler<NuriServiceProto.NUR0101U00grdMasterGridColumnChangedRequest, NuriServiceProto.NUR0101U00grdMasterGridColumnChangedResponse> {   
	
	@Resource                                   
	private Nur0101Repository nur0101Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR0101U00grdMasterGridColumnChangedResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR0101U00grdMasterGridColumnChangedRequest request) throws Exception {
				
		NuriServiceProto.NUR0101U00grdMasterGridColumnChangedResponse.Builder response = NuriServiceProto.NUR0101U00grdMasterGridColumnChangedResponse.newBuilder();
		
		String language = getLanguage(vertx, sessionId);		
		String result = nur0101Repository.getNUR0101U00grdMasterGridColumnChanged(language, request.getCodeType());
		
		CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
		info.setDataValue(result);		
		response.setRetvalItem(info);
		
		return response.build();
	}
}