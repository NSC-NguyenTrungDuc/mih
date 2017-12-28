package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.helper.OrderBizHelper;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301U00CboDoctorGwaRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0301U00CboDoctorGwaResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0301U00CboDoctorGwaHandler extends ScreenHandler<OcsaServiceProto.OCS0301U00CboDoctorGwaRequest, OcsaServiceProto.OCS0301U00CboDoctorGwaResponse> {                     
	
	@Resource                                                                                                       
	private Adm3200Repository adm3200Repository;                                                                    
	
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0301U00CboDoctorGwaRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override       
	@Transactional(readOnly = true)
	public OCS0301U00CboDoctorGwaResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0301U00CboDoctorGwaRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0301U00CboDoctorGwaResponse.Builder response = OcsaServiceProto.OCS0301U00CboDoctorGwaResponse.newBuilder();                      
		String hospCode = request.getHospCode();
		String userGubun = adm3200Repository.getUserGubun(hospCode, request.getUserId());
		String language = getLanguage(vertx, sessionId);
		if(!StringUtils.isEmpty(userGubun)){
			response.setUserGubun(userGubun);
		}
		
		List<ComboListItemInfo> listDoctorGwa = bas0260Repository.getOCS0301U00CboDoctorGwa(hospCode, language, request.getUserId());
		if(!CollectionUtils.isEmpty(listDoctorGwa)){
			for(ComboListItemInfo item : listDoctorGwa){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDoctorGwaCb(info);
			}
		}
		
		if(request.getGwaInfo() != null){
			String gwaInfo = OrderBizHelper.getLoadColumnCodeName(hospCode, language, request.getGwaInfo());
			if(!StringUtils.isEmpty(gwaInfo)){
				response.setGwaInfo(gwaInfo);
			}
		}
		
		if(request.getUserInfo() != null){
			String gwaInfo = OrderBizHelper.getLoadColumnCodeName(hospCode, language, request.getUserInfo());
			if(!StringUtils.isEmpty(gwaInfo)){
				response.setUserInfo(gwaInfo);
			}
		}
		return response.build();																																					
	}                                                                                                                                                   
}