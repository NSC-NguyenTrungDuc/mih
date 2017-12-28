package nta.med.service.ihis.handler.phys;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out0103Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.dao.medi.out.Out1002Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04BtnDeleteRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")   
@Transactional
public class PHY2001U04BtnDeleteHandler
	extends ScreenHandler<PhysServiceProto.PHY2001U04BtnDeleteRequest, SystemServiceProto.UpdateResponse> {                     
	@Resource                                                                                                       
	private Out0103Repository out0103Repository;   
	@Resource
	private Out1001Repository out1001Repository;
	@Resource
	private Out1002Repository out1002Repository;
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, PHY2001U04BtnDeleteRequest request)
			throws Exception {                                                                  
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();    
  	   	String hospCode = getHospitalCode(vertx, sessionId);
		Integer result = null;
		String msg = null;
		String oErr = out0103Repository.callPrOutInsertOut0103(hospCode, request.getIudGubun(), request.getUser(), request.getNaewonDate(),request.getBunho(), request.getGwa(), 
				request.getGubun(), request.getTuyakIlsu(), request.getDoctor(), request.getInOut(), request.getChartGwa(),request.getSpecialYn(), request.getToiwonDate());
		if(!"0".equalsIgnoreCase(oErr)){
			response.setMsg( "1");
			response.setResult(false);
			throw new ExecutionException(response.build());
		}
		Double pkout1001 = CommonUtils.parseDouble(request.getPkout1001());
		msg = "2";
		result = out1001Repository.deleteOut1001ById(hospCode, pkout1001);
		result = out1002Repository.deleteOut1002ById(hospCode, request.getPkout1001());		
		return response.build();
	}
}