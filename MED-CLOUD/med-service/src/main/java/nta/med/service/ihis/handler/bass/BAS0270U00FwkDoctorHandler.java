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
import nta.med.data.dao.medi.bas.Bas0270Repository;
import nta.med.data.model.ihis.bass.BAS0270FwdDoctorInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0270U00FwkDoctorRequest;
import nta.med.service.ihis.proto.BassServiceProto.BAS0270U00FwkDoctorResponse;

@Service                                                                                                          
@Scope("prototype")
public class BAS0270U00FwkDoctorHandler extends ScreenHandler<BassServiceProto.BAS0270U00FwkDoctorRequest, BassServiceProto.BAS0270U00FwkDoctorResponse> {                             
	
	private static final Log LOG = LogFactory.getLog(BAS0270U00FwkDoctorHandler.class);                                        
		
	@Resource                                                                                                       
	private Bas0270Repository bas0270Repository;                                                                    
		                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public BAS0270U00FwkDoctorResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, BAS0270U00FwkDoctorRequest request) throws Exception {
		
		BassServiceProto.BAS0270U00FwkDoctorResponse.Builder response = BassServiceProto.BAS0270U00FwkDoctorResponse.newBuilder();
		List<BAS0270FwdDoctorInfo> listBAS0270FwdDoctorInfo = bas0270Repository.getBAS0270FwdDoctorInfo(getHospitalCode(vertx, sessionId), request.getFind1());
		
		if(!CollectionUtils.isEmpty(listBAS0270FwdDoctorInfo)) {
			for (BAS0270FwdDoctorInfo item : listBAS0270FwdDoctorInfo) {
				BassModelProto.BAS0270U00FwdDoctorInfo.Builder info = BassModelProto.BAS0270U00FwdDoctorInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addFwkList(info);
			}
		}
		
		return response.build();
	}
}                                                                                                                 
