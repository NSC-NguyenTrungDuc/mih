package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.out.Out1001;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.service.ihis.proto.NuroServiceProto;

/**
 * @author DEV-TiepNM
 */
@Service
@Scope("prototype")
public class NUR2015U01ReservationPatientHandler extends ScreenHandler<NuroServiceProto.NUR2015U01ReservationPatientRequest, NuroServiceProto.NUR2015U01ReservationPatientResponse> {
    @Resource
    private Out1001Repository out1001Repository;


    @Override
    @Transactional(readOnly = true)
    public NuroServiceProto.NUR2015U01ReservationPatientResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, NuroServiceProto.NUR2015U01ReservationPatientRequest request) throws Exception {
        NuroServiceProto.NUR2015U01ReservationPatientResponse.Builder response = NuroServiceProto.NUR2015U01ReservationPatientResponse.newBuilder();
        List<Out1001> out1001List = out1001Repository.findByHospCodeAndBunho(getHospitalCode(vertx, sessionId), request.getBunho());
        if (!CollectionUtils.isEmpty(out1001List)) {
        	response.setReservationId(out1001List.get(0).getPkout1001().toString());
        } else {
        	response.setReservationId("");
        }
        return response.build();
    }
}
