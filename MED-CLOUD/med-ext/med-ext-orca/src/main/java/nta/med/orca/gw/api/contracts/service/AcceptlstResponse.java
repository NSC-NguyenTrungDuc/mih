package nta.med.orca.gw.api.contracts.service;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;

import nta.med.orca.gw.api.contracts.message.AcceptlstInfo;

@JsonIgnoreProperties(ignoreUnknown = true)
public class AcceptlstResponse {

	private String informationDate;
	private String informationTime;
	private String apiResult;
	private String apiResultMessage;
	private String reskey;
	private String acceptanceDate;
	private List<AcceptlstInfo> acceptlstInformation;

	@JacksonXmlProperty(localName = "Information_Date")
	public String getInformationDate() {
		return informationDate;
	}

	public void setInformationDate(String informationDate) {
		this.informationDate = informationDate;
	}

	@JacksonXmlProperty(localName = "Information_Time")
	public String getInformationTime() {
		return informationTime;
	}

	public void setInformationTime(String informationTime) {
		this.informationTime = informationTime;
	}

	@JacksonXmlProperty(localName = "Api_Result")
	public String getApiResult() {
		return apiResult;
	}

	public void setApiResult(String apiResult) {
		this.apiResult = apiResult;
	}

	@JacksonXmlProperty(localName = "Api_Result_Message")
	public String getApiResultMessage() {
		return apiResultMessage;
	}

	public void setApiResultMessage(String apiResultMessage) {
		this.apiResultMessage = apiResultMessage;
	}

	@JacksonXmlProperty(localName = "Reskey")
	public String getReskey() {
		return reskey;
	}

	public void setReskey(String reskey) {
		this.reskey = reskey;
	}

	@JacksonXmlProperty(localName = "Acceptance_Date")
	public String getAcceptanceDate() {
		return acceptanceDate;
	}

	public void setAcceptanceDate(String acceptanceDate) {
		this.acceptanceDate = acceptanceDate;
	}

	@JacksonXmlProperty(localName = "Acceptlst_Information")
	public List<AcceptlstInfo> getAcceptlstInformation() {
		return acceptlstInformation;
	}

	public void setAcceptlstInformation(List<AcceptlstInfo> acceptlstInformation) {
		this.acceptlstInformation = acceptlstInformation;
	}

}
