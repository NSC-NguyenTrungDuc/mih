package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS7203 database table.
 * 
 */
@Entity
@Table(name="IFS7203")
public class Ifs7203 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private String houkokubi;
	private Date ifDate;
	private String ifErr;
	private String ifFlag;
	private String ifTime;
	private String iraiKey;
	private String kanjamei;
	private String karuteNo;
	private String koumokusuu;
	private Double pkifs7203;
	private String recordGubun;
	private String sentaCode;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;
	private String yobi1;
	private String yobi2;

	public Ifs7203() {
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	@Column(name="HOUKOKUBI")
	public String getHoukokubi() {
		return this.houkokubi;
	}

	public void setHoukokubi(String houkokubi) {
		this.houkokubi = houkokubi;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="IF_DATE")
	public Date getIfDate() {
		return this.ifDate;
	}

	public void setIfDate(Date ifDate) {
		this.ifDate = ifDate;
	}


	@Column(name="IF_ERR")
	public String getIfErr() {
		return this.ifErr;
	}

	public void setIfErr(String ifErr) {
		this.ifErr = ifErr;
	}


	@Column(name="IF_FLAG")
	public String getIfFlag() {
		return this.ifFlag;
	}

	public void setIfFlag(String ifFlag) {
		this.ifFlag = ifFlag;
	}


	@Column(name="IF_TIME")
	public String getIfTime() {
		return this.ifTime;
	}

	public void setIfTime(String ifTime) {
		this.ifTime = ifTime;
	}


	@Column(name="IRAI_KEY")
	public String getIraiKey() {
		return this.iraiKey;
	}

	public void setIraiKey(String iraiKey) {
		this.iraiKey = iraiKey;
	}

	@Column(name="KANJAMEI")
	public String getKanjamei() {
		return this.kanjamei;
	}

	public void setKanjamei(String kanjamei) {
		this.kanjamei = kanjamei;
	}


	@Column(name="KARUTE_NO")
	public String getKaruteNo() {
		return this.karuteNo;
	}

	public void setKaruteNo(String karuteNo) {
		this.karuteNo = karuteNo;
	}

	@Column(name="KOUMOKUSUU")
	public String getKoumokusuu() {
		return this.koumokusuu;
	}

	public void setKoumokusuu(String koumokusuu) {
		this.koumokusuu = koumokusuu;
	}

	@Column(name="PKIFS7203")
	public Double getPkifs7203() {
		return this.pkifs7203;
	}

	public void setPkifs7203(Double pkifs7203) {
		this.pkifs7203 = pkifs7203;
	}


	@Column(name="RECORD_GUBUN")
	public String getRecordGubun() {
		return this.recordGubun;
	}

	public void setRecordGubun(String recordGubun) {
		this.recordGubun = recordGubun;
	}


	@Column(name="SENTA_CODE")
	public String getSentaCode() {
		return this.sentaCode;
	}

	public void setSentaCode(String sentaCode) {
		this.sentaCode = sentaCode;
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

	@Column(name="YOBI1")
	public String getYobi1() {
		return this.yobi1;
	}

	public void setYobi1(String yobi1) {
		this.yobi1 = yobi1;
	}

	@Column(name="YOBI2")
	public String getYobi2() {
		return this.yobi2;
	}

	public void setYobi2(String yobi2) {
		this.yobi2 = yobi2;
	}

}