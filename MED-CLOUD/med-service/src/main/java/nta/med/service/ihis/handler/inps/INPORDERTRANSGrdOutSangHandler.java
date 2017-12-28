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
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.ihis.inps.INPORDERTRANSGrdOutSangInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSGrdOutSangRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSGrdOutSangResponse;

@Service
@Scope("prototype")
public class INPORDERTRANSGrdOutSangHandler extends ScreenHandler<InpsServiceProto.INPORDERTRANSGrdOutSangRequest , InpsServiceProto.INPORDERTRANSGrdOutSangResponse >{
	@Resource
	private OutsangRepository outsangRepository;
	
	@Override
	@Transactional(readOnly=true)
	public INPORDERTRANSGrdOutSangResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INPORDERTRANSGrdOutSangRequest request) throws Exception {
		InpsServiceProto.INPORDERTRANSGrdOutSangResponse.Builder response = InpsServiceProto.INPORDERTRANSGrdOutSangResponse.newBuilder();
		Date gijunDate = DateUtil.toDate(request.getGijunDate(), DateUtil.PATTERN_YYMMDD);
		List<INPORDERTRANSGrdOutSangInfo> grdList = outsangRepository.getINPORDERTRANSGrdOutSangInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), 
				request.getBunho(), request.getIoGubun(), gijunDate);
		if(!CollectionUtils.isEmpty(grdList)){
			for(INPORDERTRANSGrdOutSangInfo item : grdList){
				InpsModelProto.INPORDERTRANSGrdOutSangInfo.Builder info = InpsModelProto.INPORDERTRANSGrdOutSangInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdList(info);
			}
		}
		return response.build();
	}

}
