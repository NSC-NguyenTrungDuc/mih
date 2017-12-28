package nta.med.service.ihis.handler.schs;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99GetGwaNameRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99GetGwaNameResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SchsSCH0201U99GetGwaNameHandler 
	extends ScreenHandler<SchsServiceProto.SchsSCH0201U99GetGwaNameRequest, SchsServiceProto.SchsSCH0201U99GetGwaNameResponse> {
	@Resource
	private Bas0260Repository bas0260Repository;
	@Override
	@Transactional(readOnly=true)
	public SchsSCH0201U99GetGwaNameResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			SchsSCH0201U99GetGwaNameRequest request) throws Exception {
		 String result = bas0260Repository.getSchsSCH0201U99GetGwaName(getHospitalCode(vertx, sessionId),request.getGwa(),DateUtil.toDate(request.getToday(), DateUtil.PATTERN_YYMMDD));
	     SchsServiceProto.SchsSCH0201U99GetGwaNameResponse.Builder  response =  SchsServiceProto.SchsSCH0201U99GetGwaNameResponse.newBuilder();
	     if (result != null && !result.isEmpty()) {
	    	 response.setGwaName(result);
	     }
	     return response.build();
	}
}
