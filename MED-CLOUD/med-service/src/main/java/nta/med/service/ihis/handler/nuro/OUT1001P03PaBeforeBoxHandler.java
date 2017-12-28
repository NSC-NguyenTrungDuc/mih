package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.out.Out0101;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")   
public class OUT1001P03PaBeforeBoxHandler extends ScreenHandler<NuroServiceProto.OUT1001P03PaBeforeBoxRequest, NuroServiceProto.OUT1001P03PaBeforeBoxResponse> {                             
	@Resource                                                                                                       
	private Out0101Repository out0101Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.OUT1001P03PaBeforeBoxResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OUT1001P03PaBeforeBoxRequest request) throws Exception {
		NuroServiceProto.OUT1001P03PaBeforeBoxResponse.Builder response = NuroServiceProto.OUT1001P03PaBeforeBoxResponse.newBuilder(); 
		List<Out0101> listItem  = out0101Repository.getByBunho(getHospitalCode(vertx, sessionId), request.getBunho());
		if(!CollectionUtils.isEmpty(listItem)){
			for(Out0101 item : listItem){
				if(!StringUtils.isEmpty(item.getBunhoType())){
					response.setBunhoType(item.getBunhoType());
				}else{
					response.setBunhoType("0");
				}
			}
		}
		return response.build();
	}   

}
