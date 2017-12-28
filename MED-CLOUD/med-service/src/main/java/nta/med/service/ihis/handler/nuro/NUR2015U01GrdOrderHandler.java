package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.nuro.NUR2015U01GrdOrderInfo;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.NUR2015U01GrdOrderRequest;
import nta.med.service.ihis.proto.NuroServiceProto.NUR2015U01GrdOrderResponse;

@Service
@Scope("prototype")
public class NUR2015U01GrdOrderHandler extends ScreenHandler<NuroServiceProto.NUR2015U01GrdOrderRequest, NuroServiceProto.NUR2015U01GrdOrderResponse>{
	private static final Log LOGGER = LogFactory.getLog(NUR2015U01GrdOrderHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public NUR2015U01GrdOrderResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2015U01GrdOrderRequest request) throws Exception {
		NuroServiceProto.NUR2015U01GrdOrderResponse.Builder response = NuroServiceProto.NUR2015U01GrdOrderResponse.newBuilder();
		String hospCode = request.getHospCode();
		if (StringUtils.isEmpty(hospCode)){
			hospCode = getHospitalCode(vertx, sessionId);
		}
		
		//List<Out1001> listOut1001 = out1001Repository.findByHospCodeAndBunho(hospCode, request.getBunho());
		List<NUR2015U01GrdOrderInfo> itemList = out1001Repository.getNUR2015U01GrdOrderInfo(hospCode, request.getBunho(), getLanguage(vertx, sessionId));
		
		if(!CollectionUtils.isEmpty(itemList)){
			for(NUR2015U01GrdOrderInfo item : itemList){
				NuroModelProto.NUR2015U01GrdOrderInfo.Builder info = NuroModelProto.NUR2015U01GrdOrderInfo.newBuilder();
				if(item.getExamDate() != null){
					info.setExamDate(item.getExamDate());
				}
				
				if(!StringUtils.isEmpty(item.getGwa())){
					info.setGwa(item.getGwa());
				}
				
				if(item.getNaewonKey() != null){
					info.setNaewonKey(String.format("%.0f", item.getNaewonKey()));
				}
				
				if(item.getGwaName() != null){
					info.setGwaName(item.getGwaName());
				}
				
				response.addGrdOrderList(info);
			}
		}
		
		return response.build();
	}

}
