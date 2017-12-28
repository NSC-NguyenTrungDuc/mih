package nta.mss.model;

import java.util.Date;
import java.util.List;

import nta.mss.entity.UserChild;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.misc.enums.DateTimeFormat;
import nta.mss.validation.FuriganaText;

import org.hibernate.validator.constraints.NotBlank;

/**
 * The Class UserChildModel.
 *
 * @author MinhLS
 * @crtDate 2015/01/22
 */
public class UserChildModel extends BaseModel<UserChild> {

	private static final long serialVersionUID = 8809443176792584571L;

	private Integer childId;
	@NotBlank
	private String childName;
	@NotBlank
	@FuriganaText
	private String childNameFurigana;
	@NotBlank
	private String dob;
	@NotBlank
	private String sex;
	private List<PatientModel> patients;
	private List<VaccineChildHistoryModel> vaccineChildHistories;
	@SuppressWarnings("unused")
	private Date birthDay;
	private Integer userId;
	private Integer activeFlg;
	private String formattedBirthDay;
	private String genderText;
	private Integer patientId;
	private String patientCode;

	public UserChildModel() {
		super(UserChild.class);
	}

	public Integer getChildId() {
		return this.childId;
	}

	public void setChildId(Integer childId) {
		this.childId = childId;
	}

	public String getChildName() {
		return this.childName;
	}

	public void setChildName(String childName) {
		this.childName = childName;
	}

	public String getChildNameFurigana() {
		return this.childNameFurigana;
	}

	public void setChildNameFurigana(String childNameFurigana) {
		this.childNameFurigana = childNameFurigana;
	}

	public String getDob() {
		return this.dob;
	}

	public void setDob(String dob) {
		this.dob = dob;
	}

	public String getSex() {
		return this.sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public List<PatientModel> getPatients() {
		return this.patients;
	}

	public void setPatients(List<PatientModel> patients) {
		this.patients = patients;
	}

	public List<VaccineChildHistoryModel> getVaccineChildHistories() {
		return this.vaccineChildHistories;
	}

	public void setVaccineChildHistories(List<VaccineChildHistoryModel> vaccineChildHistories) {
		this.vaccineChildHistories = vaccineChildHistories;
	}

	public Date getBirthDay() {
		return MssDateTimeUtil.dateFromString(this.dob, DateTimeFormat.DATE_FORMAT_YYYYMMDD);
	}

	public void setBirthDay(Date birthDay) {
		this.birthDay = birthDay;
	}

	@Override
	public String toString() {
		return "UserChildModel [childId=" + childId + ", childName="
				+ childName + ", childNameFurigana=" + childNameFurigana
				+ ", dob=" + dob + ", sex=" + sex + ", patients=" + patients
				+ "]";
	}

	public Integer getUserId() {
		return userId;
	}

	public void setUserId(Integer userId) {
		this.userId = userId;
	}

	public Integer getActiveFlg() {
		return activeFlg;
	}

	public void setActiveFlg(Integer activeFlg) {
		this.activeFlg = activeFlg;
	}

	public String getFormattedBirthDay() {
		if (this.getBirthDay() != null) {
			return MssDateTimeUtil.convertDateToStringByLocale(new Date(this.getBirthDay().getTime()), DateTimeFormat.DATE_FORMAT_YYYYMMDD, MssContextHolder.getLocale());
		}
		return null;
	}

	public void setFormattedBirthDay(String formattedBirthDay) {
		this.formattedBirthDay = formattedBirthDay;
	}

	public String getGenderText() {
		return genderText;
	}

	public void setGenderText(String genderText) {
		this.genderText = genderText;
	}

	public Integer getPatientId() {
		return patientId;
	}

	public void setPatientId(Integer patientId) {
		this.patientId = patientId;
	}

	public String getPatientCode() {
		return patientCode;
	}

	public void setPatientCode(String patientCode) {
		this.patientCode = patientCode;
	}		
}