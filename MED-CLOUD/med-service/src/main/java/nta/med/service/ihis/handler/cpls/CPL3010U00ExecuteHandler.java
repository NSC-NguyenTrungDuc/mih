package nta.med.service.ihis.handler.cpls;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.domain.cpl.Cpl1000;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.cpl.Cpl1000Repository;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00ExecuteRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3010U00ExecuteResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service
@Scope("prototype")
public class CPL3010U00ExecuteHandler extends ScreenHandler<CplsServiceProto.CPL3010U00ExecuteRequest, CplsServiceProto.CPL3010U00ExecuteResponse>{
	@Resource
	private Cpl1000Repository cpl1000Repository;
	
	@Resource
	private Cpl2010Repository cpl2010Repository;
	
	@Override
	public CPL3010U00ExecuteResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, CPL3010U00ExecuteRequest request)
			throws Exception  {
        CplsServiceProto.CPL3010U00ExecuteResponse.Builder response = CplsServiceProto.CPL3010U00ExecuteResponse.newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId);
    	switch(request.getCallerId()) {
    	case "1":
    		response = processCase1(request, hospCode);
			break;
		case "2":
			response = processCase2(request, hospCode);
	    	break;
		case "3":
			boolean result = processCase3(request, hospCode);
			response.setCase3Result(result);
	    	break;
		default :
			result = false;
			break;
    	}
    	return response.build();
	}
	
	private CplsServiceProto.CPL3010U00ExecuteResponse.Builder processCase1(CplsServiceProto.CPL3010U00ExecuteRequest request, String hospCode){
		CplsServiceProto.CPL3010U00ExecuteResponse.Builder response = CplsServiceProto.CPL3010U00ExecuteResponse.newBuilder();
		String retVal = cpl2010Repository.checkSpecimenSerCPL3010U00Execute(hospCode, request.getSpecimenSer());
		if(!StringUtils.isEmpty(retVal)){
			response.setCase1Decode(retVal);
		}
		if(cpl2010Repository.updateCPL3010U00Execute(hospCode, request.getSpecimenSer()) > 0){
			response.setCase1UpdateResult(true);
		}else{
			response.setCase1UpdateResult(false);
		}
		Double fkcpl2010 = CommonUtils.parseDouble(request.getFkcpl2010());
		String resultCallPr = cpl2010Repository.callPrCplPartJubsuCancel(request.getUserIdStore(), request.getSpecimenSer(), fkcpl2010, request.getGubun(), hospCode,"");
		if(StringUtils.isEmpty(resultCallPr) || "".equals(resultCallPr)){
			response.setPrCplPartJubsuCancelResult(false);
		}else{
			response.setPrCplPartJubsuCancelOutput(resultCallPr);
			response.setPrCplPartJubsuCancelResult(true);
		}
		return response;
	}
	
	private CplsServiceProto.CPL3010U00ExecuteResponse.Builder processCase2(CplsServiceProto.CPL3010U00ExecuteRequest request, String hospCode){
		CplsServiceProto.CPL3010U00ExecuteResponse.Builder response = CplsServiceProto.CPL3010U00ExecuteResponse.newBuilder();
		Double fkcpl2010 = CommonUtils.parseDouble(request.getFkcpl2010());
		String resultCallPr = cpl2010Repository.callPrCplPartJubsuCancel(request.getUserIdStore(), request.getSpecimenSer(), fkcpl2010, request.getGubun(), hospCode,"");
		if(StringUtils.isEmpty(resultCallPr) || "".equals(resultCallPr)){
			response.setPrCplPartJubsuCancelResult(false);
		}else{
			response.setPrCplPartJubsuCancelResult(true);
		}
		
		return response;
	}
	
	private boolean processCase3(CplsServiceProto.CPL3010U00ExecuteRequest request, String hospCode){
		if(cpl1000Repository.updateCPL3010U00Execute(request.getUserIdCase3(), new Date(), request.getUrineRyang(), 
				request.getStabilityYn(), hospCode, request.getSpecimenSer()) > 0){
			return true;
		}else{
			Cpl1000 cpl1000 = new Cpl1000();
			cpl1000.setSysDate(new Date());
			cpl1000.setSysId(request.getUserIdCase3());
			cpl1000.setUpdDate(new Date());
			cpl1000.setUpdId(request.getUserIdCase3());
			cpl1000.setHospCode(hospCode);
			Double pkcpl1000 = CommonUtils.parseDouble(request.getPkcpl1000());
			cpl1000.setPkcpl1000(pkcpl1000);
			if (StringUtils.isEmpty(request.getUrineRyang())){
				cpl1000.setUrineRyang("0");
			}else{
				cpl1000.setUrineRyang(request.getUrineRyang());
			}
			cpl1000.setStabilityYn(request.getStabilityYn());
			cpl1000.setSpecimenSer(request.getSpecimenSer());
			cpl1000Repository.save(cpl1000);
			
			return true;
		}
	}
}
