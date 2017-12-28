package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01LabelListItemInfo;
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
public class DrgsDRG5100P01LabelListHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01LabelListRequest, DrgsServiceProto.DrgsDRG5100P01LabelListResponse> {
	private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01LabelListHandler.class);
	@Resource
	private Drg2010Repository drg2010Repository;

	@Override
	@Transactional(readOnly = true)
	public DrgsServiceProto.DrgsDRG5100P01LabelListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01LabelListRequest request) throws Exception {
		List<DrgsDRG5100P01LabelListItemInfo> listObject = drg2010Repository.getDrgsDRG5100P01LabelListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getJubsuDate(), request.getDrgBunho());
		DrgsServiceProto.DrgsDRG5100P01LabelListResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01LabelListResponse.newBuilder();
		if(!CollectionUtils.isEmpty(listObject)) {
			for(DrgsDRG5100P01LabelListItemInfo item : listObject) {
				DrgsModelProto.DrgsDRG5100P01LabelListItemInfo.Builder info = DrgsModelProto.DrgsDRG5100P01LabelListItemInfo.newBuilder();
				if (!StringUtils.isEmpty(item.getOrderDate())) {
					info.setOrderDate(DateUtil.toString(item.getOrderDate(), DateUtil.PATTERN_YYMMDD));
				}
				if (!StringUtils.isEmpty(item.getDanui())) {
					info.setDanui(item.getDanui());
				}
				if (!StringUtils.isEmpty(item.getDanui1())) {
					info.setDanui1(item.getDanui1());
				}
				if (item.getDrgBunho() != null) {
					info.setDrgBunho(item.getDrgBunho().toString());
				}
				if (!StringUtils.isEmpty(item.getBunho())) {
					info.setBunho(item.getBunho());
				}
				if (item.getDv() != null) {
					info.setDv(item.getDv().toString());
				}
				if (!StringUtils.isEmpty(item.getDrgGrp())) {
					info.setDrgGrp(item.getDrgGrp());
				}
				if (!StringUtils.isEmpty(item.getName())) {
					info.setName(item.getName());
				}
				if (!StringUtils.isEmpty(item.getGwa())) {
					info.setGwa(item.getGwa());
				}
				if (!StringUtils.isEmpty(item.getBogyongCode())) {
					info.setBogyongCode(item.getBogyongCode());
				}
				if (!StringUtils.isEmpty(item.getBogyongName())) {
					info.setBogyongName(item.getBogyongName());
				}
				if (item.getNalsu() != null) {
					info.setNalsu(item.getNalsu().toString());
				}
				if (!StringUtils.isEmpty(item.getBunryu1())) {
					info.setBunryu1(item.getBunryu1());
				}
				if (!StringUtils.isEmpty(item.getCautionNm())) {
					info.setCautionNm(item.getCautionNm());
				}
				if (!StringUtils.isEmpty(item.getJaeryoName())) {
					info.setJaeryoName(item.getJaeryoName());
				}
				if (!StringUtils.isEmpty(item.getGyunbonYn())) {
					info.setGyunbonYn(item.getGyunbonYn());
				}
				if (item.getSu() != null) {
					info.setSu(item.getSu().toString());
				}
				if (!StringUtils.isEmpty(item.getRp())) {
					info.setRp(item.getRp());
				}
				if (!StringUtils.isEmpty(item.getHopeDate())) {
					info.setHopeDate(DateUtil.toString(item.getHopeDate(), DateUtil.PATTERN_YYMMDD));
				}
				if (!StringUtils.isEmpty(item.getDonbok())) {
					info.setDonbok(item.getDonbok());
				}

				response.addLabelList(info);
			}
		}
		return response.build();
	}
}
