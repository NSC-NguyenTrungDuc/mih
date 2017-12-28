package nta.med.service.ihis.handler.schs;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.sch.Sch0108;
import nta.med.data.dao.medi.sch.Sch0108Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0109U00GrdMasterRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0109U00GrdMasterResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class SCH0109U00GrdMasterHandler
	extends ScreenHandler<SchsServiceProto.SCH0109U00GrdMasterRequest, SchsServiceProto.SCH0109U00GrdMasterResponse>{
	
	@Resource
	private Sch0108Repository sch0108Repository;
	
	@Override
	@Transactional(readOnly=true)
	public SCH0109U00GrdMasterResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, SCH0109U00GrdMasterRequest request)
			throws Exception {
        SchsServiceProto.SCH0109U00GrdMasterResponse.Builder response = SchsServiceProto.SCH0109U00GrdMasterResponse.newBuilder();
    	List<Sch0108> listSch0108 = sch0108Repository.getSCH0109U00GrdMasterInfo(getHospitalCode(vertx, sessionId),"%"+request.getCodeType()+"%", "%"+request.getCodeTypeName()+"%", getLanguage(vertx, sessionId));
    	if(listSch0108 != null && !listSch0108.isEmpty()){
			for(Sch0108 item : listSch0108){
				SchsModelProto.SCH0109U00GrdMasterInfo.Builder info = SchsModelProto.SCH0109U00GrdMasterInfo.newBuilder();
				if (!StringUtils.isEmpty(item.getCodeType())) {
        			info.setCodeType(item.getCodeType());
        		}
				if (!StringUtils.isEmpty(item.getCodeTypeName())) {
        			info.setCodeTypeName(item.getCodeTypeName());
        		}
				response.addGrdMasterList(info);
			}
		}
    	return response.build();
	}
}
