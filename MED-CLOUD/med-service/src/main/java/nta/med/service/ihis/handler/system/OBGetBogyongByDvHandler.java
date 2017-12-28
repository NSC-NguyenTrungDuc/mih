package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.data.model.ihis.system.OBGetBogyongByDvItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OBGetBogyongByDvRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OBGetBogyongByDvResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OBGetBogyongByDvHandler
	extends ScreenHandler<SystemServiceProto.OBGetBogyongByDvRequest, SystemServiceProto.OBGetBogyongByDvResponse> {                     
	@Resource                                                                                                       
	private Drg0120Repository drg0120Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OBGetBogyongByDvResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OBGetBogyongByDvRequest request)
			throws Exception {                                                                 
      	   	SystemServiceProto.OBGetBogyongByDvResponse.Builder response = SystemServiceProto.OBGetBogyongByDvResponse.newBuilder();                      
		List<OBGetBogyongByDvItemInfo> listBogyong =drg0120Repository.getOBGetBogyongByDvItemInfo(getHospitalCode(vertx, sessionId),request.getBogyongCode(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listBogyong)){
			if(!StringUtils.isEmpty(listBogyong.get(0).getBogyoungGubun())){
				response.setDv(listBogyong.get(0).getBogyoungGubun());
			}
			if(!StringUtils.isEmpty(listBogyong.get(0).getBanghyang())){
				response.setGubun(listBogyong.get(0).getBanghyang());
			}
		}
		return response.build();
	}
}