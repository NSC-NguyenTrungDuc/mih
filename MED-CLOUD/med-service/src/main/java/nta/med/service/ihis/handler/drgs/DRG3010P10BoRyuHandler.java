package nta.med.service.ihis.handler.drgs;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm0003Repository;
import nta.med.data.dao.medi.drg.Drg3010Repository;
import nta.med.data.dao.medi.drg.Drg3060Repository;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.DrgsServiceProto.DRG3010P10BoRyuRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class DRG3010P10BoRyuHandler
		extends ScreenHandler<DrgsServiceProto.DRG3010P10BoRyuRequest, SystemServiceProto.UpdateResponse> {

	private static final Log LOGGER = LogFactory.getLog(DRG3010P10BoRyuHandler.class);
	
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Resource
	private Adm0003Repository adm0003Repository;
	
	@Resource
	private Drg3010Repository drg3010Repository;
	
	@Resource
	private Drg3060Repository drg3060Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRG3010P10BoRyuRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		
		List<DrgsModelProto.DRG3010P10BoRyuInfo> infos = request.getInfoLstList();
		if(CollectionUtils.isEmpty(infos)){
			response.setResult(true);
			return response.build();
		}
		
		for (DrgsModelProto.DRG3010P10BoRyuInfo info : infos) {
			String strCheck = inp1001Repository.getToiwonGojiYnFromOcs2003Inp1001(hospCode, CommonUtils.parseDouble(info.getFkocs2003()));
			if("Y".equals(strCheck)){
				LOGGER.info(String.format("Check TOIWON_GOJI_YN: not pass hosp_code = %s, pkocs2003 = %s", hospCode, info.getFkocs2003()));
				String msg = adm0003Repository.getFormEnvironInfoMessage(language, 909.0);
				
				response.setResult(false);
				response.setMsg(msg == null ? "" : msg);
				throw new ExecutionException(response.build());
			}
			
			drg3010Repository.updateReUseYnByHospCodeFkOcs2003(hospCode, CommonUtils.parseDouble(info.getFkocs2003()), info.getReUseYn());
			
			// Execute PR_DRG_MAKE_DRG3060
			drg3060Repository.callPrDrgMakeDrg3060(hospCode, getUserId(vertx, sessionId), CommonUtils.parseDouble(info.getFkocs2003()), info.getReUseYn());
		}
		
		response.setResult(true);
		return response.build();
	}

}
