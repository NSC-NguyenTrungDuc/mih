package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.adm.Adm0000Repository;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U12LoadDrgOrderInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12LoadDrgOrderRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U12LoadDrgOrderResponse;

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
public class OCS0103U12LoadDrgOrderHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U12LoadDrgOrderRequest, OcsaServiceProto.OCS0103U12LoadDrgOrderResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U12LoadDrgOrderHandler.class);                                    
	@Resource                                                                                                       
	private Adm0000Repository adm0000Repository;    
	
	@Resource
	private Ocs0103Repository ocs0103Repository;
	                                                                                                                
	@Override         
	@Transactional(readOnly = true)
	public OCS0103U12LoadDrgOrderResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0103U12LoadDrgOrderRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0103U12LoadDrgOrderResponse.Builder response = OcsaServiceProto.OCS0103U12LoadDrgOrderResponse.newBuilder();
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
		String searchWord = adm0000Repository.callFnAdmConvertKanaFull(hospCode, request.getASearchWord());
		if(!StringUtils.isEmpty(request.getASearchWord()) && !request.getASearchWord().equals("%")){
			switch (request.getSearchCondition()) {
			case "01":
				searchWord = "%"+searchWord+"%";
				break;
			case "02":
				searchWord = searchWord+"%";
				break;
			case "03":
				searchWord = "%"+searchWord;
				break;
			case "04":
				break;
			default:
				searchWord = "%"+searchWord+"%";
				break;
			}
		}else{
			searchWord = "%";
		}
		
		String offset =  "0" ;
		if(!StringUtils.isEmpty(request.getOffset())){
			offset = request.getOffset();
		}
		Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		List<OCS0103U12LoadDrgOrderInfo> listResult = ocs0103Repository.getOCS0103U12LoadDrgOrderListItem(hospCode, language, request.getAMode(),
				request.getACode1(), request.getAWonnaeDrgYn(),DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD), searchWord, request.getProtocolId(), startNum, CommonUtils.parseInteger(offset));
		if(!CollectionUtils.isEmpty(listResult)){
			for(OCS0103U12LoadDrgOrderInfo item : listResult){
				OcsaModelProto.OCS0103U12LoadDrgOrderInfo.Builder info = OcsaModelProto.OCS0103U12LoadDrgOrderInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDrgOrderList(info);
			}
		}
		return response.build();
	}

}