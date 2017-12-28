package nta.med.service.ihis.handler.endo;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs1801Repository;
import nta.med.data.model.ihis.xrts.XRT1002U00GrdPaStatusInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.EndoModelProto;
import nta.med.service.ihis.proto.EndoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class END1001U02GrdPaStatusHandler extends ScreenHandler<EndoServiceProto.END1001U02GrdPaStatusRequest, EndoServiceProto.END1001U02GrdPaStatusResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(END1001U02GrdPaStatusHandler.class);                                    
	@Resource                                                                                                       
	private Ocs1801Repository ocs1801Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public EndoServiceProto.END1001U02GrdPaStatusResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			EndoServiceProto.END1001U02GrdPaStatusRequest request) throws Exception {
		EndoServiceProto.END1001U02GrdPaStatusResponse.Builder response = EndoServiceProto.END1001U02GrdPaStatusResponse.newBuilder();
		List<XRT1002U00GrdPaStatusInfo> listResult = ocs1801Repository.getXRT1002U00GrdPaStatusInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getBunho(), request.getHangmogCode());
		if(!CollectionUtils.isEmpty(listResult)){
			for(XRT1002U00GrdPaStatusInfo item : listResult){
				EndoModelProto.END1001U02GrdPaStatusInfo .Builder info = EndoModelProto.END1001U02GrdPaStatusInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
	    		response.addGrdPastatusItem(info);
			}
		}
		return response.build();
	}                                                                                                                 
}