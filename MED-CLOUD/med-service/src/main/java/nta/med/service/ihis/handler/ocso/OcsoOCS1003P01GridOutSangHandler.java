package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.apache.logging.log4j.util.Strings;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.ocso.OcsoOCS1003P01GridOutSangInfo;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

@Service
@Scope("prototype")
public class OcsoOCS1003P01GridOutSangHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01GridOutSangRequest, OcsoServiceProto.OcsoOCS1003P01GridOutSangResponse>{
	private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003P01GridOutSangHandler.class);

	@Resource
	private OutsangRepository outsangRepository;

	@Override
	public boolean isValid(OcsoServiceProto.OcsoOCS1003P01GridOutSangRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getNaewonDate()) && DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003P01GridOutSangResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01GridOutSangRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003P01GridOutSangResponse.Builder response = OcsoServiceProto.OcsoOCS1003P01GridOutSangResponse.newBuilder();
		List<OcsoOCS1003P01GridOutSangInfo> listObject = outsangRepository.getOcsoOCS1003P01GridOutSangInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho(),
				request.getGwa(), request.getNaewonDate());
		if (listObject != null && !listObject.isEmpty()) {
			for (OcsoOCS1003P01GridOutSangInfo obj : listObject) {
				OcsoModelProto.OcsoOCS1003P01GridOutSangInfo.Builder itemBuilder = OcsoModelProto.OcsoOCS1003P01GridOutSangInfo.newBuilder();
				BeanUtils.copyProperties(obj, itemBuilder, getLanguage(vertx, sessionId));
				if (!Strings.isEmpty(obj.getCodeName())) {
					itemBuilder.setCodeName(obj.getCodeName());
				}
				if (!Strings.isEmpty(obj.getSugaSangCode())) {
					itemBuilder.setSugaSangCode(obj.getSugaSangCode());
				}
				response.addGridOutSangItem(itemBuilder);
			}
		}
		return response.build();
	}
}
