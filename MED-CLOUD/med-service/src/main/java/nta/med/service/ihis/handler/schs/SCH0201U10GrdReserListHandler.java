package nta.med.service.ihis.handler.schs;

import java.sql.Timestamp;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inj.Inj1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201U10GrdReserListRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201U10GrdReserListResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class SCH0201U10GrdReserListHandler
	extends ScreenHandler<SchsServiceProto.SCH0201U10GrdReserListRequest, SchsServiceProto.SCH0201U10GrdReserListResponse> {                     
	@Resource                                                                                                       
	private Inj1001Repository inj1001Repository;                                                                    
	                                                                                                                
	@Override  
	@Transactional(readOnly=true)
	public SCH0201U10GrdReserListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SCH0201U10GrdReserListRequest request) throws Exception {                                                                
  	   	SchsServiceProto.SCH0201U10GrdReserListResponse.Builder response = SchsServiceProto.SCH0201U10GrdReserListResponse.newBuilder();                      
		List<Timestamp> listReser = inj1001Repository.getSCH0201U10GrdReser(getHospitalCode(vertx, sessionId), request.getBunho());
		if(!CollectionUtils.isEmpty(listReser)){
			for(Timestamp item : listReser){
				CommonModelProto.DataStringListItemInfo.Builder info = CommonModelProto.DataStringListItemInfo.newBuilder();
				if(item != null){
					info.setDataValue(DateUtil.toString(item, DateUtil.PATTERN_YYMMDD));
					response.addDateValue(info);
				}
			}
		}
		return response.build();
	}
}