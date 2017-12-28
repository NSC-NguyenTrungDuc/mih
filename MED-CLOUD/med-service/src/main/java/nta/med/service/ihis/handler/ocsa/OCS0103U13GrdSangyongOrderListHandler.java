package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U13GrdSangyongOrderListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U13GrdSangyongOrderListRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U13GrdSangyongOrderListResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U13GrdSangyongOrderListHandler
	extends ScreenHandler<OcsaServiceProto.OCS0103U13GrdSangyongOrderListRequest, OcsaServiceProto.OCS0103U13GrdSangyongOrderListResponse> {                             
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	                                                                                                                
	@Override                         
	@Transactional(readOnly = true)
	public OCS0103U13GrdSangyongOrderListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U13GrdSangyongOrderListRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0103U13GrdSangyongOrderListResponse.Builder response = OcsaServiceProto.OCS0103U13GrdSangyongOrderListResponse.newBuilder();   
  		String offset = "0";
  		if(!StringUtils.isEmpty(request.getOffset())){
  			offset = request.getOffset();
  		}
  	   	Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
    	List<OCS0103U13GrdSangyongOrderListInfo> listGrdSangyong= ocs0103Repository.getGrdSangyongOrderListInfo(getHospitalCode(vertx, sessionId),request.getUser(),
				request.getIoGubun(), request.getOrderGubun(), DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD),request.getSearchWord(), 
				request.getWonnaeDrgYn(), request.getProtocolId(), startNum, CommonUtils.parseInteger(offset), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listGrdSangyong)){
			for(OCS0103U13GrdSangyongOrderListInfo item : listGrdSangyong){
				OcsaModelProto.OCS0103U13GrdSangyongOrderListInfo.Builder info = OcsaModelProto.OCS0103U13GrdSangyongOrderListInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdSangyongItem(info);
			}
		}
		return response.build();
	}

}