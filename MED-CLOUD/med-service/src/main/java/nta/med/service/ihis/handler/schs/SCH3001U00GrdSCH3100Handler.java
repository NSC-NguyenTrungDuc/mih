package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.sch.Sch3100Repository;
import nta.med.data.model.ihis.schs.SCH3001U00GrdSCH3100Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00GrdSCH3100Request;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00GrdSCH3100Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SCH3001U00GrdSCH3100Handler
	extends ScreenHandler<SchsServiceProto.SCH3001U00GrdSCH3100Request, SchsServiceProto.SCH3001U00GrdSCH3100Response> {
	@Resource
	private Sch3100Repository sch3100Repository; 
	
	@Override
	@Transactional(readOnly=true)
	public SCH3001U00GrdSCH3100Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SCH3001U00GrdSCH3100Request request) throws Exception {
        SchsServiceProto.SCH3001U00GrdSCH3100Response.Builder response = SchsServiceProto.SCH3001U00GrdSCH3100Response.newBuilder();
    	List<SCH3001U00GrdSCH3100Info> listSCH3001U00GrdSCH3100Info = sch3100Repository.getSCH3001U00GrdSCH3100Info(getHospitalCode(vertx, sessionId), request.getJundalTable(), request.getJundalPart(), request.getGumsaja());
    	if(listSCH3001U00GrdSCH3100Info != null && !listSCH3001U00GrdSCH3100Info.isEmpty()){
			for(SCH3001U00GrdSCH3100Info item : listSCH3001U00GrdSCH3100Info){
				SchsModelProto.SCH3001U00GrdSCH3100Info.Builder info = SchsModelProto.SCH3001U00GrdSCH3100Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				
				response.addGrdSch3001List(info);
			}
    	}
    	return response.build();
	}
}
