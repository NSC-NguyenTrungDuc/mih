package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0210U00fwkCommonRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0210U00fwkCommonResponse;
import nta.med.service.ihis.proto.CommonModelProto;

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
public class BAS0210U00fwkCommonHandler extends ScreenHandler<BassServiceProto.BAS0210U00fwkCommonRequest, BassServiceProto.BAS0210U00fwkCommonResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(BAS0210U00fwkCommonHandler.class);                                        
	@Resource                                                                                                       
	private Bas0102Repository bas0102Repository;                                                                    
	                                                                                                                
	@Override     
	@Transactional(readOnly = true)
	public BAS0210U00fwkCommonResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0210U00fwkCommonRequest request)
					throws Exception {
  	   	BassServiceProto.BAS0210U00fwkCommonResponse.Builder response = BassServiceProto.BAS0210U00fwkCommonResponse.newBuilder();                      
		List<ComboListItemInfo> listFwkCommon = bas0102Repository.getBAS0210U00fwkCommon(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId),request.getFind());
		if(!CollectionUtils.isEmpty(listFwkCommon)){
			for(ComboListItemInfo item:listFwkCommon){
				CommonModelProto.ComboListItemInfo.Builder info= CommonModelProto.ComboListItemInfo.newBuilder();
				if (!StringUtils.isEmpty(item.getCode())) {
					info.setCode(item.getCode());
				}
				if (!StringUtils.isEmpty(item.getCodeName())) {
					info.setCodeName(item.getCodeName());
				}
				response.addFwkCommon(info);
			}
		}
		return response.build();
	}                                                                                                                 
}