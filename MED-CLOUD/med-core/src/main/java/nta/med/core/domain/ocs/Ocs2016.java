package nta.med.core.domain.ocs;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;

/**
 * The persistent class for the OCS2016 database table.
 * 
 */
@Entity
@Table(name = "OCS2016")
public class Ocs2016 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	
	private Double bloodSugar;
	private String bogyongCode;
	private Double bomSourceKey;
	private String bomYn;
	private String broughtDrgYn;
	private Double dv;
	private String dvTime;
	private Double fkocs2003;
	private Double fkocs2003Bscheck;
	private Double fkocs2015;
	private String hangmogCode;
	private String hospCode;
	private String jusaCode;
	private String jusaSpdGubun;
	private String muhyo;
	private Double nalsu;
	private String ordDanui;
	private Double pkocs2016;
	private Double seq;
	private Double suryang;
	private Date sysDate;
	private String sysId;
	private String timeGubun;
	private Date updDate;
	private String updId;

	public Ocs2016() {
	}

	@Column(name = "BLOOD_SUGAR")
	public Double getBloodSugar() {
		return this.bloodSugar;
	}

	public void setBloodSugar(Double bloodSugar) {
		this.bloodSugar = bloodSugar;
	}

	@Column(name = "BOGYONG_CODE")
	public String getBogyongCode() {
		return this.bogyongCode;
	}

	public void setBogyongCode(String bogyongCode) {
		this.bogyongCode = bogyongCode;
	}

	@Column(name = "BOM_SOURCE_KEY")
	public Double getBomSourceKey() {
		return this.bomSourceKey;
	}

	public void setBomSourceKey(Double bomSourceKey) {
		this.bomSourceKey = bomSourceKey;
	}

	@Column(name = "BOM_YN")
	public String getBomYn() {
		return this.bomYn;
	}

	public void setBomYn(String bomYn) {
		this.bomYn = bomYn;
	}

	@Column(name = "BROUGHT_DRG_YN")
	public String getBroughtDrgYn() {
		return this.broughtDrgYn;
	}

	public void setBroughtDrgYn(String broughtDrgYn) {
		this.broughtDrgYn = broughtDrgYn;
	}

	public Double getDv() {
		return this.dv;
	}

	public void setDv(Double dv) {
		this.dv = dv;
	}

	@Column(name = "DV_TIME")
	public String getDvTime() {
		return this.dvTime;
	}

	public void setDvTime(String dvTime) {
		this.dvTime = dvTime;
	}

	public Double getFkocs2003() {
		return this.fkocs2003;
	}

	public void setFkocs2003(Double fkocs2003) {
		this.fkocs2003 = fkocs2003;
	}

	@Column(name = "FKOCS2003_BSCHECK")
	public Double getFkocs2003Bscheck() {
		return this.fkocs2003Bscheck;
	}

	public void setFkocs2003Bscheck(Double fkocs2003Bscheck) {
		this.fkocs2003Bscheck = fkocs2003Bscheck;
	}

	public Double getFkocs2015() {
		return this.fkocs2015;
	}

	public void setFkocs2015(Double fkocs2015) {
		this.fkocs2015 = fkocs2015;
	}

	@Column(name = "HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}

	@Column(name = "HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name = "JUSA_CODE")
	public String getJusaCode() {
		return this.jusaCode;
	}

	public void setJusaCode(String jusaCode) {
		this.jusaCode = jusaCode;
	}

	@Column(name = "JUSA_SPD_GUBUN")
	public String getJusaSpdGubun() {
		return this.jusaSpdGubun;
	}

	public void setJusaSpdGubun(String jusaSpdGubun) {
		this.jusaSpdGubun = jusaSpdGubun;
	}

	public String getMuhyo() {
		return this.muhyo;
	}

	public void setMuhyo(String muhyo) {
		this.muhyo = muhyo;
	}

	public Double getNalsu() {
		return this.nalsu;
	}

	public void setNalsu(Double nalsu) {
		this.nalsu = nalsu;
	}

	@Column(name = "ORD_DANUI")
	public String getOrdDanui() {
		return this.ordDanui;
	}

	public void setOrdDanui(String ordDanui) {
		this.ordDanui = ordDanui;
	}

	public Double getPkocs2016() {
		return this.pkocs2016;
	}

	public void setPkocs2016(Double pkocs2016) {
		this.pkocs2016 = pkocs2016;
	}

	public Double getSeq() {
		return this.seq;
	}

	public void setSeq(Double seq) {
		this.seq = seq;
	}

	public Double getSuryang() {
		return this.suryang;
	}

	public void setSuryang(Double suryang) {
		this.suryang = suryang;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}

	@Column(name = "SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	@Column(name = "TIME_GUBUN")
	public String getTimeGubun() {
		return this.timeGubun;
	}

	public void setTimeGubun(String timeGubun) {
		this.timeGubun = timeGubun;
	}

	@Temporal(TemporalType.TIMESTAMP)
	@Column(name = "UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}

	@Column(name = "UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

}