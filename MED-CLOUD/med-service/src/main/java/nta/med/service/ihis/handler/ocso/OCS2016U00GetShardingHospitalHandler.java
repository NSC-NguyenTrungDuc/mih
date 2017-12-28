package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.OcsoServiceProto.OCS2016U00GetShardingHospitalRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

@Service
@Scope("prototype")
public class OCS2016U00GetShardingHospitalHandler extends ScreenHandler<OcsoServiceProto.OCS2016U00GetShardingHospitalRequest, SystemServiceProto.ComboResponse>{

	@Resource                                                                                                       
	private Bas0001Repository bas0001Repository;
	
	@Override
	@Transactional(readOnly = true)
//	@Route(global = true)
	public ComboResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2016U00GetShardingHospitalRequest request) throws Exception {
		
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();                      
		List<ComboListItemInfo> list =  bas0001Repository.getHospitalInShard(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(list)){
			for(ComboListItemInfo item : list){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addComboItem(info);
			}
		}
		
		return response.build();
		
	}

	
	
}
