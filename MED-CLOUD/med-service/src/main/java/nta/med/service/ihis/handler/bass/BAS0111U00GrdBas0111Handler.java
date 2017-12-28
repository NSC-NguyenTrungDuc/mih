package nta.med.service.ihis.handler.bass;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.bas.Bas0111Repository;
import nta.med.data.model.ihis.bass.BAS0111U00GrdBas0111ItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0111U00GrdBas0111Request;
import nta.med.service.ihis.proto.BassServiceProto.BAS0111U00GrdBas0111Response;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0111U00GrdBas0111Handler extends ScreenHandler<BassServiceProto.BAS0111U00GrdBas0111Request, BassServiceProto.BAS0111U00GrdBas0111Response> {                    
	private static final Log LOGGER = LogFactory.getLog(BAS0111U00GrdBas0111Handler.class);                                    
	@Resource                                                                                                       
	private Bas0111Repository bas0111Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public BAS0111U00GrdBas0111Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0111U00GrdBas0111Request request) throws Exception {
		BassServiceProto.BAS0111U00GrdBas0111Response.Builder response = BassServiceProto.BAS0111U00GrdBas0111Response.newBuilder();
		List<BAS0111U00GrdBas0111ItemInfo> listResult = bas0111Repository.getBAS0111U00GrdBas0111ItemInfo(getHospitalCode(vertx, sessionId), request.getFJohapGubun(), 
				request.getFJohap(), getLanguage(vertx, sessionId));
		if(!CollectionUtils.isEmpty(listResult)){
			for(BAS0111U00GrdBas0111ItemInfo info : listResult){
				BassModelProto.BAS0111U00GrdBas0111ItemInfo.Builder builder = BassModelProto.BAS0111U00GrdBas0111ItemInfo.newBuilder();
				BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
				response.addDt(builder);
			}
		}
		return response.build();
	}                                                                                                                 
}