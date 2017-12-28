package nta.med.service.ihis.handler.cpls;

import javax.annotation.Resource;

import nta.med.data.dao.medi.cpl.Cpl0001Repository;
import nta.med.data.dao.medi.cpl.Cpl0101Repository;
import nta.med.data.dao.medi.cpl.Cpl0109Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0101U00MakeValSerViceRequest;
import nta.med.service.ihis.proto.CplsServiceProto.CPL0101U00MakeValSerViceResponse;

import org.apache.commons.lang.ArrayUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class CPL0101U00MakeValSerViceHandler extends ScreenHandler<CplsServiceProto.CPL0101U00MakeValSerViceRequest, CplsServiceProto.CPL0101U00MakeValSerViceResponse> {
	private static final Log LOGGER = LogFactory.getLog(CPL0101U00MakeValSerViceHandler.class);
	@Resource
	private Cpl0109Repository cpl0109Repository;
	@Resource
	private Cpl0101Repository cpl0101Repository;
	@Resource
	private Cpl0001Repository cpl0001Repository;
	@Override
	@Transactional(readOnly = true)
	public CPL0101U00MakeValSerViceResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			CPL0101U00MakeValSerViceRequest request) throws Exception {
		String language = getLanguage(vertx, sessionId);
		String hospCode = getHospitalCode(vertx, sessionId);
		CplsServiceProto.CPL0101U00MakeValSerViceResponse.Builder response = CplsServiceProto.CPL0101U00MakeValSerViceResponse.newBuilder();
		String[] actName = {"fbxSpecimenCode","fbxDanui","fbxTubeCode","fbxUitakCode","fbxSutakCode","fbxJangbiCode","fbxJangbiCode2","fbxJangbiCode3"}; 
		String result = null;
		if(request.getACtlName().equals("fbxHangmogCode")){
			 result = cpl0101Repository.getCPL0101U00FbxHangmogCodeName(hospCode, request.getCode());
		} else if(request.getACtlName().equals("fbxJundalGubun")){
			 result = cpl0109Repository.getCPL0101U00FbxJundalGubunName(hospCode, request.getCodeType(), "CPL", request.getCode(), language);
		}else if(request.getACtlName().equals("fbxSlipCode")){
			 result = cpl0001Repository.getCPL0101U00FbxSlipCodeName(hospCode, request.getCode());
		}else if(ArrayUtils.contains(actName,request.getACtlName())){
			result = cpl0109Repository.getCPL0101U00getACtlName(hospCode, request.getCodeType(),request.getCode(),language);
		} 
		if(result != null && !result.isEmpty()){
			response.setName(result);
		}
		return response.build();
	}
}
