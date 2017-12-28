package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCSACTGrdOrderGridColumnProtectModifyHandler extends ScreenHandler<OcsoServiceProto.OCSACTGrdOrderGridColumnProtectModifyRequest, OcsoServiceProto.OCSACTSingleStringResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCSACTGrdOrderGridColumnProtectModifyHandler.class);                                    
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository; 
	@Resource
	private Ocs2003Repository ocs2003Repository;
	
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCSACTSingleStringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCSACTGrdOrderGridColumnProtectModifyRequest request) throws Exception {
		OcsoServiceProto.OCSACTSingleStringResponse.Builder response = OcsoServiceProto.OCSACTSingleStringResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		List<String> listResult = null;
		Double pkOcs = CommonUtils.parseDouble(request.getPkocs());
		if("O".equalsIgnoreCase(request.getInOutGubun())){
			listResult = ocs1003Repository.getIfDataSendYnOCS1003(hospCode, pkOcs);
		}else{
			listResult = ocs2003Repository.getIfDataSendYnOCS2003(hospCode, pkOcs);
		}
		if(!CollectionUtils.isEmpty(listResult)){
			String ifDataSend = listResult.get(0);
			if(!StringUtils.isEmpty(ifDataSend)){
				response.setResponseStr(ifDataSend);
			}
		}
		return response.build();
	}                                                                                                                 
}