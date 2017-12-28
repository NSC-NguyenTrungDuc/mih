package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.data.model.ihis.schs.SCH0201Q05LayReserListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201Q05LayReserListRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201Q05LayReserListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SCH0201Q05LayReserListHandler
	extends ScreenHandler <SchsServiceProto.SCH0201Q05LayReserListRequest, SchsServiceProto.SCH0201Q05LayReserListResponse> {
	
	@Resource
	private Sch0201Repository sch0201Repository;
	
	@Override
	@Transactional(readOnly=true)
	public SCH0201Q05LayReserListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SCH0201Q05LayReserListRequest request) throws Exception {
        SchsServiceProto.SCH0201Q05LayReserListResponse.Builder response = SchsServiceProto.SCH0201Q05LayReserListResponse.newBuilder();
    	List<SCH0201Q05LayReserListInfo> listReser = sch0201Repository.getSCH0201Q05LayReserListInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho());
    	if(listReser != null && !listReser.isEmpty()){
			for(SCH0201Q05LayReserListInfo item : listReser){
				SchsModelProto.SCH0201Q05LayReserListInfo.Builder info = SchsModelProto.SCH0201Q05LayReserListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addReserListItem(info);
			}
		}
    	return response.build(); 
	}
}
