package nta.med.service.ihis.handler.ocso;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class OcsoOCS1003P01SangDupCheckHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01SangDupCheckRequest, OcsoServiceProto.OcsoOCS1003P01SangDupCheckResponse> {
	private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003P01SangDupCheckHandler.class);
	
	@Resource
	private OutsangRepository outsangRepository;
	
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsoOCS1003P01SangDupCheckResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01SangDupCheckRequest request) throws Exception {
		OcsoServiceProto.OcsoOCS1003P01SangDupCheckResponse.Builder response = OcsoServiceProto.OcsoOCS1003P01SangDupCheckResponse.newBuilder();
		Double fkinp1001 = null;
		if (!StringUtils.isEmpty(request.getFkinp1001())) {
			fkinp1001 = CommonUtils.parseDouble(request.getFkinp1001());
		}
		String postModifierName = null;
		if (!StringUtils.isEmpty(request.getPostModifierName())) {
			postModifierName = request.getPostModifierName();
		}
		String preModifierName = null;
		if (!StringUtils.isEmpty(request.getPreModifierName())) {
			preModifierName = request.getPreModifierName();
		}
		String sangStartDate = null;
		if (!StringUtils.isEmpty(request.getSangStartDate())) {
			sangStartDate = request.getSangStartDate();
		}
		String sangEndDate = null;
		if (!StringUtils.isEmpty(request.getSangEndDate())) {
			sangEndDate	= request.getSangEndDate();	
		}
		String sangJindanDate = null;
		if (!StringUtils.isEmpty(request.getSangJindanDate())) {
			sangJindanDate	= request.getSangJindanDate();
		}
		String juSangYn = null;
		if (!StringUtils.isEmpty(request.getSangJindanDate())) {
			juSangYn	= request.getJuSangYn();
		}
		String result = outsangRepository.checkOcsoOCS1003P01SangDupCheck(getHospitalCode(vertx, sessionId), request.getIoGubun(), request.getGwa(), request.getBunho(),
				fkinp1001 , request.getSangCode(), request.getSangName(), postModifierName, preModifierName,
				sangStartDate, sangEndDate, sangJindanDate, request.getDataGubun(), juSangYn);
		
		if(!StringUtils.isEmpty(result)){
			response.setReusltSang(result);
		}
		return response.build();
	}

}
