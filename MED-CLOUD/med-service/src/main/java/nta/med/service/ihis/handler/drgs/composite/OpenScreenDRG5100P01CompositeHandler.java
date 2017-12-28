package nta.med.service.ihis.handler.drgs.composite;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.handler.drgs.DRG5100P01CheckActHandler;
import nta.med.service.ihis.handler.drgs.DrgsDRG5100P01GridPaidListHandler;
import nta.med.service.ihis.handler.system.FnDrgGetCycleOrdDateHandler;
import nta.med.service.ihis.handler.system.FormEnvironInfoSysDateHandler;
import nta.med.service.ihis.handler.system.GetPatientByCodeHandler;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

/**
 * @author DEV-TiepNM
 */
@Service
@Scope("prototype")
public class OpenScreenDRG5100P01CompositeHandler extends ScreenHandler<DrgsServiceProto.OpenScreenDRG5100P01CompositeRequest, DrgsServiceProto.OpenScreenDRG5100P01CompositeResponse>  {

    @Resource
    private DRG5100P01CheckActHandler drg5100P01CheckActHandler;

    @Resource
    private FormEnvironInfoSysDateHandler formEnvironInfoSysDateHandler;


    @Resource
    private DrgsDRG5100P01GridPaidListHandler drgsDRG5100P01GridPaidListHandler ;

    @Resource
    private GetPatientByCodeHandler getPatientByCodeHandler;


    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.OpenScreenDRG5100P01CompositeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.OpenScreenDRG5100P01CompositeRequest request) throws Exception {
        DrgsServiceProto.OpenScreenDRG5100P01CompositeResponse.Builder response = DrgsServiceProto.OpenScreenDRG5100P01CompositeResponse.newBuilder();

        for(DrgsServiceProto.DRG5100P01CheckActRequest item : request.getCheckActList())
        {
            response.addCheckAct(drg5100P01CheckActHandler.handle(vertx, clientId, sessionId, contextId, item));
        }

        for(SystemServiceProto.FormEnvironInfoSysDateRequest item : request.getSysDateList())
        {
            response.addSysDate(formEnvironInfoSysDateHandler.handle(vertx, clientId, sessionId, contextId, item));
        }

        for(DrgsServiceProto.DrgsDRG5100P01GridPaidListRequest item : request.getPaidListList())
        {
            response.addPaidList(drgsDRG5100P01GridPaidListHandler.handle(vertx, clientId, sessionId, contextId, item));
        }

        for(SystemServiceProto.GetPatientByCodeRequest item : request.getPatientBycodeList())
        {
            response.addPatientBycode(getPatientByCodeHandler.handle(vertx, clientId, sessionId, contextId, item));
        }

        return response.build();
    }
}
