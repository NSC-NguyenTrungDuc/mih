package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.nuro.OUT1001P03GrdAfterJubsuInfo;
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
public class OUT1001P03GrdAfterJubsuHandler extends ScreenHandler<NuroServiceProto.OUT1001P03GrdAfterJubsuRequest, NuroServiceProto.OUT1001P03GrdAfterJubsuResponse> {                             
	@Resource                                                                                                       
	private Out0101Repository out0101Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.OUT1001P03GrdAfterJubsuResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OUT1001P03GrdAfterJubsuRequest request) throws Exception {
		NuroServiceProto.OUT1001P03GrdAfterJubsuResponse.Builder response = NuroServiceProto.OUT1001P03GrdAfterJubsuResponse.newBuilder(); 
		List<OUT1001P03GrdAfterJubsuInfo> listPatient = out0101Repository.getOUT1001P03GrdAfterJubsuInfo(getHospitalCode(vertx, sessionId),
				getLanguage(vertx, sessionId), request.getIoGubun(), request.getBunho());
			if(!CollectionUtils.isEmpty(listPatient)){
				for(OUT1001P03GrdAfterJubsuInfo item : listPatient){
					NuroModelProto.OUT1001P03GrdAfterJubsuInfo.Builder info = NuroModelProto.OUT1001P03GrdAfterJubsuInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addGrdAfterJubsuInfo(info);
				}
			}
		return response.build();
	} 
}
