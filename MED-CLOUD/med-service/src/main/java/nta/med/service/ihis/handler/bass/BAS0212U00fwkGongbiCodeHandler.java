package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0212Repository;
import nta.med.data.model.ihis.bass.BAS0212U00fwkGongbiCodeInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0212U00fwkGongbiCodeRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0212U00fwkGongbiCodeResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0212U00fwkGongbiCodeHandler extends ScreenHandler<BassServiceProto.BAS0212U00fwkGongbiCodeRequest, BassServiceProto.BAS0212U00fwkGongbiCodeResponse> {                      
	private static final Log LOGGER = LogFactory.getLog(BAS0212U00fwkGongbiCodeHandler.class);                                    
	@Resource                                                                                                       
	private Bas0212Repository bas0212Repository;                                                                    


	@Override
	@Transactional(readOnly = true)
	public BAS0212U00fwkGongbiCodeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0212U00fwkGongbiCodeRequest request) throws Exception {
 		BassServiceProto.BAS0212U00fwkGongbiCodeResponse.Builder response = BassServiceProto.BAS0212U00fwkGongbiCodeResponse.newBuilder(); 
		List<BAS0212U00fwkGongbiCodeInfo> listResult = bas0212Repository.getBAS0212U00fwkGongbiCode(request.getFind1(), request.getStartDate(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listResult)){
			for(BAS0212U00fwkGongbiCodeInfo item : listResult){
				BassModelProto.BAS0212U00fwkGongbiCodeInfo.Builder info = BassModelProto.BAS0212U00fwkGongbiCodeInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addFwk(info);
			}
		}
		return response.build();
	}                                                                                                                 
}