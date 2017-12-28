package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.SysPropertySRepository;
import nta.med.data.model.ihis.bass.LoadCbxLanguageInfo;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.LoadCbxLanguageRequest;
import nta.med.service.ihis.proto.BassServiceProto.LoadCbxLanguageResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class LoadCbxLanguageHandler extends ScreenHandler<BassServiceProto.LoadCbxLanguageRequest, BassServiceProto.LoadCbxLanguageResponse> {                     
	
	private static final Log LOGGER = LogFactory.getLog(LoadCbxLanguageHandler.class);                                    
	
	@Resource                                                                                                       
	private SysPropertySRepository  sysPropertySRepository;                                                                      
	
	@Override        
	@Transactional(readOnly = true)
	public LoadCbxLanguageResponse handle(Vertx vertx, String clientId, String sessionId,
			long contextId, LoadCbxLanguageRequest request)
					throws Exception {
		BassServiceProto.LoadCbxLanguageResponse.Builder response = BassServiceProto.LoadCbxLanguageResponse.newBuilder();                     
		List<LoadCbxLanguageInfo> listCbxLanguages = sysPropertySRepository.getCbxLanguageInfo(request.getPropertyCode(), "1");
		if(!CollectionUtils.isEmpty(listCbxLanguages)){
			for(LoadCbxLanguageInfo item : listCbxLanguages){
				BassModelProto.LoadCbxLanguageInfo.Builder info = BassModelProto.LoadCbxLanguageInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListInfo(info);
			}
		}
		return response.build();
	}                                                                                                                 
}