package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm0000Repository;
import nta.med.data.dao.medi.xrt.Xrt0122Repository;
import nta.med.data.model.ihis.system.LoadSearchOrderInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.CommonModelProto.LoadSearchOrder1RequestInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.LoadSearchOrder1Request;
import nta.med.service.ihis.proto.SystemServiceProto.LoadSearchOrder1Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class LoadSearchOrder1Handler 
	extends ScreenHandler<SystemServiceProto.LoadSearchOrder1Request, SystemServiceProto.LoadSearchOrder1Response> {                     
	@Resource                                                                                                       
	private Xrt0122Repository xrt0122Repository; 
	@Resource                                                                                                       
	private Adm0000Repository adm0000Repository; 
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public LoadSearchOrder1Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId, LoadSearchOrder1Request request)
			throws Exception {                                                                
      	   	SystemServiceProto.LoadSearchOrder1Response.Builder response = SystemServiceProto.LoadSearchOrder1Response.newBuilder();                      
		LoadSearchOrder1RequestInfo inputInfo = request.getInputInfo();
		String searchWord = "";
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		if(inputInfo != null){
			if(!StringUtils.isEmpty(inputInfo.getSearchWord()) && !inputInfo.getSearchWord().equals("%")){
				 searchWord = adm0000Repository.callFnAdmConvertKanaFull(hospCode, inputInfo.getSearchWord());
			}else{
				searchWord = "%";
			}
			
			String offset = "0" ;
			 if(!StringUtils.isEmpty(inputInfo.getOffset())){
				offset = inputInfo.getOffset();
			 }
			 Integer startNum = CommonUtils.getStartNumberPaging(inputInfo.getPageNumber(), offset);
			List<LoadSearchOrderInfo> listResult = xrt0122Repository.getOcsLibOrderBizLoadSearchOrderListItemInfo("%" + searchWord + "%",
					hospCode, inputInfo.getGijunDate(), inputInfo.getWonnaeDrgYn(), inputInfo.getInputTab(), language, startNum, Integer.parseInt(offset), inputInfo.getProtocolId());
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