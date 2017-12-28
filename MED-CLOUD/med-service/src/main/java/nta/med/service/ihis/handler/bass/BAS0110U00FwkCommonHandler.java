package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0110U00FwkCommonRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0110U00FwkCommonResponse;
import nta.med.service.ihis.proto.CommonModelProto;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0110U00FwkCommonHandler extends ScreenHandler<BassServiceProto.BAS0110U00FwkCommonRequest, BassServiceProto.BAS0110U00FwkCommonResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(BAS0110U00FwkCommonHandler.class);                                        
	@Resource                                                                                                       
	private Bas0102Repository bas0102Repository;                                                                    
	                                                                                                                
	@Override     
	@Transactional(readOnly = true)
	public BAS0110U00FwkCommonResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0110U00FwkCommonRequest request)
			throws Exception {                                                                   
	   	BassServiceProto.BAS0110U00FwkCommonResponse.Builder response = BassServiceProto.BAS0110U00FwkCommonResponse.newBuilder();                      
		List<ComboListItemInfo> list = bas0102Repository.getBAS0210U00fwkCommon(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getFind1() + "%");
		if(!CollectionUtils.isEmpty(list)){
			for(ComboListItemInfo item : list){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addListInfo(info);
			}
		}

		return response.build();
	}                                                                                                                 
}