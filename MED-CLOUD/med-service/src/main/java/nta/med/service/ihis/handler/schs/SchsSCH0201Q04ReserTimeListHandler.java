package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.data.model.ihis.schs.SchsSCH0201Q04ReserTimeListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q04ReserTimeListRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q04ReserTimeListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SchsSCH0201Q04ReserTimeListHandler
	extends ScreenHandler<SchsServiceProto.SchsSCH0201Q04ReserTimeListRequest, SchsServiceProto.SchsSCH0201Q04ReserTimeListResponse> {
	@Resource
	private Sch0201Repository sch0201Repository;
	@Override
	@Transactional(readOnly=true)
	public SchsSCH0201Q04ReserTimeListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			SchsSCH0201Q04ReserTimeListRequest request) throws Exception {
	     List<SchsSCH0201Q04ReserTimeListInfo> listResult = sch0201Repository.getSchsSCH0201Q04ReserTimeListInfo(getHospitalCode(vertx, sessionId), request.getIpAddr());
	     SchsServiceProto.SchsSCH0201Q04ReserTimeListResponse.Builder  response =  SchsServiceProto.SchsSCH0201Q04ReserTimeListResponse.newBuilder();
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
