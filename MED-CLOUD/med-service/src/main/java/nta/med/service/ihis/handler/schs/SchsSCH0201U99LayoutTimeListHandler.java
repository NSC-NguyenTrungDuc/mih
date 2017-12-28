package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.data.model.ihis.schs.SchsSCH0201U99LayoutTimeListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99LayoutTimeListRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99LayoutTimeListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SchsSCH0201U99LayoutTimeListHandler
	extends ScreenHandler<SchsServiceProto.SchsSCH0201U99LayoutTimeListRequest, SchsServiceProto.SchsSCH0201U99LayoutTimeListResponse> {
	@Resource
	private Sch0201Repository sch0201Repository;
	@Override
	@Transactional(readOnly=true)
	public SchsSCH0201U99LayoutTimeListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			SchsSCH0201U99LayoutTimeListRequest request) throws Exception {
	     SchsServiceProto.SchsSCH0201U99LayoutTimeListResponse.Builder  response =  SchsServiceProto.SchsSCH0201U99LayoutTimeListResponse.newBuilder();
	     List<SchsSCH0201U99LayoutTimeListInfo> listResult = sch0201Repository.getSchsSCH0201U99LayoutTimeListInfo(getHospitalCode(vertx, sessionId),
	    		 request.getIpAddr());
	     if(listResult != null && !listResult.isEmpty()){
	    	 for(SchsSCH0201U99LayoutTimeListInfo item : listResult){
	    		 SchsModelProto.SchsSCH0201U99LayoutTimeListInfo.Builder info = SchsModelProto.SchsSCH0201U99LayoutTimeListInfo.newBuilder();
	    		 BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
    			 response.addLTimeList(info);
	    	 }
	     }
	     return response.build();
	}
}
