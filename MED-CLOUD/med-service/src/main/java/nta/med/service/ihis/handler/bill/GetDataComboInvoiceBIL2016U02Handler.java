package nta.med.service.ihis.handler.bill;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.bill.Bil0101;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bil.Bil0101Repository;
import nta.med.service.ihis.proto.BillModelProto;
import nta.med.service.ihis.proto.BillServiceProto;
import nta.med.service.ihis.proto.BillServiceProto.GetDataComboInvoiceBIL2016U02Request;
import nta.med.service.ihis.proto.BillServiceProto.GetDataComboInvoiceBIL2016U02Response;

@Service
@Scope("prototype")
public class GetDataComboInvoiceBIL2016U02Handler extends ScreenHandler<BillServiceProto.GetDataComboInvoiceBIL2016U02Request, BillServiceProto.GetDataComboInvoiceBIL2016U02Response>{

	@Resource
	private Bil0101Repository bil0101Repository;
	
	@Override
	@Transactional(readOnly = true)
	public GetDataComboInvoiceBIL2016U02Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			GetDataComboInvoiceBIL2016U02Request request) throws Exception {
		BillServiceProto.GetDataComboInvoiceBIL2016U02Response.Builder response = BillServiceProto.GetDataComboInvoiceBIL2016U02Response.newBuilder();
		List<Bil0101> bil0101s = bil0101Repository.findByHospCodeParentInvoiceNo(getHospitalCode(vertx, sessionId), request.getParentInvoiceNo());
		if(!CollectionUtils.isEmpty(bil0101s)){
			for(Bil0101 bil0101 : bil0101s){
				BillModelProto.GetDataComboInvoiceBIL2016U02Info.Builder info = BillModelProto.GetDataComboInvoiceBIL2016U02Info.newBuilder();
				if(!StringUtils.isEmpty(bil0101.getInvoiceNo())){
					info.setInvoiceNo(bil0101.getInvoiceNo());
				}
				if(bil0101.getInvoiceDate() != null){
					info.setInvoiceDate(DateUtil.toString(bil0101.getInvoiceDate(), DateUtil.PATTERN_YYMMDD));
				}
				response.addComboInvoice(info);
			}
		}
		return response.build();
	}

}
