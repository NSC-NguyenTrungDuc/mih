package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.model.ihis.nuro.OUT1001P03BunhoListItemInfo;
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
public class OUT1001P03BunhoListHandler extends ScreenHandler<NuroServiceProto.OUT1001P03BunhoListRequest, NuroServiceProto.OUT1001P03BunhoListResponse> {                             
	@Resource                                                                                                       
	private Out0101Repository out0101Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.OUT1001P03BunhoListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.OUT1001P03BunhoListRequest request) throws Exception {
		NuroServiceProto.OUT1001P03BunhoListResponse.Builder response = NuroServiceProto. OUT1001P03BunhoListResponse.newBuilder();
		List<OUT1001P03BunhoListItemInfo> list = out0101Repository.getOUT1001P03BunhoListItemInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(list)){
			for(OUT1001P03BunhoListItemInfo item : list){
				NuroModelProto.OUT1001P03BunhoListItemInfo.Builder info = NuroModelProto.OUT1001P03BunhoListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addBunhoList(info);
			}
		}
		return response.build();
	}

}
