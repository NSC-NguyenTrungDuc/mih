package nta.med.service.emr.handler;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.emr.EmrTagRepository;
import nta.med.data.model.ihis.emr.OCS2015U07TagChildInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.emr.proto.EmrModelProto;
import nta.med.service.emr.proto.EmrServiceProto;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U07GetChildTagOfParentRequest;
import nta.med.service.emr.proto.EmrServiceProto.OCS2015U07GetChildTagOfParentResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS2015U07GetChildTagOfParentHandler extends ScreenHandler<EmrServiceProto.OCS2015U07GetChildTagOfParentRequest, EmrServiceProto.OCS2015U07GetChildTagOfParentResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS2015U07GetChildTagOfParentHandler.class);                                    
	@Resource                                                                                                       
	private EmrTagRepository emrTagRepository;                                                                    
	                                                                                                                
	@Override       
	@Transactional(readOnly = true)
	public OCS2015U07GetChildTagOfParentResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
		OCS2015U07GetChildTagOfParentRequest request) throws Exception {
  	   	EmrServiceProto.OCS2015U07GetChildTagOfParentResponse.Builder response = EmrServiceProto.OCS2015U07GetChildTagOfParentResponse.newBuilder();                      
		List<OCS2015U07TagChildInfo> listTagChild = emrTagRepository.getOCS2015U07TagChildInfo(request.getFParentTag(), getHospitalCode(vertx, sessionId));
		if (!CollectionUtils.isEmpty(listTagChild)) {
			for (OCS2015U07TagChildInfo item : listTagChild) {
				EmrModelProto.OCS2015U07TagChildInfo.Builder info = EmrModelProto.OCS2015U07TagChildInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addTagChildList(info);
			}
		}
				
		return response.build();
	}                                                                                                                 
}