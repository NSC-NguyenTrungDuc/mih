package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCSACTBtnReserViewerClickHandler extends ScreenHandler<OcsoServiceProto.OCSACTBtnReserViewerClickRequest, OcsoServiceProto.OCSACTSingleStringResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCSACTBtnReserViewerClickHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCSACTSingleStringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCSACTBtnReserViewerClickRequest request) throws Exception {
		OcsoServiceProto.OCSACTSingleStringResponse.Builder response = OcsoServiceProto.OCSACTSingleStringResponse.newBuilder();
		List<String> listMint = ocs0132Repository.getMintByCodeAndCodeType(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "OCS_ACT_SYSTEM", request.getCode());
		if(!CollectionUtils.isEmpty(listMint)){
			String mint = listMint.get(0);
			if(!StringUtils.isEmpty(mint)){
				response.setResponseStr(mint);
			}
		}
		return response.build();
	}                                                                                                                 
}