package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01OrderListItemInfo;
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
public class DrgsDRG5100P01OrderListHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01OrderListRequest, DrgsServiceProto.DrgsDRG5100P01OrderListResponse> {
    private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01OrderListHandler.class);
    @Resource
    private Drg2010Repository drg2010Repository;

    @Override
    public boolean isValid(DrgsServiceProto.DrgsDRG5100P01OrderListRequest request, Vertx vertx, String clientId, String sessionId) {
        if(!StringUtils.isEmpty(request.getOrderDate()) && DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD) == null){
            return false;
        }
        return true;
    }

    @Override
    @Transactional(readOnly = true)
    public DrgsServiceProto.DrgsDRG5100P01OrderListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01OrderListRequest request) throws Exception {
        List<DrgsDRG5100P01OrderListItemInfo> listObject = drg2010Repository.getDrgsDRG5100P01OrderListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getOrderDate(), request.getDrgBunho(), request.getGubun(), request.getWonyoiYn(), request.getBunho());
        DrgsServiceProto.DrgsDRG5100P01OrderListResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01OrderListResponse.newBuilder();
        if (!CollectionUtils.isEmpty(listObject)) {
            for (DrgsDRG5100P01OrderListItemInfo item : listObject) {
                DrgsModelProto.DrgsDRG5100P01OrderListItemInfo.Builder info = DrgsModelProto.DrgsDRG5100P01OrderListItemInfo.newBuilder();
                if (!StringUtils.isEmpty(item.getBunho())) {
                    info.setBunho(item.getBunho());
                }
                if (item.getDrgBunho() != null) {
                    info.setDrgBunho(String.format("%.0f", item.getDrgBunho()));
                }
                if (item.getNaewonDate() != null) {
                    info.setNaewonDate(item.getNaewonDate().toString());
                }
                if (item.getGroupSer() != null) {
                    info.setGroupSer(item.getGroupSer().toString());
                }
                if (item.getJubsuDate() != null) {
                    info.setJubsuDate(item.getJubsuDate().toString());
                }
                if (item.getOrderDate() != null) {
                    info.setOrderDate(item.getOrderDate().toString());
                }
                if (!StringUtils.isEmpty(item.getJaeryoCode())) {
                    info.setJaeryoCode(item.getJaeryoCode());
                }
                if (item.getNalsu() != null) {
                    //info.setNalsu(item.getNalsu().toString());
                	info.setNalsu(String.format("%.0f", item.getNalsu()));
                }
                if (!StringUtils.isEmpty(item.getDivide())) {
                    info.setDivide(item.getDivide());
                }
                if (item.getOrdSuryang() != null) {
                    //info.setOrdSuryang(item.getOrdSuryang().toString());
                	info.setOrdSuryang(String.format("%.0f", item.getOrdSuryang()));
                }
                if (item.getOrderSuryang() != null) {
                    info.setOrderSuryang(item.getOrderSuryang().toString());
                }
                if (!StringUtils.isEmpty(item.getOrderDanui())) {
                    info.setOrderDanui(item.getOrderDanui());
                }
                if (!StringUtils.isEmpty(item.getSubulDanui())) {
                    info.setSubulDanui(item.getSubulDanui());
                }
                if (!StringUtils.isEmpty(item.getGroupYn())) {
                    info.setGroupYn(item.getGroupYn());
                }
                if (!StringUtils.isEmpty(item.getJaeryoGubun())) {
                    info.setJaeryoGubun(item.getJaeryoGubun());
                }
                if (!StringUtils.isEmpty(item.getBogyongCode())) {
                    info.setBogyongCode(item.getBogyongCode());
                }
                if (!StringUtils.isEmpty(item.getBogyongName())) {
                    info.setBogyongName(item.getBogyongName());
                }
                if (!StringUtils.isEmpty(item.getCautionName())) {
                    info.setCautionName(item.getCautionName());
                }
                if (!StringUtils.isEmpty(item.getCautionCode())) {
                    info.setCautionCode(item.getCautionCode());
                }
                if (!StringUtils.isEmpty(item.getMixYn())) {
                    info.setMixYn(item.getMixYn());
                }
                if (!StringUtils.isEmpty(item.getAtcYn())) {
                    info.setAtcYn(item.getAtcYn());
                }
                if (item.getDv() != null) {
                    //info.setDv(item.getDv().toString());
                	info.setDv(String.format("%.0f", item.getDv()));
                }
                if (!StringUtils.isEmpty(item.getDvTime())) {
                    info.setDvTime(item.getDvTime());
                }
                if (!StringUtils.isEmpty(item.getDcYn())) {
                    info.setDcYn(item.getDcYn());
                }
                if (!StringUtils.isEmpty(item.getBannabYn())) {
                    info.setBannabYn(item.getBannabYn());
                }
                if (item.getSourceFkocs1003() != null) {
                    info.setSourceFkocs1003(item.getSourceFkocs1003().toString());
                }
                if (item.getFkocs1003() != null) {
                    info.setFkocs1003(item.getFkocs1003().toString());
                }
                if (!StringUtils.isEmpty(item.getFkout1001())) {
                    info.setFkout1001(item.getFkout1001());
                }
                if (item.getSunabDate() != null) {
                    info.setSunabDate(item.getSunabDate().toString());
                }
                if (!StringUtils.isEmpty(item.getPattern())) {
                    info.setPattern(item.getPattern());
                }
                if (!StringUtils.isEmpty(item.getJaeryoName())) {
                    info.setJaeryoName(item.getJaeryoName());
                }
                if (!StringUtils.isEmpty(item.getGenericName())) {
                    info.setGenericName(item.getGenericName());
                }
                if (item.getSunabNalsu() != null) {
                    info.setSunabNalsu(item.getSunabNalsu().toString());
                }
                if (!StringUtils.isEmpty(item.getWonyoiYn())) {
                    info.setWonyoiYn(item.getWonyoiYn());
                }
                if (!StringUtils.isEmpty(item.getRemark())) {
                    info.setRemark(item.getRemark());
                }
                if (item.getActDate() != null) {
                    info.setActDate(item.getActDate().toString());
                }
                if (!StringUtils.isEmpty(item.getMayak())) {
                    info.setMayak(item.getMayak());
                }
                if (!StringUtils.isEmpty(item.getTpnJojeGubun())) {
                    info.setTpnJojeGubun(item.getTpnJojeGubun());
                }
                if (!StringUtils.isEmpty(item.getUiJusaYn())) {
                    info.setUiJusaYn(item.getUiJusaYn());
                }
                if (item.getSubulSuryang() != null) {
                    info.setSubulSuryang(item.getSubulSuryang().toString());
                }
                if (!StringUtils.isEmpty(item.getSerialV())) {
                    info.setSerialV(item.getSerialV());
                }
                if (!StringUtils.isEmpty(item.getPowderYn())) {
                    info.setPowderYn(item.getPowderYn());
                }
                if (!StringUtils.isEmpty(item.getGyunbonYn())) {
                    info.setGyunbonYn(item.getGyunbonYn());
                }
                if (!StringUtils.isEmpty(item.getPrintYn())) {
                    info.setPrintYn(item.getPrintYn());
                }
                if (!StringUtils.isEmpty(item.getOldGyunbonYn())) {
                    info.setOldGyunbonYn(item.getOldGyunbonYn());
                }
                if (!StringUtils.isEmpty(item.getOrderRemark())) {
                    info.setOrderRemark(item.getOrderRemark());
                }
                if (!StringUtils.isEmpty(item.getDrgRemark())) {
                    info.setDrgRemark(item.getDrgRemark());
                }
                if (!StringUtils.isEmpty(item.getHubakChangeYn())) {
                    info.setHubakChangeYn(item.getHubakChangeYn());
                }
                if (!StringUtils.isEmpty(item.getPharmacy())) {
                    info.setPharmacy(item.getPharmacy());
                }
                if (!StringUtils.isEmpty(item.getDrgPackYn())) {
                    info.setDrgPackYn(item.getDrgPackYn());
                }
                if (!StringUtils.isEmpty(item.getMixGroup())) {
                    info.setMixGroup(item.getMixGroup());
                }
                if (item.getHopeDate() != null) {
                    info.setHopeDate(item.getHopeDate().toString());
                }
                if (!StringUtils.isEmpty(item.getOrderGubun())) {
                    info.setOrderGubun(item.getOrderGubun());
                }
                if (!StringUtils.isEmpty(item.getBunryu1())) {
                    info.setBunryu1(item.getBunryu1());
                }

                response.addOrderList(info);
            }
        }
        return response.build();
    }
}
