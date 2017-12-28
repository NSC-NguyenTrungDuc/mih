package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.nuro.OUT1001R01LayOut0101Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype") 
public class OUT1001R01LayOut0101Handler extends ScreenHandler<NuroServiceProto.OUT1001R01LayOut0101Request, NuroServiceProto.OUT1001R01LayOut0101Response> {                             
	@Resource                                                                                                       
	private Out0101Repository out0101Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.OUT1001R01LayOut0101Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OUT1001R01LayOut0101Request request) throws Exception {
		NuroServiceProto.OUT1001R01LayOut0101Response.Builder response = NuroServiceProto.OUT1001R01LayOut0101Response.newBuilder(); 
		List<OUT1001R01LayOut0101Info> listPatient = out0101Repository.getOUT1001R01LayOut0101Info(getHospitalCode(vertx, sessionId), request.getBunho(), getLanguage(vertx, sessionId));
			if(!CollectionUtils.isEmpty(listPatient)){
				for(OUT1001R01LayOut0101Info item : listPatient){
					NuroModelProto.OUT1001R01LayOut0101Info.Builder info = NuroModelProto.OUT1001R01LayOut0101Info.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addLayoutList(info);
				}
			}
		return response.build();
	}

}
