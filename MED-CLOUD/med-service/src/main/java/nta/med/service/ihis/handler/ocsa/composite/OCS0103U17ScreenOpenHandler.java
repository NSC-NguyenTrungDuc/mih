package nta.med.service.ihis.handler.ocsa.composite;

import javax.annotation.Resource;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.CommonEnum;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.handler.ocsa.OCS0103U12GrdSangyongOrderHandler;
import nta.med.service.ihis.handler.ocsa.OCS0103U12InitializeScreenHandler;
import nta.med.service.ihis.handler.ocsa.OCS0103U12MakeSangyongTabHandler;
import nta.med.service.ihis.handler.ocsa.OCS0103U12ScreenOpenHandler;
import nta.med.service.ihis.handler.ocsa.OCS0103U17LayHangwiGubunHandler;
import nta.med.service.ihis.handler.ocsa.OCS0103U17LoadHangwiOrder3Handler;
import nta.med.service.ihis.handler.ocsa.OCS0103U17MakeJaeryoGubunTabHandler;
import nta.med.service.ihis.handler.system.GetNextGroupSerHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U17ScreenOpenRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U17ScreenOpenResponse;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class OCS0103U17ScreenOpenHandler extends ScreenHandler<OcsaServiceProto.OCS0103U17ScreenOpenRequest, OcsaServiceProto.OCS0103U17ScreenOpenResponse> {
	private static final Log LOGGER = LogFactory.getLog(OCS0103U17ScreenOpenHandler.class);  
	
	@Resource
    private OCS0103U12InitializeScreenHandler oCS0103U12InitializeScreenHandler;
	
	@Resource
    private OCS0103U12ScreenOpenHandler oCS0103U12ScreenOpenHandler;
	
	@Resource
    private OCS0103U12MakeSangyongTabHandler oCS0103U12MakeSangyongTabHandler;
	
	@Resource
    private OCS0103U12GrdSangyongOrderHandler oCS0103U12GrdSangyongOrderHandler;
	
	@Resource
    private OCS0103U17LayHangwiGubunHandler oCS0103U17LayHangwiGubunHandler;
	
	@Resource
    private OCS0103U17MakeJaeryoGubunTabHandler oCS0103U17MakeJaeryoGubunTabHandler;
	
	@Resource
    private GetNextGroupSerHandler getNextGroupSerHandler;
	
	@Resource
    private OCS0103U17LoadHangwiOrder3Handler oCS0103U17LoadHangwiOrder3Handler;
	
	@Override
	@Transactional
	public OCS0103U17ScreenOpenResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS0103U17ScreenOpenRequest request) throws Exception {
		OcsaServiceProto.OCS0103U17ScreenOpenResponse.Builder response = OcsaServiceProto.OCS0103U17ScreenOpenResponse.newBuilder();
		OcsaServiceProto.OCS0103U12MakeSangyongTabRequest sangYongTabReq = request.getSangyongTabReqItem();
		
		OcsaServiceProto.OCS0103U12InitializeScreenResponse initResponse = null;
		OcsaServiceProto.OCS0103U12MakeSangyongTabResponse sangyongTabRes = null;
		OcsaServiceProto.OCS0103U17LayHangwiGubunResponse hangwiGubunRes = null;
		
//		OCS0103U12InitializeScreenRequest
		initResponse = oCS0103U12InitializeScreenHandler.handle(vertx, clientId, sessionId, contextId, request.getInitScreenReqItem());
		response.setInitScreenResItem(initResponse);
		// MakeSangyongTab
		if(CommonEnum.SETORDER.getValue().equalsIgnoreCase(request.getOrderMode())){
			if(initResponse != null && StringUtils.isEmpty(initResponse.getCodeName()) && !StringUtils.isEmpty(initResponse.getMainDoctorCode())){
				CommonModelProto.LoadOftenUsedTabInfo.Builder info = CommonModelProto.LoadOftenUsedTabInfo.newBuilder();
				info.setInputTab(sangYongTabReq.getRequestInfo().getInputTab());
				info.setMemb(initResponse.getMainDoctorCode());
				
				sangYongTabReq = sangYongTabReq.toBuilder()
											   .setRequestInfo(info)
											   .build();
			}
		}else{
			if(CommonEnum.DOCTOR.getValue().equalsIgnoreCase(request.getUserGubun())){
				CommonModelProto.LoadOftenUsedTabInfo.Builder info = CommonModelProto.LoadOftenUsedTabInfo.newBuilder();
				info.setInputTab(sangYongTabReq.getRequestInfo().getInputTab());
				info.setMemb(StringUtils.isEmpty(request.getDoctorId()) ? "" : request.getDoctorId());
				sangYongTabReq = sangYongTabReq.toBuilder()
											   .setRequestInfo(info)
											   .build();
			}else{
				CommonModelProto.LoadOftenUsedTabInfo.Builder info = CommonModelProto.LoadOftenUsedTabInfo.newBuilder();
				info.setInputTab(sangYongTabReq.getRequestInfo().getInputTab());
				info.setMemb(StringUtils.isEmpty(request.getUserId()) ? "" : request.getUserId());
				sangYongTabReq = sangYongTabReq.toBuilder()
											   .setRequestInfo(info)
											   .build();
			}
		}
		
		sangyongTabRes = oCS0103U12MakeSangyongTabHandler.handle(vertx, clientId, sessionId, contextId, sangYongTabReq);
        response.setSangyongTabResItem(sangyongTabRes);
		
//		OCS0103U12GrdSangyongOrderArgs
		OcsaServiceProto.OCS0103U12GrdSangyongOrderRequest sangYongOderReq = request.getSangyongOrderReqItem();
			if(!CollectionUtils.isEmpty(sangyongTabRes.getResultList())){
				sangYongOderReq = sangYongOderReq.toBuilder()
						 .setOrderGubun(sangyongTabRes.getResult(0).getOrderGubun())
						 .build();
			}
            response.setSangyongOrderResItem(oCS0103U12GrdSangyongOrderHandler.handle(vertx, clientId, sessionId, contextId, sangYongOderReq));
		
//		GetNextGroupser
		SystemServiceProto.GetNextGroupSerRequest nextGroupSerReq = request.getGroupserReqItem();
		if(!StringUtils.isEmpty(nextGroupSerReq.getBunho())){
			if(CommonEnum.O.getValue().equalsIgnoreCase(request.getSangyongOrderReqItem().getIoGubun())){
				nextGroupSerReq = nextGroupSerReq.toBuilder()
											.setKeyObj(CommonEnum.OCS1003.getValue())
											.build();
			}else{
				nextGroupSerReq = nextGroupSerReq.toBuilder()
											.setKeyObj(CommonEnum.OCS2003.getValue())
											.build();
			}
			response.setGroupserResItem(getNextGroupSerHandler.handle(vertx, clientId, sessionId, contextId, nextGroupSerReq));
		}
//      OCS0103U12ScreenOpenRequest
        response.setScrOpenResItem(oCS0103U12ScreenOpenHandler.handle(vertx, clientId, sessionId, contextId, request.getScrOpenReqItem()));
//      OCS0103U17LayHangwiGubunRequest
		hangwiGubunRes = oCS0103U17LayHangwiGubunHandler.handle(vertx, clientId, sessionId, contextId, request.getHangwiGubunReqItem());
        response.setHangwiGubunResItem(hangwiGubunRes);
//		OCS0103U17LoadHangwiOrder3Args
		OcsaServiceProto.OCS0103U17LoadHangwiOrder3Request hangwiOrderReq = request.getHangwiOrderReqItem();
		if(hangwiGubunRes != null){
			if(!CollectionUtils.isEmpty(hangwiGubunRes.getLayResultList())){
				hangwiOrderReq = hangwiOrderReq.toBuilder()
							.setSlipCode(hangwiGubunRes.getLayResult(0).getSlipCode())
							.setCodeYn(hangwiGubunRes.getLayResult(0).getCodeYn())
							.build();
			}
		}
	    response.setHangwiOrderResItem(oCS0103U17LoadHangwiOrder3Handler.handle(vertx, clientId, sessionId, contextId, hangwiOrderReq));
//	    OCS0103U17MakeJaeryoGubunTabRequest
        response.setJaeryoGubunResItem(oCS0103U17MakeJaeryoGubunTabHandler.handle(vertx, clientId, sessionId, contextId, request.getJaeryoGubunReqItem()));
		
		return response.build();
	}

}
