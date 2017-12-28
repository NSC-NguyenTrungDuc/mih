package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.dao.medi.inp.App1001Repository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.nuro.NuroOUT1101Q01FwkDoctorInfo;
import nta.med.data.model.ihis.ocso.OUTSANGU00findBoxToGwaInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OcsCHTAPPROVEgetOneResultRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.StringResponse;

@Service
@Scope("prototype")
public class OcsCHTAPPROVEgetOneResultHandler
		extends ScreenHandler<OcsaServiceProto.OcsCHTAPPROVEgetOneResultRequest, SystemServiceProto.StringResponse> {
	private static final Log LOGGER = LogFactory.getLog(OcsCHTAPPROVEgetOneResultHandler.class);
	@Resource
	private Bas0260Repository bas0260Repository;
	@Resource
	private Bas0270Repository bas0270Repository;
	@Resource
	private App1001Repository app1001Repository;
	@Resource
	private Bas0102Repository bas0102Repository;
	@Resource
	private Ocs0132Repository ocs0132Repository;
	
	@Override
	@Transactional(readOnly = true)
	public StringResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OcsCHTAPPROVEgetOneResultRequest request) throws Exception {		
		SystemServiceProto.StringResponse.Builder response = SystemServiceProto.StringResponse.newBuilder();
		String controlName = request.getNameControl();
		response.setResult("");
		if (StringUtils.isEmpty(controlName))
			return response.build();
		if ("doctor".equals(controlName)) {
			List<NuroOUT1101Q01FwkDoctorInfo> list = bas0270Repository.getNuroOUT1101Q01FwkDoctorInfo(getHospitalCode(vertx, sessionId), request.getGwa(), request.getFind());
			if (!CollectionUtils.isEmpty(list)) 
				response.setResult(list.get(0).getDoctorName());
		} else if ("gwa".equals(controlName)) {
			List<OUTSANGU00findBoxToGwaInfo> list = bas0260Repository.getOUTSANGU00findBoxToGwaInfo(getHospitalCode(vertx, sessionId), DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD), request.getFind(), getLanguage(vertx, sessionId));
			if (!CollectionUtils.isEmpty(list)) 
				response.setResult(list.get(0).getGwaName());
		} else if ("change".equals(controlName)) {
			String result = app1001Repository.getApproveYnByPkapp1001(getHospitalCode(vertx, sessionId), request.getPkApp1001());
			response.setResult(result);
		} else if ("sayu".equals(controlName)) {
			String result = bas0102Repository.getCodeNameByCodeTypeAndCode(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "SANG_END_SAYU", request.getCode());
			response.setResult(result);
		} else {
			List<String> list = ocs0132Repository.getCodeNameByCodeAndCodeType(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "APPROVE_DESEASE_FLAG", request.getCode());
			if (!CollectionUtils.isEmpty(list)) 
				response.setResult(list.get(0));
		}
		return response.build();
	}

}
