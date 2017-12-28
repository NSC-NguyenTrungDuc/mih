package nta.med.service.ihis.handler.nuri;

import javax.annotation.Resource;

import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.dao.medi.nur.Nur1010Repository;
import nta.med.data.dao.medi.nur.Nur1011Repository;
import nta.med.data.dao.medi.nur.Nur1012Repository;
import nta.med.data.dao.medi.nur.Nur7001Repository;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class NUR6011U01GetNurseInfoHandler extends ScreenHandler<NuriServiceProto.NUR6011U01GetNurseInfoRequest, NuriServiceProto.NUR6011U01GetNurseInfoResponse> {   
	
	@Resource                                   
	private Nur1012Repository nur1012Repository;
	
	@Resource                                   
	private Nur1010Repository nur1010Repository;
	
	@Resource                                   
	private Nur1011Repository nur1011Repository;
	
	@Resource                                   
	private Nur7001Repository nur7001Repository;
	
	@Resource                                   
	private Inp1001Repository inp1001Repository;

	@Override
	@Transactional(readOnly = true)
	public NuriServiceProto.NUR6011U01GetNurseInfoResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR6011U01GetNurseInfoRequest request) throws Exception {
				
		NuriServiceProto.NUR6011U01GetNurseInfoResponse.Builder response = NuriServiceProto.NUR6011U01GetNurseInfoResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		Double fkinp1001 = CommonUtils.parseDouble(request.getFkinp1001());
		String bunho = request.getBunho();
		String jukyongDate = request.getJukyongDate();
		
		response.setLifeSelfGrade(nur1012Repository.getNUR6011U01GetNurseInfoLifeSelfGrade(hospCode, fkinp1001, jukyongDate));
		response.setUserNm(nur1010Repository.getNUR6011U01GetNurseInfoUser(hospCode, fkinp1001, jukyongDate));
		response.setGanhodo(nur1011Repository.getNUR6011U01GetNurseInfoGanhodo(hospCode, fkinp1001, jukyongDate));
		response.setWeight(nur7001Repository.getNUR6011U01GetNurseInfoWeight(hospCode, bunho, jukyongDate));
		response.setIpwonDate(inp1001Repository.getNUR6011U01GetNurseInfoIpwonDate(hospCode, fkinp1001));
		
		return response.build();
	}
}
