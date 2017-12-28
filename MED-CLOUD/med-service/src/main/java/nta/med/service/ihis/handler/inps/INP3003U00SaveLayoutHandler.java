package nta.med.service.ihis.handler.inps;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.model.ihis.inps.CommonProcResultInfo;
import nta.med.service.ihis.proto.InpsModelProto;
import nta.med.service.ihis.proto.InpsModelProto.INP3003U00grdINP1001Info;
import nta.med.service.ihis.proto.InpsServiceProto;
import nta.med.service.ihis.proto.InpsServiceProto.INP3003U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class INP3003U00SaveLayoutHandler
		extends ScreenHandler<InpsServiceProto.INP3003U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(INP3003U00SaveLayoutHandler.class);

	@Resource
	private Inp1001Repository inp1001Repository;

	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INP3003U00SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		
		List<InpsModelProto.INP3003U00grdINP1001Info> lstInfo = request.getGrdSaveList();
		if(CollectionUtils.isEmpty(lstInfo)){
			response.setResult(false);
			return response.build();
		}
		
		for (INP3003U00grdINP1001Info info : lstInfo) {
			CommonProcResultInfo prInfo = inp1001Repository.callPrInpProcessToiwon(hospCode, userId, CommonUtils.parseDouble(info.getPkinp1001()),
					info.getSimsaMagamDate(), info.getSimsaMagamTime(), info.getSimsaMagamYn(), info.getToiwonDate(),info.getToiwonTime(), info.getGaToiwonDate());
			if(prInfo == null){
				LOGGER.info("CALL PROC PR_INP_PROCESS_TOIWON: RESULT IS NULL");
				throw new ExecutionException(response.setResult(false).build());
			}
			
			if(prInfo.getStrResult1() == null){
				LOGGER.info("CALL PROC PR_INP_PROCESS_TOIWON: ERR IS NULL");
				throw new ExecutionException(response.setResult(false).build());
			}
			
			if(!prInfo.getStrResult1().equals("0")){
				LOGGER.info("CALL PROC PR_INP_PROCESS_TOIWON FAIL !!!");
				throw new ExecutionException(response.setResult(false).build());
			}
			
			List<Double> lstPkinp1001 = inp1001Repository.getListPkinp1001(hospCode, CommonUtils.parseDouble(info.getPkinp1001()));
			if(!CollectionUtils.isEmpty(lstPkinp1001)){
				for (Double pkInp1001 : lstPkinp1001) {
					CommonProcResultInfo prInfoSub = inp1001Repository.callPrInpProcessToiwon(hospCode, userId, pkInp1001,
							info.getSimsaMagamDate(), info.getSimsaMagamTime(), info.getSimsaMagamYn(), info.getToiwonDate(),info.getToiwonTime(), info.getGaToiwonDate());
					if(prInfoSub == null){
						LOGGER.info("CALL PROC PR_INP_PROCESS_TOIWON(SUB): RESULT IS NULL");
						throw new ExecutionException(response.setResult(false).build());
					}
					
					if(prInfoSub.getStrResult1() == null){
						LOGGER.info("CALL PROC PR_INP_PROCESS_TOIWON(SUB): ERR IS NULL");
						throw new ExecutionException(response.setResult(false).build());
					}
					
					if(!prInfoSub.getStrResult1().equals("0")){
						LOGGER.info("CALL PROC PR_INP_PROCESS_TOIWON(SUB) FAIL !!!");
						throw new ExecutionException(response.setResult(false).build());
					}
				}
			}
			
			if(!StringUtils.isEmpty(info.getResultAfterDis())){
				boolean updResult = updateINPINP3003U00U00Execute(hospCode, getUserId(vertx, sessionId), info);
				if(!updResult){
					LOGGER.info("UPDATE Inp1001 FAIL");
					throw new ExecutionException(response.setResult(false).build());
				}
			}
		}
		
		response.setResult(true);
		return response.build();
	}

	private boolean updateINPINP3003U00U00Execute(String hospCode, String userId, INP3003U00grdINP1001Info info) {
		return inp1001Repository.updateINPINP3003U00U00Execute(
				hospCode,
				userId,
				CommonUtils.parseDouble(info.getPkinp1001()),
				info.getResultAfterDis(),
				info.getResultAfterDisRemark()) > 0;
	}
}