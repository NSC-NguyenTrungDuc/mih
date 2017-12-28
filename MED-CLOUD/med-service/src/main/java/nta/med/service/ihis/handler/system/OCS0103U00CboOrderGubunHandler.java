package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.domain.ocs.Ocs0132;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;
import nta.med.service.ihis.proto.SystemServiceProto.OCS0103U00CboOrderGubunRequest;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U00CboOrderGubunHandler
	extends ScreenHandler<SystemServiceProto.OCS0103U00CboOrderGubunRequest, SystemServiceProto.ComboResponse> {                     
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                     
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, OCS0103U00CboOrderGubunRequest request)
			throws Exception {                                                                 
  	   	SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
		List<ComboListItemInfo> listCombo = ocs0132Repository.getCodeAndCodeNameByCodeType(hospCode, language, "ORDER_GUBUN_BAS");
		List<Ocs0132> ocs0132s = ocs0132Repository.getByCodeTypeOrderByCode(hospCode, language, "ADMISSION_FEE");
		if(!CollectionUtils.isEmpty(ocs0132s)){
			for(Ocs0132 ocs0132 : ocs0132s){
				ComboListItemInfo info = new ComboListItemInfo(ocs0132.getCode(), ocs0132.getCodeName()); 
				listCombo.add(info);
			}
		}
		if(!CollectionUtils.isEmpty(listCombo)){
			for(ComboListItemInfo item : listCombo){
				CommonModelProto.ComboListItemInfo.Builder info  = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboItem(info);
			}
		}	
		return response.build();
	}                                                                                                                                                   
}