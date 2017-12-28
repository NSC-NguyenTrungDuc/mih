package nta.med.service.ihis.handler.schs;

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
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.data.model.ihis.schs.SCH0201U99BookingInfo;
import nta.med.data.model.ihis.schs.SCH0201U99ClinicInfo;
import nta.med.data.model.ihis.schs.SCH0201U99ClinicLinkInfo;
import nta.med.data.model.ihis.schs.SCH0201U99PatientInfo;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201U99GetListBookingRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SCH0201U99GetListBookingResponse;

@Service
@Scope("prototype")
public class SCH0201U99GetListBookingHandler extends ScreenHandler<SchsServiceProto.SCH0201U99GetListBookingRequest, SchsServiceProto.SCH0201U99GetListBookingResponse>{
	private static final Log logger = LogFactory.getLog(SCH0201U99GetListBookingHandler.class);
	
	@Resource
	private Sch0201Repository sch0201Repository;
	
	@Override
	@Transactional(readOnly = true)
	public SCH0201U99GetListBookingResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			SCH0201U99GetListBookingRequest request) throws Exception {
		SchsServiceProto.SCH0201U99GetListBookingResponse.Builder response = SchsServiceProto.SCH0201U99GetListBookingResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String hospCodeLink = request.getHospCodeLink();
		String bunhoLink = request.getBunhoLink();
		String reserDate = request.getReserDate();
		String reserTime = request.getReserTime();
		String hangmogCode = request.getHangmogCode();
		// get linked clinic' name
		List<SCH0201U99ClinicLinkInfo> listClinic = sch0201Repository.getLinkedClinic(request.getHospCodeLink(), language);
		if(!CollectionUtils.isEmpty(listClinic)){
			response.setYoyangNameLink(listClinic.get(0).getYoyangName());
			response.setAddressLink(listClinic.get(0).getAddress());
			response.setTelLink(listClinic.get(0).getTel());
		}
		// get linked patient' name
		List<SCH0201U99PatientInfo> patientName = sch0201Repository.getSCH0201U99PatientInfo(hospCode, hospCodeLink, bunhoLink);
		if(!CollectionUtils.isEmpty(patientName)){
			if(!StringUtils.isEmpty(patientName.get(0).getSuname())){
				response.setSuname(patientName.get(0).getSuname());
			}
			if(!StringUtils.isEmpty(patientName.get(0).getBirth())){
				response.setBirth(patientName.get(0).getBirth());
			}
			if(!StringUtils.isEmpty(patientName.get(0).getAge())){
				response.setAge(CommonUtils.parseString(patientName.get(0).getAge()));
			}
			if(!StringUtils.isEmpty(patientName.get(0).getBunho())){
				response.setBunho(patientName.get(0).getBunho());
			}
		}
		// get clinic info
		List<SCH0201U99ClinicInfo> clinicInfo = sch0201Repository.getSCH0201U99ClinicInfo(hospCode, language, bunhoLink, hospCodeLink, reserDate, reserTime);
		if(!CollectionUtils.isEmpty(clinicInfo)){
			if(!StringUtils.isEmpty(clinicInfo.get(0).getYoyangName())){
				response.setYoyangName(clinicInfo.get(0).getYoyangName());
			}
			if(!StringUtils.isEmpty(clinicInfo.get(0).getGwaName())){
				response.setGwaName(clinicInfo.get(0).getGwaName());
			}
			if(!StringUtils.isEmpty(clinicInfo.get(0).getDoctorName())){
				response.setDoctorName(clinicInfo.get(0).getDoctorName());
			}
		}
		
		
		// booking info
		List<SCH0201U99BookingInfo> listBookingInfo = sch0201Repository.getSCH0201U99BookingInfo(hospCode, language, bunhoLink, hospCodeLink, hangmogCode, reserDate);
		if(!CollectionUtils.isEmpty(listBookingInfo)){
			for (SCH0201U99BookingInfo sch0201u99BookingInfo : listBookingInfo) {
				SchsModelProto.SCH0201U99BookingInfo.Builder info = SchsModelProto.SCH0201U99BookingInfo.newBuilder();
				BeanUtils.copyProperties(sch0201u99BookingInfo, info, getLanguage(vertx, sessionId));
				response.addBookingList(info);
			}
		}
		
		// barcode linked patient
		String barcodeString = sch0201Repository.getBarcodeLinkedPatient(bunhoLink);
		if(!StringUtils.isEmpty(barcodeString)){
			response.setBunhoLink(barcodeString);
		}
		
		return response.build();
	}
	
}

