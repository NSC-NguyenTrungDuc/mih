package nta.med.service.ihis.handler.cpls;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00QueryLaySpecimenReadUpdateRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CPL3010U00QueryLaySpecimenReadUpdateHandler extends ScreenHandler <CplsServiceProto.CPL3010U00QueryLaySpecimenReadUpdateRequest, SystemServiceProto.UpdateResponse> {
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	public boolean isValid(CPL3010U00QueryLaySpecimenReadUpdateRequest request,
			Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getGumJubsuDate()) && DateUtil.toDate(request.getGumJubsuDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL3010U00QueryLaySpecimenReadUpdateRequest request)
			throws Exception {
		String hospCode = getHospitalCode(vertx, sessionId);
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
    	boolean result = updateCpl2010(request, hospCode);
    	response.setResult(result);
    	return response.build();
	}


	public boolean updateCpl2010(CplsServiceProto.CPL3010U00QueryLaySpecimenReadUpdateRequest request, String hospCode){
		Date gumJubsuDate = DateUtil.toDate(request.getGumJubsuDate(), DateUtil.PATTERN_YYMMDD);
		if(cpl2010Repository.updateCPL3010U00QueryLaySpecimenReadUpdate(gumJubsuDate, request.getGumJubsuTime(), request.getPartJubsuja(), hospCode, 
				request.getSpecimenSer()) > 0){
			return true;
		}else{
			return false;
		}
	}
}
