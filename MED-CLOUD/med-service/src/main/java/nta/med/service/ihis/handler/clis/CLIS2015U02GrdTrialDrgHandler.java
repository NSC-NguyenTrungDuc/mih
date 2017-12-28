package nta.med.service.ihis.handler.clis;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.ClisServiceProto;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U02GrdTrialDrgRequest;
import nta.med.service.ihis.proto.ClisServiceProto.CLIS2015U02GrdTrialDrgResponse;

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
public class CLIS2015U02GrdTrialDrgHandler extends ScreenHandler<ClisServiceProto.CLIS2015U02GrdTrialDrgRequest, ClisServiceProto.CLIS2015U02GrdTrialDrgResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(CLIS2015U02GrdTrialDrgHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public CLIS2015U02GrdTrialDrgResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			CLIS2015U02GrdTrialDrgRequest request) throws Exception {
		ClisServiceProto.CLIS2015U02GrdTrialDrgResponse.Builder response = ClisServiceProto.CLIS2015U02GrdTrialDrgResponse.newBuilder();
		Integer startNum = null;
		String offset = request.getOffset();
		if(!StringUtils.isEmpty(request.getPageNumber())){
			startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		}
		List<ComboListItemInfo> list = ocs0103Repository.getClis2015U02TrialItemListInfo(getHospitalCode(vertx, sessionId), CommonUtils.parseInteger(request.getProtocolId()), 
				startNum,  CommonUtils.parseInteger(offset));
		if(!CollectionUtils.isEmpty(list)){
			for(ComboListItemInfo item : list){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdList(info);
			}
		}
		return response.build();
	}                                                                                                                 
}