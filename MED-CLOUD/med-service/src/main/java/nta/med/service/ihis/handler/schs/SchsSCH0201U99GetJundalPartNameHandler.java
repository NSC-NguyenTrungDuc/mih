package nta.med.service.ihis.handler.schs;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99GetJundalPartNameRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99GetJundalPartNameResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SchsSCH0201U99GetJundalPartNameHandler
	extends ScreenHandler<SchsServiceProto.SchsSCH0201U99GetJundalPartNameRequest, SchsServiceProto.SchsSCH0201U99GetJundalPartNameResponse> {
	@Resource
	private Bas0260Repository bas0260Repository;
	@Override
	@Transactional(readOnly=true)
	public SchsSCH0201U99GetJundalPartNameResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			SchsSCH0201U99GetJundalPartNameRequest request) throws Exception {
		 String result = bas0260Repository.getSCH0201U99GetJundalPartName(getHospitalCode(vertx, sessionId),request.getIoGubun(),request.getJundalPart(),DateUtil.toDate(request.getToday(), DateUtil.PATTERN_YYMMDD));
	     SchsServiceProto.SchsSCH0201U99GetJundalPartNameResponse.Builder  response =  SchsServiceProto.SchsSCH0201U99GetJundalPartNameResponse.newBuilder();
	     if (result != null && !result.isEmpty()) {
	    	 response.setJundalPartName(result);
	     }
	     return response.build();
	}
}
