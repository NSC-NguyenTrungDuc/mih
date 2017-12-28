package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.data.model.ihis.schs.SCH0201U10LayReserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201U10LayReserInfoRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201U10LayReserInfoResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class SCH0201U10LayReserInfoHandler 
	extends ScreenHandler<SchsServiceProto.SCH0201U10LayReserInfoRequest, SchsServiceProto.SCH0201U10LayReserInfoResponse>{                     
	@Resource                                                                                                       
	private Sch0201Repository sch0201Repository;                                                                    
	                                                                                                                
	@Override   
	@Transactional(readOnly=true)
	public SCH0201U10LayReserInfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SCH0201U10LayReserInfoRequest request) throws Exception {                                                                  
  	   	SchsServiceProto.SCH0201U10LayReserInfoResponse.Builder response = SchsServiceProto.SCH0201U10LayReserInfoResponse.newBuilder();                      
		List<SCH0201U10LayReserInfo> listReser = sch0201Repository.getSCH0201U10LayReserInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho(), request.getReserDate());
		if(!CollectionUtils.isEmpty(listReser)){
			for(SCH0201U10LayReserInfo item : listReser){
				SchsModelProto.SCH0201U10LayReserInfo.Builder info = SchsModelProto.SCH0201U10LayReserInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayList(info);
			}
		}
		return response.build();
	}
}