package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.ocso.OcsoOCS1003Q05DiseaseListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsoOCS1003Q05DiseaseListHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003Q05DiseaseListRequest, OcsoServiceProto.OcsoOCS1003Q05DiseaseListResponse> {
	private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003Q05DiseaseListHandler.class);

	@Resource
	private OutsangRepository outsangRepository;
	
	@Override
	public boolean isValid(OcsoServiceProto.OcsoOCS1003Q05DiseaseListRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getNaewonDate()) && DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003Q05DiseaseListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003Q05DiseaseListRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003Q05DiseaseListResponse.Builder response = OcsoServiceProto.OcsoOCS1003Q05DiseaseListResponse.newBuilder();
		List<OcsoOCS1003Q05DiseaseListItemInfo> listObject = outsangRepository.getOcsoOCS1003Q05DiseaseList(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getIoGubun(), request.getJubsuNo(),
				request.getNaewonDate(), request.getGwa(), request.getDoctor(), request.getNaewonType(), request.getBunho());
		if (!CollectionUtils.isEmpty(listObject)) {
			for (OcsoOCS1003Q05DiseaseListItemInfo item : listObject) {
				OcsoModelProto.OcsoOCS1003Q05DiseaseListItemInfo.Builder info = OcsoModelProto.OcsoOCS1003Q05DiseaseListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getSer() != null) {
					info.setSer(String.format("%.0f",item.getSer()));
				}
				if (item.getJubsuNo() != null) {
					info.setJubsuNo(String.format("%.0f",item.getJubsuNo()));
				}
				response.addDiseaseListItem(info);
			}
		}
		return response.build();
	}
}
