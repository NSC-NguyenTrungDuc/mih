package nta.med.service.emr.handler.composite;

import javax.annotation.Resource;

import org.vertx.java.core.Vertx;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.handler.OCS2015U00GetPatientInfoHandler;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.OCSACT2CompositeSecondRequest;
import nta.med.service.emr.proto.EmrServiceProto.OCSACT2CompositeSecondResponse;
import nta.med.service.ihis.handler.cpls.CplsCPL2010U00CheckInjCplOrderCPL2010Handler;
import nta.med.service.ihis.handler.injs.InjsINJ1001U01DetailListHandler;
import nta.med.service.ihis.handler.nuri.NUR1016U00GrdNUR1016Handler;
import nta.med.service.ihis.handler.nuri.NUR1017U00GrdNUR1017Handler;
import nta.med.service.ihis.handler.nuro.OUT0106U00GridListHandler;
import nta.med.service.ihis.handler.nuro.OcsLoadInputTabHandler;
import nta.med.service.ihis.handler.nuro.composite.OcsLoadInputAndVisibleControlHandler;
import nta.med.service.ihis.handler.system.GetPatientByCodeHandler;

@Service                                                                                                          
@Scope("prototype")
public class OCSACT2CompositeSecondHandler extends ScreenHandler<EmrServiceProto.OCSACT2CompositeSecondRequest, EmrServiceProto.OCSACT2CompositeSecondResponse>{
	private static final Log LOGGER = LogFactory.getLog(OCSACT2CompositeSecondHandler.class); 
	
	@Resource                                                                                                       
	private OCS2015U00GetPatientInfoHandler cCS2015U00GetPatientInfoHandler;
	@Resource
	private NUR1016U00GrdNUR1016Handler nUR1016U00GrdNUR1016Handler;
	@Resource
	private NUR1017U00GrdNUR1017Handler nUR1017U00GrdNUR1017Handler;
	@Resource
	private OUT0106U00GridListHandler oUT0106U00GridListHandler;
	@Resource
	private GetPatientByCodeHandler getPatientByCodeHandler;
	@Resource
	private OcsLoadInputAndVisibleControlHandler oCSLoadinputAndVisibleControlHandler;
	@Resource
	private OcsLoadInputTabHandler oCSLoadInputTabHandler;
	@Resource
	private InjsINJ1001U01DetailListHandler injsINJ1001U01DetailListHandler;
	@Resource
	private CplsCPL2010U00CheckInjCplOrderCPL2010Handler cplsCPL2010U00CheckInjCplOrderCPL2010Handler;

	@Override
	@Transactional(readOnly = true)
	public OCSACT2CompositeSecondResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCSACT2CompositeSecondRequest request) throws Exception {
		EmrServiceProto.OCSACT2CompositeSecondResponse.Builder response = EmrServiceProto.OCSACT2CompositeSecondResponse.newBuilder();
		//1
		response.setGetPatientInfoRes(cCS2015U00GetPatientInfoHandler.handle(vertx, clientId, sessionId, contextId, request.getGetPatientInfo()));
		//2
		response.setGrdNur1016Res(nUR1016U00GrdNUR1016Handler.handle(vertx, clientId, sessionId, contextId, request.getGrdNur1016()));
		//3
		response.setGrdNur1017Res(nUR1017U00GrdNUR1017Handler.handle(vertx, clientId, sessionId, contextId, request.getGrdNur1017()));
		//4
		response.setGrdListOut0106U00Res(oUT0106U00GridListHandler.handle(vertx, clientId, sessionId, contextId, request.getGrdListOut0106U00()));
		//5
		response.setGetPatientBycodeRes(getPatientByCodeHandler.handle(vertx, clientId, sessionId, contextId, request.getGetPatientBycode()));
		//6
		response.setInputVisibleRes(oCSLoadinputAndVisibleControlHandler.handle(vertx, clientId, sessionId, contextId, request.getInputVisible()));
		//7
		response.setInputTabRes(oCSLoadInputTabHandler.handle(vertx, clientId, sessionId, contextId, request.getInputTab()));
		//8
		response.setDetailListRes(injsINJ1001U01DetailListHandler.handle(vertx, clientId, sessionId, contextId, request.getDetailList()));
		//9
		response.setCheckInjRes(cplsCPL2010U00CheckInjCplOrderCPL2010Handler.handle(vertx, clientId, sessionId, contextId, request.getCheckInj()));
		
		return response.build();
	}

}
