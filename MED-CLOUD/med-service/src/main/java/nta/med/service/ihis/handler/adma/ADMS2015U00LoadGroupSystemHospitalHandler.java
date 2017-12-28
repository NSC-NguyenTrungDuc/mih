package nta.med.service.ihis.handler.adma;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.bas.Bas0001;
import nta.med.core.glossary.Language;
import nta.med.core.glossary.UserGroup;
import nta.med.core.glossary.UserRole;
import nta.med.data.dao.medi.adm.AdmsGroupRepository;
import nta.med.data.dao.medi.adm.AdmsGroupSystemRepository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.model.ihis.adma.ADMS2015U00GetGroupHospitalInfo;
import nta.med.data.model.ihis.adma.ADMS2015U00GetHospitalInfo;
import nta.med.data.model.ihis.adma.ADMS2015U00GetSystemHospitalInfo;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.AdmaServiceProto.ADMS2015U00LoadGroupSystemHospitalRequest;
import nta.med.service.ihis.proto.AdmaServiceProto.ADMS2015U00LoadGroupSystemHospitalResponse;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00GrdOCS0108Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00GrdOCS0108Response;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

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
public class ADMS2015U00LoadGroupSystemHospitalHandler extends ScreenHandler<AdmaServiceProto.ADMS2015U00LoadGroupSystemHospitalRequest, AdmaServiceProto.ADMS2015U00LoadGroupSystemHospitalResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(ADMS2015U00LoadGroupSystemHospitalHandler.class);                                    
	@Resource
	private Bas0001Repository bas0001Repository;
	@Resource
	private AdmsGroupRepository admsGroupRepository;
	@Resource
	private AdmsGroupSystemRepository admsGroupSystemRepository;
	@Override
	public boolean isAuthorized(Vertx vertx, String sessionId){

		return UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId));
	}
	
	@Override
	public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADMS2015U00LoadGroupSystemHospitalRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			List<Bas0001> bas0001s = bas0001Repository.findLatestByHospCode(request.getHospCode());
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(bas0001s.size() > 0 ? bas0001s.get(0).getHospCode() : getHospitalCode(vertx, sessionId),
					bas0001s.size() > 0 ? bas0001s.get(0).getLanguage() : getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override  
	@Transactional(readOnly = true)    
	public ADMS2015U00LoadGroupSystemHospitalResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			ADMS2015U00LoadGroupSystemHospitalRequest request) throws Exception {
  	   	AdmaServiceProto.ADMS2015U00LoadGroupSystemHospitalResponse.Builder response = AdmaServiceProto.ADMS2015U00LoadGroupSystemHospitalResponse.newBuilder();
  	   	String language = getLanguage(vertx, sessionId);
  	   	ADMS2015U00GetHospitalInfo getHosp = bas0001Repository.getADMS2015U00GetHospitalInfo(request.getHospCode(), language);
		if(getHosp != null && !getHosp.getHospCode().isEmpty()) {
			List<ADMS2015U00GetGroupHospitalInfo> listGroup = admsGroupRepository.getADMS2015U00GetGroupHospitalInfo(request.getHospCode(), language);
			if(!CollectionUtils.isEmpty(listGroup)) {
				for (ADMS2015U00GetGroupHospitalInfo itemGroup : listGroup) {
					AdmaModelProto.ADMS2015U00GroupHospitalInfo.Builder infoGroup = AdmaModelProto.ADMS2015U00GroupHospitalInfo.newBuilder();
					if (itemGroup.getAdmsGroupId() != null) {
						infoGroup.setAdmsGroupId(itemGroup.getAdmsGroupId().toString());
					}
					if (!StringUtils.isEmpty(itemGroup.getGrpId())) {
						infoGroup.setGrpId(itemGroup.getGrpId());
					}
					if (itemGroup.getGrpSeq() != null) {
						infoGroup.setGrpSeq(itemGroup.getGrpSeq().toString());
					}
					if (!StringUtils.isEmpty(itemGroup.getHospCode())) {
						infoGroup.setHospCode(itemGroup.getHospCode());
					}
					if (itemGroup.getSelectFlg() != null) {
						infoGroup.setSelectFlg("1".equals(itemGroup.getSelectFlg()) ? "Y" : "N");
					}
					if (!StringUtils.isEmpty(itemGroup.getGrpNm())) {
						infoGroup.setGrpNm(itemGroup.getGrpNm());
					}
					response.addGroupInfo(infoGroup);
				}
				if (!listGroup.get(0).getGrpId().isEmpty()) {
					List<ADMS2015U00GetSystemHospitalInfo> listSystem = admsGroupSystemRepository.getADMS2015U00GetSystemHospitalInfo(request.getHospCode(), listGroup.get(0).getGrpId(), language);
					if(!CollectionUtils.isEmpty(listSystem)) {
						for (ADMS2015U00GetSystemHospitalInfo itemSystem : listSystem) {
							AdmaModelProto.ADMS2015U00SystemHospitalInfo.Builder infoSystem = AdmaModelProto.ADMS2015U00SystemHospitalInfo.newBuilder();
							if (itemSystem.getAdmsGroupSystemId() != null) {
								infoSystem.setAdmsGroupSystemId(itemSystem.getAdmsGroupSystemId().toString());
							}
							if (!StringUtils.isEmpty(itemSystem.getSysId())) {
								infoSystem.setSystemId(itemSystem.getSysId());
							}
							if (itemSystem.getSysSeq() != null) {
								infoSystem.setSystemSeq(itemSystem.getSysSeq().toString());
							}
							if (!StringUtils.isEmpty(itemSystem.getHospCode())) {
								infoSystem.setHospCode(itemSystem.getHospCode());
							}
							if (itemSystem.getSelectFlg() != null) {
								infoSystem.setSelectFlg("1".equals(itemSystem.getSelectFlg()) ? "Y" : "N");
							}
							if (!StringUtils.isEmpty(itemSystem.getSysNm())) {
								infoSystem.setSysNm(itemSystem.getSysNm());
							}

							response.addSystemInfo(infoSystem);
						}
					}
				}
			}
		} 
				
		return response.build();
	} 
	
	@Override
	public ADMS2015U00LoadGroupSystemHospitalResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			ADMS2015U00LoadGroupSystemHospitalRequest request, ADMS2015U00LoadGroupSystemHospitalResponse response) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			setSessionInfo(vertx, sessionId,
					SessionUserInfo.setSessionUserInfoByUserGroup(UserGroup.NTA.getValue(), Language.JAPANESE.toString().toUpperCase(), "", 0));
		}
		
		return response;
	}
	
}