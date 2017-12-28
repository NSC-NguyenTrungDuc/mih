package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm0000Repository;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.system.OBLoadSearchOrderInfoDRGInfo;
import nta.med.core.glossary.Language;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.OBLoadSearchOrderInfoDRGRequest;
import nta.med.service.ihis.proto.SystemServiceProto.OBLoadSearchOrderInfoDRGResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OBLoadSearchOrderInfoDRGHandler 
	extends ScreenHandler<SystemServiceProto.OBLoadSearchOrderInfoDRGRequest, SystemServiceProto.OBLoadSearchOrderInfoDRGResponse> {                     
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;     
	@Resource                                                                                                       
	private Adm0000Repository adm0000Repository;  
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OBLoadSearchOrderInfoDRGResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OBLoadSearchOrderInfoDRGRequest request) throws Exception {                                                                  
  	   	SystemServiceProto.OBLoadSearchOrderInfoDRGResponse.Builder response = SystemServiceProto.OBLoadSearchOrderInfoDRGResponse.newBuilder();
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
		String searchWord = "";
		if(!request.getSearchWord().isEmpty() && !request.getSearchWord().equals("%")){
			 String getResult = adm0000Repository.callFnAdmConvertKanaFull(hospCode, request.getSearchWord());
			 
			if (getLanguage(vertx, sessionId).equals(Language.VIETNAMESE.toString().toUpperCase())
					|| getLanguage(vertx, sessionId).equals(Language.ENGLISH.toString().toUpperCase())) {
				getResult = request.getSearchWord();
			}
			 
			 if(!StringUtils.isEmpty(getResult)){
				 searchWord = getResult;
				 switch (request.getSearchCondition()) {
				case "01":
					searchWord = "%" + searchWord + "%";
					break;
				case "02":
					searchWord = searchWord + "%";
					break;
				case "03":
					searchWord = "%" + searchWord;
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
		String offset = request.getOffSet();
        Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		List<OBLoadSearchOrderInfoDRGInfo> listSearchOrder= ocs0103Repository.getOBLoadSearchOrderInfoDRGInfo(hospCode, language,
				request.getGenericSearchYn(), searchWord, request.getGijunDate(), request.getWonnaeDrgYn(), request.getInputTab(), request.getProtocolId(), startNum, CommonUtils.parseInteger(offset));
		if(!CollectionUtils.isEmpty(listSearchOrder)){
			for(OBLoadSearchOrderInfoDRGInfo item : listSearchOrder){
				CommonModelProto.OBLoadSearchOrderInfoDRGInfo.Builder info = CommonModelProto.OBLoadSearchOrderInfoDRGInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addSearchOrderDrgItem(info);
			}
		}
		return response.build();
	}
}