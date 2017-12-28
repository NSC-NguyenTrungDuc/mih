package nta.med.service.ihis.handler.ocso.composite;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.handler.ocso.OCSACT2GetComboUserHandler;
import nta.med.service.ihis.handler.ocso.OCSACT2GetGrdPaListHandler;
import nta.med.service.ihis.handler.ocso.OCSACTCboSystemSelectedIndexChangedHandler;
import nta.med.service.ihis.handler.ocso.OCSACTCboTimeAndSystemHandler;
import nta.med.service.ihis.handler.ocso.OCSACTLayconstantAlarmHandler;
import nta.med.service.ihis.handler.ocso.OCSACTLayconstantConstHandler;
import nta.med.service.ihis.proto.OcsoModelProto.OCSACT2GetGrdPaListInfo;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OCSACT2CompositeRequest;
import nta.med.service.ihis.proto.OcsoServiceProto.OCSACT2CompositeResponse;
import nta.med.service.ihis.proto.OcsoServiceProto.OCSACT2GetComboUserRequest;

@Service                                                                                                          
@Scope("prototype") 
public class OCSACT2CompositeHandler  extends ScreenHandler<OcsoServiceProto.OCSACT2CompositeRequest, OcsoServiceProto.OCSACT2CompositeResponse>{

	private static final Log LOGGER = LogFactory.getLog(OCSACT2CompositeHandler.class);                                    
	@Resource                                                                                                       
	private OCSACTCboTimeAndSystemHandler oCSACTCboTimeAndSystemHandler; 
	@Resource                                                                                                       
	private OCSACT2GetComboUserHandler oCSACT2GetComboUserHandler; 
	@Resource                                                                                                       
	private OCSACT2GetGrdPaListHandler oCSACT2GetGrdPaListHandler; 
	@Resource                                                                                                       
	private OCSACTCboSystemSelectedIndexChangedHandler oCSACTCboSystemSelectedIndexChangedHandler; 
	@Resource                                                                                                       
	private OCSACTLayconstantConstHandler oCSACTLayconstantConstHandler; 
	@Resource                                                                                                       
	private OCSACTLayconstantAlarmHandler oCSACTLayconstantAlarmHandler;
	
	@Override
	@Transactional(readOnly = true)
	public OCSACT2CompositeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCSACT2CompositeRequest request) throws Exception {
		OcsoServiceProto.OCSACT2CompositeResponse.Builder response = OcsoServiceProto.OCSACT2CompositeResponse.newBuilder(); 
		response.setCboTimeAndSysRes(oCSACTCboTimeAndSystemHandler.handle(vertx, clientId, sessionId, contextId, request.getCboTimeAndSys()));
		//1
		response.setGrdPaListRes(oCSACT2GetGrdPaListHandler.handle(vertx, clientId, sessionId, contextId, request.getGrdPaList()));
		
		List<OCSACT2GetGrdPaListInfo> grdPaListInfo = response.getGrdPaListRes().getPaItemList();
		
		if (!CollectionUtils.isEmpty(grdPaListInfo)) {
			OCSACT2GetGrdPaListInfo firstItem = grdPaListInfo.get(0);
			
			OCSACT2GetComboUserRequest getComboUserRequest = OCSACT2GetComboUserRequest.newBuilder()
					.setJundalTable(firstItem.getJundalTable())
					.setHospCode(getHospitalCode(vertx, sessionId))
					.build();
			response.setCboUserRes(oCSACT2GetComboUserHandler.handle(vertx, clientId, sessionId, contextId, getComboUserRequest));
		} else {
			response.setCboUserRes(oCSACT2GetComboUserHandler.handle(vertx, clientId, sessionId, contextId, request.getCboUser()));
		}
		
		response.setCboSelectedIndexChangeRes(oCSACTCboSystemSelectedIndexChangedHandler.handle(vertx, clientId, sessionId, contextId, request.getCboSelectedIndexChange()));
		
		response.setLayConstantConsRes(oCSACTLayconstantConstHandler.handle(vertx, clientId, sessionId, contextId, request.getLayConstantCons()));
		
		response.setLayConstantRes(oCSACTLayconstantAlarmHandler.handle(vertx, clientId, sessionId, contextId, request.getLayConstantAlarm()));
		return response.build();
	}

}
