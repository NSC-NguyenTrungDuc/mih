package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur1123;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.nur.Nur1123Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1123U00grdDetailCheckRequest;
import nta.med.service.ihis.proto.NuriServiceProto.NUR1123U00grdDetailCheckResponse;

@Service                                                                                                          
@Scope("prototype")
public class NUR1123U00grdDetailCheckHandler extends ScreenHandler<NuriServiceProto.NUR1123U00grdDetailCheckRequest, NuriServiceProto.NUR1123U00grdDetailCheckResponse> {                     
	
	@Resource                                   
	private Nur1123Repository nur1123Repository;

	@Override
	@Transactional(readOnly = true)
	public NUR1123U00grdDetailCheckResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR1123U00grdDetailCheckRequest request) throws Exception {
		
		NuriServiceProto.NUR1123U00grdDetailCheckResponse.Builder response = NuriServiceProto.NUR1123U00grdDetailCheckResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String codeType = request.getCodeType();
		String code = request.getCode();
		
		List<Nur1123> listInfo = nur1123Repository.findByHospCodeAndCodeTypeAndCode(hospCode, codeType, code);
		response.setGrdDetailCheckresult(!CollectionUtils.isEmpty(listInfo) ? "Y" : "");
		
		return response.build();
	}
}
