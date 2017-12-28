package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.InjsServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class INJ1002U01LoadComboBoxHandler extends ScreenHandler<InjsServiceProto.INJ1002U01LoadComboBoxRequest, InjsServiceProto.INJ1002U01LoadComboBoxResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(INJ1002U01LoadComboBoxHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    

	@Override
	@Transactional(readOnly=true)
	public InjsServiceProto.INJ1002U01LoadComboBoxResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ1002U01LoadComboBoxRequest request) throws Exception {
		InjsServiceProto.INJ1002U01LoadComboBoxResponse.Builder response = InjsServiceProto.INJ1002U01LoadComboBoxResponse.newBuilder(); 
		List<ComboListItemInfo> list = ocs0132Repository.getInjsComboListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "JUSA");
		if(!CollectionUtils.isEmpty(list)){
			for(ComboListItemInfo item : list){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCboList(info);
			}
		}
		return response.build();
	}                                                                                                                 
}