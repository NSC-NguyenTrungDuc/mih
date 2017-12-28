package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.out.Out0101Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.nuro.RES1001R00BookingInfo;
import nta.med.data.model.ihis.nuro.RES1001R00ClinicInfo;
import nta.med.data.model.ihis.nuro.RES1001R00ClinicNameInfo;
import nta.med.data.model.ihis.nuro.RES1001R00PatientNameInfo;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.NuroServiceProto.RES1001R00PrintBookingRequest;
import nta.med.service.ihis.proto.NuroServiceProto.RES1001R00PrintBookingResponse;

@Service
@Scope("prototype")
public class RES1001R00PrintBookingHandler extends ScreenHandler<NuroServiceProto.RES1001R00PrintBookingRequest, NuroServiceProto.RES1001R00PrintBookingResponse>{
	private static final Log logger = LogFactory.getLog(RES1001R00PrintBookingHandler.class);
	@Resource                                                                                                       
	private Bas0001Repository bas0001Repository;
	@Resource                                                                                                       
	private Out0101Repository out0101Repository;
	@Resource
	private Out1001Repository out1001Repository;
	
	@Override
	@Transactional(readOnly = true)
	public RES1001R00PrintBookingResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			RES1001R00PrintBookingRequest request) throws Exception {
		NuroServiceProto.RES1001R00PrintBookingResponse.Builder response = NuroServiceProto.RES1001R00PrintBookingResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String hospCodeLink = request.getHospCodeLink();
		String language = getLanguage(vertx, sessionId);
		String bunho = request.getBunho();
		// get linked clinic' name
		List<RES1001R00ClinicNameInfo> clinicName = bas0001Repository.getRES1001R00ClinicName(hospCodeLink, language);
		if(!CollectionUtils.isEmpty(clinicName)){
			if(!StringUtils.isEmpty(clinicName.get(0).getYoyngName())){
				response.setYoyangNameLink(clinicName.get(0).getYoyngName());
			}
			if(!StringUtils.isEmpty(clinicName.get(0).getAddress())){
				response.setAddress(clinicName.get(0).getAddress());
			}
			if(!StringUtils.isEmpty(clinicName.get(0).getTel())){
				response.setTel(clinicName.get(0).getTel());
			}
		}
		// get linked patient' name
		List<RES1001R00PatientNameInfo> patientName = out0101Repository.getRES1001R00PatientName(hospCode, bunho);
		if(!CollectionUtils.isEmpty(patientName)){
			if(!StringUtils.isEmpty(patientName.get(0).getSuname())){
				response.setSuname(patientName.get(0).getSuname());
			}
			if(!StringUtils.isEmpty(patientName.get(0).getBirth())){
				response.setBirth(patientName.get(0).getBirth());
			}
			if(!StringUtils.isEmpty(patientName.get(0).getAge())){
				response.setAge(String.format("%.0f", patientName.get(0).getAge()));
			}
		}
		// get clinic info
		List<RES1001R00ClinicInfo> clinicInfo = bas0001Repository.getRES1001R00ClinicInfo(hospCode, hospCodeLink, language, bunho);
		if(!CollectionUtils.isEmpty(clinicInfo)){
			if(!StringUtils.isEmpty(clinicInfo.get(0).getYoyangName())){
				response.setYoyangName(clinicInfo.get(0).getYoyangName());
			}
			if(!StringUtils.isEmpty(clinicInfo.get(0).getBunho())){
				response.setBunho(clinicInfo.get(0).getBunho());
			}
		}
		// booking info
		List<RES1001R00BookingInfo> bookingInfo = out1001Repository.getRES1001R00BookingInfo(hospCodeLink, language, bunho, 
				request.getGwa(), request.getDoctor(), DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD), request.getJubsuTime());
		if(!CollectionUtils.isEmpty(bookingInfo)){
			if(!StringUtils.isEmpty(bookingInfo.get(0).getBunhoLink())){
				response.setBunhoLink(bookingInfo.get(0).getBunhoLink());
			}
			if(!StringUtils.isEmpty(bookingInfo.get(0).getGwaName())){
				response.setGwaName(bookingInfo.get(0).getGwaName());
			}
			if(!StringUtils.isEmpty(bookingInfo.get(0).getDoctorName())){
				response.setDoctorName(bookingInfo.get(0).getDoctorName());
			}
			if(!StringUtils.isEmpty(bookingInfo.get(0).getNaewonDate())){
				response.setNaewonDate(bookingInfo.get(0).getNaewonDate());
			}
			if(!StringUtils.isEmpty(bookingInfo.get(0).getJubsuTime())){
				response.setJubsuTime(bookingInfo.get(0).getJubsuTime());
			}
		}
		
		return response.build();
	}
	
}

