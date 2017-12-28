package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201Q12FindBoxRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201Q12FindBoxResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SCH0201Q12FindBoxHandler
	extends ScreenHandler<SchsServiceProto.SCH0201Q12FindBoxRequest, SchsServiceProto.SCH0201Q12FindBoxResponse> {
	@Resource
	private Sch0201Repository sch0201Repository;
	@Override
	@Transactional(readOnly=true)
	public SCH0201Q12FindBoxResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, SCH0201Q12FindBoxRequest request)
			throws Exception {
	     List<String> listResult = sch0201Repository.getSCH0201Q12DistinctDoctorNameListInfo(getHospitalCode(vertx, sessionId), request.getGwa(),request.getDoctor());
	     SchsServiceProto.SCH0201Q12FindBoxResponse.Builder response =  SchsServiceProto.SCH0201Q12FindBoxResponse.newBuilder();
	     if(listResult != null && !listResult.isEmpty() && listResult.get(0) != null){
			 response.setDoctorName(listResult.get(0));
	     }
	     return response.build();
	}
}
