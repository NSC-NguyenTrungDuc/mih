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

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ifs.Ifs0001Repository;
import nta.med.data.model.ihis.bass.ComBizLoadIFS0001Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.ComBizLoadIFS0001InfoRequest;
import nta.med.service.ihis.proto.BassServiceProto.ComBizLoadIFS0001InfoResponse;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ComBizLoadIFS0001InfoHandler extends ScreenHandler<BassServiceProto.ComBizLoadIFS0001InfoRequest, BassServiceProto.ComBizLoadIFS0001InfoResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(ComBizLoadIFS0001InfoHandler.class);                                    
	@Resource                                                                                                       
	private Ifs0001Repository ifs0001Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public ComBizLoadIFS0001InfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			ComBizLoadIFS0001InfoRequest request) throws Exception {
      	   	BassServiceProto.ComBizLoadIFS0001InfoResponse.Builder response = BassServiceProto.ComBizLoadIFS0001InfoResponse.newBuilder();                      
			List<ComBizLoadIFS0001Info> list = ifs0001Repository.getComBizLoadIFS0001ListItem(getHospitalCode(vertx, sessionId), request.getCodeType());
			if(!CollectionUtils.isEmpty(list)){
				for(ComBizLoadIFS0001Info item : list){
					BassModelProto.ComBizLoadIFS0001Info.Builder info = BassModelProto.ComBizLoadIFS0001Info.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addInfoList(info);
				}
			}
		return response.build();
	}                                                                                                            
}