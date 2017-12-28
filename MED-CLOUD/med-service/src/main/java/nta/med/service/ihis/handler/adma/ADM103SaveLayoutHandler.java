package nta.med.service.ihis.handler.adma;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.adm.Adm3100;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.Language;
import nta.med.core.glossary.UserGroup;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.adm.Adm3100Repository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.service.ihis.proto.AdmaModelProto.ADM103UgrdUserGrpInfo;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service                                                                                                          
@Scope("prototype")
@Transactional
public class ADM103SaveLayoutHandler extends ScreenHandler<AdmaServiceProto.ADM103SaveLayoutRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(ADM103SaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private Adm3100Repository adm3100Repository;
	@Resource                                                                                                       
	private Bas0001Repository bas0001Repository;

	
	@Override
    @Transactional
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM103SaveLayoutRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			List<Bas0001> bas0001s = bas0001Repository.findLatestByHospCode(request.getHospCode());
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(bas0001s.size() > 0 ? bas0001s.get(0).getHospCode() : getHospitalCode(vertx, sessionId),
					bas0001s.size() > 0 ? bas0001s.get(0).getLanguage() : getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM103SaveLayoutRequest request) throws Exception {
		String language = getLanguage(vertx, sessionId);
		SystemServiceProto.UpdateResponse.Builder response = saveLayout(request, language);
		if(!response.getResult()){
			throw new ExecutionException(response.build());
		}
		return response.build();
	}
	
	public SystemServiceProto.UpdateResponse.Builder saveLayout(AdmaServiceProto.ADM103SaveLayoutRequest request, String language){
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		List<ADM103UgrdUserGrpInfo> listItem = request.getItemInfoList();
		String hospCode = request.getHospCode();
		if(!CollectionUtils.isEmpty(listItem)){
			for(ADM103UgrdUserGrpInfo item : listItem){
				if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					Adm3100 adm3100 = new Adm3100();
					adm3100.setHospCode(hospCode);
					adm3100.setUserGroup(item.getUserGroup());
					adm3100.setGroupNm(item.getGroupNm());
					adm3100.setUpMemb(request.getSysId());
					adm3100.setUpTime(new Date());
					adm3100.setCrMemb(request.getSysId());
					adm3100.setCrTime(new Date());
					adm3100.setLanguage(language);
					adm3100Repository.save(adm3100);
				} else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					if(adm3100Repository.updateADM103SaveLayout(hospCode, item.getGroupNm(), request.getSysId(), new Date(), item.getUserGroup(), language) <= 0){
						response.setResult(false);
						return response;
					}
				} else if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					if(adm3100Repository.deleteADM103SaveLayout(hospCode, item.getUserGroup(), language) <= 0){
						response.setResult(false);
						return response;
					}
				}
			}
		}
		response.setResult(true);
		return response;
	}
	
	@Override
	public UpdateResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
				AdmaServiceProto.ADM103SaveLayoutRequest request, UpdateResponse response) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			setSessionInfo(vertx, sessionId,
					SessionUserInfo.setSessionUserInfoByUserGroup(UserGroup.NTA.getValue(), Language.JAPANESE.toString().toUpperCase(), "", 0));
		}
			
		return response;
	}
}
