package nta.med.service.ihis.handler.injs;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inj.Inj1001Repository;
import nta.med.data.model.ihis.injs.INJ0000Q00layOrderInfo;
import nta.med.service.ihis.proto.InjsModelProto;
import nta.med.service.ihis.proto.InjsServiceProto;
import nta.med.service.ihis.proto.InjsServiceProto.INJ0000Q00layOrderRequest;
import nta.med.service.ihis.proto.InjsServiceProto.INJ0000Q00layOrderResponse;

@Service                                                                                                          
@Scope("prototype")
public class INJ0000Q00layOrderHandler extends ScreenHandler<InjsServiceProto.INJ0000Q00layOrderRequest, InjsServiceProto.INJ0000Q00layOrderResponse>{
	@Resource
	private Inj1001Repository inj1001Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public INJ0000Q00layOrderResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INJ0000Q00layOrderRequest request) throws Exception {
		InjsServiceProto.INJ0000Q00layOrderResponse.Builder response = InjsServiceProto.INJ0000Q00layOrderResponse.newBuilder();
		List<INJ0000Q00layOrderInfo> list = inj1001Repository.getINJ0000Q00layOrderInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho(), request.getGubun(), request.getMessageGubun());
		if (!CollectionUtils.isEmpty(list)) {
			for (INJ0000Q00layOrderInfo item : list) {
				InjsModelProto.INJ0000Q00layOrderInfo.Builder info = InjsModelProto.INJ0000Q00layOrderInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayItem(info);
			}
		}
		return response.build();
	}

}
