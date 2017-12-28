package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype") 
@Transactional
public class NUR2001U04SaveLayoutHandler extends ScreenHandler<NuroServiceProto.NUR2001U04SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(NUR2001U04SaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;                                                                    
	                                                                                                                
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NUR2001U04SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		Integer result = null;
		for(NuroModelProto.NUR2001U04SaveLayoutInfo item : request.getSaveLayoutItemList()){
			Double pkout1001 = CommonUtils.parseDouble(item.getPkout1001());
			 result = out1001Repository.updatePhyWherePkout1001(request.getHospCode(), request.getUserId(), item.getNaewonYn(),
					 item.getArriveTime(), item.getJubsuGubun(), pkout1001);
		}
		response.setResult(result != null && result > 0);
   	 	return response.build();
	}                                                                                                                 
}