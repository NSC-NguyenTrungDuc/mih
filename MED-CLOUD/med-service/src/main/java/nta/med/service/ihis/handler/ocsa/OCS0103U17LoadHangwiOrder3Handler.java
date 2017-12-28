package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.adm.Adm0000Repository;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U17GrdSearchOrderInfo;
import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U17LoadHangwiOrder3Request;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U17LoadHangwiOrder3Response;

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
public class OCS0103U17LoadHangwiOrder3Handler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U17LoadHangwiOrder3Request, OcsaServiceProto.OCS0103U17LoadHangwiOrder3Response> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U17LoadHangwiOrder3Handler.class);                                    
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;   
	@Resource
	private Adm0000Repository adm0000Repository;
	                                                                                                                
	@Override          
	@Transactional(readOnly = true)
	public OCS0103U17LoadHangwiOrder3Response handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U17LoadHangwiOrder3Request request) throws Exception {                                                                 
  	   	OcsaServiceProto.OCS0103U17LoadHangwiOrder3Response.Builder response = OcsaServiceProto.OCS0103U17LoadHangwiOrder3Response.newBuilder();
  	   	String hospCode = getHospitalCode(vertx, sessionId);
		String searchWord  = "";
		searchWord = adm0000Repository.callFnAdmConvertKanaFull(hospCode, request.getSearchword());
		
		if(getLanguage(vertx, sessionId).equals(Language.VIETNAMESE.toString().toUpperCase()) || getLanguage(vertx, sessionId).equals(Language.ENGLISH.toString().toUpperCase()))
		{
			searchWord = request.getSearchword();
		}
		
		if(!StringUtils.isEmpty(request.getSearchword()) && !request.getSearchword().equals("%")){
			switch (request.getSearchcondition()) {
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
  	    
		List<OCS0103U17GrdSearchOrderInfo> listResutl = ocs0103Repository.getOCS0103U17LoadHangwiOrder3ListItem(hospCode, request.getCodeYn(), request.getMode(), request.getSlipCode(),
				searchWord, request.getWonnaeDrgYn(), DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD), request.getInputTab(), request.getUser(), request.getProtocolId()
				, pageNumber, offset, getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listResutl)){
			for(OCS0103U17GrdSearchOrderInfo item : listResutl){
				OcsaModelProto.OCS0103U17GrdSearchOrderInfo.Builder info = OcsaModelProto.OCS0103U17GrdSearchOrderInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdSearchOrderInfo(info);
			}
		}
		return response.build();	
	}

}