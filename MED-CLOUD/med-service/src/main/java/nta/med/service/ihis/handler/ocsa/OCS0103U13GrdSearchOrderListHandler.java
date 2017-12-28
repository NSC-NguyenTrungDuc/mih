package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U13GrdSearchOrderListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U13GrdSearchOrderListRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U13GrdSearchOrderListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U13GrdSearchOrderListHandler
	extends ScreenHandler<OcsaServiceProto.OCS0103U13GrdSearchOrderListRequest, OcsaServiceProto.OCS0103U13GrdSearchOrderListResponse> {                             
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override                      
	@Transactional(readOnly = true)
	public OCS0103U13GrdSearchOrderListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U13GrdSearchOrderListRequest request) throws Exception {                                                                
  	   	OcsaServiceProto.OCS0103U13GrdSearchOrderListResponse.Builder response = OcsaServiceProto.OCS0103U13GrdSearchOrderListResponse.newBuilder();
  	   	
  	   	Integer offset = CommonUtils.parseInteger(request.getOffset());
	   	Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		List<OCS0103U13GrdSearchOrderListInfo> listGrdSearch= ocs0103Repository.getOCS0103U13GrdSearchOrderListInfo(getHospitalCode(vertx, sessionId),
				request.getSearchWord(),request.getOrderDate(), request.getProtocolId(), startNum, offset, getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listGrdSearch)){
			for(OCS0103U13GrdSearchOrderListInfo item : listGrdSearch){
				OcsaModelProto.OCS0103U13GrdSearchOrderListInfo.Builder info= OcsaModelProto.OCS0103U13GrdSearchOrderListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdSearchOrderListItem(info);
			}
		}
		return response.build();
	}

}