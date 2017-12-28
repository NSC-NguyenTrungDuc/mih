package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.data.dao.medi.CommonRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuriServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class NUR1016U00SelectNextValHandler extends ScreenHandler<NuriServiceProto.NUR1016U00SelectNextValRequest, NuriServiceProto.NUR1016U00SelectNextValResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(NUR1016U00SelectNextValHandler.class);                                        
	@Resource                                                                                                       
	private CommonRepository commonRepository;                                                                    

	@Override
	@Transactional
	public NuriServiceProto.NUR1016U00SelectNextValResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuriServiceProto.NUR1016U00SelectNextValRequest request) throws Exception {
		NuriServiceProto.NUR1016U00SelectNextValResponse .Builder response=NuriServiceProto.NUR1016U00SelectNextValResponse .newBuilder();
		String result = commonRepository.getNextVal("NUR1016_SEQ");
		if(!StringUtils.isEmpty(result)){
			response.setNextVal(result);
		}
		return response.build();
	}                                                                                                               
}                                                                                                                 
