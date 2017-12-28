package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.schs.SchsSCH0201U99ReserListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99ReserListRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99ReserListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SchsSCH0201U99ReserListHandler
	extends ScreenHandler<SchsServiceProto.SchsSCH0201U99ReserListRequest, SchsServiceProto.SchsSCH0201U99ReserListResponse> {
	@Resource
	private Out1001Repository out1001Repository;
	@Override
	@Transactional(readOnly=true)
	public SchsSCH0201U99ReserListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SchsSCH0201U99ReserListRequest request) throws Exception {
	     SchsServiceProto.SchsSCH0201U99ReserListResponse.Builder  response =  SchsServiceProto.SchsSCH0201U99ReserListResponse.newBuilder();
	     List<SchsSCH0201U99ReserListInfo> listResult = out1001Repository.getSchsSCH0201U99ReserListInfo(getHospitalCode(vertx, sessionId), request.getBunho());
	     if(listResult != null && !listResult.isEmpty()){
	    	 for(SchsSCH0201U99ReserListInfo item : listResult){
	    		 SchsModelProto.SchsSCH0201U99ReserListInfo.Builder info = SchsModelProto.SchsSCH0201U99ReserListInfo.newBuilder();
	    		 BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
    			 response.addReserList(info);
	    	 }
	     }
	     return response.build();
	}
}
