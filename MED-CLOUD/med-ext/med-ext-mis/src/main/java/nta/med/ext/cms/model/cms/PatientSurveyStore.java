package nta.med.ext.cms.model.cms;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.dataformat.xml.JacksonXmlModule;
import com.fasterxml.jackson.dataformat.xml.XmlMapper;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlElementWrapper;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlProperty;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlRootElement;
import nta.med.ext.support.proto.HospitalModelProto;

@JsonIgnoreProperties(ignoreUnknown = true)
@JacksonXmlRootElement(localName = "survey")
public class PatientSurveyStore {

	private Long id;

	private String description;

	@JacksonXmlProperty(localName = "survey_title")
	@JsonProperty("survey_title")
	private String title;

	@JacksonXmlProperty(localName = "department_code")
	@JsonProperty("department_code")
	private String departmentCode;

	@JacksonXmlProperty(localName = "department_name")
	@JsonProperty("department_name")
	private String departmentName;

	@JacksonXmlProperty(localName = "patient_code")
	@JsonProperty("patient_code")
	private String patientCode;

	@JacksonXmlProperty(localName = "patient_name")
	@JsonProperty("patient_name")
	private String patientName;

	@JacksonXmlProperty(localName = "reservation_date")
	@JsonProperty("reservation_date")
	private Date reservationDate;

	@JacksonXmlProperty(localName = "reservation_time")
	@JsonProperty("reservation_time")
	private String reservationTime;

	@JacksonXmlProperty(localName = "answer_date")
	@JsonProperty("answer_date")
	private String answerDate;

	private List<QuestionGroupStore> group;

	@JsonIgnore
	private boolean result;

	@JsonIgnore
	private String error;

	@JacksonXmlProperty(localName = "description")
	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	@JacksonXmlProperty(localName = "group")
	@JacksonXmlElementWrapper(useWrapping = false)
	public List<QuestionGroupStore> getGroup() {
		return group;
	}

	private RelationSurveyModel relateSurvey;

	private HospitalInfoModel hospitalInfoModel;

	private BigDecimal statusFlg ;

	public void setGroup(List<QuestionGroupStore> group) {
		this.group = group;
	}

	public String toXml() throws Exception {
		JacksonXmlModule module = new JacksonXmlModule();
		module.setDefaultUseWrapper(true);
		XmlMapper xmlMapper = new XmlMapper(module);
		return xmlMapper.writeValueAsString(this);
	}

	@JsonProperty("relate_survey")
	public RelationSurveyModel getRelateSurvey() {
		return relateSurvey;
	}

	@JsonProperty("hospital_info")
	public HospitalInfoModel getHospitalInfoModel() {
		return hospitalInfoModel;
	}

	public void setHospitalInfoModel(HospitalInfoModel hospitalInfoModel) {
		this.hospitalInfoModel = hospitalInfoModel;
	}

	public void setRelateSurvey(RelationSurveyModel relateSurvey) {
		this.relateSurvey = relateSurvey;
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getTitle() {
		return title;
	}

	public void setTitle(String title) {
		this.title = title;
	}

	public String getDepartmentCode() {
		return departmentCode;
	}

	public void setDepartmentCode(String departmentCode) {
		this.departmentCode = departmentCode;
	}

	public String getDepartmentName() {
		return departmentName;
	}

	public void setDepartmentName(String departmentName) {
		this.departmentName = departmentName;
	}

	public String getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}

	public String getPatientName() {
		return patientName;
	}

	public void setPatientName(String patientName) {
		this.patientName = patientName;
	}

	public Date getReservationDate() {
		return reservationDate;
	}

	public void setReservationDate(Date reservationDate) {
		this.reservationDate = reservationDate;
	}

	public String getReservationTime() {
		return reservationTime;
	}

	public void setReservationTime(String reservationTime) {
		this.reservationTime = reservationTime;
	}

	public String getAnswerDate() {
		return answerDate;
	}

	public void setAnswerDate(String answerDate) {
		this.answerDate = answerDate;
	}

	public boolean isResult() {
		return result;
	}

	public void setResult(boolean result) {
		this.result = result;
	}

	public String getError() {
		return error;
	}

	public void setError(String error) {
		this.error = error;
	}
	@JsonProperty("status_flg")
	public BigDecimal getStatusFlg() {
		return statusFlg;
	}

	public void setStatusFlg(BigDecimal statusFlg) {
		this.statusFlg = statusFlg;
	}
}
