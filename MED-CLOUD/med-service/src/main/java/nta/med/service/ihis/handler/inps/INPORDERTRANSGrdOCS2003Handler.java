package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.model.ihis.inps.INPORDERTRANSGrdOCS2003Info;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSGrdOCS2003Request;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSGrdOCS2003Response;

@Service
@Scope("prototype")
public class INPORDERTRANSGrdOCS2003Handler extends
		ScreenHandler<InpsServiceProto.INPORDERTRANSGrdOCS2003Request, InpsServiceProto.INPORDERTRANSGrdOCS2003Response> {

	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	public INPORDERTRANSGrdOCS2003Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INPORDERTRANSGrdOCS2003Request request) throws Exception {
		
		InpsServiceProto.INPORDERTRANSGrdOCS2003Response.Builder response = InpsServiceProto.INPORDERTRANSGrdOCS2003Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<INPORDERTRANSGrdOCS2003Info> infos = ocs2003Repository.getINPORDERTRANSGrdOCS2003Info(hospCode
				, language
				, request.getSendYn()
				, CommonUtils.parseDouble(request.getPkinp3010())
				, DateUtil.toDate(request.getActingDate(), DateUtil.PATTERN_YYMMDD)
				, request.getBunho());
		
		if(CollectionUtils.isEmpty(infos)){
			return response.build();
		}
		
		for (INPORDERTRANSGrdOCS2003Info info : infos) {
			InpsModelProto.INPORDERTRANSGrdOCS2003Info.Builder pInfo = InpsModelProto.INPORDERTRANSGrdOCS2003Info.newBuilder();
			BeanUtils.copyProperties(info, pInfo, language);
			response.addGrdList(pInfo);
		}
		
		return response.build();
	}

}
