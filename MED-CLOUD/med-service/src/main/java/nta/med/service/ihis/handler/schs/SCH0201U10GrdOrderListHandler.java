package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.data.model.ihis.schs.SCH0201U10GrdOrderItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201U10GrdOrderListRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201U10GrdOrderListResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class SCH0201U10GrdOrderListHandler
	extends ScreenHandler<SchsServiceProto.SCH0201U10GrdOrderListRequest, SchsServiceProto.SCH0201U10GrdOrderListResponse> {                     
	@Resource                                                                                                       
	private Sch0201Repository sch0201Repository;                                                                    
	                                                                                                                
	@Override         
	@Transactional(readOnly=true)
	public SCH0201U10GrdOrderListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SCH0201U10GrdOrderListRequest request) throws Exception {                                                               
  	   	SchsServiceProto.SCH0201U10GrdOrderListResponse.Builder response = SchsServiceProto.SCH0201U10GrdOrderListResponse.newBuilder();                      
		List<SCH0201U10GrdOrderItemInfo> listGrd = sch0201Repository.getSCH0201U10GrdOrderItemInfo(getHospitalCode(vertx, sessionId), 
				getLanguage(vertx, sessionId), request.getBunho(), request.getReserDate());
		if(!CollectionUtils.isEmpty(listGrd)){
			for(SCH0201U10GrdOrderItemInfo item : listGrd){
				SchsModelProto.SCH0201U10GrdOrderListInfo.Builder info = SchsModelProto.SCH0201U10GrdOrderListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdOrderList(info);
			}
		}
		return response.build();
	}
}