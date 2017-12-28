package nta.med.service.ihis.handler.bass;

import javax.annotation.Resource;

import nta.med.core.domain.adm.Adm9983;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.adm.Adm9983Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310P01GrdYjCodeRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310P01GrdYjCodeResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0310P01GrdYjCodeHandler extends ScreenHandler<BassServiceProto.BAS0310P01GrdYjCodeRequest, BassServiceProto.BAS0310P01GrdYjCodeResponse> {                    
	private static final Log LOGGER = LogFactory.getLog(BAS0310P01GrdYjCodeHandler.class);                                    
	@Resource                                                                                                       
	private Adm9983Repository adm9983Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public BAS0310P01GrdYjCodeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0310P01GrdYjCodeRequest request)
			throws Exception {
		BassServiceProto.BAS0310P01GrdYjCodeResponse.Builder response = BassServiceProto.BAS0310P01GrdYjCodeResponse.newBuilder();
		Page<Adm9983> listResult = adm9983Repository.findAll(new PageRequest(0, 2000));
		if(!CollectionUtils.isEmpty(listResult.getContent())){
			for(Adm9983 info : listResult){
				BassModelProto.BAS0310P01GrdYjCodeInfo.Builder builder = BassModelProto.BAS0310P01GrdYjCodeInfo.newBuilder();
				BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
				response.addDt(builder);
			}
		}
		return response.build();
	}                                                                                                                 
}