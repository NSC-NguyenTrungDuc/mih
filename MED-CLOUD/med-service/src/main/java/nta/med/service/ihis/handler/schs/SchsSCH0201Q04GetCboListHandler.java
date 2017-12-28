package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.sch.Sch0109;
import nta.med.data.dao.medi.sch.Sch0109Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q04GetCboListRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201Q04GetCboListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class SchsSCH0201Q04GetCboListHandler
	extends ScreenHandler<SchsServiceProto.SchsSCH0201Q04GetCboListRequest, SchsServiceProto.SchsSCH0201Q04GetCboListResponse> {                     
	@Resource                                                                                                       
	private Sch0109Repository sch0109Repository;                                                                    
	                                                                                                                
	@Override                            
	@Transactional(readOnly=true)
	public SchsSCH0201Q04GetCboListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			SchsSCH0201Q04GetCboListRequest request) throws Exception {                                                                  
  	   	SchsServiceProto.SchsSCH0201Q04GetCboListResponse.Builder response = SchsServiceProto.SchsSCH0201Q04GetCboListResponse.newBuilder();       
		List<Sch0109> listObj = sch0109Repository.getSCH0201Q04GetCboInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "GROUP");
		if (!CollectionUtils.isEmpty(listObj)) {
			for (Sch0109 sch0109 : listObj) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				if (!StringUtils.isEmpty(sch0109.getCode())) {
					info.setCode(sch0109.getCode());
				}
				if (!StringUtils.isEmpty(sch0109.getCodeName())) {
					info.setCodeName(sch0109.getCodeName());
				}
				response.addCboItem(info);
			}
		}
		return response.build();
	}
}