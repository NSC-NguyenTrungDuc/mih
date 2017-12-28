package nta.med.service.ihis.handler.nuts;

import java.sql.SQLException;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nut.Nut2010Repository;
import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.service.ihis.proto.NutsModelProto;
import nta.med.service.ihis.proto.NutsServiceProto;
import nta.med.service.ihis.proto.NutsServiceProto.NUT9001U00PRNutMagamRequest;
import nta.med.service.ihis.proto.NutsServiceProto.NUT9001U00PRNutMagamResponse;

@Service
@Scope("prototype")
public class NUT9001U00PRNutMagamHandler extends
		ScreenHandler<NutsServiceProto.NUT9001U00PRNutMagamRequest, NutsServiceProto.NUT9001U00PRNutMagamResponse> {
	
	private static final Log LOGGER = LogFactory.getLog(NUT9001U00PRNutMagamHandler.class);
	
	@Resource
	private Nut2010Repository nut2010Repository;
	
	@Override
	@Transactional
	public NUT9001U00PRNutMagamResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUT9001U00PRNutMagamRequest request) throws Exception {
		
		NutsServiceProto.NUT9001U00PRNutMagamResponse.Builder response = NutsServiceProto.NUT9001U00PRNutMagamResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		response.setResult(true);
		
		try {
			CommonProcResultInfo pInfo = nut2010Repository.callPrNutMagam(hospCode
					, request.getUpdId()
					, DateUtil.toDate(request.getMagamDate(), DateUtil.PATTERN_YYMMDD)
					, request.getBldGubun()
					, request.getNutMagamGubun());
			
			if(pInfo == null){
				LOGGER.info(String.format("EXECUTE PROCEDURE PR_NUT_MAGAM FAIL, RESULT = NULL, HOSP_CODE = %s", hospCode));
				return response.build();
			}
			
			LOGGER.info(String.format("EXECUTE PROCEDURE PR_NUT_MAGAM FAIL, O_FLAG = %s, HOSP_CODE = %s", (pInfo.getStrResult3() == null ? "NULL" : pInfo.getStrResult3()), hospCode));
			NutsModelProto.NUT9001U00PRNutMagamInfo.Builder info = NutsModelProto.NUT9001U00PRNutMagamInfo.newBuilder()
					.setFknut2011(pInfo.getStrResult1() == null ? "" : pInfo.getStrResult1())
					.setMagamSeq(pInfo.getStrResult2() == null ? "" : pInfo.getStrResult2())
					.setFlag(pInfo.getStrResult3() == null ? "" : pInfo.getStrResult3());
			
			response.setProcItem(info);
		} catch (Exception e) {
			LOGGER.info(String.format("EXECUTE PROCEDURE PR_NUT_MAGAM FAIL: hosp_code = %s", hospCode), e);
			response.setResult(false);
			
			if(e.getCause().getCause() instanceof SQLException){
				SQLException sqle = ((SQLException)e.getCause().getCause());
				response.setMsg(sqle.getMessage() != null ? sqle.getMessage() : "");
			}
			
			throw new ExecutionException(response.build());
		}
		
		return response.build();
	}

}
