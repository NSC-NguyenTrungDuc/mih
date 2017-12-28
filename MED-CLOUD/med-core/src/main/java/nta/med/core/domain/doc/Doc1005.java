package nta.med.core.domain.doc;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the DOC1005 database table.
 * 
 */
@Entity
@NamedQuery(name="Doc1005.findAll", query="SELECT d FROM Doc1005 d")
public class Doc1005 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Date balbyoungDate;
	private String bonjuk;
	private double fkdoc1001;
	private String haebuView;
	private String hospCode;
	private String jikjong;
	private String sagoAddress;
	private Date sagoDate;
	private String sagoGubun;
	private String sagoGubunText;
	private String sagoJangso;
	private String sagoJangsoText;
	private String sagoSanghwang;
	private String sain1;
	private String sain2;
	private String sain3;
	private String sain4;
	private String samangAddress;
	private Date samangDate;
	private String samangGigan;
	private String samangGubun1;
	private String samangGubun2;
	private String samangJangso;
	private Date susulDate;
	private String susulView;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Doc1005() {
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="BALBYOUNG_DATE")
	public Date getBalbyoungDate() {
		return this.balbyoungDate;
	}

	public void setBalbyoungDate(Date balbyoungDate) {
		this.balbyoungDate = balbyoungDate;
	}


	public String getBonjuk() {
		return this.bonjuk;
	}

	public void setBonjuk(String bonjuk) {
		this.bonjuk = bonjuk;
	}


	public double getFkdoc1001() {
		return this.fkdoc1001;
	}

	public void setFkdoc1001(double fkdoc1001) {
		this.fkdoc1001 = fkdoc1001;
	}


	@Column(name="HAEBU_VIEW")
	public String getHaebuView() {
		return this.haebuView;
	}

	public void setHaebuView(String haebuView) {
		this.haebuView = haebuView;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	public String getJikjong() {
		return this.jikjong;
	}

	public void setJikjong(String jikjong) {
		this.jikjong = jikjong;
	}


	@Column(name="SAGO_ADDRESS")
	public String getSagoAddress() {
		return this.sagoAddress;
	}

	public void setSagoAddress(String sagoAddress) {
		this.sagoAddress = sagoAddress;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SAGO_DATE")
	public Date getSagoDate() {
		return this.sagoDate;
	}

	public void setSagoDate(Date sagoDate) {
		this.sagoDate = sagoDate;
	}


	@Column(name="SAGO_GUBUN")
	public String getSagoGubun() {
		return this.sagoGubun;
	}

	public void setSagoGubun(String sagoGubun) {
		this.sagoGubun = sagoGubun;
	}


	@Column(name="SAGO_GUBUN_TEXT")
	public String getSagoGubunText() {
		return this.sagoGubunText;
	}

	public void setSagoGubunText(String sagoGubunText) {
		this.sagoGubunText = sagoGubunText;
	}


	@Column(name="SAGO_JANGSO")
	public String getSagoJangso() {
		return this.sagoJangso;
	}

	public void setSagoJangso(String sagoJangso) {
		this.sagoJangso = sagoJangso;
	}


	@Column(name="SAGO_JANGSO_TEXT")
	public String getSagoJangsoText() {
		return this.sagoJangsoText;
	}

	public void setSagoJangsoText(String sagoJangsoText) {
		this.sagoJangsoText = sagoJangsoText;
	}


	@Column(name="SAGO_SANGHWANG")
	public String getSagoSanghwang() {
		return this.sagoSanghwang;
	}

	public void setSagoSanghwang(String sagoSanghwang) {
		this.sagoSanghwang = sagoSanghwang;
	}


	public String getSain1() {
		return this.sain1;
	}

	public void setSain1(String sain1) {
		this.sain1 = sain1;
	}


	public String getSain2() {
		return this.sain2;
	}

	public void setSain2(String sain2) {
		this.sain2 = sain2;
	}


	public String getSain3() {
		return this.sain3;
	}

	public void setSain3(String sain3) {
		this.sain3 = sain3;
	}


	public String getSain4() {
		return this.sain4;
	}

	public void setSain4(String sain4) {
		this.sain4 = sain4;
	}


	@Column(name="SAMANG_ADDRESS")
	public String getSamangAddress() {
		return this.samangAddress;
	}

	public void setSamangAddress(String samangAddress) {
		this.samangAddress = samangAddress;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SAMANG_DATE")
	public Date getSamangDate() {
		return this.samangDate;
	}

	public void setSamangDate(Date samangDate) {
		this.samangDate = samangDate;
	}


	@Column(name="SAMANG_GIGAN")
	public String getSamangGigan() {
		return this.samangGigan;
	}

	public void setSamangGigan(String samangGigan) {
		this.samangGigan = samangGigan;
	}


	@Column(name="SAMANG_GUBUN1")
	public String getSamangGubun1() {
		return this.samangGubun1;
	}

	public void setSamangGubun1(String samangGubun1) {
		this.samangGubun1 = samangGubun1;
	}


	@Column(name="SAMANG_GUBUN2")
	public String getSamangGubun2() {
		return this.samangGubun2;
	}

	public void setSamangGubun2(String samangGubun2) {
		this.samangGubun2 = samangGubun2;
	}


	@Column(name="SAMANG_JANGSO")
	public String getSamangJangso() {
		return this.samangJangso;
	}

	public void setSamangJangso(String samangJangso) {
		this.samangJangso = samangJangso;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SUSUL_DATE")
	public Date getSusulDate() {
		return this.susulDate;
	}

	public void setSusulDate(Date susulDate) {
		this.susulDate = susulDate;
	}


	@Column(name="SUSUL_VIEW")
	public String getSusulView() {
		return this.susulView;
	}

	public void setSusulView(String susulView) {
		this.susulView = susulView;
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