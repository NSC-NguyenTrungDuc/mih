package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0212Repository;
import nta.med.data.model.ihis.system.LoadOftenUsedResponseInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CommonModelProto.LoadOftenUsedInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.LoadOftenUsedRequest;
import nta.med.service.ihis.proto.SystemServiceProto.LoadOftenUsedResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class LoadOftenUsedHandler 
	extends ScreenHandler<SystemServiceProto.LoadOftenUsedRequest, SystemServiceProto.LoadOftenUsedResponse> {                     
	@Resource                                                                                                       
	private Ocs0212Repository ocs0212Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public LoadOftenUsedResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, LoadOftenUsedRequest request)
			throws Exception {                                                                 
      	   	SystemServiceProto.LoadOftenUsedResponse.Builder response = SystemServiceProto.LoadOftenUsedResponse.newBuilder();                      
		LoadOftenUsedInfo inputInfo = request.getInputInfo();
		if(inputInfo != null){
			String searchWord  = "";
			if(StringUtils.isEmpty(inputInfo.getSearchWord())){
				searchWord = null;
			}else{
				searchWord = inputInfo.getSearchWord();
			}
			List<LoadOftenUsedResponseInfo> list = ocs0212Repository.getLoadOftenUsedResponseListItem(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
					inputInfo.getMembGubun(), inputInfo.getMemb(), inputInfo.getOrderGubun(), inputInfo.getWonnaeDrgYn(), searchWord);
			if(!CollectionUtils.isEmpty(list)){
				for(LoadOftenUsedResponseInfo item : list){
					CommonModelProto.LoadOftenUsedResponseInfo.Builder info = CommonModelProto.LoadOftenUsedResponseInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addUsedInfo(info);
				}
			}
		}
		return response.build();
	}
}