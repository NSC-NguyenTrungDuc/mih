package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
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
public class OCSACTBtnEMRClickHandler extends ScreenHandler<OcsoServiceProto.OCSACTBtnEMRClickRequest, OcsoServiceProto.OCSACTSingleStringResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCSACTBtnEMRClickHandler.class);                                    
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OCSACTSingleStringResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCSACTBtnEMRClickRequest request) throws Exception {
		OcsoServiceProto.OCSACTSingleStringResponse.Builder response = OcsoServiceProto.OCSACTSingleStringResponse.newBuilder(); 
		Double pkout1001 = CommonUtils.parseDouble(request.getNaewonKey());
		List<String> listResult = out1001Repository.getnaewonDateByPkout1001(getHospitalCode(vertx, sessionId), pkout1001);
		if(!CollectionUtils.isEmpty(listResult)){
			String naewonDate = listResult.get(0);
			if(!StringUtils.isEmpty(naewonDate))
				response.setResponseStr(naewonDate);
		}
		return response.build();
	}                                                                                                                 
}