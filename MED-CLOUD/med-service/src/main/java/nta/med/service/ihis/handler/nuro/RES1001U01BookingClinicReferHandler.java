package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.nuro.RES1001U01BookingClinicReferInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.RES1001U01BookingClinicReferRequest;
import nta.med.service.ihis.proto.NuroServiceProto.RES1001U01BookingClinicReferResponse;

@Service
@Scope("prototype")
public class RES1001U01BookingClinicReferHandler extends ScreenHandler<NuroServiceProto.RES1001U01BookingClinicReferRequest, NuroServiceProto.RES1001U01BookingClinicReferResponse>{
	
	private static final Log LOGGER = LogFactory.getLog(RES1001U01BookingClinicReferHandler.class);
	
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;

	@Override
	public boolean isValid(NuroServiceProto.RES1001U01BookingClinicReferRequest request, Vertx vertx, String clientId, String sessionId) {
		if (!StringUtils.isEmpty(request.getNaewonDate()) && DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD) == null) {
			return false;
		}
		return true;
	}
	
	@Override
	@Transactional(readOnly = true)
	public RES1001U01BookingClinicReferResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			RES1001U01BookingClinicReferRequest request) throws Exception {
		
		LOGGER.info("RES1001U01BookingClinicReferHandler : naewon_date = " + request.getNaewonDate() + ", gwa = " + request.getGwa() + ", doctor = " + request.getDoctor());
		
		NuroServiceProto.RES1001U01BookingClinicReferResponse.Builder response = NuroServiceProto.RES1001U01BookingClinicReferResponse.newBuilder();
		List<RES1001U01BookingClinicReferInfo> listItem = out1001Repository.getRES1001U01BookingClinicReferInfo(request.getNaewonDate(), 
																												getHospitalCode(vertx, sessionId), 
																												request.getGwa(), 
																												request.getDoctor());
		
		if(!CollectionUtils.isEmpty(listItem)){
			for (RES1001U01BookingClinicReferInfo item : listItem) {
				NuroModelProto.RES1001U01BookingClinicReferInfo.Builder info = NuroModelProto.RES1001U01BookingClinicReferInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addLst(info);
			}
		}
		
		return response.build();
	} 
	
	
	
}
