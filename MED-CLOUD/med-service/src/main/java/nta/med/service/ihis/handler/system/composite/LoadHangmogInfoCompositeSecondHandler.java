package nta.med.service.ihis.handler.system.composite;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.handler.system.*;
import nta.med.service.ihis.proto.SystemServiceProto;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

/**
 * @author dainguyen.
 */
@Service
@Scope("prototype")
public class LoadHangmogInfoCompositeSecondHandler extends ScreenHandler<SystemServiceProto.LoadHangmogInfoCompositeSecondRequest, SystemServiceProto.LoadHangmogInfoCompositeSecondResponse> {

    @Resource
    private GetMsgInsulinHandler getMsgInsulinHandler;

    @Resource
    private HIOcsCheckJundalPartLoadJaeryoJundalHandler hiOcsCheckJundalPartLoadJaeryoJundalHandler;

    @Resource
    private HIOcsBogyongHandler hiOcsBogyongHandler;

    @Resource
    private HIOcsSpecificCommentHandler hiOcsSpecificCommentHandler;

    @Resource
    private HILoadCodeNameHandler hiLoadCodeNameHandler;
    
    @Resource
    private LoadColumnCodeNameHandler loadColumnCodeNameHandler;
    
    @Resource
    private OBCheckSpecialDrugForPatientHandler oBCheckSpecialDrugForPatientHandler;
    
    @Resource
    private OBCheckRegularDrugHandler oBCheckRegularDrugHandler;
    
    @Resource
    private HIGetGenericNameHandler hIGetGenericNameHandler;
    
    @Resource
    private OBGetBogyongInfo2Handler oBGetBogyongInfo2Handler;

    @Override
    @Transactional(readOnly = true)
    public SystemServiceProto.LoadHangmogInfoCompositeSecondResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, SystemServiceProto.LoadHangmogInfoCompositeSecondRequest request) throws Exception {
        SystemServiceProto.LoadHangmogInfoCompositeSecondResponse.Builder response = SystemServiceProto.LoadHangmogInfoCompositeSecondResponse.newBuilder();

        for (SystemServiceProto.GetMsgInsulinRequest item : request.getMsgInsulinList()) {
            response.addMsgInsulin(getMsgInsulinHandler.handle(vertx, clientId, sessionId, contextId, item));
        }

        for (SystemServiceProto.HIOcsCheckJundalPartLoadJaeryoJundalRequest item : request.getOcsCheckJundalPartLoadJaeryoJundalList()) {
            response.addOcsCheckJundalPartLoadJaeryoJundal(hiOcsCheckJundalPartLoadJaeryoJundalHandler.handle(vertx, clientId, sessionId, contextId, item));
        }

        for (SystemServiceProto.HIOcsBogyongRequest item : request.getOcsBogyongList()) {
            response.addOcsBogyong(hiOcsBogyongHandler.handle(vertx, clientId, sessionId, contextId, item));
        }

        for (SystemServiceProto.HIOcsSpecificCommentRequest item : request.getOcsSpecificCommentList()) {
            response.addOcsSpecificComment(hiOcsSpecificCommentHandler.handle(vertx, clientId, sessionId, contextId, item));
        }

        for (SystemServiceProto.HILoadCodeNameRequest item : request.getLoadCodeNameList()) {
            response.addLoadCodeName(hiLoadCodeNameHandler.handle(vertx, clientId, sessionId, contextId, item));
        }
        
        for(SystemServiceProto.LoadColumnCodeNameRequest item : request.getLoadColumnCodeNameList()){
        	response.addLoadColumnCodeName(loadColumnCodeNameHandler.handle(vertx, clientId, sessionId, contextId, item));
        }
        
        for(SystemServiceProto.OBCheckSpecialDrugForPatientRequest item : request.getCheckSpecialDrugForPatientList()){
        	response.addCheckSpecialDrugForPatient(oBCheckSpecialDrugForPatientHandler.handle(vertx, clientId, sessionId, contextId, item));
        }
        
        for(SystemServiceProto.OBCheckRegularDrugRequest item : request.getCheckRegularDrugList()){
        	response.addCheckRegularDrug(oBCheckRegularDrugHandler.handle(vertx, clientId, sessionId, contextId, item));
        }
        
        for(SystemServiceProto.HIGetGenericNameRequest item : request.getGetGenericNameList()){
        	response.addGetGenericName(hIGetGenericNameHandler.handle(vertx, clientId, sessionId, contextId, item));
        }
        
        for(SystemServiceProto.OBGetBogyongInfo2Request item : request.getGetBogyongInfo2List()){
        	response.addGetBogyongInfo2(oBGetBogyongInfo2Handler.handle(vertx, clientId, sessionId, contextId, item));
        }
        return response.build();
    }
}
