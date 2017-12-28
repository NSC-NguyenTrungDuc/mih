package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0110Repository;
import nta.med.data.model.ihis.bass.BAS0111U00GrdMasterItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0111U00GrdMasterRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0111U00GrdMasterResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0111U00GrdMasterHandler extends ScreenHandler<BassServiceProto.BAS0111U00GrdMasterRequest, BassServiceProto.BAS0111U00GrdMasterResponse> {                    
	private static final Log LOGGER = LogFactory.getLog(BAS0111U00GrdMasterHandler.class);                                    
	@Resource                                                                                                       
	private Bas0110Repository bas0110Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public BAS0111U00GrdMasterResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0111U00GrdMasterRequest request)
			throws Exception {
		BassServiceProto.BAS0111U00GrdMasterResponse.Builder response = BassServiceProto.BAS0111U00GrdMasterResponse.newBuilder();
		List<BAS0111U00GrdMasterItemInfo> listResult = bas0110Repository.getBAS0111U00GrdMasterItemInfo(request.getFJohapGubun(), request.getFJohap(), 
				request.getFNaewonDate(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listResult)){
			for(BAS0111U00GrdMasterItemInfo info : listResult){
				BassModelProto.BAS0111U00GrdMasterItemInfo.Builder builder = BassModelProto.BAS0111U00GrdMasterItemInfo.newBuilder();
				BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
				response.addDt(builder);
			}
		}
		return response.build();
	}                                                                                                                 
}