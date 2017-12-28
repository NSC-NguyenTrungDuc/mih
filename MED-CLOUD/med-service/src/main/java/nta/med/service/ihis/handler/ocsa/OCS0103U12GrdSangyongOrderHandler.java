package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.adm.Adm0000Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U12GrdSangyongOrderInfo;
import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12GrdSangyongOrderRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12GrdSangyongOrderResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OCS0103U12GrdSangyongOrderHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U12GrdSangyongOrderRequest, OcsaServiceProto.OCS0103U12GrdSangyongOrderResponse> {                     
	@Resource                                                                                                       
	private Ocs1003Repository ocs1003Repository;
	@Resource                                                                                                       
	private Adm0000Repository adm0000Repository; 
	                                                                                                                
	@Override        
	@Transactional(readOnly = true)
	public OCS0103U12GrdSangyongOrderResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U12GrdSangyongOrderRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0103U12GrdSangyongOrderResponse.Builder response = OcsaServiceProto.OCS0103U12GrdSangyongOrderResponse.newBuilder();
  	   	String searchWord = request.getSearchWord();
  	   	if(!StringUtils.isEmpty(searchWord) && Language.JAPANESE.toString().equalsIgnoreCase(getLanguage(vertx, sessionId)))
		{
  	   		searchWord = adm0000Repository.callFnAdmConvertKanaFull(getHospitalCode(vertx, sessionId), searchWord);
		}
		List<OCS0103U12GrdSangyongOrderInfo> list = ocs1003Repository.getOCS0103U12GrdSangyongOrder(request.getUser(), getHospitalCode(vertx, sessionId), request.getIoGubun(),
				request.getOrderGubun(), DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD), "%" + searchWord + "%", request.getWonnaeDrgYn(), request.getProtocolId(), getLanguage(vertx, sessionId));
			if(!CollectionUtils.isEmpty(list)){
			for(OCS0103U12GrdSangyongOrderInfo item : list){
				OcsaModelProto.OCS0103U12GrdSangyongOrderInfo.Builder info = OcsaModelProto.OCS0103U12GrdSangyongOrderInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdSangyongList(info);
			}
		}
		return response.build();
	}

}