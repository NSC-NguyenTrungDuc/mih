package nta.med.service.ihis.handler.ocsi;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.inps.OCS2003R00layOCS2001Info;
import nta.med.service.ihis.proto.OcsiModelProto;
import nta.med.service.ihis.proto.OcsiServiceProto;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003R00layOCS2001Request;
import nta.med.service.ihis.proto.OcsiServiceProto.OCS2003R00layOCS2001Response;

@Service
@Scope("prototype")
public class OCS2003R00layOCS2001Handler extends ScreenHandler<OcsiServiceProto.OCS2003R00layOCS2001Request, OcsiServiceProto.OCS2003R00layOCS2001Response>{
	@Resource
	private OutsangRepository outsangRepository;
	
	@Override
	@Transactional(readOnly=true)
	public OCS2003R00layOCS2001Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			OCS2003R00layOCS2001Request request) throws Exception {
		OcsiServiceProto.OCS2003R00layOCS2001Response.Builder response = OcsiServiceProto.OCS2003R00layOCS2001Response.newBuilder();
		Double fkinp1001 = CommonUtils.parseDouble(request.getFkinp1001());
		List<OCS2003R00layOCS2001Info> layList = outsangRepository.getOCS2003R00layOCS2001Info(getHospitalCode(vertx, sessionId), request.getBunho(), fkinp1001, request.getGwa());
		if(!CollectionUtils.isEmpty(layList)){
			for(OCS2003R00layOCS2001Info item : layList){
				OcsiModelProto.OCS2003R00layOCS2001Info.Builder info = OcsiModelProto.OCS2003R00layOCS2001Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLay2001(info);
			}
		}
		return response.build();
	}

}
