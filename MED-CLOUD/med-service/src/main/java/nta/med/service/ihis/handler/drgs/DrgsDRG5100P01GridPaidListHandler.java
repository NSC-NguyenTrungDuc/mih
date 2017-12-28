package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01PaidOrderListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;

import java.math.BigInteger;
import java.util.List;

@Service
@Scope("prototype")
public class DrgsDRG5100P01GridPaidListHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01GridPaidListRequest, DrgsServiceProto.DrgsDRG5100P01GridPaidListResponse> {
    private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01GridPaidListHandler.class);

    @Resource
    private Drg2010Repository drg2010Repository;

    @Override
    public boolean isValid(DrgsServiceProto.DrgsDRG5100P01GridPaidListRequest request, Vertx vertx, String clientId, String sessionId) {
        if(!StringUtils.isEmpty(request.getFromDate()) && DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD) == null){
            return false;
        } else if(!StringUtils.isEmpty(request.getToDate()) && DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD) == null){
            return false;
        }
        return true;
    }

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DrgsDRG5100P01GridPaidListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01GridPaidListRequest request) throws Exception {
        DrgsServiceProto.DrgsDRG5100P01GridPaidListResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01GridPaidListResponse.newBuilder();
        String hospitalCode = getHospitalCode(vertx, sessionId);
        if (request.getXrbOrderValue()) {
            List<DrgsDRG5100P01PaidOrderListItemInfo> listObject = drg2010Repository.getDrgsDRG5100P01PaidListItemInfo(hospitalCode,
                    request.getGwa(), DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD), DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD)
                    , request.getGubun(), request.getWonyoiYn(), request.getBunho(), false);
            if (!CollectionUtils.isEmpty(listObject)) {
                for (DrgsDRG5100P01PaidOrderListItemInfo item : listObject) {
                    DrgsModelProto.DrgsDRG5100P01GridPaidListItemInfo.Builder info = DrgsModelProto.DrgsDRG5100P01GridPaidListItemInfo.newBuilder();
                    BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                    if (item.getDrgBunho() != null) {
                        info.setDrgBunho(String.format("%.0f", item.getDrgBunho()));
                    }
                    if (new BigInteger("1").compareTo(item.getNumProtocol()) <= 0) {
	        			info.setTrialYn("Y");
	        		} else {
	        			info.setTrialYn("N");
	        		}
                    response.addPaidOrderList(info);
                }
            }
        } else {
            List<DrgsDRG5100P01PaidOrderListItemInfo> listObject = drg2010Repository.getDrgsDRG5100P01PaidListItemInfo(hospitalCode,
                    request.getGwa(), DateUtil.toDate(request.getFromDate(), DateUtil.PATTERN_YYMMDD), DateUtil.toDate(request.getToDate(), DateUtil.PATTERN_YYMMDD)
                    , request.getGubun(), request.getWonyoiYn(), request.getBunho(), true);
            if (!CollectionUtils.isEmpty(listObject)) {
                for (DrgsDRG5100P01PaidOrderListItemInfo item : listObject) {
                    DrgsModelProto.DrgsDRG5100P01GridPaidListItemInfo.Builder info = DrgsModelProto.DrgsDRG5100P01GridPaidListItemInfo.newBuilder();
                    BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                    if (item.getDrgBunho() != null) {
                        info.setDrgBunho(String.format("%.0f", item.getDrgBunho()));
                    }
                    if (new BigInteger("1").compareTo(item.getNumProtocol()) <= 0) {
	        			info.setTrialYn("Y");
	        		} else {
	        			info.setTrialYn("N");
	        		}
                    response.addPaidOrderList(info);
                }
            }
        }
        return response.build();
    }
}
