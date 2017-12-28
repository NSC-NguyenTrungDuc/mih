package nta.med.service.ihis.handler.invs;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.annotation.Route;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.data.model.ihis.invs.LoadGrdDetailINV0101Info;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.LoadGrdDetailINV0101Request;
import nta.med.service.ihis.proto.InvsServiceProto.LoadGrdDetailINV0101Response;

@Service                                                                                                          
@Scope("prototype")
public class LoadGrdDetailINV0101Handler extends ScreenHandler<InvsServiceProto.LoadGrdDetailINV0101Request, InvsServiceProto.LoadGrdDetailINV0101Response>{

	@Resource
    private Inv0102Repository inv0102Repository;
	
	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public LoadGrdDetailINV0101Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			LoadGrdDetailINV0101Request request) throws Exception {
		
		InvsServiceProto.LoadGrdDetailINV0101Response.Builder response = InvsServiceProto.LoadGrdDetailINV0101Response.newBuilder();
		List<LoadGrdDetailINV0101Info> listData = inv0102Repository.getGrdDetailINV0101Info(getHospitalCode(vertx, sessionId), request.getCodeType(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listData)){
			for (LoadGrdDetailINV0101Info item : listData) {
				InvsModelProto.LoadGrdDetailINV0101Info.Builder info = InvsModelProto.LoadGrdDetailINV0101Info .newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListDetail(info);
			}
		}
		
		return response.build();
	}
	
}
