package nta.med.service.ihis.handler.cpls;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.domain.cpl.Cpl2090;
import nta.med.data.dao.medi.cpl.Cpl2090Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02ExecuteCase2Request;
import nta.med.service.ihis.proto.CplsServiceProto.CPL3020U02ExecuteCase2Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
@Transactional
public class CPL3020U02ExecuteCase2Handler extends ScreenHandler<CplsServiceProto.CPL3020U02ExecuteCase2Request, CplsServiceProto.CPL3020U02ExecuteCase2Response> {
	@Resource
	private Cpl2090Repository cpl2090Repository;
	
	@Override
	public CPL3020U02ExecuteCase2Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CPL3020U02ExecuteCase2Request request) throws Exception {
        CplsServiceProto.CPL3020U02ExecuteCase2Response.Builder response = CplsServiceProto.CPL3020U02ExecuteCase2Response.newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId);
    	String retVal = cpl2090Repository.checkExitCPL3020U02ExecuteCase2(hospCode, request.getJundalGubun(), request.getSpecimenSer());
    	if(!StringUtils.isEmpty(retVal) && "Y".equals(retVal)){
    		if(cpl2090Repository.updateCPL3020U02ExecuteCase2(request.getUserId(), new Date(), request.getCode(), request.getNote(),
    				request.getEtcComment(), hospCode, request.getJundalGubun(), request.getSpecimenSer())>0){
    			response.setUpdateCPL2090Result(true);
    		}else{
    			response.setUpdateCPL2090Result(false);
    		}
    	}else {
    		Cpl2090 cpl2090 = new Cpl2090();
    		Date sysdate = new Date();
    		cpl2090.setSysDate(sysdate);
    		cpl2090.setSysId(request.getUserId());
    		cpl2090.setUpdDate(sysdate);
    		cpl2090.setUpdId(request.getUserId());
    		cpl2090.setHospCode(hospCode);
    		cpl2090.setJundalPart(request.getJundalGubun());
    		cpl2090.setSpecimenSer(request.getSpecimenSer());
    		cpl2090.setCode(request.getCode());
    		cpl2090.setNote(request.getNote());
    		cpl2090.setEtcComment(request.getEtcComment());
    		cpl2090Repository.save(cpl2090);
    		response.setInsertCPL2090Result(true);
    	}
    	return response.build();
	}
}
