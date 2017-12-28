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
import nta.med.data.model.ihis.injs.INJ0000Q00layActingInfo;
import nta.med.service.ihis.proto.InjsModelProto;
import nta.med.service.ihis.proto.InjsServiceProto;
import nta.med.service.ihis.proto.InjsServiceProto.INJ0000Q00layActingRequest;
import nta.med.service.ihis.proto.InjsServiceProto.INJ0000Q00layActingResponse;

@Service                                                                                                          
@Scope("prototype") 
public class INJ0000Q00layActingHandler extends ScreenHandler<InjsServiceProto.INJ0000Q00layActingRequest, InjsServiceProto.INJ0000Q00layActingResponse>{
	@Resource
	private Inj1001Repository inj1001Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public INJ0000Q00layActingResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INJ0000Q00layActingRequest request) throws Exception {
		InjsServiceProto.INJ0000Q00layActingResponse.Builder response = InjsServiceProto.INJ0000Q00layActingResponse.newBuilder();
		List<INJ0000Q00layActingInfo> list = inj1001Repository.getINJ0000Q00layActingInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho(), request.getMessageGubun());
		if (!CollectionUtils.isEmpty(list)) {
			for (INJ0000Q00layActingInfo item : list) {
				InjsModelProto.INJ0000Q00layActingInfo.Builder info = InjsModelProto.INJ0000Q00layActingInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayItem(info);
			}
		}
		return response.build();
	}

}
