package nta.med.service.ihis.handler.bill;

import javax.annotation.Resource;

import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.bas.Bas0501;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bas.Bas0501Repository;
import nta.med.service.ihis.proto.BillServiceProto;
import nta.med.service.ihis.proto.BillServiceProto.BIL0102U00PrintTemplateRequest;
import nta.med.service.ihis.proto.BillServiceProto.BIL0102U00PrintTemplateResponse;

@Service
@Scope("prototype")
public class BIL0102U00PrintTemplateHandler extends ScreenHandler<BillServiceProto.BIL0102U00PrintTemplateRequest, BillServiceProto.BIL0102U00PrintTemplateResponse>{
	@Resource                                                                                                       
	private Bas0501Repository bas0501Repository; 
	
	@Override
	@Transactional(readOnly = true)
	public BIL0102U00PrintTemplateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			BIL0102U00PrintTemplateRequest request) throws Exception {
		BillServiceProto.BIL0102U00PrintTemplateResponse.Builder response = BillServiceProto.BIL0102U00PrintTemplateResponse.newBuilder();
		String language = getLanguage(vertx, sessionId);
		Bas0501 bas0501 = bas0501Repository.findByHospCodeAndTplCode(getHospitalCode(vertx, sessionId), language, "BIL");
		if(bas0501 != null){
			response.setTemplate(StringUtils.isEmpty(bas0501.getPrintContent()) ? "" : bas0501.getPrintContent());
		}
		return response.build();
	}

}
