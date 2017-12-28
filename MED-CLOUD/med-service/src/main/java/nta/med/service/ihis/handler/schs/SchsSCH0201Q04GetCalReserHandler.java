package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.data.model.ihis.schs.SchsSCH0201Q04ReserTimeListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q04GetCalReserRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q04GetCalReserResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype") 
@Transactional
public class SchsSCH0201Q04GetCalReserHandler
	extends ScreenHandler<SchsServiceProto.SchsSCH0201Q04GetCalReserRequest, SchsServiceProto.SchsSCH0201Q04GetCalReserResponse> {                     
	@Resource                                                                                                       
	private Sch0201Repository sch0201Repository;                                                                    
	                                                                                                                
	@Override
	public SchsSCH0201Q04GetCalReserResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			SchsSCH0201Q04GetCalReserRequest request) throws Exception {                                                               
  	   	 SchsServiceProto.SchsSCH0201Q04GetCalReserResponse.Builder response = SchsServiceProto.SchsSCH0201Q04GetCalReserResponse.newBuilder();
  	   	 String hospCode = getHospitalCode(vertx, sessionId);
		 sch0201Repository.callSchsSCH0201Q04PrSchTimeList(hospCode,request.getIpAddr(),request.getJundalTable(),
	    		 request.getJundalPart(),request.getGumsaja(),request.getReserDate());
		 response.setResult(true);  
		 List<SchsSCH0201Q04ReserTimeListInfo> listResult = sch0201Repository.getSchsSCH0201Q04ReserTimeListInfo(hospCode, request.getIpAddr());
	     if(listResult != null && !listResult.isEmpty()){
	    	 for(SchsSCH0201Q04ReserTimeListInfo item : listResult){
	    		 SchsModelProto.SchsSCH0201Q04ReserTimeListInfo.Builder info =  SchsModelProto.SchsSCH0201Q04ReserTimeListInfo.newBuilder();
	    		 BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
	    		 response.addReserTimeListItem(info);
	    	 }
	     }
	     return response.build();
	}
}