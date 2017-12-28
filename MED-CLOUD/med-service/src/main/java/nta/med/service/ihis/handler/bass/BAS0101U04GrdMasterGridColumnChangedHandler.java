package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.data.dao.medi.bas.Bas0101Repository;
import nta.med.data.model.ihis.bass.BAS0101U00PrBasGridColumnChangedItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0101U04GrdMasterGridColumnChangedRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0101U04GrdMasterGridColumnChangedResponse;

@Service                                                                                                          
@Scope("prototype")
@Transactional
public class BAS0101U04GrdMasterGridColumnChangedHandler extends ScreenHandler<BassServiceProto.BAS0101U04GrdMasterGridColumnChangedRequest, BassServiceProto.BAS0101U04GrdMasterGridColumnChangedResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(BAS0101U04GrdMasterGridColumnChangedHandler.class);        
	
	@Resource                                                                                                       
	private Bas0101Repository bas0101Repository;
	
	@Override                                                                                                       
	public BAS0101U04GrdMasterGridColumnChangedResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			BAS0101U04GrdMasterGridColumnChangedRequest request)
			throws Exception {                                                                   
		BassServiceProto.BAS0101U04GrdMasterGridColumnChangedResponse.Builder response = BassServiceProto.BAS0101U04GrdMasterGridColumnChangedResponse.newBuilder();                      
		BAS0101U00PrBasGridColumnChangedItemInfo info = bas0101Repository.callPrBasGridColumnChanged(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getMasterCheck(), request.getCodeType(), request.getColId());
		if(info != null){
			if(!StringUtils.isEmpty(info.getDupYn())){
				response.setDupYn(info.getDupYn());
			}
			if(!StringUtils.isEmpty(info.getError())){
				response.setIoError(info.getError());
			}
		}

		return response.build();
	}

}
