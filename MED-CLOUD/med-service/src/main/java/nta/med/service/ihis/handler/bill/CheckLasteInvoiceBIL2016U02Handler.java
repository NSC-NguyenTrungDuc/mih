package nta.med.service.ihis.handler.bill;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.bil.Bil0101Repository;
import nta.med.service.ihis.proto.BillModelProto;
import nta.med.service.ihis.proto.BillServiceProto;
import nta.med.service.ihis.proto.BillServiceProto.CheckLasteInvoiceBIL2016U02Request;
import nta.med.service.ihis.proto.BillServiceProto.CheckLasteInvoiceBIL2016U02Response;

@Service
@Scope("prototype")
public class CheckLasteInvoiceBIL2016U02Handler  extends ScreenHandler<BillServiceProto.CheckLasteInvoiceBIL2016U02Request, BillServiceProto.CheckLasteInvoiceBIL2016U02Response>{

	@Resource
	private Bil0101Repository bil0101Repository;
	
	@Override
	public CheckLasteInvoiceBIL2016U02Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			CheckLasteInvoiceBIL2016U02Request request) throws Exception {
		BillServiceProto.CheckLasteInvoiceBIL2016U02Response.Builder response = BillServiceProto.CheckLasteInvoiceBIL2016U02Response.newBuilder();
		List<String> results = bil0101Repository.getLasteInvoiceBIL2016U02(getHospitalCode(vertx, sessionId), request.getParentInvoiceNo());
		if(!CollectionUtils.isEmpty(results)){
			for(String item : results){
				BillModelProto.CheckLasteInvoiceBIL2016U02Info.Builder info = BillModelProto.CheckLasteInvoiceBIL2016U02Info.newBuilder();
				if(!StringUtils.isEmpty(item)){
					info.setLatestInvoice(item);
				}
				response.addCheckLasteInvoice(info);
			}
		}
		return response.build();
	}

}
