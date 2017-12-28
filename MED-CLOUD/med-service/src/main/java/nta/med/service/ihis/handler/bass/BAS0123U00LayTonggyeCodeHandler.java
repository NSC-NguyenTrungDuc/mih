package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.domain.bas.Bas0102;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0123U00LayTonggyeCodeRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0123U00LayTonggyeCodeResponse;
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
public class BAS0123U00LayTonggyeCodeHandler extends ScreenHandler<BassServiceProto.BAS0123U00LayTonggyeCodeRequest, BassServiceProto.BAS0123U00LayTonggyeCodeResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(BAS0123U00LayTonggyeCodeHandler.class);                                    
	@Resource                                                                                                       
	private Bas0102Repository bas0102Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public BAS0123U00LayTonggyeCodeResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			BAS0123U00LayTonggyeCodeRequest request) throws Exception {                                                                   
  	   	BassServiceProto.BAS0123U00LayTonggyeCodeResponse.Builder response = BassServiceProto.BAS0123U00LayTonggyeCodeResponse.newBuilder();                      
		List<Bas0102> listItem = bas0102Repository.getByCodeAndCodeType(getHospitalCode(vertx, sessionId), request.getCode(), request.getCodeType(), getLanguage(vertx, sessionId));
		if (!CollectionUtils.isEmpty(listItem)) {
			for (Bas0102 item : listItem) {
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder(); 
				if(!StringUtils.isEmpty(item.getCodeName())) {
					info.setCodeName(item.getCodeName());
				}
				if(!StringUtils.isEmpty(item.getSortKey())) {
					info.setCode(item.getSortKey()+"");
				}
				response.addInfo(info);
			}
		}
		return response.build();
	}                                                                                                                 
}