package nta.med.core.domain.oif;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OIF5102 database table.
 * 
 */
@Entity
@NamedQuery(name="Oif5102.findAll", query="SELECT o FROM Oif5102 o")
public class Oif5102 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String categoriName;
	private String categoriTd;
	private String code;
	private String codeName;
	private String endDate;
	private double fkoif1101;
	private double fkoif5101;
	private String hospCode;
	private String outCome;
	private double pkSeq;
	private String startDate;
	private Date sysDate;
	private String sysId;
	private String system;
	private Date updDate;
	private String updId;

	public Oif5102() {
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


	@Column(name="END_DATE")
	public String getEndDate() {
		return this.endDate;
	}

	public void setEndDate(String endDate) {
		this.endDate = endDate;
	}


	public double getFkoif1101() {
		return this.fkoif1101;
	}

	public void setFkoif1101(double fkoif1101) {
		this.fkoif1101 = fkoif1101;
	}


	public double getFkoif5101() {
		return this.fkoif5101;
	}

	public void setFkoif5101(double fkoif5101) {
		this.fkoif5101 = fkoif5101;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="OUT_COME")
	public String getOutCome() {
		return this.outCome;
	}

	public void setOutCome(String outCome) {
		this.outCome = outCome;
	}


	@Column(name="PK_SEQ")
	public double getPkSeq() {
		return this.pkSeq;
	}

	public void setPkSeq(double pkSeq) {
		this.pkSeq = pkSeq;
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