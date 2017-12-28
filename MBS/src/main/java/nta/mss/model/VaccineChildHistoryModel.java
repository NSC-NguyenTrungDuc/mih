package nta.mss.model;

import java.sql.Timestamp;

import javax.validation.constraints.NotNull;

import org.hibernate.validator.constraints.NotBlank;

import nta.mss.entity.VaccineChildHistory;

/**
 * The Class VaccineChildHistory.
 *
 * @author MinhLS
 * @crtDate 2015/01/22
 */
public class VaccineChildHistoryModel extends BaseModel<VaccineChildHistory> {

	private static final long serialVersionUID = -1093736115165446887L;
	
	private Integer vaccineChildId;
	@NotNull
	private Integer childId;
	private Integer reservationId;
	@NotNull
	private Integer vaccineId;
	@NotBlank
	private String hospitalName;
	private Timestamp injectedDate;
	private Integer injectedNo;
	private Integer activeFlg;
	@NotNull
	private String injectedDateStr;
	private String vaccineName;
	private String dayAge;
	private String dob;
	private Integer reservationStatus;
	private Integer vaccineHospitalId;
	private Integer loginHospitalId;
	private String kcckVaccineCode;

	public VaccineChildHistoryModel() {
		super(VaccineChildHistory.class);
	}

	public Integer getVaccineChildId() {
		return this.vaccineChildId;
	}

	public void setVaccineChildId(Integer vaccineChildId) {
		this.vaccineChildId = vaccineChildId;
	}

	public String getHospitalName() {
		return this.hospitalName;
	}

	public void setHospitalName(String hospitalName) {
		this.hospitalName = hospitalName;
	}

	public Timestamp getInjectedDate() {
		return this.injectedDate;
	}

	public void setInjectedDate(Timestamp injectedDate) {
		this.injectedDate = injectedDate;
	}

	public Integer getInjectedNo() {
		return this.injectedNo;
	}

	public void setInjectedNo(Integer injectedNo) {
		this.injectedNo = injectedNo;
	}

	public Integer getChildId() {
		return childId;
	}

	public void setChildId(Integer childId) {
		this.childId = childId;
	}

	public Integer getReservationId() {
		return reservationId;
	}

	public void setReservationId(Integer reservationId) {
		this.reservationId = reservationId;
	}
	
	public Integer getVaccineId() {
		return vaccineId;
	}

	public void setVaccineId(Integer vaccineId) {
		this.vaccineId = vaccineId;
	}


	@Override
	public String toString() {
		return "VaccineChildHistory [vaccineChildId=" + vaccineChildId
				+ ", hospitalName=" + hospitalName + ", injectedDate="
				+ injectedDate + ", injectedNo=" + injectedNo + "]";
	}

	public Integer getActiveFlg() {
		return activeFlg;
	}

	public void setActiveFlg(Integer activeFlg) {
		this.activeFlg = activeFlg;
	}

	public String getInjectedDateStr() {
		return injectedDateStr;
	}

	public void setInjectedDateStr(String injectedDateStr) {
		this.injectedDateStr = injectedDateStr;
	}

	public String getVaccineName() {
		return vaccineName;
	}

	public void setVaccineName(String vaccineName) {
		this.vaccineName = vaccineName;
	}

	public String getDayAge() {
		return dayAge;
	}

	public void setDayAge(String dayAge) {
		this.dayAge = dayAge;
	}

	public String getDob() {
		return dob;
	}

	public void setDob(String dob) {
		this.dob = dob;
	}

	public Integer getReservationStatus() {
		return reservationStatus;
	}

	public void setReservationStatus(Integer reservationStatus) {
		this.reservationStatus = reservationStatus;
	}

	public Integer getVaccineHospitalId() {
		return vaccineHospitalId;
	}

	public void setVaccineHospitalId(Integer vaccineHospitalId) {
		this.vaccineHospitalId = vaccineHospitalId;
	}

	public Integer getLoginHospitalId() {
		return loginHospitalId;
	}

	public void setLoginHospitalId(Integer loginHospitalId) {
		this.loginHospitalId = loginHospitalId;
	}

	public String getKcckVaccineCode() {
		return kcckVaccineCode;
	}

	public void setKcckVaccineCode(String kcckVaccineCode) {
		this.kcckVaccineCode = kcckVaccineCode;
	}
	
}