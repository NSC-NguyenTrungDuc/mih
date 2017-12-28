package nta.med.service.ihis.handler.invs;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.inv.Inv0101Repository;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.service.ihis.proto.InvsServiceProto;

@Service
@Scope("prototype")
public class CheckData0101U01Handler extends ScreenHandler<InvsServiceProto.CheckData0101U01Request, InvsServiceProto.CheckData0101U01Response> {
    private static final Log LOGGER = LogFactory.getLog(CheckData0101U01Handler.class);
    
    @Resource
    private Inv0101Repository inv0101Repository;
    
	@Resource
    private Inv0102Repository inv0102Repository;

    @Override
    @Transactional(readOnly = true)
    public InvsServiceProto.CheckData0101U01Response handle(Vertx vertx, String clientId, String sessionId, long contextId, InvsServiceProto.CheckData0101U01Request request) throws Exception {
    	InvsServiceProto.CheckData0101U01Response.Builder response = InvsServiceProto.CheckData0101U01Response.newBuilder();
        String resultDel = inv0102Repository.checkDRG0102U00CheckExitToDelete(getHospitalCode(vertx, sessionId), request.getCodeType(), getLanguage(vertx, sessionId));
        if (!StringUtils.isEmpty(resultDel)) {
            response.setDelDetail(resultDel);
        }
        String resultMaster = inv0101Repository.checkDRG0102U00GrdMasterGridColumnChanged(request.getCodeType(), getLanguage(vertx, sessionId));
        if (!StringUtils.isEmpty(resultMaster)) {
            response.setCheckMaster(resultMaster);
        }
        String resultDetail = inv0102Repository.checkDrg0102U01GrdDetail(getHospitalCode(vertx, sessionId), request.getCodeType(), request.getCode(), getLanguage(vertx, sessionId));
        if (!StringUtils.isEmpty(resultDetail)) {
            response.setCheckDetail(resultDetail);
        }
        return response.build();
    }
}
