package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OCS0150 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs0150.findAll", query="SELECT o FROM Ocs0150 o")
@Table(name="OCS0150")
public class Ocs0150 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String allergyPopYn;
	private String doOrderPopYn;
	private String doctor;
	private String drgPrtYn;
	private String emrPopYn;
	private String generalDispYn;
	private String gwa;
	private String hospCode;
	private String ioGubun;
	private String orderLabelPrtYn;
	private String reserPrtYn;
	private String sameNameCheckYn;
	private String sentouSearchYn;
	private String specialwritePopYn;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String vitalsignsPopYn;
	private String xrtPrtYn;
	private String checkingDrgYn;
	private String potionDrugYn;
	private String diseaseUnregisteredYn;
	private String infectionPopYn;

	public Ocs0150() {
	}


	@Column(name="ALLERGY_POP_YN")
	public String getAllergyPopYn() {
		return this.allergyPopYn;
	}

	public void setAllergyPopYn(String allergyPopYn) {
		this.allergyPopYn = allergyPopYn;
	}


	@Column(name="DO_ORDER_POP_YN")
	public String getDoOrderPopYn() {
		return this.doOrderPopYn;
	}

	public void setDoOrderPopYn(String doOrderPopYn) {
		this.doOrderPopYn = doOrderPopYn;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	@Column(name="DRG_PRT_YN")
	public String getDrgPrtYn() {
		return this.drgPrtYn;
	}

	public void setDrgPrtYn(String drgPrtYn) {
		this.drgPrtYn = drgPrtYn;
	}


	@Column(name="EMR_POP_YN")
	public String getEmrPopYn() {
		return this.emrPopYn;
	}

	public void setEmrPopYn(String emrPopYn) {
		this.emrPopYn = emrPopYn;
	}


	@Column(name="GENERAL_DISP_YN")
	public String getGeneralDispYn() {
		return this.generalDispYn;
	}

	public void setGeneralDispYn(String generalDispYn) {
		this.generalDispYn = generalDispYn;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IO_GUBUN")
	public String getIoGubun() {
		return this.ioGubun;
	}

	public void setIoGubun(String ioGubun) {
		this.ioGubun = ioGubun;
	}


	@Column(name="ORDER_LABEL_PRT_YN")
	public String getOrderLabelPrtYn() {
		return this.orderLabelPrtYn;
	}

	public void setOrderLabelPrtYn(String orderLabelPrtYn) {
		this.orderLabelPrtYn = orderLabelPrtYn;
	}


	@Column(name="RESER_PRT_YN")
	public String getReserPrtYn() {
		return this.reserPrtYn;
	}

	public void setReserPrtYn(String reserPrtYn) {
		this.reserPrtYn = reserPrtYn;
	}


	@Column(name="SAME_NAME_CHECK_YN")
	public String getSameNameCheckYn() {
		return this.sameNameCheckYn;
	}

	public void setSameNameCheckYn(String sameNameCheckYn) {
		this.sameNameCheckYn = sameNameCheckYn;
	}


	@Column(name="SENTOU_SEARCH_YN")
	public String getSentouSearchYn() {
		return this.sentouSearchYn;
	}

	public void setSentouSearchYn(String sentouSearchYn) {
		this.sentouSearchYn = sentouSearchYn;
	}


	@Column(name="SPECIALWRITE_POP_YN")
	public String getSpecialwritePopYn() {
		return this.specialwritePopYn;
	}

	public void setSpecialwritePopYn(String specialwritePopYn) {
		this.specialwritePopYn = specialwritePopYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}


	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}


	@Column(name="UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}


	@Column(name="VITALSIGNS_POP_YN")
	public String getVitalsignsPopYn() {
		return this.vitalsignsPopYn;
	}

	public void setVitalsignsPopYn(String vitalsignsPopYn) {
		this.vitalsignsPopYn = vitalsignsPopYn;
	}


	@Column(name="XRT_PRT_YN")
	public String getXrtPrtYn() {
		return this.xrtPrtYn;
	}

	public void setXrtPrtYn(String xrtPrtYn) {
		this.xrtPrtYn = xrtPrtYn;
	}

	@Column(name="CHECKING_DRUG_YN")
	public String getCheckingDrgYn() {
		return this.checkingDrgYn;
	}

	public void setCheckingDrgYn(String checkingDrgYn) {
		this.checkingDrgYn = checkingDrgYn;
	}
	
	@Column(name="POTION_DRUG_YN")
	public String getPotionDrugYn() {
		return potionDrugYn;
	}


	public void setPotionDrugYn(String potionDrugYn) {
		this.potionDrugYn = potionDrugYn;
	}

	@Column(name="DISEASE_UNREGISTERED_YN")
	public String getDiseaseUnregisteredYn() {
		return diseaseUnregisteredYn;
	}


	public void setDiseaseUnregisteredYn(String diseaseUnregisteredYn) {
		this.diseaseUnregisteredYn = diseaseUnregisteredYn;
	}

	@Column(name="INFECTION_POP_YN")
	public String getInfectionPopYn() {
		return infectionPopYn;
	}


	public void setInfectionPopYn(String infectionPopYn) {
		this.infectionPopYn = infectionPopYn;
	}


	@Override
	public String toString() {
		return "Ocs0150 [allergyPopYn=" + allergyPopYn + ", doOrderPopYn="
				+ doOrderPopYn + ", doctor=" + doctor + ", drgPrtYn="
				+ drgPrtYn + ", emrPopYn=" + emrPopYn + ", generalDispYn="
				+ generalDispYn + ", gwa=" + gwa + ", hospCode=" + hospCode
				+ ", ioGubun=" + ioGubun + ", orderLabelPrtYn="
				+ orderLabelPrtYn + ", reserPrtYn=" + reserPrtYn
				+ ", sameNameCheckYn=" + sameNameCheckYn + ", sentouSearchYn="
				+ sentouSearchYn + ", specialwritePopYn=" + specialwritePopYn
				+ ", sysDate=" + sysDate + ", sysId=" + sysId + ", updDate="
				+ updDate + ", updId=" + updId + ", vitalsignsPopYn="
				+ vitalsignsPopYn + ", xrtPrtYn=" + xrtPrtYn + ", checkingDrgYn=" 
				+ checkingDrgYn + ", potionDrugYn=" + potionDrugYn 
				+ ", diseaseUnregisteredYn=" + diseaseUnregisteredYn 
				+ ", infectionPopYn=" + infectionPopYn + "]";
	}

}