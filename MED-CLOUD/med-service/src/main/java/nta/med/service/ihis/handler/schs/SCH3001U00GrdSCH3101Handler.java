package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.sch.Sch3101Repository;
import nta.med.data.model.ihis.schs.SCH3001U00GrdSCH3101Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00GrdSCH3101Request;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00GrdSCH3101Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SCH3001U00GrdSCH3101Handler 
	extends ScreenHandler<SchsServiceProto.SCH3001U00GrdSCH3101Request, SchsServiceProto.SCH3001U00GrdSCH3101Response> {
	
	@Resource
	private Sch3101Repository sch3101Repository; 
	
	@Override
	@Transactional(readOnly=true)
	public SCH3001U00GrdSCH3101Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SCH3001U00GrdSCH3101Request request) throws Exception {
        SchsServiceProto.SCH3001U00GrdSCH3101Response.Builder response = SchsServiceProto.SCH3001U00GrdSCH3101Response.newBuilder();
    	List<SCH3001U00GrdSCH3101Info> listSCH3001U00GrdSCH3101Info = sch3101Repository.getSCH3001U00GrdSCH3101Info(getHospitalCode(vertx, sessionId), request.getJundalTable(), request.getJundalPart(),
    			request.getGumsaja(), request.getReserDate());
    	if(listSCH3001U00GrdSCH3101Info != null && !listSCH3001U00GrdSCH3101Info.isEmpty()){
			for(SCH3001U00GrdSCH3101Info item : listSCH3001U00GrdSCH3101Info){
				SchsModelProto.SCH3001U00GrdSCH3101Info.Builder info = SchsModelProto.SCH3001U00GrdSCH3101Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				
				response.addGrdSch3101List(info);
			}
		}
    	return response.build();
	}
}
