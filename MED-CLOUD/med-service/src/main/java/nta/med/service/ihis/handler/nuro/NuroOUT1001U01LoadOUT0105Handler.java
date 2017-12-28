package nta.med.service.ihis.handler.nuro;


import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.nuro.NuroOUT1001U01LoadOUT0105Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class NuroOUT1001U01LoadOUT0105Handler  extends ScreenHandler<NuroServiceProto.NuroOUT1001U01LoadOUT0105Request, NuroServiceProto.NuroOUT1001U01LoadOUT0105Response> {
	private static final Log LOGGER = LogFactory.getLog(NuroOUT1001U01LoadOUT0105Handler.class);
	@Resource
	private Out1001Repository out1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public NuroServiceProto.NuroOUT1001U01LoadOUT0105Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT1001U01LoadOUT0105Request request) throws Exception {
		NuroServiceProto.NuroOUT1001U01LoadOUT0105Response.Builder response = NuroServiceProto.NuroOUT1001U01LoadOUT0105Response.newBuilder();
		List<NuroOUT1001U01LoadOUT0105Info> listNuroOUT1001U01LoadOUT0105Info = out1001Repository.getNuroOUT1001U01LoadOUT0105Info(getHospitalCode(vertx, sessionId), request.getGongbiCode(), request.getFkout1001());
		if(listNuroOUT1001U01LoadOUT0105Info != null && !listNuroOUT1001U01LoadOUT0105Info.isEmpty()){
			for(NuroOUT1001U01LoadOUT0105Info item : listNuroOUT1001U01LoadOUT0105Info){
				NuroModelProto.NuroOUT1001U01LoadOUT0105Info.Builder nuroLoadOUT0105Info = NuroModelProto.NuroOUT1001U01LoadOUT0105Info.newBuilder();
				if(item.getGongbiCode() != null){
					nuroLoadOUT0105Info.setGongbiCode(item.getGongbiCode());
				}
				if(item.getPriority() != null){
					nuroLoadOUT0105Info.setPriority(item.getPriority().toString());
				}
				response.addItemValue(nuroLoadOUT0105Info);
			}
		}
		return response.build();
	}
	
}
