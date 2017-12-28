package nta.med.service.ihis.handler.adma;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.annotation.Resource;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.adm.AdmsGroup;
import nta.med.core.domain.adm.AdmsGroupSystem;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.Language;
import nta.med.core.glossary.UserGroup;
import nta.med.core.glossary.UserRole;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.AdmsGroupRepository;
import nta.med.data.dao.medi.adm.AdmsGroupSystemRepository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.AdmaModelProto;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.AdmaServiceProto.ADMS2015U00CreateGroupHospitalRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
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
@Transactional
public class ADMS2015U00CreateGroupHospitalHandler extends ScreenHandler<AdmaServiceProto.ADMS2015U00CreateGroupHospitalRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(ADMS2015U00CreateGroupHospitalHandler.class);                                    
	
	@Resource
	private AdmsGroupRepository admsGroupRepository;
	
	@Resource
	private AdmsGroupSystemRepository admsGroupSystemRepository;
	
	@Resource                                                                                                       
	private Bas0001Repository bas0001Repository;
	
	@Override
	public boolean isAuthorized(Vertx vertx, String sessionId){
		return UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId));
	}
	
	@Override
	public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			ADMS2015U00CreateGroupHospitalRequest request) throws Exception {
		
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			List<Bas0001> bas0001s = bas0001Repository.findLatestByHospCode(request.getHospCode());
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(bas0001s.size() > 0 ? bas0001s.get(0).getHospCode() : getHospitalCode(vertx, sessionId),
					bas0001s.size() > 0 ? bas0001s.get(0).getLanguage() : getLanguage(vertx, sessionId), "", 1));
		}
	}
	
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			ADMS2015U00CreateGroupHospitalRequest request) throws Exception {
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();                      
		List<AdmaModelProto.ADMS2015U00GroupHospitalInfo> listGroup = request.getGroupListInfoList();
		List<AdmaModelProto.ADMS2015U00SystemHospitalInfo> listSystem = request.getSystemListItemList();
		try {
			Map<String, Long> mapAmsGroupId = new HashMap<String, Long>();
			if (!CollectionUtils.isEmpty(listGroup)) {
				for (AdmaModelProto.ADMS2015U00GroupHospitalInfo infoGroup : listGroup) {
					if (DataRowState.ADDED.getValue().equals(infoGroup.getDataRowState())){
						AdmsGroup admsGroup = insertAdmsGroupItem(request, infoGroup);
						mapAmsGroupId.put(infoGroup.getGrpId(), admsGroup.getAdmsGroupId());
					} else if (DataRowState.MODIFIED.getValue().equals(infoGroup.getDataRowState())) {
						insertOrUpdateAdmsGroupItem(request, infoGroup, mapAmsGroupId);
					} 
				}
			}
			
			if (!CollectionUtils.isEmpty(listSystem)) {
				for (AdmaModelProto.ADMS2015U00SystemHospitalInfo infoSystem : listSystem) {
					if (mapAmsGroupId == null || mapAmsGroupId.get(request.getGroupId()) == null) {
						List<AdmsGroup> listAdmsGroups = admsGroupRepository.getAdmsGroupItem(request.getHospCode(), request.getGroupId());
						if (!CollectionUtils.isEmpty(listAdmsGroups)) {
							mapAmsGroupId.put(request.getGroupId(), listAdmsGroups.get(0).getAdmsGroupId());
						} else {
							LOGGER.warn("NOT EXIST AdmsGroupId for grd_id = " + request.getGroupId());
							response.setResult(false);
							throw new ExecutionException(response.build());
						}
					}
					
					if (DataRowState.ADDED.getValue().equals(infoSystem.getDataRowState())){
						insertAdmsGroupSystemItem(request, infoSystem, mapAmsGroupId.get(infoSystem.getAdmsGroupSystemId()));
					} else if (DataRowState.MODIFIED.getValue().equals(infoSystem.getDataRowState())) {
						Integer selectFlg = "Y".equalsIgnoreCase(infoSystem.getSelectFlg()) ? 1 : 0;
						Integer update = admsGroupSystemRepository.updateAdmsGroupSystemItem(CommonUtils.parseInteger(infoSystem.getSystemSeq()), 
								selectFlg, request.getHospCode(), request.getGroupId(), infoSystem.getSystemId());
						if (update == null || update == 0) {
							insertAdmsGroupSystemItem(request, infoSystem, mapAmsGroupId.get(request.getGroupId()));
						}
					} 
				}
			}
			response.setResult(true);
		} catch (Exception e) {
			LOGGER.error(e.getMessage(), e);
			response.setResult(false);
			throw new ExecutionException(response.build());
		}
		return response.build();
	}
	
	@Override
	public UpdateResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			ADMS2015U00CreateGroupHospitalRequest request, UpdateResponse response) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			setSessionInfo(vertx, sessionId,
					SessionUserInfo.setSessionUserInfoByUserGroup(UserGroup.NTA.getValue(), Language.JAPANESE.toString().toUpperCase(), "", 0));
		}
		
		return response;
	}
	
	private Integer insertOrUpdateAdmsGroupItem(AdmaServiceProto.ADMS2015U00CreateGroupHospitalRequest request, AdmaModelProto.ADMS2015U00GroupHospitalInfo infoGroup, Map<String, Long> mapAmsGroupId){
		List<AdmsGroup> listGroup = admsGroupRepository.getAdmsGroupItem(request.getHospCode(), infoGroup.getGrpId());
		if (!CollectionUtils.isEmpty(listGroup)) {
			for (AdmsGroup item: listGroup) {
				item.setGrpSeq(CommonUtils.parseInteger(infoGroup.getGrpSeq()));
//				item.setSelectFlg(new BigDecimal("Y".equalsIgnoreCase(infoGroup.getSelectFlg()) ? 1D : 0D));
				if("Y".equalsIgnoreCase(infoGroup.getSelectFlg())){
					item.setSelectFlg(1);
				}else{
					item.setSelectFlg(0);
				}
				admsGroupRepository.save(item);
				mapAmsGroupId.put(item.getGrpId(), item.getAdmsGroupId());
			}
		} else {
			AdmsGroup newItem = insertAdmsGroupItem(request, infoGroup);
			mapAmsGroupId.put(newItem.getGrpId(), newItem.getAdmsGroupId());
		}
		return listGroup.size();
	}
	
	private AdmsGroup insertAdmsGroupItem (AdmaServiceProto.ADMS2015U00CreateGroupHospitalRequest request, AdmaModelProto.ADMS2015U00GroupHospitalInfo infoGroup) {
		AdmsGroup admsGroup = new AdmsGroup();
		admsGroup.setGrpId(infoGroup.getGrpId());
		admsGroup.setGrpSeq(CommonUtils.parseInteger(infoGroup.getGrpSeq()));
		admsGroup.setHospCode(request.getHospCode());
		if("Y".equalsIgnoreCase(infoGroup.getSelectFlg())){
			admsGroup.setSelectFlg(1);
		}else{
			admsGroup.setSelectFlg(0);
		}
		admsGroup.setSysId(request.getUserId());
		admsGroup.setUpdId(request.getUserId());
		admsGroup.setActiveFlg(1);
		admsGroupRepository.save(admsGroup);
		return admsGroup;
	}
	
	private void insertAdmsGroupSystemItem (AdmaServiceProto.ADMS2015U00CreateGroupHospitalRequest request, AdmaModelProto.ADMS2015U00SystemHospitalInfo infoSystem, Long admsGroupId) {
		AdmsGroupSystem admsGroupSystem = new AdmsGroupSystem();
		admsGroupSystem.setAdmsGroupId(admsGroupId);
		admsGroupSystem.setSystemId(infoSystem.getSystemId());
		admsGroupSystem.setSystemSeq(CommonUtils.parseInteger(infoSystem.getSystemSeq()));
		admsGroupSystem.setGrpId(request.getGroupId());
		admsGroupSystem.setHospCode(request.getHospCode());
		admsGroupSystem.setSelectFlg("Y".equalsIgnoreCase(infoSystem.getSelectFlg()) ? 1 : 0);
		admsGroupSystem.setSysId(request.getUserId());
		admsGroupSystem.setUpdId(request.getUserId());
		admsGroupSystem.setActiveFlg(1);
		admsGroupSystemRepository.save(admsGroupSystem);
	}
}