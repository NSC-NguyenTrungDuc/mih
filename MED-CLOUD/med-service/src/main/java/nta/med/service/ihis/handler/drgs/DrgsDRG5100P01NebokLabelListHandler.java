package nta.med.service.ihis.handler.drgs;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01NebokLabelListItemInfo;
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
public class DrgsDRG5100P01NebokLabelListHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01NebokLabelListRequest, DrgsServiceProto.DrgsDRG5100P01NebokLabelListResponse> {
	private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01NebokLabelListHandler.class);
	@Resource
	private Drg2010Repository drg2010Repository;

	@Override
	@Transactional(readOnly = true)
	public DrgsServiceProto.DrgsDRG5100P01NebokLabelListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01NebokLabelListRequest request) throws Exception {
		List<DrgsDRG5100P01NebokLabelListItemInfo> listObject = drg2010Repository.getDrgsDRG5100P01NebokLabelListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getJubsuDate(), request.getDrgBunho(), request.getBunho());
		DrgsServiceProto.DrgsDRG5100P01NebokLabelListResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01NebokLabelListResponse.newBuilder();
		if(!CollectionUtils.isEmpty(listObject)) {
			for(DrgsDRG5100P01NebokLabelListItemInfo item : listObject) {
				DrgsModelProto.DrgsDRG5100P01NebokLabelListItemInfo.Builder info = DrgsModelProto.DrgsDRG5100P01NebokLabelListItemInfo.newBuilder();
				if (!StringUtils.isEmpty(item.getBunho())) {
					info.setBunho(item.getBunho());
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
				if (item.getAge() != null) {
					info.setAge(item.getAge().toString());
				}
				if (!StringUtils.isEmpty(item.getSex())) {
					info.setSex(item.getSex());
				}
				if (!StringUtils.isEmpty(item.getBirth())) {
					info.setBirth(DateUtil.toString(item.getBirth(), DateUtil.PATTERN_YYMMDD));
				}
				if (item.getDrgBunho() != null) {
					info.setDrgBunho(item.getDrgBunho().toString());
				}
				if (!StringUtils.isEmpty(item.getRpBunho())) {
					info.setRpBunho(item.getRpBunho());
				}
				if (!StringUtils.isEmpty(item.getReserDate())) {
					info.setReserDate(item.getReserDate());
				}
				if (!StringUtils.isEmpty(item.getJusaGubun())) {
					info.setJusaGubun(item.getJusaGubun());
				}
				if (!StringUtils.isEmpty(item.getJusaSpdGubun())) {
					info.setJusaSpdGubun(item.getJusaSpdGubun());
				}
				if (item.getSuryang() != null) {
					info.setSuryang(item.getSuryang().toString());
				}
				if (!StringUtils.isEmpty(item.getOrdDanui())) {
					info.setOrdDanui(item.getOrdDanui());
				}
				if (!StringUtils.isEmpty(item.getDvTime())) {
					info.setDvTime(item.getDvTime());
				}
				if (item.getDv() != null) {
					info.setDv(item.getDv().toString());
				}
				if (!StringUtils.isEmpty(item.getBogyongCode())) {
					info.setBogyongCode(item.getBogyongCode());
				}
				if (item.getSubulSuryang() != null) {
					info.setSubulSuryang(item.getSubulSuryang().toString());
				}
				if (!StringUtils.isEmpty(item.getSubulDanui())) {
					info.setSubulDanui(item.getSubulDanui());
				}
				if (!StringUtils.isEmpty(item.getJaeryoName())) {
					info.setJaeryoName(item.getJaeryoName());
				}
				if (item.getNalsuCnt() != null) {
					info.setNalsuCnt(item.getNalsuCnt().toString());
				}

				response.addNebokLabelList(info);
			}
		}
		return response.build();
	}
}
