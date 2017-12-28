package nta.med.service.ihis.handler.endo;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.out.Out0106Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.EndoModelProto;
import nta.med.service.ihis.proto.EndoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class END1001U02LayOrderDateHandler extends ScreenHandler<EndoServiceProto.END1001U02LayOrderDateRequest, EndoServiceProto.END1001U02LayOrderDateResponse> {                      
	private static final Log LOGGER = LogFactory.getLog(END1001U02LayOrderDateHandler.class);                                    
	@Resource                                                                                                       
	private Out0106Repository out0106Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public EndoServiceProto.END1001U02LayOrderDateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			EndoServiceProto.END1001U02LayOrderDateRequest request) throws Exception {
		EndoServiceProto.END1001U02LayOrderDateResponse.Builder response = EndoServiceProto.END1001U02LayOrderDateResponse.newBuilder();  
		List<String> listResult = out0106Repository.getXRT1002U00LayOrderDate(getHospitalCode(vertx, sessionId), "PFE", request.getBunho());
		if(!CollectionUtils.isEmpty(listResult)){
			for(String item : listResult){
				EndoModelProto.END1001U02LayOrderDateInfo.Builder info = EndoModelProto.END1001U02LayOrderDateInfo.newBuilder();
				if(!StringUtils.isEmpty(item)){
					info.setOrderDate(item);
				}
				response.addLayOrderDateItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}