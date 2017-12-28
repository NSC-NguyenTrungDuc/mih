package nta.med.service.ihis.handler.ocsa;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.adm.Adm0000Repository;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U15GrdSlipHangmogInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U15GrdSlipHangmogRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U15GrdSlipHangmogResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
public class OCS0103U15GrdSlipHangmogHandler
	extends ScreenHandler<OcsaServiceProto.OCS0103U15GrdSlipHangmogRequest, OcsaServiceProto.OCS0103U15GrdSlipHangmogResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U15GrdSlipHangmogHandler.class);                                    
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	
	@Resource                                                                                                       
	private Adm0000Repository adm0000Repository; 
	
	@Override            
	@Transactional(readOnly = true)
	public OCS0103U15GrdSlipHangmogResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U15GrdSlipHangmogRequest request) throws Exception {                                                                  
  	   	OcsaServiceProto.OCS0103U15GrdSlipHangmogResponse.Builder response = OcsaServiceProto.OCS0103U15GrdSlipHangmogResponse.newBuilder();
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
		Date orderDate = DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD);
		Integer offset = CommonUtils.parseInteger(request.getOffset());
  	   	Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), request.getOffset());
		List<OCS0103U15GrdSlipHangmogInfo> listGrd = ocs0103Repository.getOCS0103U15GrdSlipHangmogInfo(hospCode, request.getMode(),
				request.getSlipCode(), request.getWonnaeDrgYn(), orderDate, request.getInputTab(), searchWord, request.getProtocolId(),startNum, offset);
		if(!CollectionUtils.isEmpty(listGrd)){
			for(OCS0103U15GrdSlipHangmogInfo item : listGrd){
				OcsaModelProto.OCS0103U15GrdSlipHangmogInfo.Builder info = OcsaModelProto.OCS0103U15GrdSlipHangmogInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListItem(info);
			}
		}
		return response.build();
	}

}
