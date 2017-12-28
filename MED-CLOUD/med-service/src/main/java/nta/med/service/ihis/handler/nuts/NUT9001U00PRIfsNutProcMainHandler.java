package nta.med.service.ihis.handler.nuts;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.nut.Nut2010Repository;
import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.service.ihis.proto.NutsModelProto;
import nta.med.service.ihis.proto.NutsServiceProto;
import nta.med.service.ihis.proto.NutsServiceProto.NUT9001U00PRIfsNutProcMainRequest;
import nta.med.service.ihis.proto.NutsServiceProto.NUT9001U00PRIfsNutProcMainResponse;

@Service
@Scope("prototype")
public class NUT9001U00PRIfsNutProcMainHandler extends
		ScreenHandler<NutsServiceProto.NUT9001U00PRIfsNutProcMainRequest, NutsServiceProto.NUT9001U00PRIfsNutProcMainResponse> {

	private static final Log LOGGER = LogFactory.getLog(NUT9001U00PRNutMagamHandler.class);
	
	@Resource
	private Nut2010Repository nut2010Repository;
	
	@Override
	public NUT9001U00PRIfsNutProcMainResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUT9001U00PRIfsNutProcMainRequest request) throws Exception {
		NutsServiceProto.NUT9001U00PRIfsNutProcMainResponse.Builder response = NutsServiceProto.NUT9001U00PRIfsNutProcMainResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		
		/*
		 * Call PR_IFS_NUT_PROC_MAIN IUD: IFS7501 UPADTE NUT2011 A SET
		 * A.IF_SEND_FLAG = 'Y' WHERE A.HOSP_CODE = I_HOSP_CODE AND A.PKNUT2011 = I_MASTER_FK
		 */

		CommonProcResultInfo pInfo = nut2010Repository.callPrIfsNutProcMain(hospCode
				, CommonUtils.parseDouble(request.getMasterFk())
				, request.getSendYn());
		
		if(pInfo == null){
			LOGGER.info(String.format("EXECUTE PROCEDURE PR_IFS_NUT_PROC_MAIN FAIL, RESULT = NULL, HOSP_CODE = %s", hospCode));
			return response.build();
		}
		
		NutsModelProto.NUT9001U00PRIfsNutProcMainInfo.Builder info = NutsModelProto.NUT9001U00PRIfsNutProcMainInfo
				.newBuilder().setCnt(pInfo.getStrResult1())
				.setFlag(pInfo.getStrResult2())
				.setMsg(pInfo.getStrResult3());
		
		response.setProcItem(info);
		return response.build();
	}
	
}
