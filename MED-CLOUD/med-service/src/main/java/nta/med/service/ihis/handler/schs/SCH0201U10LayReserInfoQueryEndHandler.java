package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201U10LayReserInfoQueryEndRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201U10LayReserInfoQueryEndResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang3.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class SCH0201U10LayReserInfoQueryEndHandler
	extends ScreenHandler<SchsServiceProto.SCH0201U10LayReserInfoQueryEndRequest, SchsServiceProto.SCH0201U10LayReserInfoQueryEndResponse> {                     
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;       
	
	
	@Override
	public boolean isValid(SchsServiceProto.SCH0201U10LayReserInfoQueryEndRequest request, Vertx vertx, String clientId, String sessionId) {
		if(!StringUtils.isEmpty(request.getReserDate()) && DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD) == null ) {
			return false;
		}
		return true;
	}
	                                                                                                                
	@Override 
	@Transactional(readOnly=true)
	public SCH0201U10LayReserInfoQueryEndResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			SCH0201U10LayReserInfoQueryEndRequest request) throws Exception {                                                                 
  	   	SchsServiceProto.SCH0201U10LayReserInfoQueryEndResponse.Builder response = SchsServiceProto.SCH0201U10LayReserInfoQueryEndResponse.newBuilder();                      
		List<String> getReserMoveName = out1001Repository.getReserMoveName(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho(),
				DateUtil.toDate(request.getReserDate(), DateUtil.PATTERN_YYMMDD) , request.getGwa());
		if(!CollectionUtils.isEmpty(getReserMoveName)){
			if(!StringUtils.isEmpty(getReserMoveName.get(0))){
				response.setReserMoveName(getReserMoveName.get(0));
			}
		}
		return response.build();
	}
}