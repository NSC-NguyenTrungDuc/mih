package nta.med.service.ihis.handler.schs;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99DeleteSCH0201Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class SchsSCH0201U99DeleteSCH0201Handler
	extends ScreenHandler<SchsServiceProto.SchsSCH0201U99DeleteSCH0201Request, SystemServiceProto.UpdateResponse> {
	@Resource
	private Sch0201Repository sch0201Repository;
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SchsSCH0201U99DeleteSCH0201Request request) throws Exception {
	     SystemServiceProto.UpdateResponse.Builder  response =  SystemServiceProto.UpdateResponse.newBuilder();
	     boolean result = deleteSCH0201(request, getHospitalCode(vertx, sessionId));
	     response.setResult(result);
	     return response.build();
	}
	
	public boolean deleteSCH0201(SchsServiceProto.SchsSCH0201U99DeleteSCH0201Request request, String hospCode){
		if(sch0201Repository.deleteSch0201U99(hospCode, CommonUtils.parseDouble(request.getFPksch())) >0){
			return true;
		}
		return false;
	}
}
