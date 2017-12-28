package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.drg.Drg0120;
import nta.med.data.dao.medi.drg.Drg0120Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OBGetBogyongInfo2Request;
import nta.med.service.ihis.proto.SystemServiceProto.OBGetBogyongResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OBGetBogyongInfo2Handler
	extends ScreenHandler<SystemServiceProto.OBGetBogyongInfo2Request, SystemServiceProto.OBGetBogyongResponse> {                     
	@Resource                                                                                                       
	private Drg0120Repository drg0120Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OBGetBogyongResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, OBGetBogyongInfo2Request request)
			throws Exception {                                                             
      	   	SystemServiceProto.OBGetBogyongResponse.Builder response = SystemServiceProto.OBGetBogyongResponse.newBuilder();                      
		List<Drg0120> listDrg= drg0120Repository.getObjectOBGetBogyongInfo(getHospitalCode(vertx, sessionId),request.getBogyongCode(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listDrg)){
			for(Drg0120 drg : listDrg){
				CommonModelProto.OBGetBogyongInfo.Builder info =CommonModelProto.OBGetBogyongInfo.newBuilder();
				if(!StringUtils.isEmpty(drg.getBogyongName())){
					info.setBogyongName(drg.getBogyongName());
				}
				if(!StringUtils.isEmpty(drg.getDonbogYn())){
					info.setDonbogYn(drg.getDonbogYn());
				}
				if(!StringUtils.isEmpty(drg.getBogyongGubun())){
					info.setNvl(drg.getBogyongGubun());
				}else{
					info.setNvl("99");
				}
				response.addBogyongInfoItem(info);
			}
		}
		return response.build();
	}
}