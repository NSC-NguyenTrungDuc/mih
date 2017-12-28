package nta.med.core.domain.oif;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OIF5101 database table.
 * 
 */
@Entity
//@NamedQuery(name="Oif5101.findAll", query="SELECT o FROM Oif5101 o")
@Table(name="OIF5101")
public class Oif5101 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String categoriName;
	private String categoriTd;
	private String code;
	private String codeName;
	private String docUid;
	private String endDate;
	private Double fkoif1101;
	private String gwa;
	private String gwaName;
	private String hospCode;
	private String license;
	private String outCome;
	private Double pkoif5101;
	private String startDate;
	private Date sysDate;
	private String sysId;
	private String system;
	private Date updDate;
	private String updId;

	public Oif5101() {
	}


	@Column(name="CATEGORI_NAME")
	public String getCategoriName() {
		return this.categoriName;
	}

	public void setCategoriName(String categoriName) {
		this.categoriName = categoriName;
	}


	@Column(name="CATEGORI_TD")
	public String getCategoriTd() {
		return this.categoriTd;
	}

	public void setCategoriTd(String categoriTd) {
		this.categoriTd = categoriTd;
	}


	public String getCode() {
		return this.code;
	}

	public void setCode(String code) {
		this.code = code;
	}


	@Column(name="CODE_NAME")
	public String getCodeName() {
		return this.codeName;
	}

	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}


	@Column(name="DOC_UID")
	public String getDocUid() {
		return this.docUid;
	}

	public void setDocUid(String docUid) {
		this.docUid = docUid;
	}


	@Column(name="END_DATE")
	public String getEndDate() {
		return this.endDate;
	}

	public void setEndDate(String endDate) {
		this.endDate = endDate;
	}


	public Double getFkoif1101() {
		return this.fkoif1101;
	}

	public void setFkoif1101(Double fkoif1101) {
		this.fkoif1101 = fkoif1101;
	}


	public String getGwa() {
		return this.gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}


	@Column(name="GWA_NAME")
	public String getGwaName() {
		return this.gwaName;
	}

	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getLicense() {
		return this.license;
	}

	public void setLicense(String license) {
		this.license = license;
	}


	@Column(name="OUT_COME")
	public String getOutCome() {
		return this.outCome;
	}

	public void setOutCome(String outCome) {
		this.outCome = outCome;
	}


	public Double getPkoif5101() {
		return this.pkoif5101;
	}

	public void setPkoif5101(Double pkoif5101) {
		this.pkoif5101 = pkoif5101;
	}


	@Column(name="START_DATE")
	public String getStartDate() {
		return this.startDate;
	}

	public void setStartDate(String startDate) {
		this.startDate = startDate;
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


	public String getSystem() {
		return this.system;
	}

	public void setSystem(String system) {
		this.system = system;
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

}