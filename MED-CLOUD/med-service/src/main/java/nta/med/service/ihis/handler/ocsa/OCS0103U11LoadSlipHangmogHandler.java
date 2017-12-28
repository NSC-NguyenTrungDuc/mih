package nta.med.service.ihis.handler.ocsa;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.adm.Adm0000Repository;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.ocsa.OCS0103U11LoadSlipHangmogInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsaModelProto;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U11LoadSlipHangmogRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U11LoadSlipHangmogResponse;

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
public class OCS0103U11LoadSlipHangmogHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U11LoadSlipHangmogRequest, OcsaServiceProto.OCS0103U11LoadSlipHangmogResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U11LoadSlipHangmogHandler.class);                                    
	@Resource                                                                                                       
	private Adm0000Repository adm0000Repository;                                                                    
	@Resource
	private Ocs0103Repository ocs0103Repository;
	@Override                 
	@Transactional(readOnly = true)
	public OCS0103U11LoadSlipHangmogResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OCS0103U11LoadSlipHangmogRequest request) throws Exception {
  	   	OcsaServiceProto.OCS0103U11LoadSlipHangmogResponse.Builder response = OcsaServiceProto.OCS0103U11LoadSlipHangmogResponse.newBuilder();                      
		String searchWord = "";
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
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

		List<OCS0103U11LoadSlipHangmogInfo> list = ocs0103Repository.getOCS0103U11LoadSlipHangmogListItem(hospCode, language,
				request.getSlipCode(), searchWord, DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD), request.getProtocolId());
		if(!CollectionUtils.isEmpty(list)){
			for(OCS0103U11LoadSlipHangmogInfo item : list){
				OcsaModelProto.OCS0103U11LoadSlipHangmogInfo.Builder info = OcsaModelProto.OCS0103U11LoadSlipHangmogInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addSlipHangmogInfo(info);
			}
		}
		return response.build();
	}
}