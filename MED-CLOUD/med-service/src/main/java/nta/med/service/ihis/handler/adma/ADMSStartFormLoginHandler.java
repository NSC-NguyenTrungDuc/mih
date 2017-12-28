package nta.med.service.ihis.handler.adma;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm0200Repository;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.model.ihis.adma.ADMSStartFormLoginInfo;
import nta.med.data.model.ihis.adma.UserLoginFormListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.AdmaServiceProto.ADMSStartFormLoginRequest;
import nta.med.service.ihis.proto.AdmaServiceProto.ADMSStartFormLoginResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ADMSStartFormLoginHandler extends ScreenHandler<AdmaServiceProto.ADMSStartFormLoginRequest, AdmaServiceProto.ADMSStartFormLoginResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(ADMSStartFormLoginHandler.class);                                    
	@Resource                                                                                                       
	private Adm3200Repository adm3200Repository;
	@Resource                                                                                                       
	private Adm0200Repository adm0200Repository;
	                                                                                                                
	@Override                 
	@Transactional(readOnly = true)    
	public ADMSStartFormLoginResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, ADMSStartFormLoginRequest request)
					throws Exception {
  	   	AdmaServiceProto.ADMSStartFormLoginResponse.Builder response = AdmaServiceProto.ADMSStartFormLoginResponse.newBuilder();                      
		UserLoginFormListItemInfo userLogin = adm3200Repository.getUserLoginFormListItemInfo(request.getSysId(), request.getPwd());
		List<ADMSStartFormLoginInfo> listStartForm = null;
		String language = getLanguage(vertx, sessionId);
		if (userLogin!=null) {
			if ("NTA".equals(userLogin.getHospCode()) && "SAM".equals(userLogin.getUserGroup())) {
				listStartForm = adm0200Repository.getADMSStartFormLoginInfo(userLogin.getHospCode(), userLogin.getUserId(), language, false);
			} else {
				listStartForm = adm0200Repository.getADMSStartFormLoginInfo(userLogin.getHospCode(), userLogin.getUserId(), language, true);
			}
			if (!CollectionUtils.isEmpty(listStartForm)) {
				for (ADMSStartFormLoginInfo item : listStartForm) {
					AdmaModelProto.ADMSStartFormLoginInfo.Builder info = AdmaModelProto.ADMSStartFormLoginInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addLoginInfo(info);
				}
			}
		}
				
		return response.build();
	}                                                                                                                 
}