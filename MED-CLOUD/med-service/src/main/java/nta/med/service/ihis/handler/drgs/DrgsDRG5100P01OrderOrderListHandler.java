package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01OrderOrderListItemInfo;
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
import java.util.List;

@Service
@Scope("prototype")
public class DrgsDRG5100P01OrderOrderListHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01OrderOrderListRequest, DrgsServiceProto.DrgsDRG5100P01OrderOrderListResponse> {
    private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01OrderOrderListHandler.class);
    @Resource
    private Drg2010Repository drg2010Repository;

    @Override
    public boolean isValid(DrgsServiceProto.DrgsDRG5100P01OrderOrderListRequest request, Vertx vertx, String clientId, String sessionId) {
        if(!StringUtils.isEmpty(request.getOrderDate()) && DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD) == null){
            return false;
        }
        return true;
    }

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DrgsDRG5100P01OrderOrderListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01OrderOrderListRequest request) throws Exception {
        DrgsServiceProto.DrgsDRG5100P01OrderOrderListResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01OrderOrderListResponse.newBuilder();
        String hospitalCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        List<DrgsDRG5100P01OrderOrderListItemInfo> listObject = drg2010Repository.getDrgsDRG5100P01OrderOrderListItemInfo(hospitalCode,
                language, request.getOrderDate(), request.getDrgBunho(), request.getGubun());
        if (!CollectionUtils.isEmpty(listObject)) {
            for (DrgsDRG5100P01OrderOrderListItemInfo item : listObject) {
                DrgsModelProto.DrgsDRG5100P01OrderOrderListItemInfo.Builder info = DrgsModelProto.DrgsDRG5100P01OrderOrderListItemInfo.newBuilder();
                if (item.getDrgBunho() != null) {
                    info.setDrgBunho(String.format("%.0f", item.getDrgBunho()));
                }
                if (!StringUtils.isEmpty(item.getBunho())) {
                    info.setBunho(item.getBunho());
                }
                if (!StringUtils.isEmpty(item.getOrderDate())) {
                    info.setOrderDate(DateUtil.toString(item.getOrderDate(), DateUtil.PATTERN_YYMMDD));
                }
                if (!StringUtils.isEmpty(item.getJubsuDate())) {
                    info.setJubsuDate(DateUtil.toString(item.getJubsuDate(), DateUtil.PATTERN_YYMMDD));
                }
                if (!StringUtils.isEmpty(item.getDrgJubsuDate())) {
                    info.setDrgJubsuDate(DateUtil.toString(item.getDrgJubsuDate(), DateUtil.PATTERN_YYMMDD));
                }
                if (!StringUtils.isEmpty(item.getJubsuTime())) {
                    info.setJubsuTime(item.getJubsuTime());
                }
                if (!StringUtils.isEmpty(item.getDoctor())) {
                    info.setDoctor(item.getDoctor());
                }
                if (!StringUtils.isEmpty(item.getDoctorName())) {
                    info.setDoctorName(item.getDoctorName());
                }
                if (!StringUtils.isEmpty(item.getGwa())) {
                    info.setGwa(item.getGwa());
                }
                if (!StringUtils.isEmpty(item.getBuseoName())) {
                    info.setBuseoName(item.getBuseoName());
                }
                if (!StringUtils.isEmpty(item.getActDate())) {
                    info.setActDate(DateUtil.toString(item.getActDate(), DateUtil.PATTERN_YYMMDD));
                }
                if (!StringUtils.isEmpty(item.getActYn())) {
                    info.setActYn(item.getActYn());
                }
                if (!StringUtils.isEmpty(item.getSunabDate())) {
                    info.setSunabDate(DateUtil.toString(item.getSunabDate(), DateUtil.PATTERN_YYMMDD));
                }
                if (!StringUtils.isEmpty(item.getChulgoDate())) {
                    info.setChulgoDate(DateUtil.toString(item.getChulgoDate(), DateUtil.PATTERN_YYMMDD));
                }
                if (!StringUtils.isEmpty(item.getBoryuYn())) {
                    info.setBoryuYn(item.getBoryuYn());
                }
                if (!StringUtils.isEmpty(item.getChulgoBuseo())) {
                    info.setChulgoBuseo(item.getChulgoBuseo());
                }
                if (!StringUtils.isEmpty(item.getOrderRemark())) {
                    info.setOrderRemark(item.getOrderRemark());
                }
                if (!StringUtils.isEmpty(item.getDrgRemark())) {
                    info.setDrgRemark(item.getDrgRemark());
                }
                if (!StringUtils.isEmpty(item.getWonyoiOrderYn())) {
                    info.setWonyoiOrderYn(item.getWonyoiOrderYn());
                }
                if (item.getFkout1001() != null) {
                    info.setFkout1001(item.getFkout1001().toString());
                }
                if (item.getFkocs1003() != null) {
                    info.setFkocs1003(item.getFkocs1003().toString());
                }
                if (!StringUtils.isEmpty(item.getNaewonYn())) {
                    info.setNaewonYn(item.getNaewonYn());
                }
                if(!StringUtils.isEmpty(item.getIfDataSendYn())){
                	info.setIfDataSendYn(item.getIfDataSendYn());
                }
                response.addOrderOrderList(info);
            }
        }
        return response.build();
    }
}
