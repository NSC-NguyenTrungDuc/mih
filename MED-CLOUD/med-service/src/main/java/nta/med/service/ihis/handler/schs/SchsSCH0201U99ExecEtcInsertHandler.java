package nta.med.service.ihis.handler.schs;


import javax.annotation.Resource;

import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99ExecEtcInsertRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99StoreProcedureResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class SchsSCH0201U99ExecEtcInsertHandler
	extends ScreenHandler<SchsServiceProto.SchsSCH0201U99ExecEtcInsertRequest, SchsServiceProto.SchsSCH0201U99StoreProcedureResponse> {
	@Resource
	private Sch0201Repository sch0201Repository;
	@Override
	public SchsSCH0201U99StoreProcedureResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			SchsSCH0201U99ExecEtcInsertRequest request) throws Exception {
	     SchsServiceProto.SchsSCH0201U99StoreProcedureResponse.Builder  response =  SchsServiceProto.SchsSCH0201U99StoreProcedureResponse.newBuilder();
	     String	 result= sch0201Repository.callPrSchSch0201EtcInsert(getHospitalCode(vertx, sessionId),
	    		 request.getIBunho(), request.getIJundalTable(), request.getIJundalPart(), request.getIHangmogCode(), request.getIUserId());
	     if(result.equalsIgnoreCase("O")){
		     response.setResult(true);
	     }else{
	    	 response.setResult(false);
	     }
	     return response.build();
	}
}
