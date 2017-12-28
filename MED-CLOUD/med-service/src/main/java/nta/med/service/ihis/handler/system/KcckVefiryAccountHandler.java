package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.model.ihis.system.AccountInfo;
import nta.med.data.model.ihis.system.AdmLoginFormCheckLoginUserInfo;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class KcckVefiryAccountHandler
		extends ScreenHandler<SystemServiceProto.KcckVefiryAccountRequest, SystemServiceProto.KcckVefiryAccountResponse> {
	private static final Log LOGGER = LogFactory.getLog(KcckVefiryAccountHandler.class);

	@Resource                                                                                                       
	private Bas0001Repository bas0001Repository;   
	
	@Resource
	private Adm3200Repository adm3200Repository;
	
	@Override
	@Transactional(readOnly = true)
    @Route(global = true)
	public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			SystemServiceProto.KcckVefiryAccountRequest request) throws Exception {
		List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(request.getHospCode());
		if (!CollectionUtils.isEmpty(bas0001List)) {
			Bas0001 bas0001 = bas0001List.get(0);
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(bas0001.getHospCode(),
					bas0001.getLanguage(), "", 1, ""));
		} else {
			LOGGER.info("kcck KcckVefiryAccountHandler preHandle not found hosp code");
		}
	}
	
	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.KcckVefiryAccountResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			SystemServiceProto.KcckVefiryAccountRequest request) throws Exception {	
		SystemServiceProto.KcckVefiryAccountResponse.Builder response = SystemServiceProto.KcckVefiryAccountResponse.newBuilder();
		if(SystemServiceProto.KcckVefiryAccountRequest.AccountType.MBS == request.getAccountType()){
			AccountInfo account = adm3200Repository.verifyAccountInfo(request.getLoginId(), request.getPassword(), getHospitalCode(vertx, sessionId));
			if (account != null) {
				SystemModelProto.SysAccountInfo.Builder accountInfo = SystemModelProto.SysAccountInfo.newBuilder();
				BeanUtils.copyProperties(account, accountInfo, getLanguage(vertx, sessionId));
				
				response.setSysAccountInfo(accountInfo);
				response.setResult(true);
				return response.build();
			}
		}
		
		if(SystemServiceProto.KcckVefiryAccountRequest.AccountType.MIS == request.getAccountType()){
			AdmLoginFormCheckLoginUserInfo account = adm3200Repository.getAdmLoginFormCheckLoginUserInfo(request.getLoginId(), request.getPassword(), request.getHospCode());
			if(account != null){
				SystemModelProto.SysAccountInfo.Builder accountInfo = SystemModelProto.SysAccountInfo.newBuilder();
				accountInfo.setUserId(account.getUserId());
				accountInfo.setUserName(account.getUserNm());
				
				response.setSysAccountInfo(accountInfo);
				response.setResult(true);
				return response.build();
			}
		}
		
		response.setResult(false);
		return response.build();
	}
}
