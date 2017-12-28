package nta.mss.model;

import java.sql.Timestamp;
import java.util.List;

import nta.mss.entity.Vaccine;

/**
 * The Class VaccineModel.
 *
 * @author MinhLS
 * @crtDate 2015/01/22
 */
public class VaccineModel extends BaseModel<Vaccine> {

	private static final long serialVersionUID = 6258964206381007670L;

	private Integer vaccineId;
	private Timestamp fromDate;
	private String injectPosition;
	private Integer limitAgeFromMonth;
	private Integer limitAgeToMonth;
	private Timestamp toDate;
	private Integer totalInject;
	private String vaccineName;
	private Integer vaccineStatus;
	private String vaccineType;
	private String vaccineVolume;
	private Integer warningDays;
	private Integer vaccineGroupId;
	private String description;
	private String vaccineCd;
	private List<VaccineChildHistoryModel> vaccineChildHistories;
	private List<VaccineRecommendAgeModel> vaccineRecommendAges;
	private List<VaccineSupportFeeModel> vaccineSupportFees;
	private List<VaccineInjectDayModel> VaccineInjectDays;

	public VaccineModel() {
		super(Vaccine.class);
	}

	public Integer getVaccineId() {
		return this.vaccineId;
	}

	public void setVaccineId(Integer vaccineId) {
		this.vaccineId = vaccineId;
	}

	public Timestamp getFromDate() {
		return this.fromDate;
	}

	public void setFromDate(Timestamp fromDate) {
		this.fromDate = fromDate;
	}

	public String getInjectPosition() {
		return this.injectPosition;
	}

	public void setInjectPosition(String injectPosition) {
		this.injectPosition = injectPosition;
	}

	public Integer getLimitAgeFromMonth() {
		return this.limitAgeFromMonth;
	}

	public void setLimitAgeFromMonth(Integer limitAgeFromMonth) {
		this.limitAgeFromMonth = limitAgeFromMonth;
	}

	public Integer getLimitAgeToMonth() {
		return this.limitAgeToMonth;
	}

	public void setLimitAgeToMonth(Integer limitAgeToMonth) {
		this.limitAgeToMonth = limitAgeToMonth;
	}

	public Timestamp getToDate() {
		return this.toDate;
	}

	public void setToDate(Timestamp toDate) {
		this.toDate = toDate;
	}

	public Integer getTotalInject() {
		return this.totalInject;
	}

	public void setTotalInject(Integer totalInject) {
		this.totalInject = totalInject;
	}

	public String getVaccineName() {
		return this.vaccineName;
	}

	public void setVaccineName(String vaccineName) {
		this.vaccineName = vaccineName;
	}

	public Integer getVaccineStatus() {
		return this.vaccineStatus;
	}

	public void setVaccineStatus(Integer vaccineStatus) {
		this.vaccineStatus = vaccineStatus;
	}

	public String getVaccineType() {
		return this.vaccineType;
	}

	public void setVaccineType(String vaccineType) {
		this.vaccineType = vaccineType;
	}

	public String getVaccineVolume() {
		return this.vaccineVolume;
	}

	public void setVaccineVolume(String vaccineVolume) {
		this.vaccineVolume = vaccineVolume;
	}

	public Integer getWarningDays() {
		return this.warningDays;
	}

	public void setWarningDays(Integer warningDays) {
		this.warningDays = warningDays;
	}

	public List<VaccineChildHistoryModel> getVaccineChildHistories() {
		return this.vaccineChildHistories;
	}

	public void setVaccineChildHistories(List<VaccineChildHistoryModel> vaccineChildHistories) {
		this.vaccineChildHistories = vaccineChildHistories;
	}

	public List<VaccineRecommendAgeModel> getVaccineRecommendAges() {
		return this.vaccineRecommendAges;
	}

	public void setVaccineRecommendAges(List<VaccineRecommendAgeModel> vaccineRecommendAges) {
		this.vaccineRecommendAges = vaccineRecommendAges;
	}

	public List<VaccineSupportFeeModel> getVaccineSupportFees() {
		return this.vaccineSupportFees;
	}

	public void setVaccineSupportFees(List<VaccineSupportFeeModel> vaccineSupportFees) {
		this.vaccineSupportFees = vaccineSupportFees;
	}

	public List<VaccineInjectDayModel> getVaccineInjectDays() {
		return this.VaccineInjectDays;
	}

	public void setVaccineInjectDays(List<VaccineInjectDayModel> VaccineInjectDays) {
		this.VaccineInjectDays = VaccineInjectDays;
	}

	public Integer getVaccineGroupId() {
		return vaccineGroupId;
	}

	public void setVaccineGroupId(Integer vaccineGroupId) {
		this.vaccineGroupId = vaccineGroupId;
	}
	
	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public String getVaccineCd() {
		return vaccineCd;
	}

	public void setVaccineCd(String vaccineCd) {
		this.vaccineCd = vaccineCd;
	}

	@Override
	public String toString() {
		return "VaccineModel [vaccineId=" + vaccineId + ", fromDate="
				+ fromDate + ", injectPosition=" + injectPosition
				+ ", limitAgeFromMonth=" + limitAgeFromMonth
				+ ", limitAgeToMonth=" + limitAgeToMonth + ", toDate=" + toDate
				+ ", totalInject=" + totalInject + ", vaccineName="
				+ vaccineName + ", vaccineStatus=" + vaccineStatus
				+ ", vaccineType=" + vaccineType + ", vaccineVolume="
				+ vaccineVolume + ", warningDays=" + warningDays + "]";
	}

}