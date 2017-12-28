package nta.med.service.ihis.handler.adma;

import java.util.ArrayList;
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

import nta.med.core.domain.adm.Adm0500;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.Language;
import nta.med.core.glossary.UserGroup;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm0500Repository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.service.ihis.proto.AdmaModelProto.ADM108UGrdListItemInfo;
import nta.med.service.ihis.proto.AdmaServiceProto.ADM108USaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;
import nta.med.service.ihis.proto.AdmaServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Transactional
@Service
@Scope("prototype")
public class ADM108USaveLayoutHandler extends ScreenHandler<AdmaServiceProto.ADM108USaveLayoutRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOGGER = LogFactory.getLog(ADM108USaveLayoutHandler.class);
    
    @Resource
    private Adm0500Repository adm0500Repository;
    
    @Resource                                                                                                       
	private Bas0001Repository bas0001Repository;
    
    @Override
    public boolean isAuthorized(Vertx vertx, String sessionId){
		return UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))
				|| UserRole.NORMAL_ADMIN.getValue().equals(getUserRole(vertx, sessionId));
    }
    
    @Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId,
    		ADM108USaveLayoutRequest request) throws Exception {
    	
    	if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			List<Bas0001> bas0001s = bas0001Repository.findLatestByHospCode(request.getHospCode());
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(bas0001s.size() > 0 ? bas0001s.get(0).getHospCode() : getHospitalCode(vertx, sessionId),
					bas0001s.size() > 0 ? bas0001s.get(0).getLanguage() : getLanguage(vertx, sessionId), "", 1));
		}
    }
    
    @Override
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, AdmaServiceProto.ADM108USaveLayoutRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        if (CollectionUtils.isEmpty(request.getGrdListItemInfoList())) {
            response.setResult(false);
            return response.build();
        }
        
        String hospCode = UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) ? request.getHospCode() : getHospitalCode(vertx, sessionId);
        response.setResult(saveAdm0500(hospCode, request));
        return response.build();
    }

    @Override
    public UpdateResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
    		ADM108USaveLayoutRequest request, UpdateResponse response) throws Exception {
    	if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			setSessionInfo(vertx, sessionId,
					SessionUserInfo.setSessionUserInfoByUserGroup(UserGroup.NTA.getValue(), Language.JAPANESE.toString().toUpperCase(), "", 0));
		}
			
		return response;
    }
    
    public boolean saveAdm0500(String hospCode, AdmaServiceProto.ADM108USaveLayoutRequest request) {
        boolean save = false;
        String userId = request.getUserId();
        List<Adm0500> listSave = new ArrayList<>();
        
        for (ADM108UGrdListItemInfo item : request.getGrdListItemInfoList()) {
            if (item.getDataRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
                Adm0500 adm0500 = getAdm0500(item, userId, hospCode);
                listSave.add(adm0500);
            } else if (item.getDataRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
                save = deleteAdm0500(item, hospCode);
                if (!save) return false;
            }
        }
        
        for (ADM108UGrdListItemInfo item : request.getGrdListItemInfoList()) {
            if (item.getDataRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
                save = updateAdm0500(item, userId, hospCode);
                if (!save) return false;
            }
        }
        
        if (!CollectionUtils.isEmpty(listSave)) {
            adm0500Repository.save(listSave);
        }
        
        return true;
    }

    public Adm0500 getAdm0500(ADM108UGrdListItemInfo item, String userId, String hospCode) {
        Adm0500 adm0500 = new Adm0500();
        adm0500.setSysId(item.getSysId());
        adm0500.setSeq(CommonUtils.parseDouble(item.getNewSeq()));
        adm0500.setPgmSysId(item.getPgmSysId());
        adm0500.setPgmId(item.getPgmId());
        adm0500.setCrMemb(userId);
        adm0500.setCrTime(new Date());
        adm0500.setHospCode(hospCode);
        
        return adm0500;
    }

    public boolean updateAdm0500(ADM108UGrdListItemInfo item, String userId, String hospCode) {
    	return adm0500Repository.updateAdm108UModified(
                item.getPgmSysId(),
                item.getPgmId(),
                userId,
                new Date(),
                CommonUtils.parseDouble(item.getNewSeq()),
                item.getSysId(),
                CommonUtils.parseDouble(item.getSeq()),
                hospCode) > 0;
    }

    public boolean deleteAdm0500(ADM108UGrdListItemInfo item, String hospCode) {
    	return adm0500Repository.deleteAdm108UDeleted(item.getSysId(), CommonUtils.parseDouble(item.getSeq()), hospCode) > 0;
    }
}