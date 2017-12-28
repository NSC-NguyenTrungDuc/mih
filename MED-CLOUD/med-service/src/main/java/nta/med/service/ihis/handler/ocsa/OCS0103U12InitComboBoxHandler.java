package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12InitComboBoxRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12InitComboBoxResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U12InitComboBoxHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U12InitComboBoxRequest, OcsaServiceProto.OCS0103U12InitComboBoxResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS0103U12InitComboBoxHandler.class);                                        
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override          
	@Transactional(readOnly = true)
	public OCS0103U12InitComboBoxResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0103U12InitComboBoxRequest request) throws Exception {                                                                 
  	   	OcsaServiceProto.OCS0103U12InitComboBoxResponse.Builder response = OcsaServiceProto.OCS0103U12InitComboBoxResponse.newBuilder();                      
		//cboSearch
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
		List<ComboListItemInfo> listCboSearch = ocs0132Repository.getInjsComboListItemInfo(hospCode, language, "SEARCH_GUBUN");
		if(!CollectionUtils.isEmpty(listCboSearch)){
			for(ComboListItemInfo item :listCboSearch){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCboSearchConditionList(info);
			}
		}
		//cboInput
		List<ComboListItemInfo> listCboInputGubun = ocs0132Repository.getOCS0103U12CboInitGubunListItem(hospCode, language);
		if(!CollectionUtils.isEmpty(listCboInputGubun)){
			for(ComboListItemInfo item :listCboInputGubun){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCboInputGubun(info);
			}
		}
		return response.build();
	}

}