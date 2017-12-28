package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.cpl.Cpltemp;
import nta.med.data.dao.medi.cpl.CpltempRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0000Q00InsertCPLTEMPRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class CPL0000Q00InsertCPLTEMPHandler extends ScreenHandler<CplsServiceProto.CPL0000Q00InsertCPLTEMPRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOG = LogFactory.getLog(CPL0000Q00InsertCPLTEMPHandler.class);
	
	@Resource
	private CpltempRepository cpltempRepository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL0000Q00InsertCPLTEMPRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        String hospitalCode = getHospitalCode(vertx, sessionId);
    	boolean result = insertOcs5010(request, hospitalCode);
    	response.setResult(result);
        return response.build();
	}
	
	private boolean insertOcs5010(CplsServiceProto.CPL0000Q00InsertCPLTEMPRequest request, String hospitalCode) {
		try{
			Cpltemp cpltemp = new Cpltemp();
			cpltemp.setIpAddress(request.getUserId());
			cpltemp.setJundalGubun("XX");
			cpltemp.setSeqCode(request.getI());
			cpltemp.setHangmogCode(request.getHangmogCode());
			cpltemp.setHospCode(hospitalCode);
			
			cpltempRepository.save(cpltemp);
			return true;
		}catch (Exception e) {
        	LOG.error(e.getMessage(),e);
        	return false;
        }
	}
}
