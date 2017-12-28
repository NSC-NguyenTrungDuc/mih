package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0123Repository;
import nta.med.data.model.ihis.bass.BAS0123U00FwkZipCodeInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0123U00FwkZipCodeRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0123U00FwkZipCodeResponse;

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
public class BAS0123U00FwkZipCodeHandler extends ScreenHandler<BassServiceProto.BAS0123U00FwkZipCodeRequest, BassServiceProto.BAS0123U00FwkZipCodeResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(BAS0123U00FwkZipCodeHandler.class);                                    
	@Resource                                                                                                       
	private Bas0123Repository bas0123Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public BAS0123U00FwkZipCodeResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0123U00FwkZipCodeRequest request) throws Exception {                                                                   
  	   	BassServiceProto.BAS0123U00FwkZipCodeResponse.Builder response = BassServiceProto.BAS0123U00FwkZipCodeResponse.newBuilder();                      
		List<BAS0123U00FwkZipCodeInfo> listItem = bas0123Repository.getBAS0123U00FwkZipCodeInfo(request.getCode(), request.getFind1());
		if (!CollectionUtils.isEmpty(listItem)) {
			for (BAS0123U00FwkZipCodeInfo item : listItem) {
				BassModelProto.BAS0123U00FwkZipCodeInfo.Builder info = BassModelProto.BAS0123U00FwkZipCodeInfo.newBuilder(); 
				if(!StringUtils.isEmpty(item.getZipCode())) {
					info.setZipCode(item.getZipCode());
				}
				if(!StringUtils.isEmpty(item.getZipName1())) {
					info.setZipName1(item.getZipName1());
				}
				if(!StringUtils.isEmpty(item.getZipName2())) {
					info.setZipName2(item.getZipName2());
				}
				if(!StringUtils.isEmpty(item.getZipName3())) {
					info.setZipName3(item.getZipName3());
				}
				response.addInfo(info);
			}
		}
		return response.build();
	}                                                                                                                 
}