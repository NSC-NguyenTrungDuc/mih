package nta.med.service.emr.handler;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.clis.ClisProtocolPatientRepository;
import nta.med.data.model.ihis.emr.EMRGetLatestWarningStatusInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

/**
 * @author Tiepnm
 */
@Service
@Scope("prototype")
public class EMRGetLatestWarningStatusHandler extends ScreenHandler<EmrServiceProto.EMRGetLatestWarningStatusRequest, EmrServiceProto.EMRGetLatestWarningStatusResponse> {

    @Resource
    ClisProtocolPatientRepository clisProtocolPatientRepository;

    @Override
    @Transactional(readOnly = true)
    public EmrServiceProto.EMRGetLatestWarningStatusResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, EmrServiceProto.EMRGetLatestWarningStatusRequest request) throws Exception {
        EmrServiceProto.EMRGetLatestWarningStatusResponse.Builder response = EmrServiceProto.EMRGetLatestWarningStatusResponse.newBuilder();
        EMRGetLatestWarningStatusInfo emrGetLatestWarningStatusInfo = clisProtocolPatientRepository.getLatestWarningStatusInfo(getHospitalCode(vertx, sessionId), request.getBunho());
        EmrModelProto.EMRGetLatestWarningStatusInfo.Builder builder = EmrModelProto.EMRGetLatestWarningStatusInfo.newBuilder();
        if(emrGetLatestWarningStatusInfo != null){
        	 if (emrGetLatestWarningStatusInfo.getDisplayFlg() == null || !emrGetLatestWarningStatusInfo.getDisplayFlg().equals("Y") ||
                     emrGetLatestWarningStatusInfo.getUpdated() == null) {
                 emrGetLatestWarningStatusInfo.setCodeName(null);
             }
        	 BeanUtils.copyProperties(emrGetLatestWarningStatusInfo, builder, getLanguage(vertx, sessionId));
        }
        response.setWarningStatusInfo(builder);
        return response.build();
    }
}
