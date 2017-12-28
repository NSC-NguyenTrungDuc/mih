package nta.med.service.ihis.handler.ocso;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.model.ihis.ocso.OUTSANGU00findBoxToDoctorInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class OUTSANGU00findBoxToDoctorHandler extends ScreenHandler<OcsoServiceProto.OUTSANGU00findBoxToDoctorRequest, OcsoServiceProto.OUTSANGU00findBoxToDoctorResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OUTSANGU00findBoxToDoctorHandler.class);                                    
	@Resource                                                                                                       
	private Bas0260Repository bas0260Repository;                                                                    

	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OUTSANGU00findBoxToDoctorResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OUTSANGU00findBoxToDoctorRequest request) throws Exception {
		OcsoServiceProto.OUTSANGU00findBoxToDoctorResponse.Builder response = OcsoServiceProto.OUTSANGU00findBoxToDoctorResponse.newBuilder();
		List<OUTSANGU00findBoxToDoctorInfo> listOUTSANGU00findBoxToDoctorInfo = bas0260Repository.getOUTSANGU00findBoxToDoctorInfo(getHospitalCode(vertx, sessionId), request.getGwa(),
				request.getFind1(),DateUtil.toDate(request.getDoctorYmd(), DateUtil.PATTERN_YYMMDD));
		if (listOUTSANGU00findBoxToDoctorInfo != null && !listOUTSANGU00findBoxToDoctorInfo.isEmpty()){
			for(OUTSANGU00findBoxToDoctorInfo item : listOUTSANGU00findBoxToDoctorInfo){
				OcsoModelProto.OUTSANGU00findBoxToDoctorInfo.Builder info = OcsoModelProto.OUTSANGU00findBoxToDoctorInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addDoctorInfo(info);
			}
		}
		return response.build();
	}                                                                                                                 
}