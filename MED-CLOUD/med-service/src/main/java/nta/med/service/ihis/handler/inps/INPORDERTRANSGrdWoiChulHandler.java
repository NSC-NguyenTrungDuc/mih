package nta.med.service.ihis.handler.inps;

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
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdWoichulInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSGrdWoiChulRequest;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSGrdWoiChulResponse;

@Service
@Scope("prototype")
public class INPORDERTRANSGrdWoiChulHandler  extends ScreenHandler<InpsServiceProto.INPORDERTRANSGrdWoiChulRequest, InpsServiceProto.INPORDERTRANSGrdWoiChulResponse>{
	@Resource
	private Nur1014Repository nur1014Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INPORDERTRANSGrdWoiChulResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INPORDERTRANSGrdWoiChulRequest request) throws Exception {
		InpsServiceProto.INPORDERTRANSGrdWoiChulResponse.Builder response = InpsServiceProto.INPORDERTRANSGrdWoiChulResponse.newBuilder();
		Double pk1001 = CommonUtils.parseDouble(request.getPk1001());
		List<ORDERTRANSGrdWoichulInfo> grdList = nur1014Repository.getORDERTRANSGrdWoichulInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), 
				request.getSendYn(), request.getBunho(), pk1001, request.getOrderDate());
		if(!CollectionUtils.isEmpty(grdList)){
			for(ORDERTRANSGrdWoichulInfo item : grdList){
				InpsModelProto.INPORDERTRANSGrdWoiChulInfo.Builder info = InpsModelProto.INPORDERTRANSGrdWoiChulInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if(item.getFkinp1001() != null){
					info.setFkinp1001Two(CommonUtils.parseString(item.getFkinp1001()));
				}
				if(item.getFkOutDate() != null){
					info.setFkinp1001Two(DateUtil.toString(item.getFkOutDate(), DateUtil.PATTERN_YYMMDD));
				}
				response.addGrdList(info);
			}
		}
		return response.build();
	}

}
