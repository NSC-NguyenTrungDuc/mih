package nta.med.service.ihis.handler.nuri;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.dao.medi.ocs.Ocs2017Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR2017U01SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR2017U01SaveLayoutHandler
		extends ScreenHandler<NuriServiceProto.NUR2017U01SaveLayoutRequest, SystemServiceProto.UpdateResponse> {

	private static final Log LOGGER = LogFactory.getLog(NUR2017U01SaveLayoutHandler.class);
	
	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Resource
	private Ocs2017Repository ocs2017Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR2017U01SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		String callerId = request.getCallerId();
		List<NuriModelProto.NUR2017U01grdNUR2017Info> infos = request.getGrdNUR2017InfoList();
		for (NuriModelProto.NUR2017U01grdNUR2017Info info : infos) {
			if("1".equals(callerId)){
				ocs2003Repository.updateOcs2003InNUR2017U01(userId, info.getActUserName(), info.getActResDate(),
						info.getActingTime(), hospCode, CommonUtils.parseDouble(info.getFkocs2003()));
				
				ocs2017Repository.updateOcs2017InNUR2017U01(hospCode, userId, info.getActingYn(), info.getActingDate(),
						info.getActingTime(), info.getActingUser(), info.getPassYn(),
						CommonUtils.parseDouble(info.getFkocs2003()), info.getActResDate(), info.getHangmogCode(), CommonUtils.parseDouble(info.getSeq()));
			}
			else if("2".equals(callerId)){
				String workGubun = "Y".equals(info.getBannabYn()) ? "2" : "3";
				String err = ocs2017Repository.callPrOcsiProcessBannab(hospCode, workGubun,
						CommonUtils.parseDouble(info.getFkocs2003()), CommonUtils.parseDouble(info.getSeq()), userId);
				if(err == null || !"0".equals(err)){
					LOGGER.info(String.format("Execute procedure PR_OCSI_PROCESS_BANNAB fail: hosp_code = %s, err = %s", hospCode, (err == null ? "null" : err)));
					response.setResult(false);
					response.setMsg(err == null ? "" : err);
					throw new ExecutionException(response.build());
				}
			}
		}
		
		response.setResult(true);
		return response.build();
	}	
}
