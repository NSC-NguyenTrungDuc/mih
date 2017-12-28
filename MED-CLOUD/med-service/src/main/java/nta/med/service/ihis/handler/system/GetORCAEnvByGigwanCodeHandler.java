package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.domain.bas.Bas0102;
import nta.med.core.glossary.AccountingConfig;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.GetORCAEnvByGigwanCodeRequest;
import nta.med.service.ihis.proto.SystemServiceProto.GetORCAEnvByGigwanCodeResponse;

@Service
@Scope("prototype")
public class GetORCAEnvByGigwanCodeHandler extends
		ScreenHandler<SystemServiceProto.GetORCAEnvByGigwanCodeRequest, SystemServiceProto.GetORCAEnvByGigwanCodeResponse> {

	private static final Log LOGGER = LogFactory.getLog(GetORCAEnvByGigwanCodeHandler.class);
	
	@Resource
	private Bas0001Repository bas0001Repository;

	@Resource
	private Bas0102Repository bas0102Repository;

	@Override
	@Route(global = true)
	@Transactional(readOnly = true)
	public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			GetORCAEnvByGigwanCodeRequest request) throws Exception {

		Bas0001 bas0001 = bas0001Repository.getHospCodeByAcctRefId(request.getGigwanCode());
		if (bas0001 != null) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(bas0001.getHospCode(),
					bas0001.getLanguage(), "", 1, ""));
			LOGGER.info("GetORCAEnvByGigwanCodeHandler preHandle has hosp code" + bas0001.getHospCode());
		} else {
			LOGGER.info("GetORCAEnvByGigwanCodeHandler preHandle not found hosp code");
		}
	}

	@Override
	@Route(global = false)
	@Transactional(readOnly = true)
	public GetORCAEnvByGigwanCodeResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			GetORCAEnvByGigwanCodeRequest request) throws Exception {

		SystemServiceProto.GetORCAEnvByGigwanCodeResponse.Builder response = SystemServiceProto.GetORCAEnvByGigwanCodeResponse.newBuilder();
		
		List<Bas0102> orcaInfos = bas0102Repository.findByHospCodeAndCodeType(getHospitalCode(vertx, sessionId), AccountingConfig.ACCT_ORCA.getValue());

		if (!CollectionUtils.isEmpty(orcaInfos)) {
			for (Bas0102 orcaInfo : orcaInfos) {
				if (orcaInfo.getCode().equals(AccountingConfig.ORCA_IP.getValue())) {
					response.setOrcaIp(orcaInfo.getCodeName());
				} else if (orcaInfo.getCode().equals(AccountingConfig.ORCA_PORT.getValue())) {
					response.setOrcaPort(orcaInfo.getCodeName());
				} else if (orcaInfo.getCode().equals(AccountingConfig.ORCA_USER.getValue())) {
					response.setOrcaUser(orcaInfo.getCodeName());
				} else if (orcaInfo.getCode().equals(AccountingConfig.ORCA_PWD.getValue())) {
					response.setOrcaPwd(orcaInfo.getCodeName());
				}
			}
		} else {
			LOGGER.warn("Can not find ORCA env with GigwanCode = " + request.getGigwanCode());
		}

		return response.build();
	}

}
