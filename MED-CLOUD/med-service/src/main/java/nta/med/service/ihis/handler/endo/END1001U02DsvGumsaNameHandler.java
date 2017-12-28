package nta.med.service.ihis.handler.endo;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.EndoModelProto;
import nta.med.service.ihis.proto.EndoServiceProto;
import nta.med.service.ihis.proto.EndoServiceProto.END1001U02DsvGumsaNameRequest;
import nta.med.service.ihis.proto.EndoServiceProto.END1001U02DsvGumsaNameResponse;

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
public class END1001U02DsvGumsaNameHandler extends ScreenHandler<EndoServiceProto.END1001U02DsvGumsaNameRequest, EndoServiceProto.END1001U02DsvGumsaNameResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(END1001U02DsvGumsaNameHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public END1001U02DsvGumsaNameResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			END1001U02DsvGumsaNameRequest request) throws Exception {
		EndoServiceProto.END1001U02DsvGumsaNameResponse.Builder response = EndoServiceProto.END1001U02DsvGumsaNameResponse.newBuilder();
		List<String> listResult = ocs0103Repository.getHangmogNameByHospCodeAndHangmogCode(getHospitalCode(vertx, sessionId), request.getCode());
		if(!CollectionUtils.isEmpty(listResult)){
			for(String item : listResult){
				EndoModelProto.END1001U02StrInfo.Builder info = EndoModelProto.END1001U02StrInfo.newBuilder();
				if(!StringUtils.isEmpty(item)){
					info.setValue(item);
				}
				response.addDsvGumsaNameItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}