package nta.med.core.domain.ocs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the OCS2021 database table.
 * 
 */
@Entity
@NamedQuery(name="Ocs2021.findAll", query="SELECT o FROM Ocs2021 o")
public class Ocs2021 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String aboType;
	private String bunho;
	private String confirmYn;
	private double height;
	private String hospCode;
	private double pkinp1001;
	private String remark1;
	private String remark10;
	private String remark2;
	private String remark3;
	private String remark4;
	private String remark5;
	private String remark6;
	private String remark7;
	private String remark8;
	private String remark9;
	private Date sysDate;
	private String sysId;
	private String team;
	private double tp;
	private Date updDate;
	private String updId;
	private double weight;

	public Ocs2021() {
	}


	@Column(name="ABO_TYPE")
	public String getAboType() {
		return this.aboType;
	}

	public void setAboType(String aboType) {
		this.aboType = aboType;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	@Column(name="CONFIRM_YN")
	public String getConfirmYn() {
		return this.confirmYn;
	}

	public void setConfirmYn(String confirmYn) {
		this.confirmYn = confirmYn;
	}


	public double getHeight() {
		return this.height;
	}

	public void setHeight(double height) {
		this.height = height;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public double getPkinp1001() {
		return this.pkinp1001;
	}

	public void setPkinp1001(double pkinp1001) {
		this.pkinp1001 = pkinp1001;
	}


	public String getRemark1() {
		return this.remark1;
	}

	public void setRemark1(String remark1) {
		this.remark1 = remark1;
	}


	public String getRemark10() {
		return this.remark10;
	}

	public void setRemark10(String remark10) {
		this.remark10 = remark10;
	}


	public String getRemark2() {
		return this.remark2;
	}

	public void setRemark2(String remark2) {
		this.remark2 = remark2;
	}


	public String getRemark3() {
		return this.remark3;
	}

	public void setRemark3(String remark3) {
		this.remark3 = remark3;
	}


	public String getRemark4() {
		return this.remark4;
	}

	public void setRemark4(String remark4) {
		this.remark4 = remark4;
	}


	public String getRemark5() {
		return this.remark5;
	}

	public void setRemark5(String remark5) {
		this.remark5 = remark5;
	}


	public String getRemark6() {
		return this.remark6;
	}

	public void setRemark6(String remark6) {
		this.remark6 = remark6;
	}


	public String getRemark7() {
		return this.remark7;
	}

	public void setRemark7(String remark7) {
		this.remark7 = remark7;
	}


	public String getRemark8() {
		return this.remark8;
	}

	public void setRemark8(String remark8) {
		this.remark8 = remark8;
	}


	public String getRemark9() {
		return this.remark9;
	}

	public void setRemark9(String remark9) {
		this.remark9 = remark9;
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


	public String getTeam() {
		return this.team;
	}

	public void setTeam(String team) {
		this.team = team;
	}


	public double getTp() {
		return this.tp;
	}

	public void setTp(double tp) {
		this.tp = tp;
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


	public double getWeight() {
		return this.weight;
	}

	public void setWeight(double weight) {
		this.weight = weight;
	}

}