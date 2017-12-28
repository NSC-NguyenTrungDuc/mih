package nta.med.service.ihis.handler.bill;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bil.Bil0101Repository;
import nta.med.data.model.ihis.bill.LoadGridPayHistoryBIL2016U02Info;
import nta.med.service.ihis.proto.BillModelProto;
import nta.med.service.ihis.proto.BillServiceProto;
import nta.med.service.ihis.proto.BillServiceProto.LoadGridPayHistoryBIL2016U02Request;
import nta.med.service.ihis.proto.BillServiceProto.LoadGridPayHistoryBIL2016U02Response;

@Service
@Scope("prototype")
public class LoadGridPayHistoryBIL2016U02Handler extends ScreenHandler<BillServiceProto.LoadGridPayHistoryBIL2016U02Request, BillServiceProto.LoadGridPayHistoryBIL2016U02Response>{

	@Resource
	private Bil0101Repository bil0101Repository;
	
	@Override
	@Transactional(readOnly = true)
	public LoadGridPayHistoryBIL2016U02Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			LoadGridPayHistoryBIL2016U02Request request) throws Exception {
		BillServiceProto.LoadGridPayHistoryBIL2016U02Response.Builder response = BillServiceProto.LoadGridPayHistoryBIL2016U02Response.newBuilder();
		List<LoadGridPayHistoryBIL2016U02Info> results = bil0101Repository.getLoadGridPayHistoryBIL2016U02Info(getHospitalCode(vertx, sessionId), request.getParentInvoiceNo());
		if(!CollectionUtils.isEmpty(results)){
			for(LoadGridPayHistoryBIL2016U02Info item : results){
				BillModelProto.LoadGridPayHistoryBIL2016U02Info.Builder info = BillModelProto.LoadGridPayHistoryBIL2016U02Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if(item.getAmount() != null){
					info.setAmount(String.format("%.0f", item.getAmount()));
				}
				if(item.getDiscount() != null){
					info.setDiscount(String.format("%.0f", item.getDiscount()));
				}
				if(item.getAmountPaid() != null){
					info.setAmountPaid(String.format("%.0f", item.getAmountPaid()));
				}
				if(item.getAmountDebt()  != null){
					info.setAmountDebt(String.format("%.0f", item.getAmountDebt()));
				}
				response.addGrdPayHistory(info);
			}
		}
		return response.build();
	}

}
