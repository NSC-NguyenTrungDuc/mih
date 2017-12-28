package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.sch.Sch3000Repository;
import nta.med.data.model.ihis.schs.SCH3001U00GrdSCH3000Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00GrdSCH3000Request;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00GrdSCH3000Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SCH3001U00GrdSCH3000Handler
	extends ScreenHandler<SchsServiceProto.SCH3001U00GrdSCH3000Request, SchsServiceProto.SCH3001U00GrdSCH3000Response>{
	
	@Resource
	private Sch3000Repository sch3000Repository; 
	
	@Override
	@Transactional(readOnly=true)
	public SCH3001U00GrdSCH3000Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			SCH3001U00GrdSCH3000Request request) throws Exception {
        SchsServiceProto.SCH3001U00GrdSCH3000Response.Builder response = SchsServiceProto.SCH3001U00GrdSCH3000Response.newBuilder();
    	List<SCH3001U00GrdSCH3000Info> listSCH3001U00GrdSCH3000Info = sch3000Repository.getSCH3001U00GrdSCH3000Info(getHospitalCode(vertx, sessionId), request.getJundalTable(), request.getJundalPart(),
    			request.getGumsaja(), request.getJukyongDate(), request.getYoilGubun());
    	if(listSCH3001U00GrdSCH3000Info != null && !listSCH3001U00GrdSCH3000Info.isEmpty()){
			for(SCH3001U00GrdSCH3000Info item : listSCH3001U00GrdSCH3000Info){
				SchsModelProto.SCH3001U00GrdSCH3000Info.Builder info = SchsModelProto.SCH3001U00GrdSCH3000Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				if(item != null && item.getOutHospSlot() != null)
				{
					Integer hospSlot = item.getOutHospSlot().intValue();
					if(hospSlot != null)
					{
						info.setOutHospSlot(hospSlot.toString());
					}

				}
				response.addGrdSch3000List(info);
			}
		}
    	return response.build();
	}
}
