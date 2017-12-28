package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.model.ihis.inps.OCS2003R00layOCS2003Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003R00layOCS2003Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003R00layOCS2003Response;

@Service
@Scope("prototype")
public class OCS2003R00layOCS2003Handler extends ScreenHandler<OcsiServiceProto.OCS2003R00layOCS2003Request, OcsiServiceProto.OCS2003R00layOCS2003Response>{
	
	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	public OCS2003R00layOCS2003Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003R00layOCS2003Request request) throws Exception {
		
		OcsiServiceProto.OCS2003R00layOCS2003Response.Builder response = OcsiServiceProto.OCS2003R00layOCS2003Response.newBuilder();
		Double fkinp1001 = CommonUtils.parseDouble(request.getFkinp1001());
		List<OCS2003R00layOCS2003Info> layList = ocs2003Repository.getOCS2003R00layOCS2003Info(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				request.getBunho(), fkinp1001, request.getOrderDate(), request.getInputGubun(), request.getGwa(), request.getDoctor());
		
		if(!CollectionUtils.isEmpty(layList)){
			for(OCS2003R00layOCS2003Info item : layList){
				OcsiModelProto.OCS2003R00layOCS2003Info.Builder info = OcsiModelProto.OCS2003R00layOCS2003Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLay2003(info);
			}
		}
		
		return response.build();
	}

}
