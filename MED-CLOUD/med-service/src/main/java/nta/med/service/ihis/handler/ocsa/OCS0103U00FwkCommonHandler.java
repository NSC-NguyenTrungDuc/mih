package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm9983Repository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.inv.Inv0110Repository;
import nta.med.data.dao.medi.ocs.Ocs0102Repository;
import nta.med.data.dao.medi.ocs.Ocs0113Repository;
import nta.med.data.dao.medi.ocs.Ocs0116Repository;
import nta.med.data.dao.medi.ocs.Ocs0128Repository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.dao.medi.ocs.Ocs0170Repository;
import nta.med.data.dao.medi.ocs.Ocs0803Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocsa.OCS0103U00FwkCommonInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00FwkCommonRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00FwkCommonResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U00FwkCommonHandler extends ScreenHandler<OcsaServiceProto.OCS0103U00FwkCommonRequest, OcsaServiceProto.OCS0103U00FwkCommonResponse> {                     
	
	private static final Log LOGGER = LogFactory.getLog(OCS0103U00FwkCommonHandler.class);                                    
	
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository; 
	
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Resource
	private Ocs0128Repository ocs0128Repository;
	
	@Resource
	private Ocs0116Repository ocs0116Repository;
	
	@Resource
	private Ocs0102Repository ocs0102Repository;
	
	@Resource
	private Ocs0170Repository ocs0170Repository;
	
	@Resource
	private Ocs0113Repository ocs0113Repository;
	
	@Resource
	private Ocs0803Repository ocs0803Repository;
	
	@Resource
	private Inv0110Repository inv0110Repository;
	
	@Resource
	private Adm9983Repository adm9983Repository;
	                
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, OcsaServiceProto.OCS0103U00FwkCommonRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override       
	@Transactional(readOnly = true)
	public OCS0103U00FwkCommonResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0103U00FwkCommonRequest request)
			throws Exception {                                                                
  	   	OcsaServiceProto.OCS0103U00FwkCommonResponse.Builder response = OcsaServiceProto.OCS0103U00FwkCommonResponse.newBuilder();                      
		List<ComboListItemInfo> listCombo =  null;
		List<OCS0103U00FwkCommonInfo> listFwk = null;
		String hospCode = request.getHospCode();
		String language = getLanguage(vertx, sessionId);
		
		if(request.getIsGridControl()){
			switch (request.getGridName()) {
			case "grdOCS0108":
				if("ord_danui".equalsIgnoreCase(request.getControlName())){
					listCombo = ocs0132Repository.getComboDataSourceInfoByCodeTypeOrOrderBy(hospCode, language, "ORD_DANUI", true);
				}
				break;
			case "grdOCS0115":
				if("input_part".equalsIgnoreCase(request.getControlName())){
					listCombo = bas0260Repository.getSchsSCH0201Q02JundalComboList(hospCode, language, true, true, false);
				}else if("jundal_part_out".equalsIgnoreCase(request.getControlName())){
					listCombo = ocs0128Repository.getOCS0103U00ComboListItemInfo(hospCode, language, "O");
				}else if("jundal_part_inp".equalsIgnoreCase(request.getControlName())){
					listCombo = ocs0128Repository.getOCS0103U00ComboListItemInfo(hospCode, language, "I");
				}else if("move_part".equalsIgnoreCase(request.getControlName())){
					listCombo = bas0260Repository.getSchsSCH0201Q02JundalComboList(hospCode, language, true, false, true);
				}
				break;
			case "grdOCS0113":
				listCombo = ocs0116Repository.getOCS0113U00GetFindWorker(hospCode, true);
				break;
			default:
				break;
			}
		}else{
			switch (request.getControlName()) {
			 case "fbxQrySlipCode":
				 listCombo = ocs0102Repository.getOCS0103U00ComboListItemInfo(hospCode, request.getSlipGubun(), true, language);
				break;
			 case "fbxSlipCode":
				 listCombo = ocs0102Repository.getOCS0103U00ComboListItemInfo(hospCode, request.getSlipGubun(), false, language);
				 break;
			 case "fbxSpecificComment":
				 listCombo = ocs0170Repository.getOCS0103U00ComboListItemInfo(hospCode);
				 break;
			 case "fbxJundalPartOut":
				 listCombo = ocs0128Repository.getOCS0103U00ComboListItemInfo(hospCode, language, "O");
				 break;
			 case "fbxJundalPartInp":
				 listCombo = ocs0128Repository.getOCS0103U00ComboListItemInfo(hospCode, language, "I");
				 break;
			 case "fbxMovePart":
				 listCombo = bas0260Repository.getSchsSCH0201Q02JundalComboList(hospCode, language, true, false, true);
				 break;
			 case "fbxBogyongCode": 
				 listCombo = ocs0132Repository.getOCS0132ComboList(hospCode, language, "JUSA");
				 break;
			 case "fbxSpecimenDefault":
				 listCombo = ocs0113Repository.getOCS0103U00ComboListItemInfo(hospCode, request.getHangmogCode());
				 break;
			 case "fbxPatStatusGr":
				 listCombo = ocs0803Repository.getOCS0103U00ComboListItemInfo(hospCode, language);
				 break;
			 case "fbxJaeryoCode":
				 listCombo = inv0110Repository.getOCS0103U00ComboListItemInfo(hospCode, "");
				 break;
			 case "fbxYJ_CODE":
				 listFwk = adm9983Repository.getOCS0103U00OCS0103U00FwkCommonInfo(request.getSgCode(), request.getKijunCode());
				 break;
			default:
				break;
			}
		}
		if(!CollectionUtils.isEmpty(listCombo)){
			for(ComboListItemInfo item : listCombo){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboItem(info);
			}
		}
		
		if(!CollectionUtils.isEmpty(listFwk)){
			for(OCS0103U00FwkCommonInfo item : listFwk){
				OcsaModelProto.OCS0103U00FwkCommonInfo.Builder info = OcsaModelProto.OCS0103U00FwkCommonInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addFwkItem(info);
			}
		}
		
		return response.build();
	}

}