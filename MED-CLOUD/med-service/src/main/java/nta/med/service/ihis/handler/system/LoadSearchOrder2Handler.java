package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.glossary.Language;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm0000Repository;
import nta.med.data.dao.medi.xrt.Xrt0122Repository;
import nta.med.data.model.ihis.system.LoadSearchOrderInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CommonModelProto.LoadSearchOrder2RequestInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.LoadSearchOrder2Request;
import nta.med.service.ihis.proto.SystemServiceProto.LoadSearchOrder2Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class LoadSearchOrder2Handler
	extends ScreenHandler<SystemServiceProto.LoadSearchOrder2Request, SystemServiceProto.LoadSearchOrder2Response> {                     
	@Resource                                                                                                       
	private Adm0000Repository adm0000Repository;                                                                    
	@Resource
	private Xrt0122Repository xrt0122Repository;
	
	@Override
	@Transactional(readOnly = true)
	public LoadSearchOrder2Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId, LoadSearchOrder2Request request)
			throws Exception {                                                                
  	   	SystemServiceProto.LoadSearchOrder2Response.Builder response = SystemServiceProto.LoadSearchOrder2Response.newBuilder(); 
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	    String language = getLanguage(vertx, sessionId);
		LoadSearchOrder2RequestInfo inputInfo = request.getInputInfo();
		
		if(inputInfo != null){
			String searchWord = "";
			if("%".equals(inputInfo.getSearchWord())){
				searchWord = inputInfo.getSearchWord();
			}else{
				searchWord = adm0000Repository.callFnAdmConvertKanaFull(hospCode, inputInfo.getSearchWord());
			}
			if(getLanguage(vertx, sessionId).equals(Language.VIETNAMESE.toString().toUpperCase()) || getLanguage(vertx, sessionId).equals(Language.ENGLISH.toString().toUpperCase()))
			{
				searchWord = inputInfo.getSearchWord();
			}

			if(!StringUtils.isEmpty(searchWord) && !searchWord.equals("%")){
				switch (inputInfo.getSearchCondition()) {
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
//			if(!StringUtils.isEmpty(request.getOffset())){
//				offset = request.getOffset();
//			}
//			Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
			
			String offset =  "1000" ;
			Integer startNum = 0;
			
			if(!StringUtils.isEmpty(request.getPageNumber())){
				offset = request.getOffset();
				startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
			}
			
			List<LoadSearchOrderInfo> listResult = xrt0122Repository.getOcsLibOrderBizLoadSearchOrderListItemInfo(searchWord,
					hospCode, inputInfo.getGijunDate(), inputInfo.getWonnaeDrgYn(),inputInfo.getInputTab(), language, startNum, Integer.parseInt(offset), request.getProtocolId());
			if(!CollectionUtils.isEmpty(listResult)){
				for(LoadSearchOrderInfo item : listResult){
					CommonModelProto.LoadSearchOrderInfo.Builder info = CommonModelProto.LoadSearchOrderInfo.newBuilder();
					BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
					response.addSearchResult(info);
				}
			}
		}
		return response.build();
	}
}