package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01WnSerialQryListItemInfo;
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
public class DrgsDRG5100P01WnSerialQryListHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01WnSerialQryListRequest, DrgsServiceProto.DrgsDRG5100P01WnSerialQryListResponse> {
	private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01WnSerialQryListHandler.class);
	@Resource
	private Drg2010Repository drg2010Repository;

	@Override
	public boolean isValid(DrgsServiceProto.DrgsDRG5100P01WnSerialQryListRequest request, Vertx vertx, String clientId, String sessionId) {
		if(!StringUtils.isEmpty(request.getJubsuDate()) && DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD) == null){
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public DrgsServiceProto.DrgsDRG5100P01WnSerialQryListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01WnSerialQryListRequest request) throws Exception {
					List<DrgsDRG5100P01WnSerialQryListItemInfo> listObject = drg2010Repository.getDrgsDRG5100P01WnSerialQryListItem(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
					request.getJubsuDate(), request.getDrgBunho(), request.getOSerialText());
			DrgsServiceProto.DrgsDRG5100P01WnSerialQryListResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01WnSerialQryListResponse.newBuilder();
			if(!CollectionUtils.isEmpty(listObject)) {
				for(DrgsDRG5100P01WnSerialQryListItemInfo item : listObject) {
					DrgsModelProto.DrgsDRG5100P01WnSerialQryListItemInfo.Builder info = DrgsModelProto.DrgsDRG5100P01WnSerialQryListItemInfo.newBuilder();
					if (item.getGroupSer() != null) {
						info.setGroupSer(item.getGroupSer().toString());
					}
					if (!StringUtils.isEmpty(item.getJaeryoCode())) {
						info.setJaeryoCode(item.getJaeryoCode());
					}
					if (item.getNalsu() != null) {
						info.setNalsu(item.getNalsu().toString());
					}
					if (!StringUtils.isEmpty(item.getDivide())) {
						info.setDivide(item.getDivide());
					}
					if (item.getDrgOrderSuryang() != null) {
						info.setDrgOrderSuryang(item.getDrgOrderSuryang().toString());
					}
					if (item.getOrderSuryang() != null) {
						info.setOrderSuryang(item.getOrderSuryang().toString());
					}
					if (!StringUtils.isEmpty(item.getDrgOrderDanui())) {
						info.setDrgOrderDanui(item.getDrgOrderDanui());
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
						info.setDv(item.getDv().toString());
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
					if (!StringUtils.isEmpty(item.getSunabDate())) {
						info.setSunabDate(item.getSunabDate());
					}
					if (!StringUtils.isEmpty(item.getPattern())) {
						info.setPattern(item.getPattern());
					}
					if (!StringUtils.isEmpty(item.getJaeryoName())) {
						info.setJaeryoName(item.getJaeryoName());
					}
					if (!StringUtils.isEmpty(item.getSunabNalsu())) {
						info.setSunabNalsu(item.getSunabNalsu().toString());
					}
					if (!StringUtils.isEmpty(item.getWonyoiYn())) {
						info.setWonyoiYn(item.getWonyoiYn());
					}
					if (!StringUtils.isEmpty(item.getActDate())) {
						info.setActDate(item.getActDate());
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
					if (!StringUtils.isEmpty(item.getGwaName())) {
						info.setGwaName(item.getGwaName());
					}
					if (!StringUtils.isEmpty(item.getDoctorName())) {
						info.setDoctorName(item.getDoctorName());
					}
					if (!StringUtils.isEmpty(item.getSuname())) {
						info.setSuname(item.getSuname());
					}
					if (!StringUtils.isEmpty(item.getSuname2())) {
						info.setSuname2(item.getSuname2());
					}
					if (!StringUtils.isEmpty(item.getBirth())) {
						info.setBirth(item.getBirth());
					}
					if (!StringUtils.isEmpty(item.getSexAge())) {
						info.setSexAge(item.getSexAge());
					}
					if (!StringUtils.isEmpty(item.getOtherGwa())) {
						info.setOtherGwa(item.getOtherGwa());
					}
					if (!StringUtils.isEmpty(item.getDoOrder())) {
						info.setDoOrder(item.getDoOrder());
					}
					if (!StringUtils.isEmpty(item.getHopeDate())) {
						info.setHopeDate(item.getHopeDate());
					}
					if (!StringUtils.isEmpty(item.getPowderYn())) {
						info.setPowderYn(item.getPowderYn());
					}
					if (!StringUtils.isEmpty(item.getLine())) {
						info.setLine(item.getLine());
					}
					if (!StringUtils.isEmpty(item.getKyukyeok())) {
						info.setKyukyeok(item.getKyukyeok());
					}
					if (!StringUtils.isEmpty(item.getLicense())) {
						info.setLicense(item.getLicense());
					}
					if (!StringUtils.isEmpty(item.getMixGroup())) {
						info.setMixGroup(item.getMixGroup());
					}
					if (!StringUtils.isEmpty(item.getDonbok())) {
						info.setDonbok(item.getDonbok());
					}
					if (!StringUtils.isEmpty(item.getTusuk())) {
						info.setTusuk(item.getTusuk());
					}
					if (!StringUtils.isEmpty(item.getCautionNm())) {
						info.setCautionNm(item.getCautionNm());
					}
					if (!StringUtils.isEmpty(item.getOrderSort())) {
						info.setOrderSort(item.getOrderSort());
					}
					if (!StringUtils.isEmpty(item.getTextColor())) {
						info.setTextColor(item.getTextColor());
					}
					if (!StringUtils.isEmpty(item.getChanggo())) {
						info.setChanggo(item.getChanggo());
					}
					if (!StringUtils.isEmpty(item.getHubalChangeYn())) {
						info.setHubalChangeYn(item.getHubalChangeYn());
					}
					if (!StringUtils.isEmpty(item.getHubalAllYn())) {
						info.setHubalAllYn(item.getHubalAllYn());
					}

					response.addSerialQryList(info);
				}
			}
		return response.build();
	}
}
