package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.model.ihis.drgs.DRG0201U00GrdPaidInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.math.BigInteger;
import java.util.List;

@Service
@Scope("prototype")
public class DRG0201U00GrdPaidHandler extends ScreenHandler<DrgsServiceProto.DRG0201U00GrdPaidRequest, DrgsServiceProto.DRG0201U00GrdPaidResponse> {
    private static final Log LOG = LogFactory.getLog(DRG0201U00GrdPaidHandler.class);
    @Resource
    private Drg2010Repository drg2010Repository;

    @Override
    public boolean isValid(DrgsServiceProto.DRG0201U00GrdPaidRequest request, Vertx vertx, String clientId, String sessionId) {
        if(!StringUtils.isEmpty(request.getOrderDate()) && DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD) == null){
            return false;
        }
        return true;
    }

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DRG0201U00GrdPaidResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0201U00GrdPaidRequest request) throws Exception {
        DrgsServiceProto.DRG0201U00GrdPaidResponse.Builder response = DrgsServiceProto.DRG0201U00GrdPaidResponse.newBuilder();
        List<DRG0201U00GrdPaidInfo> listObject = null;
        String hospitalCode = getHospitalCode(vertx, sessionId);
        if (request.getBunho().isEmpty()) {
            listObject = drg2010Repository.getDrg0201u00GridPaidInfo(hospitalCode, DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD), null, request.getGubun());
        } else {
            listObject = drg2010Repository.getDrg0201u00GridPaidInfo(hospitalCode, DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD), request.getBunho(), request.getGubun());
        }
        if (!CollectionUtils.isEmpty(listObject)) {
            for (DRG0201U00GrdPaidInfo item : listObject) {
                DrgsModelProto.DRG0201U00GrdPaidInfo.Builder info = DrgsModelProto.DRG0201U00GrdPaidInfo.newBuilder();
                if (item.getDrgBunho() != null) {
                    info.setDrgBunho(String.format("%.0f", item.getDrgBunho()));
                }
                if (!StringUtils.isEmpty(item.getBunho())) {
                    info.setBunho(item.getBunho());
                }
                if (item.getOrderDate() != null) {
                    info.setOrderDate(DateUtil.toString(item.getOrderDate(), DateUtil.PATTERN_YYMMDD));
                }
                if (!StringUtils.isEmpty(item.getJojeYn())) {
                    info.setJojeYn(item.getJojeYn());
                }
                if (!StringUtils.isEmpty(item.getSuname())) {
                    info.setSuname(item.getSuname());
                }
                if (!StringUtils.isEmpty(item.getOrderRemark())) {
                    info.setOrderRemark(item.getOrderRemark());
                }
                if (!StringUtils.isEmpty(item.getDrgRemark())) {
                    info.setDrgRemark(item.getDrgRemark());
                }
                if (new BigInteger("1").compareTo(item.getNumProtocol()) <= 0) {
        			info.setTrialYn("Y");
        		} else {
        			info.setTrialYn("N");
        		}
                response.addGrdPaidItem(info);
            }
        }
        return response.build();
    }
}
