package nta.med.service.ihis.handler.drgs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.model.ihis.drgs.DrgsDRG5100P01DrgwonneaOWnCurListInfo;
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

@Service
@Scope("prototype")
public class DrgsDRG5100P01DrgwonneaOWnCurListHandler extends ScreenHandler<DrgsServiceProto.DrgsDRG5100P01DrgwonneaOWnCurListRequest, DrgsServiceProto.DrgsDRG5100P01DrgwonneaOWnCurListResponse> {
	private static final Log LOG = LogFactory.getLog(DrgsDRG5100P01DrgwonneaOWnCurListHandler.class);
	@Resource
	private Drg2010Repository drg2010Repository;

	@Override
	public boolean isValid(DrgsServiceProto.DrgsDRG5100P01DrgwonneaOWnCurListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getJubsuDate()) && DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}

	@Override
	@Transactional(readOnly = true)
	public DrgsServiceProto.DrgsDRG5100P01DrgwonneaOWnCurListResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DrgsDRG5100P01DrgwonneaOWnCurListRequest request) throws Exception {
		List<DrgsDRG5100P01DrgwonneaOWnCurListInfo> listObject = drg2010Repository.getDrgsDRG5100P01DrgwonneaOWnCurList(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getJubsuDate(), request.getDrgBunho());
			DrgsServiceProto.DrgsDRG5100P01DrgwonneaOWnCurListResponse.Builder response = DrgsServiceProto.DrgsDRG5100P01DrgwonneaOWnCurListResponse.newBuilder();
			if(!CollectionUtils.isEmpty(listObject)) {
				for(DrgsDRG5100P01DrgwonneaOWnCurListInfo item : listObject) {
					DrgsModelProto.DrgsDRG5100P01DrgwonneaOWnCurListInfo.Builder info = DrgsModelProto.DrgsDRG5100P01DrgwonneaOWnCurListInfo.newBuilder();
					if (!StringUtils.isEmpty(item.getBunho())) {
						info.setBunho(item.getBunho());
					}
					if (!StringUtils.isEmpty(item.getDrgBunho())) {
						info.setDrgBunho(item.getDrgBunho());
					}
					if (!StringUtils.isEmpty(item.getNaewonDate())) {
						info.setNaewonDate(item.getNaewonDate());
					}
					if (!StringUtils.isEmpty(item.getJubsuDate())) {
						info.setJubsuDate(item.getJubsuDate());
					}
					if (!StringUtils.isEmpty(item.getOrderDate())) {
						info.setOrderDate(item.getOrderDate());
					}
					if (!StringUtils.isEmpty(item.getSerialV())) {
						info.setSerialV(item.getSerialV());
					}
					if (!StringUtils.isEmpty(item.getSerialText())) {
						info.setSerialText(item.getSerialText());
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
					if (!StringUtils.isEmpty(item.getGigamDate())) {
						info.setGigamDate(item.getGigamDate());
					}

					response.addCurList(info);
				}
			}
		return response.build();
	}
}
