package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ifs.Ifs5011Repository;
import nta.med.data.model.ihis.nuro.ORDERTRANSSangSendAllInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ORDERTRANSSangSendAllHandler extends ScreenHandler<NuroServiceProto.ORDERTRANSSangSendAllRequest, NuroServiceProto.ORDERTRANSSangSendAllResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(ORDERTRANSSangSendAllHandler.class);                                    
	@Resource                                                                                                       
	private Ifs5011Repository ifs5011Repository;                                                                    
	                                                                                                                

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.ORDERTRANSSangSendAllResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.ORDERTRANSSangSendAllRequest request) throws Exception {
		NuroServiceProto.ORDERTRANSSangSendAllResponse.Builder response = NuroServiceProto.ORDERTRANSSangSendAllResponse.newBuilder();
		List<ORDERTRANSSangSendAllInfo> listResult = ifs5011Repository.getORDERTRANSSangSendAllInfo(getHospitalCode(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listResult)){
			for(ORDERTRANSSangSendAllInfo item : listResult){
				NuroModelProto.ORDERTRANSSangSendAllInfo.Builder info = NuroModelProto.ORDERTRANSSangSendAllInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if (item.getIfsKey() != null) {
					info.setIfsKey(String.format("%.0f",item.getIfsKey()));
				}
				response.addSangInfoItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}