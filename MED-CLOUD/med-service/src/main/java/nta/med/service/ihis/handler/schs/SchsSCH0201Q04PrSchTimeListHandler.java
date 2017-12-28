package nta.med.service.ihis.handler.schs;

import javax.annotation.Resource;

import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q04PrSchTimeListRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q04PrSchTimeListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class SchsSCH0201Q04PrSchTimeListHandler
	extends ScreenHandler<SchsServiceProto.SchsSCH0201Q04PrSchTimeListRequest, SchsServiceProto.SchsSCH0201Q04PrSchTimeListResponse> {
	@Resource
	private Sch0201Repository sch0201Repository;
	@Override
	public SchsSCH0201Q04PrSchTimeListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			SchsSCH0201Q04PrSchTimeListRequest request) throws Exception {
	     SchsServiceProto.SchsSCH0201Q04PrSchTimeListResponse.Builder  response =  SchsServiceProto.SchsSCH0201Q04PrSchTimeListResponse.newBuilder();
		 sch0201Repository.callSchsSCH0201Q04PrSchTimeList(getHospitalCode(vertx, sessionId),request.getIpAddr(),request.getJundalTable(),
	    		 request.getJundalPart(),request.getGumsaja(),request.getReserDate());
	     response.setResult(true);
	     return response.build();
	}
}
