package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OUT0101Q01CboSexHandler extends ScreenHandler<NuroServiceProto.OUT0101Q01CboSexRequest, NuroServiceProto.OUT0101Q01CboSexResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OUT0101Q01CboSexHandler.class);                                        
	@Resource                                                                                                       
	private Bas0102Repository bas0102Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.OUT0101Q01CboSexResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OUT0101Q01CboSexRequest request) throws Exception {
		NuroServiceProto.OUT0101Q01CboSexResponse.Builder response = NuroServiceProto.OUT0101Q01CboSexResponse.newBuilder();  
		List<ComboListItemInfo> listCboSex= bas0102Repository.getOUT0101Q01CboSex(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listCboSex)){
			for(ComboListItemInfo item:listCboSex){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}