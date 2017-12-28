package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.phys.PHY2001U04CboJubsuGubunInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.PHY2001U04CboJubsuGubunRequest;
import nta.med.service.ihis.proto.SystemServiceProto.PHY2001U04CboJubsuGubunResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY2001U04CboJubsuGubunHandler extends ScreenHandler <SystemServiceProto.PHY2001U04CboJubsuGubunRequest, SystemServiceProto.PHY2001U04CboJubsuGubunResponse> {                     
	@Resource                                                                                                       
	private Bas0102Repository bas0102Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public PHY2001U04CboJubsuGubunResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PHY2001U04CboJubsuGubunRequest request) throws Exception {
  	   	SystemServiceProto.PHY2001U04CboJubsuGubunResponse.Builder response = SystemServiceProto.PHY2001U04CboJubsuGubunResponse.newBuilder();                      
		List<PHY2001U04CboJubsuGubunInfo> listCbo = bas0102Repository.getPHY2001U04CboJubsuGubunInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listCbo)){
			for(PHY2001U04CboJubsuGubunInfo item : listCbo){
				SystemModelProto.PHY2001U04CboJubsuGubunInfo.Builder info = SystemModelProto.PHY2001U04CboJubsuGubunInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCboJubsuGubun(info);
			}
		}
		return response.build();
	}                                                                                                                 
}