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
import nta.med.data.dao.medi.inp.Inp2004Repository;
import nta.med.data.model.ihis.nuro.ORDERTRANSGrdListInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSSelectListSQL3Request;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSSelectListSQL3Response;

@Service
@Scope("prototype")
public class INPORDERTRANSSelectListSQL3Handler extends ScreenHandler<InpsServiceProto.INPORDERTRANSSelectListSQL3Request, InpsServiceProto.INPORDERTRANSSelectListSQL3Response>{
	@Resource
	private Inp2004Repository inp2004Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INPORDERTRANSSelectListSQL3Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INPORDERTRANSSelectListSQL3Request request) throws Exception {
		InpsServiceProto.INPORDERTRANSSelectListSQL3Response.Builder response = InpsServiceProto.INPORDERTRANSSelectListSQL3Response.newBuilder();
		List<ORDERTRANSGrdListInfo> grdList = inp2004Repository.getORDERTRANSGrdListInfoCase3(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), 
				request.getIoGubun(), request.getSendYn(), request.getBunho(), request.getActingDate());
		if(!CollectionUtils.isEmpty(grdList)){
			for(ORDERTRANSGrdListInfo item : grdList){
				InpsModelProto.INPORDERTRANSSelectListSQL3Info.Builder info = InpsModelProto.INPORDERTRANSSelectListSQL3Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getFkinp1001() != null) {
					info.setFkinp1001(String.format("%.0f",item.getFkinp1001()));
				}
				if (item.getPkout() != null) {
					info.setPkout(String.format("%.0f",item.getPkout()));
				}
				response.addGrdList(info);
			}
		}
		return response.build();
	}

}
