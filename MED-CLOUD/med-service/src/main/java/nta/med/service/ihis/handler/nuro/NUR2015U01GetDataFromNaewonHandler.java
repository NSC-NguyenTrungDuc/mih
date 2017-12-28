package nta.med.service.ihis.handler.nuro;

import nta.med.core.domain.out.Out1001;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.service.ihis.proto.NuroServiceProto;
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
public class NUR2015U01GetDataFromNaewonHandler  extends ScreenHandler<NuroServiceProto.NUR2015U01GetDataFromNaewonRequest, NuroServiceProto.NUR2015U01GetDataFromNaewonResponse>  {
    @Resource
    private Out1001Repository out1001Repository;

    @Override
    @Transactional(readOnly = true)
    public NuroServiceProto.NUR2015U01GetDataFromNaewonResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, NuroServiceProto.NUR2015U01GetDataFromNaewonRequest request) throws Exception {
        Out1001 out1001 = out1001Repository.findByHospCodeAndPkOut1001(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(request.getNaewonKey()));
        NuroServiceProto.NUR2015U01GetDataFromNaewonResponse.Builder response =  NuroServiceProto.NUR2015U01GetDataFromNaewonResponse.newBuilder();
        if(out1001 != null)
        {
            response.setExamDate(DateUtil.toString(out1001.getNaewonDate(), DateUtil.PATTERN_YYMMDD));
            response.setDepartmentCode(out1001.getGwa());

        }
        return response.build();
    }
}
