package nta.med.service.ihis.handler.phys;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.model.ihis.phys.Phy8002U01BtnPrintGetDataWindowInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysModelProto;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U01BtnPrintGetDataWindowRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY8002U01BtnPrintGetDataWindowResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PHY8002U01BtnPrintGetDataWindowHandler
	extends ScreenHandler<PhysServiceProto.PHY8002U01BtnPrintGetDataWindowRequest, PhysServiceProto.PHY8002U01BtnPrintGetDataWindowResponse> {                     
	@Resource                                                                                                       
	private Bas0001Repository bas0001Repository;                                                                    
	                                                                                                                
	@Override                   
	@Transactional(readOnly=true)
	public PHY8002U01BtnPrintGetDataWindowResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			PHY8002U01BtnPrintGetDataWindowRequest request) throws Exception {                                                                  
  	   	PhysServiceProto.PHY8002U01BtnPrintGetDataWindowResponse.Builder response = PhysServiceProto.PHY8002U01BtnPrintGetDataWindowResponse.newBuilder();                      
		List<Phy8002U01BtnPrintGetDataWindowInfo> list =  bas0001Repository.getPhy8002U01BtnPrintGetDataWindowListItem(getHospitalCode(vertx, sessionId));
		if(!CollectionUtils.isEmpty(list)){
			for(Phy8002U01BtnPrintGetDataWindowInfo item : list){
				PhysModelProto.PHY8002U01BtnPrintGetDataWindowInfo.Builder info = PhysModelProto.PHY8002U01BtnPrintGetDataWindowInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addInfoList(info);
			}
		}
		return response.build();
	}
}