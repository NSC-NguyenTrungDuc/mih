package nta.med.service.ihis.handler.nuro;

import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.Out1003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

/**
 * @author DEV-TiepNM
 */

@Service
@Scope("prototype")
@Transactional
public class NUROAccountForcedEndHandler extends ScreenHandler<NuroServiceProto.NUROAccountForcedEndRequest, NuroServiceProto.NUROAccountForcedEndResponse> {

    @Resource
    Ocs1003Repository ocs1003Repository;

    @Resource
    Out1003Repository out1003Repository;

    @Override
    public NuroServiceProto.NUROAccountForcedEndResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, NuroServiceProto.NUROAccountForcedEndRequest request) throws Exception {
        String hospCode = getHospitalCode(vertx, sessionId);
        List<NuroModelProto.NUROAccountForcedEndInfo> listInfo = request.getListInfoList();

        NuroServiceProto.NUROAccountForcedEndResponse.Builder response = NuroServiceProto.NUROAccountForcedEndResponse.newBuilder();


        Integer pkOut1003 = out1003Repository.callPrIfsOutOrderMasterInsert(hospCode, request.getBunho(),
                DateUtil.toDate(request.getActingDate(), DateUtil.PATTERN_DDMMYYYY), request.getGubun(), request.getGwa(), request.getDoctor(), request.getChojae());


        if(pkOut1003 == null || pkOut1003 <= 0){
            response.setResult(false);
            return response.build();
        }

        for (NuroModelProto.NUROAccountForcedEndInfo info : listInfo) {
            ocs1003Repository.updateORDERTRANOcs1003Update(DateUtil.toDate(info.getSunabDate(),
                    DateUtil.PATTERN_DDMMYYYY), CommonUtils.parseDouble(String.valueOf(pkOut1003)), CommonUtils.parseDouble(info.getPkocs1003()),hospCode);
        }

        response.setResult(true);
        response.setStrOutput(String.valueOf(pkOut1003));
        return response.build();


    }
}
