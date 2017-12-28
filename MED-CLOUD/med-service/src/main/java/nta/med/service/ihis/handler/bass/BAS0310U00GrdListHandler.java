package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm0000Repository;
import nta.med.data.dao.medi.bas.Bas0310Repository;
import nta.med.data.model.ihis.adma.BAS0310U00GrdListInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310U00GrdListRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0310U00GrdListResponse;

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
public class BAS0310U00GrdListHandler extends ScreenHandler<BassServiceProto.BAS0310U00GrdListRequest, BassServiceProto.BAS0310U00GrdListResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(BAS0310U00GrdListHandler.class);
	
	@Resource                                                                                                       
	private Adm0000Repository adm0000Repository;
	
	@Resource                                   
	private Bas0310Repository bas0310Repository;
	
	public boolean isValid(BassServiceProto.BAS0310U00GrdListRequest request, Vertx vertx, String clientId, String sessionId) {
    	if(StringUtils.isEmpty(request.getOffset())){
			return false;
		}
		return true;
    }
	                                                                                                                
	@Override
	@Transactional
	public BAS0310U00GrdListResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0310U00GrdListRequest request)
					throws Exception {
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
  	   	BassServiceProto.BAS0310U00GrdListResponse.Builder response = BassServiceProto.BAS0310U00GrdListResponse.newBuilder();   
  	   	String offset = request.getOffset();
  	   	Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		String sgCode = "%"+adm0000Repository.callFnAdmConvertKanaFull(hospitalCode, request.getAText())+"%";
		List<BAS0310U00GrdListInfo> listItem = bas0310Repository.getBAS0310U00GrdList(hospitalCode, language, sgCode, request.getBunCode(), startNum, CommonUtils.parseInteger(offset));
		if(!CollectionUtils.isEmpty(listItem)){
			for(BAS0310U00GrdListInfo item : listItem){
				BassModelProto.BAS0310U00GrdListItemInfo.Builder builder = BassModelProto.BAS0310U00GrdListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, builder, getLanguage(vertx, sessionId));
				response.addListInfo(builder);
			}
		}
		return response.build();
	}                                                                                                                 
}