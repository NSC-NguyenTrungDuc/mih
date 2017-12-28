package nta.med.service.ihis.handler.schs;

import javax.annotation.Resource;

import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q01ExitsJundalTableRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q01ExitsJundalTableResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SchsSCH0201Q01ExitsJundalTableHandler
	extends ScreenHandler<SchsServiceProto.SchsSCH0201Q01ExitsJundalTableRequest, SchsServiceProto.SchsSCH0201Q01ExitsJundalTableResponse> {
	@Resource
	private Sch0201Repository sch0201Repository;
	@Override
	@Transactional(readOnly=true)
	public SchsSCH0201Q01ExitsJundalTableResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			SchsSCH0201Q01ExitsJundalTableRequest request) throws Exception {
	     String result = sch0201Repository.getSchsSCH0201Q01ExitsJundalTable(getHospitalCode(vertx, sessionId), request.getHangmogCode(),request.getJundalTable());
	     SchsServiceProto.SchsSCH0201Q01ExitsJundalTableResponse.Builder  response =  SchsServiceProto.SchsSCH0201Q01ExitsJundalTableResponse.newBuilder();
	     if(result != null && !result.isEmpty()){
	    	   response.setResult(result);
     	 }
	     return response.build();
	}
}
