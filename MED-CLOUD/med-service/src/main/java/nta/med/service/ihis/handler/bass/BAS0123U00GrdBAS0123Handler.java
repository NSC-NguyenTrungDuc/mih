package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0123Repository;
import nta.med.data.model.ihis.bass.BAS0123U00GrdBAS0123Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0123U00GrdBAS0123Request;
import nta.med.service.ihis.proto.BassServiceProto.BAS0123U00GrdBAS0123Response;

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
public class BAS0123U00GrdBAS0123Handler extends ScreenHandler<BassServiceProto.BAS0123U00GrdBAS0123Request, BassServiceProto.BAS0123U00GrdBAS0123Response> {                     
	private static final Log LOGGER = LogFactory.getLog(BAS0123U00GrdBAS0123Handler.class);                                    
	@Resource                                                             	                                          
	private Bas0123Repository bas0123Repository;                                                                    
	                                                                                                                
	@Override    
	@Transactional(readOnly = true)
	public BAS0123U00GrdBAS0123Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0123U00GrdBAS0123Request request) throws Exception {                                                                   
  	   	BassServiceProto.BAS0123U00GrdBAS0123Response.Builder response = BassServiceProto.BAS0123U00GrdBAS0123Response.newBuilder();                      
		List<BAS0123U00GrdBAS0123Info> listItem = bas0123Repository.getBAS0123U00GrdBAS0123Info(request.getCode());
		if (!CollectionUtils.isEmpty(listItem)) {
			for (BAS0123U00GrdBAS0123Info item : listItem) {
				BassModelProto.BAS0123U00GrdBAS0123Info.Builder info = BassModelProto.BAS0123U00GrdBAS0123Info.newBuilder(); 
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
				if(!StringUtils.isEmpty(item.getZipNameGana1())) {
					info.setZipNameGana1(item.getZipNameGana1());
				}
				if(!StringUtils.isEmpty(item.getZipNameGana2())) {
					info.setZipNameGana2(item.getZipNameGana2());
				}
				if(!StringUtils.isEmpty(item.getZipNameGana3())) {
					info.setZipNameGana3(item.getZipNameGana3());
				}
				response.addInfo(info);
			}
		}
		return response.build();
	}
}