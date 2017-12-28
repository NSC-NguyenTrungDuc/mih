package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.data.model.ihis.schs.SchsSCH0201Q04PrartListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q04PrartListRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q04PrartListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SchsSCH0201Q04PrartListHandler
	extends ScreenHandler<SchsServiceProto.SchsSCH0201Q04PrartListRequest, SchsServiceProto.SchsSCH0201Q04PrartListResponse> {
	@Resource
	private Sch0201Repository sch0201Repository;
	@Override
	@Transactional(readOnly=true)
	public SchsSCH0201Q04PrartListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SchsSCH0201Q04PrartListRequest request) throws Exception {
	     List<SchsSCH0201Q04PrartListItemInfo> listResult = sch0201Repository.getSchsSCH0201Q04PrartListItemInfo(getHospitalCode(vertx, sessionId), request.getJundalTable());
	     SchsServiceProto.SchsSCH0201Q04PrartListResponse.Builder  response =  SchsServiceProto.SchsSCH0201Q04PrartListResponse.newBuilder();
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
	    		 response.addPrartListItem(info);
	    	 }
	     }
	     return response.build();
	}
}
