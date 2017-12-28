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
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur1014Repository;
import nta.med.data.model.ihis.inps.INPORDERTRANSGrdWoiChulInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSGrdWoiChul2Request;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSGrdWoiChul2Response;

@Service
@Scope("prototype")
public class INPORDERTRANSGrdWoiChul2Handler extends ScreenHandler<InpsServiceProto.INPORDERTRANSGrdWoiChul2Request, InpsServiceProto.INPORDERTRANSGrdWoiChul2Response>{
	@Resource
	private Nur1014Repository nur1014Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INPORDERTRANSGrdWoiChul2Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INPORDERTRANSGrdWoiChul2Request request) throws Exception {
		InpsServiceProto.INPORDERTRANSGrdWoiChul2Response.Builder response = InpsServiceProto.INPORDERTRANSGrdWoiChul2Response.newBuilder();
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
        Date firstDate = DateUtil.toDate(request.getYmdFirst(), DateUtil.PATTERN_YYMMDD);
        Date lastDate = DateUtil.toDate(request.getYmdLast(), DateUtil.PATTERN_YYMMDD);
		List<INPORDERTRANSGrdWoiChulInfo> grdList = nur1014Repository.getINPORDERTRANSGrdWoiChulInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), 
				request.getSendYn(), request.getBunho(), firstDate, lastDate, startNum, CommonUtils.parseInteger(offset));
		if(!CollectionUtils.isEmpty(grdList)){
			for(INPORDERTRANSGrdWoiChulInfo item : grdList){
				InpsModelProto.INPORDERTRANSGrdWoiChulInfo.Builder info = InpsModelProto.INPORDERTRANSGrdWoiChulInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdList(info);
			}
		}
		return response.build();
	}

}
