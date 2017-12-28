package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.sch.Sch3000Repository;
import nta.med.data.model.ihis.schs.SCH3001U00GrdJukyongDateInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00GrdJukyongDateRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SCH3001U00GrdJukyongDateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SCH3001U00GrdJukyongDateHandler
	extends ScreenHandler<SchsServiceProto.SCH3001U00GrdJukyongDateRequest, SchsServiceProto.SCH3001U00GrdJukyongDateResponse>{
	
	@Resource
	private Sch3000Repository sch3000Repository;
	
	@Override
	@Transactional(readOnly=true)
	public SCH3001U00GrdJukyongDateResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			SCH3001U00GrdJukyongDateRequest request) throws Exception {
        SchsServiceProto.SCH3001U00GrdJukyongDateResponse.Builder response = SchsServiceProto.SCH3001U00GrdJukyongDateResponse.newBuilder();
    	List<SCH3001U00GrdJukyongDateInfo> listSCH3001U00GrdJukyongDateInfo = sch3000Repository.getSCH3001U00GrdJukyongDateInfo(getHospitalCode(vertx, sessionId) , request.getJundalTable(), request.getJundalPart(), request.getGumsaja());
    	if(listSCH3001U00GrdJukyongDateInfo != null && !listSCH3001U00GrdJukyongDateInfo.isEmpty()){
			for(SCH3001U00GrdJukyongDateInfo item : listSCH3001U00GrdJukyongDateInfo){
				SchsModelProto.SCH3001U00GrdJukyongDateInfo.Builder info = SchsModelProto.SCH3001U00GrdJukyongDateInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				
				response.addGrdJukyongDateList(info);
			}
    	}
    	return response.build();
	}
}
