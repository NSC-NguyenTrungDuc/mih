package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.data.dao.medi.nur.Nur0101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuriServiceProto;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR0101U01GrdMasterGridColumnChangedHandler extends ScreenHandler<NuriServiceProto.NUR0101U01GrdMasterGridColumnChangedRequest, NuriServiceProto.NUR0101U01CheckYResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(NUR0101U01GrdMasterGridColumnChangedHandler.class);
	
	@Resource                                   
	private Nur0101Repository nur0101Repository;
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR0101U01CheckYResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NUR0101U01GrdMasterGridColumnChangedRequest request) throws Exception {
		NuriServiceProto.NUR0101U01CheckYResponse.Builder response = NuriServiceProto.NUR0101U01CheckYResponse.newBuilder();   
		String result = nur0101Repository.getNUR0101U01ExecuteTDupCheck(request.getCodeType(), getLanguage(vertx, sessionId));
		if(!StringUtils.isEmpty(result)){
			response.setYValue(result);
		}
		return response.build();
	}
}