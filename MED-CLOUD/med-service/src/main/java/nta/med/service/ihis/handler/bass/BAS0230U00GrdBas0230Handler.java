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
import nta.med.data.dao.medi.bas.Bas0230Repository;
import nta.med.data.model.ihis.adma.BAS0230U00GrdBAS0230Info;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0230U00GrdBas0230Request;
import nta.med.service.ihis.proto.BassServiceProto.BAS0230U00GrdBas0230Response;
import nta.med.service.ihis.proto.CommonModelProto;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0230U00GrdBas0230Handler extends ScreenHandler<BassServiceProto.BAS0230U00GrdBas0230Request, BassServiceProto.BAS0230U00GrdBas0230Response> {                     
	private static final Log LOGGER = LogFactory.getLog(BAS0230U00GrdBas0230Handler.class);                                    
	@Resource                                                                                                       
	private Bas0230Repository bas0230Repository;                                                                    
	                                                                                                                
	@Override      
	@Transactional(readOnly = true)
	public BAS0230U00GrdBas0230Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0230U00GrdBas0230Request request) throws Exception {
  	   	BassServiceProto.BAS0230U00GrdBas0230Response.Builder response = BassServiceProto.BAS0230U00GrdBas0230Response.newBuilder();                      
		List<BAS0230U00GrdBAS0230Info> listItem = bas0230Repository.getBAS0230U00GrdBAS0230(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getStartYmd());
		if (!CollectionUtils.isEmpty(listItem)) {
			for (BAS0230U00GrdBAS0230Info item : listItem) {
				CommonModelProto.BAS0230U00GrdBAS0230Info.Builder info = CommonModelProto.BAS0230U00GrdBAS0230Info.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addGrdBas0230Info(info);
			}
		}
		return response.build();
	}
}