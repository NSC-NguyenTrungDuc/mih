package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl0111Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00VsvNoteRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U00VsvNoteResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL3020U00VsvNoteHandler extends ScreenHandler <CplsServiceProto.CPL3020U00VsvNoteRequest, CplsServiceProto.CPL3020U00VsvNoteResponse> {
	@Resource
	private Cpl0111Repository cpl0111Repository;
	
	@Override
	@Transactional(readOnly = true)
	public CPL3020U00VsvNoteResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL3020U00VsvNoteRequest request)
			throws Exception{
        CplsServiceProto.CPL3020U00VsvNoteResponse.Builder response = CplsServiceProto.CPL3020U00VsvNoteResponse.newBuilder();
    	String vsvNote = cpl0111Repository.getCPL3020U02InitializeVsvNote(getHospitalCode(vertx, sessionId), request.getJundalGubun(), request.getCode());
    	if (!StringUtils.isEmpty(vsvNote)) {
        	response.setNote(vsvNote);
		}
    	return response.build();
	}
}
