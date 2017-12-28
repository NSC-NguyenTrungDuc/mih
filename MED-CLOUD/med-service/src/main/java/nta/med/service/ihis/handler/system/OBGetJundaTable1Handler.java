package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.system.OBGetJundaTable1Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OBGetJundaTable1Request;
import nta.med.service.ihis.proto.SystemServiceProto.OBGetJundaTable1Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OBGetJundaTable1Handler
	extends ScreenHandler<SystemServiceProto.OBGetJundaTable1Request, SystemServiceProto.OBGetJundaTable1Response> {                     
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OBGetJundaTable1Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OBGetJundaTable1Request request)
			throws Exception {                                                                 
  	   	SystemServiceProto.OBGetJundaTable1Response.Builder response = SystemServiceProto.OBGetJundaTable1Response.newBuilder();                      
		List<OBGetJundaTable1Info> listJunda=ocs0103Repository.getOBGetJundaTable1Info(getHospitalCode(vertx, sessionId),request.getHangmogCode(),request.getIoGubun(),request.getJundalPart());
		if(!CollectionUtils.isEmpty(listJunda)){
			for(OBGetJundaTable1Info item : listJunda){
				CommonModelProto.OBGetJundaTable1Info.Builder info = CommonModelProto.OBGetJundaTable1Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addJundalTableItem(info);
			}
		}
		return response.build();
	}
}