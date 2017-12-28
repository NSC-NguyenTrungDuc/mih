package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ifs.Ifs0002Repository;
import nta.med.data.model.ihis.bass.ComBizLoadIFS0002Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.ComBizLoadIFS0002InfoRequest;
import nta.med.service.ihis.proto.BassServiceProto.ComBizLoadIFS0002InfoResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ComBizLoadIFS0002InfoHandler extends ScreenHandler<BassServiceProto.ComBizLoadIFS0002InfoRequest, BassServiceProto.ComBizLoadIFS0002InfoResponse>{                     
	private static final Log LOGGER = LogFactory.getLog(ComBizLoadIFS0002InfoHandler.class);                                    
	@Resource                                                                                                       
	private Ifs0002Repository ifs0002Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public ComBizLoadIFS0002InfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			ComBizLoadIFS0002InfoRequest request) throws Exception {
      	   	BassServiceProto.ComBizLoadIFS0002InfoResponse.Builder response = BassServiceProto.ComBizLoadIFS0002InfoResponse.newBuilder();                      
			List<ComBizLoadIFS0002Info> list = ifs0002Repository.getComBizLoadIFS0002ListItem(getHospitalCode(vertx, sessionId), request.getCodeType(), request.getCode());
			if(!CollectionUtils.isEmpty(list)){
				for(ComBizLoadIFS0002Info item : list){
					BassModelProto.ComBizLoadIFS0002Info.Builder info = BassModelProto.ComBizLoadIFS0002Info.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addInfoList(info);
				}
			}
		return response.build();
	}                                                                                                            
}