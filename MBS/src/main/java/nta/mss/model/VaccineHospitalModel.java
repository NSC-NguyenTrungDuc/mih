package nta.mss.model;

import java.io.Serializable;
import java.math.BigDecimal;
import java.sql.Timestamp;
import java.util.List;

import javax.validation.constraints.NotNull;

import org.hibernate.validator.constraints.NotBlank;
import org.springframework.format.annotation.NumberFormat;

import nta.mss.entity.VaccineHospital;

/**
 * The Class VaccineHospitalModel.
 *
 * @author MinhLS
 * @crtDate 2015/03/25
 */
public class VaccineHospitalModel extends BaseModel<VaccineHospital> implements Serializable {
	private static final long serialVersionUID = 1L;

	private Integer vaccineHospitalId;
	private String description;
	private Timestamp fromDate;
	private Timestamp toDate;
	@NotNull
	private BigDecimal vaccineStatus;
	@NotNull
	@NumberFormat
	private Integer warningDays;
	@NotNull
	private Integer vaccineId;
	private Integer hospitalId;
	private List<VaccineChildHistoryModel> vaccineChildHistories;
	private String vaccineName;
	private String strFromDate;
	private String strToDate;
	private Integer active_flg;
	private String kcckVaccineCode;
	
	public VaccineHospitalModel() {
		super(VaccineHospital.class);
	}

	public Integer getVaccineHospitalId() {
		return vaccineHospitalId;
	}

	public void setVaccineHospitalId(Integer vaccineHospitalId) {
		this.vaccineHospitalId = vaccineHospitalId;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public Timestamp getFromDate() {
		return fromDate;
	}

	public void setFromDate(Timestamp fromDate) {
		this.fromDate = fromDate;
	}

	public Timestamp getToDate() {
		return toDate;
	}

	public void setToDate(Timestamp toDate) {
		this.toDate = toDate;
	}

	public BigDecimal getVaccineStatus() {
		return vaccineStatus;
	}

	public void setVaccineStatus(BigDecimal vaccineStatus) {
		this.vaccineStatus = vaccineStatus;
	}

	public Integer getWarningDays() {
		return warningDays;
	}

	public void setWarningDays(Integer warningDays) {
		this.warningDays = warningDays;
	}

	public Integer getVaccineId() {
		return vaccineId;
	}

	public void setVaccineId(Integer vaccineId) {
		this.vaccineId = vaccineId;
	}

	public Integer getHospitalId() {
		return hospitalId;
	}

	public void setHospitalId(Integer hospitalId) {
		this.hospitalId = hospitalId;
	}

	public List<VaccineChildHistoryModel> getVaccineChildHistories() {
		return vaccineChildHistories;
	}

	public void setVaccineChildHistories(
			List<VaccineChildHistoryModel> vaccineChildHistories) {
		this.vaccineChildHistories = vaccineChildHistories;
	}

	public String getVaccineName() {
		return vaccineName;
	}

	public void setVaccineName(String vaccineName) {
		this.vaccineName = vaccineName;
	}

	public String getStrFromDate() {
		return strFromDate;
	}

	public void setStrFromDate(String strFromDate) {
		this.strFromDate = strFromDate;
	}

	public String getStrToDate() {
		return strToDate;
	}

	public void setStrToDate(String strToDate) {
		this.strToDate = strToDate;
	}

	public Integer getActive_flg() {
		return active_flg;
	}

	public void setActive_flg(Integer active_flg) {
		this.active_flg = active_flg;
	}

	public String getKcckVaccineCode() {
		return kcckVaccineCode;
	}

	public void setKcckVaccineCode(String kcckVaccineCode) {
		this.kcckVaccineCode = kcckVaccineCode;
	}

	
}