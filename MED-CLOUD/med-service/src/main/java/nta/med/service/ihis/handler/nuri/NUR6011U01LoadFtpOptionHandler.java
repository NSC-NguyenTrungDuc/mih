package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR6011U01LoadFtpOptionHandler extends ScreenHandler<NuriServiceProto.NUR6011U01LoadFtpOptionRequest, SystemServiceProto.StringResponse> {   
	
	@Resource                                   
	private Nur0102Repository nur0102Repository;

	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR6011U01LoadFtpOptionRequest request) throws Exception {
				
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		String result = nur0102Repository.getNUR0102CodeName(hospCode, language, "FTP_OPTION", request.getGubun().toUpperCase());
		response.setResult(result);
		
		return response.build();
	}
}