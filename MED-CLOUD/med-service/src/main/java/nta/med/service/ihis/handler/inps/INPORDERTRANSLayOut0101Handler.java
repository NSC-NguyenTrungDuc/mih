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
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.inps.INPBATCHTRANSlayOut0101Info;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSLayOut0101Request;
import nta.med.service.ihis.proto.InpsServiceProto.INPORDERTRANSLayOut0101Response;

@Service
@Scope("prototype")
public class INPORDERTRANSLayOut0101Handler extends ScreenHandler<InpsServiceProto.INPORDERTRANSLayOut0101Request, InpsServiceProto.INPORDERTRANSLayOut0101Response>{
	@Resource
	private Out0101Repository out0101Repository;
	
	@Override
	@Transactional(readOnly=true)
	public INPORDERTRANSLayOut0101Response handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INPORDERTRANSLayOut0101Request request) throws Exception {
		InpsServiceProto.INPORDERTRANSLayOut0101Response.Builder response = InpsServiceProto.INPORDERTRANSLayOut0101Response.newBuilder();
		List<INPBATCHTRANSlayOut0101Info> result = out0101Repository.getINPBATCHTRANSlayOut0101Info(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho());
		if(!CollectionUtils.isEmpty(result)){
			for(INPBATCHTRANSlayOut0101Info item : result){
				InpsModelProto.INPORDERTRANSLayOut0101Info.Builder info = InpsModelProto.INPORDERTRANSLayOut0101Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLayList(info);
			}
		}
		return response.build();
	}

}
