package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.sch.Sch0002Repository;
import nta.med.data.model.ihis.schs.SCH3001U00GrdSCH0002Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00GrdSCH0002Request;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00GrdSCH0002Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SCH3001U00GrdSCH0002Handler
	extends ScreenHandler<SchsServiceProto.SCH3001U00GrdSCH0002Request, SchsServiceProto.SCH3001U00GrdSCH0002Response> {
	
	@Resource
	private Sch0002Repository sch0002Repository; 
	
	@Override
	@Transactional(readOnly=true)
	public SCH3001U00GrdSCH0002Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SCH3001U00GrdSCH0002Request request) throws Exception {
        SchsServiceProto.SCH3001U00GrdSCH0002Response.Builder response = SchsServiceProto.SCH3001U00GrdSCH0002Response.newBuilder();
    	List<SCH3001U00GrdSCH0002Info> listSCH3001U00GrdSCH0002Info = sch0002Repository.getSCH3001U00GrdSCH0002Info(getHospitalCode(vertx, sessionId), request.getJundalTable(),request.getJundalPart());
    	if(listSCH3001U00GrdSCH0002Info != null && !listSCH3001U00GrdSCH0002Info.isEmpty()){
			for(SCH3001U00GrdSCH0002Info item : listSCH3001U00GrdSCH0002Info){
				SchsModelProto.SCH3001U00GrdSCH0002Info.Builder info = SchsModelProto.SCH3001U00GrdSCH0002Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				
				response.addGrdSch0002List(info);
			}
		}
    	return response.build();
	}
}
