package nta.med.service.ihis.handler.bass;

import nta.med.data.dao.medi.bas.Bas0123Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.List;

/**
 * @author Tiepnm
 */
@Transactional(readOnly = true)
@Service
@Scope("prototype")
public class BAS0111U00VzvZipCodeHandler extends ScreenHandler<BassServiceProto.BAS0111U00VzvZipCodeRequest, BassServiceProto.BAS0111U00VzvZipCodeResponse> {

    @Resource
    private Bas0123Repository bas0123Repository;

    @Override
    public BassServiceProto.BAS0111U00VzvZipCodeResponse handle(Vertx vertx, String clientId, String sessionId,
                                                            long contextId, BassServiceProto.BAS0111U00VzvZipCodeRequest request) throws Exception {
        BassServiceProto.BAS0111U00VzvZipCodeResponse.Builder response = BassServiceProto.BAS0111U00VzvZipCodeResponse.newBuilder();
        List<String> listResult = bas0123Repository.getZipNameByZipCode(request.getFZip1(), request.getFZip2());

        if (!CollectionUtils.isEmpty(listResult)) {
            for (String layVzvItemInfo : listResult) {
                BassModelProto.BAS0111U00LayVzvItemInfo.Builder bas0111U00LayVzvItemInfo = BassModelProto.BAS0111U00LayVzvItemInfo.newBuilder();
                if (!StringUtils.isEmpty(layVzvItemInfo)) {
                    bas0111U00LayVzvItemInfo.setName(layVzvItemInfo);
                }
                response.addDt(bas0111U00LayVzvItemInfo);

            }

        }
        return response.build();

    }
}
