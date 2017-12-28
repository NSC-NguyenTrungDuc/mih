package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class CFFormGetSelectHopeDateCboNalsuHandler extends ScreenHandler<SystemServiceProto.CFFormGetSelectHopeDateCboNalsuRequest, SystemServiceProto.ComboResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(CFFormGetSelectHopeDateCboNalsuHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.ComboResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SystemServiceProto.CFFormGetSelectHopeDateCboNalsuRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder(); 
		List<ComboListItemInfo> listResult =  ocs0132Repository.getComboDataSourceInfoByCodeType(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "NALSU", false);
		if(!CollectionUtils.isEmpty(listResult)){
			for(ComboListItemInfo info : listResult){
				CommonModelProto.ComboListItemInfo.Builder builder = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
				response.addComboItem(builder);
			}
		}
		return response.build();
	}                                                                                                                 
}