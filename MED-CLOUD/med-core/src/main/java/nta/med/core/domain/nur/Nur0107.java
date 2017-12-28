package nta.med.core.domain.nur;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the NUR0107 database table.
 * 
 */
@Entity
@NamedQuery(name="Nur0107.findAll", query="SELECT n FROM Nur0107 n")
public class Nur0107 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String bunho;
	private double fkinp1001;
	private String hospCode;
	private String printGubun01;
	private String printGubun02;
	private String printGubun03;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Nur0107() {
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public double getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="PRINT_GUBUN_01")
	public String getPrintGubun01() {
		return this.printGubun01;
	}

	public void setPrintGubun01(String printGubun01) {
		this.printGubun01 = printGubun01;
	}


	@Column(name="PRINT_GUBUN_02")
	public String getPrintGubun02() {
		return this.printGubun02;
	}

	public void setPrintGubun02(String printGubun02) {
		this.printGubun02 = printGubun02;
	}


	@Column(name="PRINT_GUBUN_03")
	public String getPrintGubun03() {
		return this.printGubun03;
	}

	public void setPrintGubun03(String printGubun03) {
		this.printGubun03 = printGubun03;
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

}