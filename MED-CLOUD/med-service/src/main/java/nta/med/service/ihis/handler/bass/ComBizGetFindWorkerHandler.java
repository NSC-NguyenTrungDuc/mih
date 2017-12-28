package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.cpl.Cpl0108Repository;
import nta.med.data.model.ihis.bass.ComBizGetFindWorkerInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.helper.OrderBizHelper;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.ComBizGetFindWorkerRequest;
import nta.med.service.ihis.proto.BassServiceProto.ComBizGetFindWorkerResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class ComBizGetFindWorkerHandler extends ScreenHandler<BassServiceProto.ComBizGetFindWorkerRequest, BassServiceProto.ComBizGetFindWorkerResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(ComBizGetFindWorkerHandler.class);                                    
	@Resource                                                                                                       
	private Cpl0108Repository cpl0108Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional
	public ComBizGetFindWorkerResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, ComBizGetFindWorkerRequest request)
					throws Exception {
  	   	BassServiceProto.ComBizGetFindWorkerResponse.Builder response = BassServiceProto.ComBizGetFindWorkerResponse.newBuilder();                      
		List<ComBizGetFindWorkerInfo> list = OrderBizHelper.getBassComBiz(getHospitalCode(vertx, sessionId), request.getColName(), request.getArgu1(), request.getFind1(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(list)){
			for(ComBizGetFindWorkerInfo item : list){
				BassModelProto.ComBizGetFindWorkerInfo.Builder info = BassModelProto.ComBizGetFindWorkerInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addInfoList(info);
			}
		}

		return response.build();
	}                                                                                                            
}