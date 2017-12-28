package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0132Repository;
import nta.med.data.model.ihis.nuro.OUT1001P03GrdOrderInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class OUT1001P03GrdAfterOrderHandler extends ScreenHandler<NuroServiceProto.OUT1001P03GrdAfterOrderRequest, NuroServiceProto.OUT1001P03GrdAfterOrderResponse> {                             
	@Resource                                                                                                       
	private Ocs0132Repository ocs0132Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.OUT1001P03GrdAfterOrderResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OUT1001P03GrdAfterOrderRequest request) throws Exception {
		NuroServiceProto.OUT1001P03GrdAfterOrderResponse.Builder response = NuroServiceProto.OUT1001P03GrdAfterOrderResponse.newBuilder(); 
		List<OUT1001P03GrdOrderInfo> listPatient = ocs0132Repository.getOUT1001P03GrdOrderInfo(getHospitalCode(vertx, sessionId),
				getLanguage(vertx, sessionId), request.getIoGubun(), request.getBunho(),CommonUtils.parseDouble(request.getNaewonKey()), false);
			if(!CollectionUtils.isEmpty(listPatient)){
				for(OUT1001P03GrdOrderInfo item : listPatient){
					NuroModelProto.OUT1001P03GrdOrderInfo.Builder info = NuroModelProto.OUT1001P03GrdOrderInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addGrdOrderInfo(info);
				}
			}
		return response.build();
	} 
}
