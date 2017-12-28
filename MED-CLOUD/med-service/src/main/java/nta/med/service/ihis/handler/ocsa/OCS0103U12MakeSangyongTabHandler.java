package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U12MakeSangyongTabInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto.LoadOftenUsedTabInfo;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12MakeSangyongTabRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12MakeSangyongTabResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U12MakeSangyongTabHandler
	extends ScreenHandler<OcsaServiceProto.OCS0103U12MakeSangyongTabRequest, OcsaServiceProto.OCS0103U12MakeSangyongTabResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OCS0103U12MakeSangyongTabHandler.class);                                        
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    
	                                                                                                                
	@Override                                      
	@Transactional(readOnly = true)
	public OCS0103U12MakeSangyongTabResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U12MakeSangyongTabRequest request) throws Exception {                                                                 
  	   	OcsaServiceProto.OCS0103U12MakeSangyongTabResponse.Builder response = OcsaServiceProto.OCS0103U12MakeSangyongTabResponse.newBuilder();                      
		LoadOftenUsedTabInfo item = request.getRequestInfo();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		if(item != null){
			if(!item.getInputTab().equalsIgnoreCase("07")){
				List<OCS0103U12MakeSangyongTabInfo> list = ocs0132Repository.getOCS0103U12MakeSangyongTabListItem(item.getMemb(), item.getInputTab(), hospCode, language);
				if(!CollectionUtils.isEmpty(list)){
					for(OCS0103U12MakeSangyongTabInfo object : list){
						OcsaModelProto.OCS0103U12MakeSangyongTabInfo.Builder info = OcsaModelProto.OCS0103U12MakeSangyongTabInfo.newBuilder();
						BeanUtils.copyProperties(object, info, getLanguage(vertx, sessionId));
						response.addResult(info);
					}
				}
			}else{
				List<OCS0103U12MakeSangyongTabInfo> list = ocs0132Repository.getOCS0103U12MakeSangyongTabListItemElse(item.getMemb(), hospCode, language);
				if(!CollectionUtils.isEmpty(list)){
					for(OCS0103U12MakeSangyongTabInfo object : list){
						OcsaModelProto.OCS0103U12MakeSangyongTabInfo.Builder info = OcsaModelProto.OCS0103U12MakeSangyongTabInfo.newBuilder();
						BeanUtils.copyProperties(object, info, getLanguage(vertx, sessionId));
						response.addResult(info);
					}
				}
			}
		} 
		return response.build();
	}

}