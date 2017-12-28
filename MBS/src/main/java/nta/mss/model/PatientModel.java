package nta.mss.model;

import java.util.Date;
import java.util.Map;

import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;

import nta.mss.entity.Patient;
import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.misc.enums.*;
import nta.mss.validation.CheckSpecialChar;
import nta.mss.validation.Email;
import nta.mss.validation.Phone;
import nta.mss.validation.FuriganaText;

import org.apache.commons.fileupload.FileUpload;
import org.hibernate.validator.constraints.NotBlank;
import org.springframework.web.multipart.MultipartFile;

/**
 * The Class PatientModel.
 *
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 */
@SuppressWarnings("unused")
public class PatientModel extends BaseModel<Patient> {
	private static final long serialVersionUID = 1L;

	@NotBlank
//	@Size(max=64)
	private String name;
	@NotBlank
//	@Size(max=64)	
	private String nameFurigana;
	@NotBlank
	@Phone
	private String phoneNumber;
	@NotBlank
	@Email
	private String email;
	@NotBlank
	private String gender;
	private String dob;
	private Date birthDay;
	private Integer reminderTime = ReminderTime.BEFORE_30_MINUTES.toKey();
	@CheckSpecialChar
	private String cardNumber;
	private Map<Integer,String> mapReminderTime;

	private Integer patientId;
	private boolean isNewBooking;
	private Integer childId;
	private String genderText;
	private String formattedBirthDay;
	private String kcckParentCode;
	private String patientIconPath;
	private MultipartFile file;

	//Add field profileId for movietalk
	private Long profileId;

	/**
	 * Instantiates a new patient model.
	 */
	public PatientModel() {
		super(Patient.class);
	}
	public String getPhoneNumber() {
		return phoneNumber;
	}

	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public Integer getPatientId() {
		return patientId;
	}

	public void setPatientId(Integer patientId) {
		this.patientId = patientId;
	}

	public String getCardNumber() {
		return cardNumber;
	}

	public void setCardNumber(String cardNumber) {
		this.cardNumber = cardNumber;
	}

	public String getNameFurigana() {
		return nameFurigana;
	}

	public void setNameFurigana(String nameFurigana) {
		this.nameFurigana = nameFurigana;
	}

	public Integer getReminderTime() {
		return reminderTime;
	}

	public void setReminderTime(Integer reminderTime) {
		this.reminderTime = reminderTime;
	}

	public Map<Integer, String> getMapReminderTime() {
		return mapReminderTime;
	}

	public void setMapReminderTime(Map<Integer, String> mapReminderTime) {
		this.mapReminderTime = mapReminderTime;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	@Override
	public String toString() {
		return "PatientModel [name=" + name + ", nameFurigana=" + nameFurigana + ", phoneNumber=" + phoneNumber
				+ ", email=" + email + ", gender=" + gender + ", dob=" + dob + ", reminderTime=" + reminderTime
				+ ", cardNumber=" + cardNumber + ", mapReminderTime=" + mapReminderTime + ", patientId=" + patientId
				+ ", isNewBooking=" + isNewBooking + ", childId=" + childId + "]";
	}

	public boolean isNewBooking() {
		return isNewBooking;
	}

	public void setNewBooking(boolean isNewBooking) {
		this.isNewBooking = isNewBooking;
	}

	public Integer getChildId() {
		return childId;
	}

	public void setChildId(Integer childId) {
		this.childId = childId;
	}
	public String getGender() {
		return gender;
	}
	public void setGender(String gender) {
		this.gender = gender;
	}
	public String getDob() {
		return this.dob;
	}

	public void setDob(String dob) {
		this.dob = dob;
	}

	public Date getBirthDay() {
		return birthDay;
	}

	public void setBirthDay(Date birthDay) {
		this.birthDay = birthDay;
	}
	public String getGenderText() {
		return genderText;
	}
	public void setGenderText(String genderText) {
		this.genderText = genderText;
	}
	public String getFormattedBirthDay() {
		if (this.dob != null) {
			return MssDateTimeUtil.convertStringDateByLocale(this.dob, DateTimeFormat.DATE_FORMAT_YYYYMMDD_EXTEND, MssContextHolder.getLocale());
		}
		return null;
	}

	public void setFormattedBirthDay(String formattedBirthDay) {
		this.formattedBirthDay = formattedBirthDay;
	}
	public String getKcckParentCode() {
		return kcckParentCode;
	}
	public void setKcckParentCode(String kcckParentCode) {
		this.kcckParentCode = kcckParentCode;
	}
	public MultipartFile getFile() {
		return file;
	}
	public void setFile(MultipartFile file) {
		this.file = file;
	}
	public String getPatientIconPath() {
		return patientIconPath;
	}
	public void setPatientIconPath(String patientIconPath) {
		this.patientIconPath = patientIconPath;
	}
	public Long getProfileId() {
		return profileId;
	}
	public void setProfileId(Long profileId) {
		this.profileId = profileId;
	}

}