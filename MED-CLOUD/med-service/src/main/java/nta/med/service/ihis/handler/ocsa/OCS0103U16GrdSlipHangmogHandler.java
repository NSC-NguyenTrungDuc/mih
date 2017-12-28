package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U16GrdSlipHangmogInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U16GrdSlipHangmogRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U16GrdSlipHangmogResponse;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U16GrdSlipHangmogHandler
	extends ScreenHandler<OcsaServiceProto.OCS0103U16GrdSlipHangmogRequest, OcsaServiceProto.OCS0103U16GrdSlipHangmogResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U16GrdSlipHangmogHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override          
	@Transactional(readOnly = true)
	public OCS0103U16GrdSlipHangmogResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U16GrdSlipHangmogRequest request) throws Exception {                                                                 
  	   	OcsaServiceProto.OCS0103U16GrdSlipHangmogResponse.Builder response = OcsaServiceProto.OCS0103U16GrdSlipHangmogResponse.newBuilder();
		String searchWord = request.getSearchWord();
		if(StringUtils.isEmpty(searchWord))
		{
			searchWord = "%";
		}
		List<OCS0103U16GrdSlipHangmogInfo> listGrdHangMog=ocs0103Repository.getOCS0103U16GrdSlipHangmogInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),
				request.getMode(), request.getXrayCodeYn(), request.getSlipCode(),
				DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD), request.getInputTab(), request.getXrayBuwi(), request.getWonnaeDrgYn(), searchWord);
		if (!CollectionUtils.isEmpty(listGrdHangMog)){
			for(OCS0103U16GrdSlipHangmogInfo item : listGrdHangMog){
				OcsaModelProto.OCS0103U16GrdSlipHangmogInfo.Builder info= OcsaModelProto.OCS0103U16GrdSlipHangmogInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addSlipHangmogItem(info);
			}
		}
		return response.build();
	}

}