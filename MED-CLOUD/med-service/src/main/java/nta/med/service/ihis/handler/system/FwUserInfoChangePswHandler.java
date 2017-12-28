package nta.med.service.ihis.handler.system;

import java.math.BigDecimal;
import java.util.Date;
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

import nta.med.core.common.annotation.Route;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.adm.LoginExtRepository;
import nta.med.data.model.ihis.system.FwUserInfoChangePswInfo;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class FwUserInfoChangePswHandler extends ScreenHandler<SystemServiceProto.FwUserInfoChangePswRequest, SystemServiceProto.UpdateResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(FwUserInfoChangePswHandler.class);                                    
	@Resource                                                                                                       
	private Adm3200Repository adm3200Repository;                                                                    
	@Resource
	private CommonRepository commonRepository;
	@Resource
    private LoginExtRepository loginExtRepository;

	@Override
	@Route(global = false)
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SystemServiceProto.FwUserInfoChangePswRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder(); 
		List<FwUserInfoChangePswInfo> listResult = adm3200Repository.getFwUserInfoChangePswInfo(getHospitalCode(vertx, sessionId), request.getUserId());
		Integer updateResult = null;
		if(!CollectionUtils.isEmpty(listResult)){
			boolean tExist = false;
			String hospCode = null;
			
//			List<String> listHosp = adm3200Repository.getHospCodeFwUserInfoChangePsw(request.getUserId());
//			if(!CollectionUtils.isEmpty(listHosp)){
//				hospCode = listHosp.get(0);
//			}
//			 
//			if(StringUtils.isEmpty(request.getUserId())){
//				hospCode = getHospitalCode(vertx, sessionId);
//			}
			
			hospCode = getHospitalCode(vertx, sessionId);
			
			if(request.getAttempt() > 5){
				//lock
				updateResult = loginExtRepository.changeLockStatus(BigDecimal.ZERO, request.getUserId(), hospCode);
				response.setResult(updateResult != null && updateResult > 0);
				return response.build();
			}
			String language = getLanguage(vertx, sessionId);
			for(FwUserInfoChangePswInfo result : listResult){
				if(result.getUserEndYmd() != null && 
						DateUtil.compare(DateUtil.toString(result.getUserEndYmd(), DateUtil.PATTERN_YYMMDD) , DateUtil.toString(new Date(), DateUtil.PATTERN_YYMMDD), DateUtil.PATTERN_YYMMDD) == -1){
					String mesage = commonRepository.getMessageByCodeAndLanguage("1", language);
					response.setResult(false);
					if(!StringUtils.isEmpty(mesage)){
						response.setMsg(mesage);
					}
					throw new ExecutionException(response.build());
				}
				if(!result.getPswd().equals(request.getOldPassword())){
					String mesage = commonRepository.getMessageByCodeAndLanguage("2", language);
					response.setResult(false);
					if(!StringUtils.isEmpty(mesage)){
						response.setMsg(mesage);
					}
					throw new ExecutionException(response.build());
				}
				tExist = true;
			}
			if(tExist == false){
				String mesage = commonRepository.getMessageByCodeAndLanguage("3", language);
				response.setResult(false);
				if(!StringUtils.isEmpty(mesage)){
					response.setMsg(mesage);
				}
				throw new ExecutionException(response.build());
			}
			
			updateResult = adm3200Repository.updateFwUserInfoChangePsw(hospCode, request.getNewPassword(), request.getUserId());
			updateResult = loginExtRepository.updateLoginExt(BigDecimal.ZERO, BigDecimal.ONE, request.getPwdHistory() , new Date(), request.getUserId(), hospCode);
		}
		response.setResult(updateResult != null && updateResult > 0);
		return response.build();
	}                                                                                                                 
}