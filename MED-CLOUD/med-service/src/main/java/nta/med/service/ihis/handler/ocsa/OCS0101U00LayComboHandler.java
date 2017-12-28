package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.dao.medi.ocs.Ocs0133Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0101U00LayComboRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0101U00LayComboResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0101U00LayComboHandler extends ScreenHandler<OcsaServiceProto.OCS0101U00LayComboRequest, OcsaServiceProto.OCS0101U00LayComboResponse>{                             
	private static final Log LOGGER = LogFactory.getLog(OCS0101U00LayComboHandler.class);                                        
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;   
	
	@Resource
	private Ocs0133Repository ocs0133Repository;
	                                                                                                                
	@Override         
	@Transactional(readOnly = true)
	public OCS0101U00LayComboResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OCS0101U00LayComboRequest request)
			throws Exception {     
		String hospCode = request.getHospCode();
		String language = getLanguage(vertx, sessionId);
  	   	OcsaServiceProto.OCS0101U00LayComboResponse.Builder response = OcsaServiceProto.OCS0101U00LayComboResponse.newBuilder();                      
		// ORDER_GUBUN_BAS
		List<ComboListItemInfo> listOrderGubun = ocs0132Repository.getOCS0101U00ComboListItem(hospCode, "ORDER_GUBUN_BAS", language);
		if(!CollectionUtils.isEmpty(listOrderGubun)){
			for(ComboListItemInfo item : listOrderGubun){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListOrderGubun(info);
			}
		}
		
		// INPUT_CONTROL
		List<ComboListItemInfo> listInputControl = ocs0133Repository.getOCS0101U00InputControlComboListItem(hospCode, language);
		if(!CollectionUtils.isEmpty(listInputControl)){
			for(ComboListItemInfo item : listInputControl){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListInputControl(info);
			}
		}
		//DV
		List<ComboListItemInfo> listDV = ocs0132Repository.getOCS0101U00ComboListItem(hospCode, "DV_TIME", language);
		if(!CollectionUtils.isEmpty(listDV)){
			for(ComboListItemInfo item : listDV){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListDv(info);
			}
		}
		
		// INPUT_TYPE
		List<ComboListItemInfo> listInputType = ocs0132Repository.getOCS0101U00ComboListItem(hospCode, "INPUT_TYPE", language);
		if(!CollectionUtils.isEmpty(listInputType)){
			for(ComboListItemInfo item : listInputType){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListInputType(info);
			}
		}
		
		return response.build();
	}
}