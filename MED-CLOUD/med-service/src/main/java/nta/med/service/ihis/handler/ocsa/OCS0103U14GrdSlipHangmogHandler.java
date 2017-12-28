package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.adm.Adm0000Repository;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U14GrdSlipHangmogInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U14GrdSlipHangmogRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U14GrdSlipHangmogResponse;

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
public class OCS0103U14GrdSlipHangmogHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U14GrdSlipHangmogRequest, OcsaServiceProto.OCS0103U14GrdSlipHangmogResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U14GrdSlipHangmogHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	        
	@Resource                                                                                                       
	private Adm0000Repository adm0000Repository; 
	
	@Override          
	@Transactional(readOnly = true)
	public OCS0103U14GrdSlipHangmogResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U14GrdSlipHangmogRequest request) throws Exception {                                                                 
  	   	OcsaServiceProto.OCS0103U14GrdSlipHangmogResponse.Builder response = OcsaServiceProto.OCS0103U14GrdSlipHangmogResponse.newBuilder();
  	    String hospCode = getHospitalCode(vertx, sessionId);
  	    String searchWord = "";
  	    if(!request.getSearchWord().equals("%")&&!StringUtils.isEmpty(request.getSearchWord())){
			searchWord = adm0000Repository.callFnAdmConvertKanaFull(hospCode, request.getSearchWord());
			if(!StringUtils.isEmpty(searchWord)){
				switch (request.getSearchCondition()) {
				case "01":
					 searchWord = "%" + searchWord + "%";
					break;
				case "02":
					 searchWord =  searchWord + "%";
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
			}
		}else{
			searchWord = "%";
		}
  	    
  	    String offset =  "0" ;
		if(!StringUtils.isEmpty(request.getOffset())){
			offset = request.getOffset();
		}
		Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		
    	List<OCS0103U14GrdSlipHangmogInfo> listGrdSlip =ocs0103Repository.getOCS0103U14GrdSlipHangmogInfo(hospCode, request.getPfeCodeYn(), request.getMode(), request.getSlipCode(),
    			searchWord, request.getWonnaeDrgYn(), DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD), request.getInputTab(), request.getUser(), 
    			request.getProtocolId(), startNum, Integer.parseInt(offset));
		if(!CollectionUtils.isEmpty(listGrdSlip)){
			for(OCS0103U14GrdSlipHangmogInfo item : listGrdSlip){
				OcsaModelProto.OCS0103U14GrdSlipHangmogInfo.Builder info = OcsaModelProto.OCS0103U14GrdSlipHangmogInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addSlipHangmogItem(info);
			}
		}
		return response.build();
	}

}