package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.inp.Inp1001;
import nta.med.core.domain.out.Out0101;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.GetPatientInfoRequest;
import nta.med.service.ihis.proto.SystemServiceProto.GetPatientInfoResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class GetPatientInfoHandler 
	extends ScreenHandler<SystemServiceProto.GetPatientInfoRequest, SystemServiceProto.GetPatientInfoResponse>{                     
	@Resource                                                                                                       
	private Out0101Repository out0101Repository;                                                                    
	@Resource                                                                                                       
	private Inp1001Repository inp1001Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	@Route(global = false)
	public GetPatientInfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, GetPatientInfoRequest request)
			throws Exception {                                                                
  	   	SystemServiceProto.GetPatientInfoResponse.Builder response = SystemServiceProto.GetPatientInfoResponse.newBuilder();
  	   	String hospCode = getHospitalCode(vertx, sessionId);
		List<Out0101> listOut0101 = out0101Repository.getByBunho(hospCode, request.getBunho());
		if (!CollectionUtils.isEmpty(listOut0101)) {
			for (Out0101 out0101 : listOut0101) {
				if(!StringUtils.isEmpty(out0101.getDeleteYn())) {
					response.setDeleteYn(out0101.getDeleteYn());
				}
				if(!StringUtils.isEmpty(out0101.getJubsuBreak())) {
					response.setJubsubreak(out0101.getJubsuBreak());
				}
				if(!StringUtils.isEmpty(out0101.getJubsuBreakReason())) {
					response.setJubsubreakreason(out0101.getJubsuBreakReason());
				}
				break;
			}
		}
		List<Inp1001> listInp1001 = inp1001Repository.getPatientInfo(hospCode, request.getBunho());
		String jaewonpatientYn = "N";
		if (!CollectionUtils.isEmpty(listInp1001)) {
			for (Inp1001 inp1001 : listInp1001) {
				if(inp1001.getPkinp1001() != null) {
					response.setMPkinp1001(inp1001.getPkinp1001()+"");
				}
				jaewonpatientYn = "Y";
				break;
			}
		}
		response.setJaewonpatientYn(jaewonpatientYn);
		return response.build(); 
	}
}