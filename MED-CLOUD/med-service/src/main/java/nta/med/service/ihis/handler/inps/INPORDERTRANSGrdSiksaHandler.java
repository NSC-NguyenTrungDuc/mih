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
import nta.med.data.dao.medi.ocs.Ocs2015Repository;
import nta.med.data.model.ihis.inps.INPORDERTRANSGrdSiksaInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSGrdSiksaRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSGrdSiksaResponse;

@Service
@Scope("prototype")
public class INPORDERTRANSGrdSiksaHandler  extends ScreenHandler<InpsServiceProto.INPORDERTRANSGrdSiksaRequest, InpsServiceProto.INPORDERTRANSGrdSiksaResponse>{
	@Resource
	private Ocs2015Repository ocs2015Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INPORDERTRANSGrdSiksaResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INPORDERTRANSGrdSiksaRequest request) throws Exception {
		InpsServiceProto.INPORDERTRANSGrdSiksaResponse.Builder response = InpsServiceProto.INPORDERTRANSGrdSiksaResponse.newBuilder();
		String offset = request.getOffset();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
        Date firstDate = DateUtil.toDate(request.getYmdFirst(), DateUtil.PATTERN_YYMMDD);
        Date lastDate = DateUtil.toDate(request.getYmdLast(), DateUtil.PATTERN_YYMMDD);
		List<INPORDERTRANSGrdSiksaInfo> grdList = ocs2015Repository.getINPORDERTRANSGrdSiksaInfo(getHospitalCode(vertx, sessionId), request.getBunho(), 
				request.getSendYn(), firstDate, lastDate, startNum, CommonUtils.parseInteger(offset));
		if(!CollectionUtils.isEmpty(grdList)){
			for(INPORDERTRANSGrdSiksaInfo item : grdList){
				InpsModelProto.INPORDERTRANSGrdSiksaInfo.Builder info = InpsModelProto.INPORDERTRANSGrdSiksaInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdList(info);
			}
		}
		return response.build();
	}

}
