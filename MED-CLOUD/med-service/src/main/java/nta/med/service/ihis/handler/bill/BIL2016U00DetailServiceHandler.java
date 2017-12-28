package nta.med.service.ihis.handler.bill;

import nta.med.core.domain.bas.Bas0102;
import nta.med.core.domain.bill.Bil0001;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.bil.Bil0001Repository;
import nta.med.data.model.ihis.bill.BIL2016U00DetailServiceInfo;
import nta.med.data.model.ihis.ocsa.OCSAPPROVEGrdOrderInfo;
import nta.med.service.ihis.proto.BillModelProto;
import nta.med.service.ihis.proto.BillServiceProto;
import org.apache.commons.collections.CollectionUtils;
import org.apache.logging.log4j.util.Strings;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

/**
 * @author DEV-TiepNM
 */
@Service
@Scope("prototype")
public class BIL2016U00DetailServiceHandler extends ScreenHandler<BillServiceProto.BIL2016U00DetailServiceRequest, BillServiceProto.BIL2016U00DetailServiceResponse>  {
    @Resource
    private Bil0001Repository bil0001Repository;

    @Resource
    private Bas0102Repository bas0102Repository;

    @Override
    @Transactional(readOnly = true)
    public BillServiceProto.BIL2016U00DetailServiceResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, BillServiceProto.BIL2016U00DetailServiceRequest request) throws Exception {

        BillServiceProto.BIL2016U00DetailServiceResponse.Builder response = BillServiceProto.BIL2016U00DetailServiceResponse.newBuilder();

        List<Bil0001> bil0001s = bil0001Repository.findByHospCodeAndHangmogCode(getHospitalCode(vertx, sessionId), request.getHangmogCode());
        if(!CollectionUtils.isEmpty(bil0001s))
        {
            BillModelProto.BIL2016U00DetailServiceInfo.Builder info =  BillModelProto.BIL2016U00DetailServiceInfo.newBuilder();

            String hangmogCode  = bil0001s.get(0).getHangmogCode();
            BigDecimal insurancePrice  = bil0001s.get(0) != null ? bil0001s.get(0).getPrice1() : BigDecimal.ZERO;
            BigDecimal servicePrice = bil0001s.get(0) != null ? bil0001s.get(0).getPrice2() : BigDecimal.ZERO;
            BigDecimal foreignerPrice = bil0001s.get(0) != null ? bil0001s.get(0).getPrice3() : BigDecimal.ZERO;
            DecimalFormat df1 = new DecimalFormat("###.###");
            info.setHangmogCode(request.getHangmogCode());
            if(insurancePrice != null)
            {
                info.setInsurancePrice(df1.format(insurancePrice));
            }
            if(servicePrice != null)
            {
                info.setServicePrice(df1.format(servicePrice));
            }
            if(foreignerPrice != null)
            {
                info.setForeignerPrice(df1.format(foreignerPrice));
            }

            info.setHangmogCode(hangmogCode);

            response.setInfo(info);
        }

        return response.build();
    }
}
