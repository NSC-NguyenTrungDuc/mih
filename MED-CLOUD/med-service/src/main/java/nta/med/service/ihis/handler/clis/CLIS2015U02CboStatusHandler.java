package nta.med.service.ihis.handler.clis;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U02CboStatusRequest;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.ComboResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CLIS2015U02CboStatusHandler extends ScreenHandler<ClisServiceProto.CLIS2015U02CboStatusRequest, SystemServiceProto.ComboResponse> {
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	public ComboResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CLIS2015U02CboStatusRequest request)
					throws Exception {
            SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
            List<ComboListItemInfo> listResult = bas0102Repository.getCLIS2015U02CboStatus(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), 
            		"PROTOCOL_STATUS", request.getIsAll());
            if(!CollectionUtils.isEmpty(listResult)){
            	for(ComboListItemInfo item : listResult){
            		CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
            		BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
    				response.addComboItem(info);
            	}
            }          
		return response.build();
	}

}
