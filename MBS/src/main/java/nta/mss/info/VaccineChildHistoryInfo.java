package nta.mss.info;

import java.math.BigDecimal;
import java.sql.Timestamp;

public class VaccineChildHistoryInfo {
	private Integer vaccineChildId;
	private Integer childId;
	private Integer reservationId;
	private Integer vaccineId;
	private String hospitalName;
	private Timestamp injectedDate;
	private Integer injectedNo;
	private BigDecimal activeFlg;
	private Integer vaccineGroupId;
	private String childName;
	private String vaccineName;
	
	public VaccineChildHistoryInfo(Integer vaccineChildId, Integer childId,
			Integer reservationId, Integer vaccineId, String hospitalName,
			Timestamp injectedDate, Integer injectedNo, BigDecimal activeFlg,
			Integer vaccineGroupId, String childName, String vaccineName) {
		this.vaccineChildId = vaccineChildId;
		this.childId = childId;
		this.reservationId = reservationId;
		this.vaccineId = vaccineId;
		this.hospitalName = hospitalName;
		this.injectedDate = injectedDate;
		this.injectedNo = injectedNo;
		this.activeFlg = activeFlg;
		this.vaccineGroupId = vaccineGroupId;
		this.setChildName(childName);
		this.setVaccineName(vaccineName);
	}
	public Integer getVaccineChildId() {
		return vaccineChildId;
	}
	public void setVaccineChildId(Integer vaccineChildId) {
		this.vaccineChildId = vaccineChildId;
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
	public String getHospitalName() {
		return hospitalName;
	}
	public void setHospitalName(String hospitalName) {
		this.hospitalName = hospitalName;
	}
	public Timestamp getInjectedDate() {
		return injectedDate;
	}
	public void setInjectedDate(Timestamp injectedDate) {
		this.injectedDate = injectedDate;
	}
	public Integer getInjectedNo() {
		return injectedNo;
	}
	public void setInjectedNo(Integer injectedNo) {
		this.injectedNo = injectedNo;
	}
	public BigDecimal getActiveFlg() {
		return activeFlg;
	}
	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}
	public Integer getVaccineGroupId() {
		return vaccineGroupId;
	}
	public void setVaccineGroupId(Integer vaccineGroupId) {
		this.vaccineGroupId = vaccineGroupId;
	}
	public String getVaccineName() {
		return vaccineName;
	}
	public void setVaccineName(String vaccineName) {
		this.vaccineName = vaccineName;
	}
	public String getChildName() {
		return childName;
	}
	public void setChildName(String childName) {
		this.childName = childName;
	}
	
}
