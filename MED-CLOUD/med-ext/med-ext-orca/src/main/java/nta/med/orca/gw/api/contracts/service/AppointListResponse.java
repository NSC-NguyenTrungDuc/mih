package nta.med.orca.gw.api.contracts.service;

import java.util.List;

import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

import nta.med.orca.gw.api.contracts.message.AppointlstInformationChild;
import nta.med.orca.gw.api.contracts.message.BaseNode;

public class AppointListResponse {

	private String type;
	private BaseNode informationDate;
	private BaseNode informationTime;
	private BaseNode apiResult;
	private BaseNode apiResultMessage;
	private BaseNode reskey;
	private BaseNode appointmentDate;
	private List<AppointlstInformationChild> appointList;
	
	@JacksonXmlProperty(localName = "type", isAttribute = true)
	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

	@JacksonXmlProperty(localName = "Information_Date")
	public BaseNode getInformationDate() {
		return informationDate;
	}

	public void setInformationDate(BaseNode informationDate) {
		this.informationDate = informationDate;
	}

	@JacksonXmlProperty(localName = "Information_Time")
	public BaseNode getInformationTime() {
		return informationTime;
	}

	public void setInformationTime(BaseNode informationTime) {
		this.informationTime = informationTime;
	}

	@JacksonXmlProperty(localName = "Api_Result")
	public BaseNode getApiResult() {
		return apiResult;
	}

	public void setApiResult(BaseNode apiResult) {
		this.apiResult = apiResult;
	}

	@JacksonXmlProperty(localName = "Api_Result_Message")
	public BaseNode getApiResultMessage() {
		return apiResultMessage;
	}

	public void setApiResultMessage(BaseNode apiResultMessage) {
		this.apiResultMessage = apiResultMessage;
	}

	@JacksonXmlProperty(localName = "Reskey")
	public BaseNode getReskey() {
		return reskey;
	}

	public void setReskey(BaseNode reskey) {
		this.reskey = reskey;
	}

	@JacksonXmlProperty(localName = "Appointment_Date")
	public BaseNode getAppointmentDate() {
		return appointmentDate;
	}

	public void setAppointmentDate(BaseNode appointmentDate) {
		this.appointmentDate = appointmentDate;
	}

	@JacksonXmlProperty(localName = "Appointlst_Information")
	public List<AppointlstInformationChild> getAppointList() {
		return appointList;
	}

	public void setAppointList(List<AppointlstInformationChild> appointList) {
		this.appointList = appointList;
	}	
	
}
