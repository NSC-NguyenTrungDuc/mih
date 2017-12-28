package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0102;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1123U00grdMasterCheckRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1123U00grdMasterCheckResponse;

@Service                                                                                                          
@Scope("prototype")
public class NUR1123U00grdMasterCheckHandler extends ScreenHandler<NuriServiceProto.NUR1123U00grdMasterCheckRequest, NuriServiceProto.NUR1123U00grdMasterCheckResponse> {                     
	
	@Resource                                   
	private Nur0102Repository nur0102Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR1123U00grdMasterCheckResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1123U00grdMasterCheckRequest request) throws Exception {
		
		NuriServiceProto.NUR1123U00grdMasterCheckResponse.Builder response = NuriServiceProto.NUR1123U00grdMasterCheckResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		
		List<Nur0102> listInfo = nur0102Repository.findByCodeTypeLanguage(hospCode, "WATCH_TEMPLATE", getLanguage(vertx, sessionId));
		response.setCheckresult(!CollectionUtils.isEmpty(listInfo) ? "Y" : "");
		
		return response.build();
	}
}
