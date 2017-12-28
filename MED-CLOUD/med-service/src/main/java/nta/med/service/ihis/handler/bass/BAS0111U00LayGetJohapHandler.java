package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.data.dao.medi.bas.Bas0210Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0111U00LayGetJohapRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0111U00LayGetJohapResponse;

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
public class BAS0111U00LayGetJohapHandler extends ScreenHandler<BassServiceProto.BAS0111U00LayGetJohapRequest, BassServiceProto.BAS0111U00LayGetJohapResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(BAS0111U00LayGetJohapHandler.class);                                    
	@Resource                                                                                                       
	private Bas0210Repository bas0210Repository;                                                                    
	

	@Override
	@Transactional(readOnly = true)
	public BAS0111U00LayGetJohapResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0111U00LayGetJohapRequest request) throws Exception {
 	   	BassServiceProto.BAS0111U00LayGetJohapResponse.Builder response = BassServiceProto.BAS0111U00LayGetJohapResponse.newBuilder();    
 	   List<String> listResult = bas0210Repository.getBAS0111U00LayGetJohap(request.getFGubun(), request.getFNaewonDate(), getLanguage(vertx, sessionId));
 	  if(!CollectionUtils.isEmpty(listResult)){
			for(String item : listResult){
				BassModelProto.BAS0111U00LayVzvItemInfo.Builder info = BassModelProto.BAS0111U00LayVzvItemInfo.newBuilder();
				if(!StringUtils.isEmpty(item)){
					info.setName(item);
				}
				response.addDt(info);
			}
		}
		return response.build();
	}                                                                                                                 
}