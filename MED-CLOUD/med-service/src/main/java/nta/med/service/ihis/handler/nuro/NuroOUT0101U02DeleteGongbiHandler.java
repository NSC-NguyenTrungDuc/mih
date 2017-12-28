package nta.med.service.ihis.handler.nuro;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out0105Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class NuroOUT0101U02DeleteGongbiHandler extends ScreenHandler<NuroServiceProto.NuroOUT0101U02DeleteGongbiRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOG = LogFactory.getLog(NuroOUT0101U02DeleteGongbiHandler.class);
	@Resource
	private Out0105Repository out0105Repository;

    @Override
	public boolean isValid(NuroServiceProto.NuroOUT0101U02DeleteGongbiRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getStartDate()) && DateUtil.toDate(request.getStartDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
    
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroOUT0101U02DeleteGongbiRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		boolean result = deleteOut0105ByPatientCodeAndGongbiCode(request, getHospitalCode(vertx, sessionId));
        response.setResult(result);
		return response.build();
	}
	
	 private boolean deleteOut0105ByPatientCodeAndGongbiCode(NuroServiceProto.NuroOUT0101U02DeleteGongbiRequest request, String hospCode) {
 		Integer resultDelete = out0105Repository.deleteOut0105ByPatientCodeAndGongbiCode(hospCode, request.getStartDate(), request.getPatientCode(), request.getGongbiCode()) ;
         if (resultDelete > 0) {
         	LOG.info("DELETE Out0105 successfully for " + resultDelete + " records");
         	return true;
         }else{
         	return false;
         }
	 }
}
