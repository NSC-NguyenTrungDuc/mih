package nta.med.service.ihis.handler.drug;

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

import nta.med.core.domain.bas.Bas0001;
import nta.med.core.glossary.Language;
import nta.med.core.glossary.UserGroup;
import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.DrugServiceProto;
import nta.med.service.ihis.proto.DrugServiceProto.DRG0120U00ComboListResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class DRG0120U00ComboListHandler extends ScreenHandler<DrugServiceProto.DRG0120U00ComboListRequest, DrugServiceProto.DRG0120U00ComboListResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(DRG0120U00ComboListHandler.class);                                    
	@Resource                                                                                                       
	private Inv0102Repository inv0102Repository;    
	@Resource
    private Bas0001Repository bas0001Repository;

	@Override
    @Transactional
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, DrugServiceProto.DRG0120U00ComboListRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			List<Bas0001> bas0001s = bas0001Repository.findLatestByHospCode(request.getHospCode());
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(bas0001s.size() > 0 ? bas0001s.get(0).getHospCode() : getHospitalCode(vertx, sessionId),
					bas0001s.size() > 0 ? bas0001s.get(0).getLanguage() : getLanguage(vertx, sessionId), "", 1));
		}
    }
	

	@Override
	@Transactional(readOnly = true)
	public DrugServiceProto.DRG0120U00ComboListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			DrugServiceProto.DRG0120U00ComboListRequest request) throws Exception {
		DrugServiceProto.DRG0120U00ComboListResponse.Builder response = DrugServiceProto.DRG0120U00ComboListResponse.newBuilder(); 
		// 32
		List<ComboListItemInfo> list32 = inv0102Repository.getDRG0120U00ComboListItem(getHospitalCode(vertx, sessionId), request.getParam32(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(list32)){
			for(ComboListItemInfo item : list32){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCboList32(info);
			}
		}
		
		//33
		List<ComboListItemInfo> list33 = inv0102Repository.getDRG0120U00ComboListItem(getHospitalCode(vertx, sessionId), request.getParam33(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(list33)){
			for(ComboListItemInfo item : list33){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCboList33(info);
			}
		}
		
		// 34
		List<ComboListItemInfo> list34 = inv0102Repository.getDRG0120U00ComboListItem(getHospitalCode(vertx, sessionId), request.getParam34(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(list34)){
			for(ComboListItemInfo item : list34){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCboList34(info);
			}
		}
		
		// 35
		List<ComboListItemInfo> list35 = inv0102Repository.getDRG0120U00ComboListItem(getHospitalCode(vertx, sessionId), request.getParam35(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(list35)){
			for(ComboListItemInfo item : list35){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCboList35(info);
			}
		}
		
		//UA
		List<ComboListItemInfo> listUa = inv0102Repository.getDRG0120U00ComboListItem(getHospitalCode(vertx, sessionId), request.getParamUA(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listUa)){
			for(ComboListItemInfo item : listUa){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCboListUA(info);
			}
		}
		return response.build();
	}    
	
	@Override
	public DRG0120U00ComboListResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			DrugServiceProto.DRG0120U00ComboListRequest request, DRG0120U00ComboListResponse response) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			setSessionInfo(vertx, sessionId,
					SessionUserInfo.setSessionUserInfoByUserGroup(UserGroup.NTA.getValue(), Language.JAPANESE.toString().toUpperCase(), "", 0));
		}
		
		return response;
	}
}