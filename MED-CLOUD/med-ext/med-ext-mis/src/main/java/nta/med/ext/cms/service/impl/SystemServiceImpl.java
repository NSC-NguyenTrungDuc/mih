package nta.med.ext.cms.service.impl;

import java.util.UUID;
import java.util.concurrent.TimeUnit;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.util.StringUtils;

import nta.med.common.glossary.Lifecyclet;
import nta.med.core.domain.cms.CmsHospitalInfo;
import nta.med.data.dao.cms.CmsHospitalInfoRepository;
import nta.med.ext.cms.caching.TokenManager;
import nta.med.ext.cms.model.cms.CmsSession;
import nta.med.ext.cms.service.SystemService;
import nta.med.ext.support.proto.SystemServiceProto.GetMisTokenRequest;
import nta.med.ext.support.proto.SystemServiceProto.GetMisTokenResponse;
import nta.med.ext.support.service.system.SystemRpcService;

@Component("systemService")
public class SystemServiceImpl implements SystemService, SystemRpcService.Service{

	private static final Log LOGGER = LogFactory.getLog(SystemServiceImpl.class);
	
    @Autowired
	private TokenManager<CmsSession> cache;
	
	@Resource
	private CmsHospitalInfoRepository cmsHospitalInfoRepository;
    
	@Override
	public GetMisTokenResponse getMisToken(GetMisTokenRequest request) throws Exception {
		GetMisTokenResponse.Builder response = GetMisTokenResponse.newBuilder();
		String hospCode = request.getHospCode();
		String userId = request.getUserId();
		String token = cache.getTokenByHospCodeUserId(hospCode, userId);
		
		LOGGER.info("SystemServiceImpl getMisToken: hosp_code = " + hospCode + ", userId = " + userId);
		
		if(StringUtils.isEmpty(token)){
			LOGGER.info("SystemServiceImpl getMisToken : Create new token...");
			CmsHospitalInfo hospInfo = cmsHospitalInfoRepository.findByHospCode(hospCode);
			CmsSession cmsSession = new CmsSession();
			token = UUID.randomUUID().toString();
			cmsSession.setToken(token);
			cmsSession.setHospCode(hospCode);
			cmsSession.setUserName(userId);
			cmsSession.setFullName("");
			cmsSession.setLocale(hospInfo != null ? hospInfo.getLocale() : "");
			
			cache.put(token, cmsSession);
		}
		
		response.setId(request.getId());
		response.setToken(token);
		LOGGER.info("SystemServiceImpl getMisToken token = " + token);
		return response.build();
	}

}
