package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103Q00CheckHangmogNameInxRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103Q00CheckHangmogNameInxResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class OCS0103Q00CheckHangmogNameInxHandler extends ScreenHandler<OcsaServiceProto.OCS0103Q00CheckHangmogNameInxRequest, OcsaServiceProto.OCS0103Q00CheckHangmogNameInxResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103Q00CheckHangmogNameInxHandler.class);        
	
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                        
	                                                                                                                
	@Override          
	@Transactional(readOnly = true)
	public OCS0103Q00CheckHangmogNameInxResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103Q00CheckHangmogNameInxRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0103Q00CheckHangmogNameInxResponse.Builder response = OcsaServiceProto.OCS0103Q00CheckHangmogNameInxResponse.newBuilder();
		List<String> listResult = ocs0103Repository.checkHangmogNameInx(request.getHangmogNameInx());
		if(!CollectionUtils.isEmpty(listResult)){
			for(String result : listResult){
				CommonModelProto.DataStringListItemInfo.Builder builder = CommonModelProto.DataStringListItemInfo.newBuilder();
				builder.setDataValue(result);
				response.addResult(builder);
			}
		}
		return response.build();
	}

}
