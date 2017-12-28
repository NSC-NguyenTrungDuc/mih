package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm0000Repository;
import nta.med.data.dao.medi.ocs.Ocs0142Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U17GrdJaeryoOrderInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U17LoadJaeryoOrderRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U17LoadJaeryoOrderResponse;

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
public class OCS0103U17LoadJaeryoOrderHandler
	extends ScreenHandler<OcsaServiceProto.OCS0103U17LoadJaeryoOrderRequest, OcsaServiceProto.OCS0103U17LoadJaeryoOrderResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U17LoadJaeryoOrderHandler.class);                                    
	@Resource                                                                                                       
	private Adm0000Repository adm0000Repository;                                                                    
	@Resource
	private Ocs0142Repository ocs0142Repository;
	
	@Override                       
	@Transactional(readOnly = true)
	public OCS0103U17LoadJaeryoOrderResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U17LoadJaeryoOrderRequest request) throws Exception {                                                                 
  	   	OcsaServiceProto.OCS0103U17LoadJaeryoOrderResponse.Builder response = OcsaServiceProto.OCS0103U17LoadJaeryoOrderResponse.newBuilder();
  	   	String hospCode = getHospitalCode(vertx, sessionId);
		String searchWord  = "";
		searchWord = adm0000Repository.callFnAdmConvertKanaFull(hospCode, request.getSearchWord());
		if(!StringUtils.isEmpty(request.getSearchWord()) && !request.getSearchWord().equals("%")){
			switch (request.getSearchCondition()) {
			case "01":
				searchWord = "%" + searchWord + "%";
				break;
			case "02":
				searchWord = searchWord + "%";
				break;
			case "03":
				searchWord = "%" + searchWord ;
				break;
			case "04":
				break;
			default:
				searchWord = "%" + searchWord + "%";
				break;
			}
		}else{
			searchWord = "%";
		}
		Integer pageNumber = 1;
  	   	Integer offset = 200;
  	   	if(CommonUtils.parseInteger(request.getPageNumber()) != null){
  	   		pageNumber = CommonUtils.parseInteger(request.getPageNumber());
  	   	}
  	    if(CommonUtils.parseInteger(request.getOffset()) != null){
  	    	offset = CommonUtils.parseInteger(request.getOffset());
	   	}
		List<OCS0103U17GrdJaeryoOrderInfo> listResult = ocs0142Repository.getOCS0103U17LoadJaeryoOrderListItem(hospCode, request.getMode(),
				request.getOrderGubun(), searchWord, request.getOrderDate(), request.getWonnaeDrgYn(), request.getInputTab(), true, request.getProtocolId(), pageNumber, offset, "", getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listResult)){
			for(OCS0103U17GrdJaeryoOrderInfo item : listResult){
				OcsaModelProto.OCS0103U17GrdJaeryoOrderInfo.Builder info = OcsaModelProto.OCS0103U17GrdJaeryoOrderInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdList(info);
			}
		}
		return response.build();
	}

}