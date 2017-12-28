package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OCSACTCboTimeAndSystemRequest;
import nta.med.service.ihis.proto.OcsoServiceProto.OCSACTCboTimeAndSystemResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCSACTCboTimeAndSystemHandler extends ScreenHandler<OcsoServiceProto.OCSACTCboTimeAndSystemRequest, OcsoServiceProto.OCSACTCboTimeAndSystemResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCSACTCboTimeAndSystemHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;
	@Resource
	private Nur0102Repository nur0102Repository;

	@Override
	@Transactional(readOnly = true)
	public OCSACTCboTimeAndSystemResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCSACTCboTimeAndSystemRequest request) throws Exception {
		OcsoServiceProto.OCSACTCboTimeAndSystemResponse.Builder response = OcsoServiceProto.OCSACTCboTimeAndSystemResponse.newBuilder();   
		//list CboSystem
		List<ComboListItemInfo> listSystem = ocs0132Repository.getOCS0103U10SearchConditionCbo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "OCS_ACT_SYSTEM", true);
		if(!CollectionUtils.isEmpty(listSystem)){
			for(ComboListItemInfo item : listSystem){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCboSystem(info);
			}
		}
		//list CboTime
		List<ComboListItemInfo> listTime = nur0102Repository.getNuroComboTime(getLanguage(vertx, sessionId), getHospitalCode(vertx, sessionId), "NUR2001U04_TIMER", false);
		if(!CollectionUtils.isEmpty(listTime)){
			for(ComboListItemInfo item : listTime){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCboTime(info);
			}
		}
		return response.build();
	}                                                                                                                 
}