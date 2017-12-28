package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs2015Repository;
import nta.med.data.model.ihis.inps.INPORDERTRANSSelectListSQL1Info;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSSelectListSQL1Request;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSSelectListSQL1Response;

@Service
@Scope("prototype")
public class INPORDERTRANSSelectListSQL1Handler extends
		ScreenHandler<InpsServiceProto.INPORDERTRANSSelectListSQL1Request, InpsServiceProto.INPORDERTRANSSelectListSQL1Response> {

	@Resource
	private Ocs2015Repository ocs2015Repository;
	
	@Override
	public INPORDERTRANSSelectListSQL1Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INPORDERTRANSSelectListSQL1Request request) throws Exception {
		InpsServiceProto.INPORDERTRANSSelectListSQL1Response.Builder response = InpsServiceProto.INPORDERTRANSSelectListSQL1Response.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<INPORDERTRANSSelectListSQL1Info> infos = ocs2015Repository.getINPORDERTRANSSelectListSQL1Info(hospCode, language
				, request.getBunho()
				, request.getYm()
				, DateUtil.toDate(request.getYmdFirst(), DateUtil.PATTERN_YYMMDD)
				, DateUtil.toDate(request.getYmdLast(), DateUtil.PATTERN_YYMMDD));
		
		if(!CollectionUtils.isEmpty(infos)){
			for (INPORDERTRANSSelectListSQL1Info info : infos) {
				InpsModelProto.INPORDERTRANSSelectListSQL1Info.Builder pInfo = InpsModelProto.INPORDERTRANSSelectListSQL1Info.newBuilder();
				BeanUtils.copyProperties(info, pInfo, language);
				response.addGrdList(pInfo);
			}
		}
		
		return response.build();
	}

}
