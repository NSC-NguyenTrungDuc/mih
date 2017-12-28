package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.model.ihis.drgs.DRG0201U00GrdOrderInfo;
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
import java.util.List;

@Service
@Scope("prototype")
public class DRG0201U00DetailServerCallHandler extends ScreenHandler<DrgsServiceProto.DRG0201U00DetailServerCallRequest, DrgsServiceProto.DRG0201U00DetailServerCallResponse> {
    private static final Log LOG = LogFactory.getLog(DRG0201U00DetailServerCallHandler.class);
    @Resource
    private Drg2010Repository drg2010Repository;

    @Override
    public boolean isValid(DrgsServiceProto.DRG0201U00DetailServerCallRequest request, Vertx vertx, String clientId, String sessionId) {
        if(!StringUtils.isEmpty(request.getJubsuDate()) && DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD) == null){
            return false;
        }
        return true;
    }

    @Override
    @Transactional
    public DrgsServiceProto.DRG0201U00DetailServerCallResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0201U00DetailServerCallRequest request) throws Exception {
        DrgsServiceProto.DRG0201U00DetailServerCallResponse.Builder response = DrgsServiceProto.DRG0201U00DetailServerCallResponse.newBuilder();
        List<DRG0201U00GrdOrderInfo> listObject = drg2010Repository.getDRG0201U00DetailServerCallInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getJubsuDate(), request.getBunho(), request.getDrgBunho(), null);
        if (!CollectionUtils.isEmpty(listObject)) {
            for (DRG0201U00GrdOrderInfo item : listObject) {
                DrgsModelProto.DRG0201U00DetailServerCallInfo.Builder info = DrgsModelProto.DRG0201U00DetailServerCallInfo.newBuilder();
                if (item.getDrgBunho() != null) {
                    info.setDrgBunho(item.getDrgBunho().toString());
                }
                if (!StringUtils.isEmpty(item.getBunho())) {
                    info.setBunho(item.getBunho());
                }
                if (item.getOrderDate() != null) {
                    info.setOrderDate(DateUtil.toString(item.getOrderDate(), DateUtil.PATTERN_YYMMDD));
                }
                if (item.getJubsuDate() != null) {
                    info.setJubsuDate(DateUtil.toString(item.getJubsuDate(), DateUtil.PATTERN_YYMMDD));
                }
                if (item.getDrgJubsuDate() != null) {
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
                if (item.getActDate() != null) {
                    info.setActDate(DateUtil.toString(item.getActDate(), DateUtil.PATTERN_YYMMDD));
                }
                if (item.getActTime() != null) {
                    info.setActTime(DateUtil.toString(item.getActTime(), DateUtil.PATTERN_YYMMDD));
                }
                if (!StringUtils.isEmpty(item.getActYn())) {
                    info.setActYn(item.getActYn());
                }
                if (item.getSunabDate() != null) {
                    info.setSunabDate(DateUtil.toString(item.getSunabDate(), DateUtil.PATTERN_YYMMDD));
                }
                if (item.getChulgoDate() != null) {
                    info.setChulgoDate(DateUtil.toString(item.getChulgoDate(), DateUtil.PATTERN_YYMMDD));
                }
                if (!StringUtils.isEmpty(item.getActUserName())) {
                    info.setActUserName(item.getActUserName());
                }
                if (!StringUtils.isEmpty(item.getWonyoiOrderYn())) {
                    info.setWonyoiOrderYn(item.getWonyoiOrderYn());
                }
                if (!StringUtils.isEmpty(item.getDisGubun())) {
                    info.setDisGubun(item.getDisGubun());
                }
                if (!StringUtils.isEmpty(item.getOrderRemark())) {
                    info.setOrderRemark(item.getOrderRemark());
                }
                if (!StringUtils.isEmpty(item.getDrgRemark())) {
                    info.setDrgRemark(item.getDrgRemark());
                }
                if (item.getFkout1001() != null) {
                    info.setFkout1001(item.getFkout1001().toString());
                }

                response.addDetailServerCall(info);
            }
        }
        return response.build();
    }
}
