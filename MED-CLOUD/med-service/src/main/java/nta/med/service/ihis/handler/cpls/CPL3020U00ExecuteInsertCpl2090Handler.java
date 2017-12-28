package nta.med.service.ihis.handler.cpls;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.cpl.Cpl2090;
import nta.med.data.dao.medi.cpl.Cpl2090Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00ExecuteInsertCpl2090Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.Date;

@Transactional
@Service
@Scope("prototype")
public class CPL3020U00ExecuteInsertCpl2090Handler extends ScreenHandler<CplsServiceProto.CPL3020U00ExecuteInsertCpl2090Request, SystemServiceProto.UpdateResponse> {
    @Resource
    private Cpl2090Repository cpl2090Repository;

    @Override
    public UpdateResponse handle(Vertx vertx, String clientId,
                                 String sessionId, long contextId,
                                 CPL3020U00ExecuteInsertCpl2090Request request) {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        try {

            String hospCode = getHospitalCode(vertx, sessionId);
            response.setResult(insertCPL3020U00(request, hospCode));

        } catch (Exception e) {
            response.setResult(false);
            throw new ExecutionException(response.build());
        }
        return response.build();
    }

    public boolean insertCPL3020U00(CplsServiceProto.CPL3020U00ExecuteInsertCpl2090Request request, String hospCode) {
        try {
            Cpl2090 cpl2090 = new Cpl2090();
            cpl2090.setSysDate(new Date());
            cpl2090.setSysId(request.getUserId());
            cpl2090.setUpdDate(new Date());
            cpl2090.setUpdId(request.getUserId());
            cpl2090.setHospCode(hospCode);
            cpl2090.setJundalPart(request.getJundalGubun());
            cpl2090.setSpecimenSer(request.getSpecimenSer());
            cpl2090.setCode(request.getCode());
            cpl2090.setNote(request.getNote());
            cpl2090.setEtcComment(request.getEtcComment());

            cpl2090Repository.save(cpl2090);
            return true;
        } catch (Exception e) {
            throw new ExecutionException();
        }
    }
}
