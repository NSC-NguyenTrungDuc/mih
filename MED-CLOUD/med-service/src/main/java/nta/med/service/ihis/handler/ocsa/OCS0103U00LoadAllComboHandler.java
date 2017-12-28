package nta.med.service.ihis.handler.ocsa;

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

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0101Repository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.dao.medi.ocs.Ocs0133Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00LoadAllComboRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00LoadAllComboResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U00LoadAllComboHandler extends ScreenHandler<OcsaServiceProto.OCS0103U00LoadAllComboRequest, OcsaServiceProto.OCS0103U00LoadAllComboResponse> {                   
	private static final Log LOGGER = LogFactory.getLog(OCS0103U00LoadAllComboHandler.class);                                    
	
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;   
	
	@Resource                                                                                                       
	private Ocs0101Repository ocs0101Repository; 
	
	@Resource                                                                                                       
	private Ocs0133Repository ocs0133Repository;  
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OCS0103U00LoadAllComboRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override
	@Transactional(readOnly = true)
	public OCS0103U00LoadAllComboResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0103U00LoadAllComboRequest request) throws Exception {
		OcsaServiceProto.OCS0103U00LoadAllComboResponse.Builder response = OcsaServiceProto.OCS0103U00LoadAllComboResponse.newBuilder();
		String hospCode = request.getHospCode();
		String language = getLanguage(vertx, sessionId);
		//order_danui_item                 
		if(!request.getIsAll()){
			List<ComboListItemInfo> listOrderDanui = ocs0132Repository.getComboOrdDanui(hospCode, language);
			if(!CollectionUtils.isEmpty(listOrderDanui)){
				for(ComboListItemInfo item : listOrderDanui){
					CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addOrderDanuiItem(info);
				}
			}
		} else {
			CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
			info.setCode("000");
			info.setCodeName("");
			response.addOrderDanuiItem(info);
			List<ComboListItemInfo> listComboOrdDanui=ocs0132Repository.getComboOrdDanui(hospCode, language);
			if(!CollectionUtils.isEmpty(listComboOrdDanui)){
				for(ComboListItemInfo item : listComboOrdDanui){
					info = CommonModelProto.ComboListItemInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addOrderDanuiItem(info);
				}
			}
		}
		//slip_gubun_item
		List<ComboListItemInfo> listSlipGubun = ocs0101Repository.getOCS0103U00ComboListItemInfoOCS0101(language);
		if(!CollectionUtils.isEmpty(listSlipGubun)){
			for(ComboListItemInfo item : listSlipGubun){
				CommonModelProto.ComboListItemInfo.Builder info  = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addSlipGubunItem(info);
			}
		}	
		//result_gubun_item                 
		List<ComboListItemInfo> listResultGubun = ocs0132Repository.getOCS0101U00ComboListItem(hospCode, "RESULT_GUBUN", language);
		if(!CollectionUtils.isEmpty(listResultGubun)){
			for(ComboListItemInfo item : listResultGubun){
				CommonModelProto.ComboListItemInfo.Builder info  = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addResultGubunItem(info);
			}
		}		
		//if_input_control_item  
		List<ComboListItemInfo> listIfInputControl = ocs0132Repository.getOCS0132ComboList(hospCode, language, "IF_INPUT_CONTROL");
		if(!CollectionUtils.isEmpty(listIfInputControl)){
			for(ComboListItemInfo item : listIfInputControl){
				CommonModelProto.ComboListItemInfo.Builder info  = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addIfInputControlItem(info);
			}
		}		
		//emergency_item  
		List<ComboListItemInfo> listEmergency = ocs0132Repository.getOCS0101U00ComboListItem(hospCode, "EMERGENCY", language);
		if(!CollectionUtils.isEmpty(listEmergency)){
			for(ComboListItemInfo item : listEmergency){
				CommonModelProto.ComboListItemInfo.Builder info  = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addEmergencyItem(info);
			}
		}		
		//subun_convert_gubun_item 
		List<ComboListItemInfo> listSubunConvertGubun = ocs0132Repository.getOCS0101U00ComboListItem(hospCode, "SUBUL_CONVERT_GUBUN", language);
		if(!CollectionUtils.isEmpty(listSubunConvertGubun)){
			for(ComboListItemInfo item : listSubunConvertGubun){
				CommonModelProto.ComboListItemInfo.Builder info  = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addSubunConvertGubunItem(info);
			}
		}		
		//wonyoi_order_yn_item    
		List<ComboListItemInfo> listWonyoiOrderYn = ocs0132Repository.getOCS0132ComboList(hospCode, language, "WONYOI_ORDER_YN");
		if(!CollectionUtils.isEmpty(listWonyoiOrderYn)){
			for(ComboListItemInfo item : listWonyoiOrderYn){
				CommonModelProto.ComboListItemInfo.Builder info  = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addWonyoiOrderYnItem(info);
			}
		}	
		//dv_time_item   
		List<ComboListItemInfo> listDvTime = ocs0132Repository.getOCS0103U00ComboListItemInfo(hospCode, language, "DV_TIME", false);
		if(!CollectionUtils.isEmpty(listDvTime)){
			for(ComboListItemInfo item : listDvTime){
				CommonModelProto.ComboListItemInfo.Builder info  = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDvTimeItem(info);
			}
		}		
		//input_control_item  
		List<ComboListItemInfo> listInputControl = ocs0133Repository.getOCS0103U00ComboListItemInfo(hospCode, language);
		if(!CollectionUtils.isEmpty(listInputControl)){
			for(ComboListItemInfo item : listInputControl){
				CommonModelProto.ComboListItemInfo.Builder info  = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addInputControlItem(info);
			}
		}		
		//order_gubun_item    
		List<ComboListItemInfo> listOrderGubun = ocs0132Repository.getOCS0103U00ComboListItemInfo(hospCode, language, "ORDER_GUBUN_BAS", true);
		if(!CollectionUtils.isEmpty(listOrderGubun)){
			for(ComboListItemInfo item : listOrderGubun){
				CommonModelProto.ComboListItemInfo.Builder info  = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addOrderGubunItem(info);
			}
		}	
		return response.build();
	}    
	
	@Override
	public OCS0103U00LoadAllComboResponse postHandle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS0103U00LoadAllComboRequest request, OCS0103U00LoadAllComboResponse response) throws Exception {
		
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId)) && !StringUtils.isEmpty(request.getHospCode())) {
			setSessionInfo(vertx, sessionId,
					SessionUserInfo.setSessionUserInfoByUserGroup("NTA", getLanguage(vertx, sessionId), "", 1));
		}
		
		return response;
	}
	
}