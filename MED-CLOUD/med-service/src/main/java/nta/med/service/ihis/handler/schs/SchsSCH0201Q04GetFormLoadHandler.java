package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.data.model.ihis.schs.SchsSCH0201Q04GetMonthReserListInfo;
import nta.med.data.model.ihis.schs.SchsSCH0201Q04PrartListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q04GetFormLoadRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q04GetFormLoadResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")          
@Transactional
public class SchsSCH0201Q04GetFormLoadHandler
	extends ScreenHandler<SchsServiceProto.SchsSCH0201Q04GetFormLoadRequest, SchsServiceProto.SchsSCH0201Q04GetFormLoadResponse> {                     
	@Resource                                                                                                       
	private Sch0201Repository sch0201Repository;                                                                    
	                                                                                                                
	@Override            
	@Transactional(readOnly=true)
	public SchsSCH0201Q04GetFormLoadResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			SchsSCH0201Q04GetFormLoadRequest request) throws Exception {                                                                  
  	   	SchsServiceProto.SchsSCH0201Q04GetFormLoadResponse.Builder response = SchsServiceProto.SchsSCH0201Q04GetFormLoadResponse.newBuilder();
  	   	String hospCode = getHospitalCode(vertx, sessionId);
		List<SchsSCH0201Q04PrartListItemInfo> listResult = sch0201Repository.getSchsSCH0201Q04PrartListItemInfo(hospCode, request.getJundalTable());
	    if(listResult != null && !listResult.isEmpty()){
	    	for(SchsSCH0201Q04PrartListItemInfo item : listResult){
	    		SchsModelProto.SchsSCH0201Q04PrartListItemInfo.Builder info =  SchsModelProto.SchsSCH0201Q04PrartListItemInfo.newBuilder();
	    		if (!StringUtils.isEmpty(item.getJundalTable())) {
	    			info.setJundalTable(item.getJundalTable());
				}
				if (!StringUtils.isEmpty(item.getJundalPart())) {
					info.setJundalPart(item.getJundalPart());
				}
				if (!StringUtils.isEmpty(item.getJundalPartName())) {
					info.setJundalPartName(item.getJundalPartName());
				}
		   		response.addPrartItem(info);
		   	 }
	    }
	    List<SchsSCH0201Q04GetMonthReserListInfo> listMothReserInfo = sch0201Repository.getSchsSCH0201Q04GetMonthReserListInfo(hospCode,
				request.getJundalTable(), request.getJundalPart(),request.getMonth());
		if (listMothReserInfo != null && !listMothReserInfo.isEmpty()) {
			for (SchsSCH0201Q04GetMonthReserListInfo item : listMothReserInfo) {
				SchsModelProto.SchsSCH0201Q04GetMonthReserListInfo.Builder info = SchsModelProto.SchsSCH0201Q04GetMonthReserListInfo
						.newBuilder();
				if (!StringUtils.isEmpty(item.getHoliDay())) {
					info.setHoliDay(item.getHoliDay().toString());
				}
				if (!StringUtils.isEmpty(item.getReserCnt())) {
					info.setReserCnt(item.getReserCnt().toString());
				}
				if (!StringUtils.isEmpty(item.getInwonCnt())) {
					info.setInwonCnt(item.getInwonCnt().toString());
				}
				response.addMonthReserItem(info);
			}
		}
		return response.build();
	}
}