package nta.med.orca.gw.api.contracts.service;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.JacksonXmlModule;
import com.fasterxml.jackson.dataformat.xml.XmlMapper;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlRootElement;

import nta.med.core.utils.CommonUtils;
import nta.med.ext.support.proto.BookingServiceProto;
import nta.med.orca.gw.api.contracts.message.AppointReq;
import nta.med.orca.gw.api.contracts.message.BaseNode;
import nta.med.orca.gw.api.contracts.message.OrcaEnvInfo;

@JsonIgnoreProperties(ignoreUnknown = true)
@JacksonXmlRootElement(localName = "data")
public class AppointmentRequest {

	private AppointReq appointReq;
	private OrcaEnvInfo orcaEnvInfo;
	private String clazz;

	@JacksonXmlProperty(localName = "appointreq")
	public AppointReq getAppointReq() {
		return appointReq;
	}

	public void setAppointReq(AppointReq appointReq) {
		this.appointReq = appointReq;
	}

	@JsonIgnore
	public OrcaEnvInfo getOrcaEnvInfo() {
		return orcaEnvInfo;
	}

	public void setOrcaEnvInfo(OrcaEnvInfo orcaEnvInfo) {
		this.orcaEnvInfo = orcaEnvInfo;
	}

	@JsonIgnore
	public String getClazz() {
		return clazz;
	}

	public void setClazz(String clazz) {
		this.clazz = clazz;
	}

	public String toXml() throws Exception {
		JacksonXmlModule module = new JacksonXmlModule();
		module.setDefaultUseWrapper(true);
		XmlMapper xmlMapper = new XmlMapper(module);
		return xmlMapper.writeValueAsString(this);
	}
	
	public void toRequest(BookingServiceProto.BookingExaminationRequest rq){
		AppointReq appointReq = new AppointReq();
		appointReq.setType("record");
		
		String bookingDate = rq.getReservationDate().replace("/", "-");
		String bookingTime = rq.getReservationTime();
		bookingTime = bookingTime.substring(0, 2) + ":" + bookingTime.substring(2, 4) + ":00";
		
		String orcaPatientId = String.valueOf(CommonUtils.parseInteger(rq.getPatientCode()));
		appointReq.setPatientID(new BaseNode(orcaPatientId));
		appointReq.setWholeName(new BaseNode(rq.getPatientNameKanji()));
		appointReq.setWholeNameInKana(new BaseNode(rq.getPatientNameKana()));
		appointReq.setAppointmentDate(new BaseNode(bookingDate));
		appointReq.setAppointmentTime(new BaseNode(bookingTime));
		appointReq.setAppointmentId(new BaseNode(""));
		appointReq.setDepartmentCode(new BaseNode(rq.getDepartmentCode()));
		appointReq.setPhysicianCode(new BaseNode(rq.getDoctorCode()));
		appointReq.setMedicalInformation(new BaseNode("99"));
		appointReq.setAppointmentInformation(new BaseNode(""));
		appointReq.setAppointmentNote(new BaseNode(""));
		
		this.setClazz("");
		if(rq.hasAction()){
			if(rq.getAction() == BookingServiceProto.BookingExaminationRequest.Action.BOOKING){
				this.setClazz("01");
			} else if(rq.getAction() == BookingServiceProto.BookingExaminationRequest.Action.CANCEL_BOOKING){
				this.setClazz("02");
			}
		}
		
		this.setAppointReq(appointReq);
	}
}
