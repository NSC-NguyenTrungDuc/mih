package nta.med.service.ihis.handler.inps;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1014Repository;
import nta.med.data.model.ihis.inps.INPORDERTRANSSelectListSQL1Info;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSSelectListSQL2Request;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSSelectListSQL2Response;

@Service
@Scope("prototype")
public class INPORDERTRANSSelectListSQL2Handler extends ScreenHandler<InpsServiceProto.INPORDERTRANSSelectListSQL2Request, InpsServiceProto.INPORDERTRANSSelectListSQL2Response>{
	@Resource
	private Nur1014Repository nur1014Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INPORDERTRANSSelectListSQL2Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INPORDERTRANSSelectListSQL2Request request) throws Exception {
		InpsServiceProto.INPORDERTRANSSelectListSQL2Response.Builder response = InpsServiceProto.INPORDERTRANSSelectListSQL2Response.newBuilder();
		Date firstDate = DateUtil.toDate(request.getYmdFirst(), DateUtil.PATTERN_YYMMDD);
        Date lastDate = DateUtil.toDate(request.getYmdLast(), DateUtil.PATTERN_YYMMDD);
		List<INPORDERTRANSSelectListSQL1Info> listResult = nur1014Repository.getINPORDERTRANSSelectListSQL2(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), 
				request.getBunho(), firstDate, lastDate, request.getYm());
		if(!CollectionUtils.isEmpty(listResult)){
			for(INPORDERTRANSSelectListSQL1Info item : listResult){
				InpsModelProto.INPORDERTRANSSelectListSQL1Info.Builder info = InpsModelProto.INPORDERTRANSSelectListSQL1Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdList(info);
			}
		}
		return response.build();
	}

}
