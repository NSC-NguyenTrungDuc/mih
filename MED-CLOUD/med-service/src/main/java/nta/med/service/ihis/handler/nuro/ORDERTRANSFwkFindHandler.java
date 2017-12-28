package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ORDERTRANSFwkFindHandler extends ScreenHandler<NuroServiceProto.ORDERTRANSFwkFindRequest,SystemServiceProto.ComboResponse > {                     
	private static final Log LOGGER = LogFactory.getLog(ORDERTRANSFwkFindHandler.class);                                    
	@Resource                                                                                                       
	private Out0102Repository out0102Repository;        
	
	@Override
	@Transactional(readOnly = true)
	public SystemServiceProto.ComboResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.ORDERTRANSFwkFindRequest request) throws Exception {
		SystemServiceProto.ComboResponse.Builder response = SystemServiceProto.ComboResponse.newBuilder();
		 List<ComboListItemInfo> listCombo = out0102Repository.getORDERTRANSFwkFind(getHospitalCode(vertx, sessionId), request.getBunho(), request.getActingDate());
		 if(!StringUtils.isEmpty(listCombo)){
			 for(ComboListItemInfo item : listCombo){
				 CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addComboItem(info);
			 }
		 }
		 return response.build();
	}                                                                                                                 
}