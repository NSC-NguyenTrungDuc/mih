package nta.med.core.domain.out;

import java.math.BigDecimal;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the OUT1001 database table.
 * 
 */
@Entity
@Table(name="OUT1001")
public class Out1001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String arriveTime;
	private String bigo;
	private String bunho;
	private String chojae;
	private String doctor;
	private BigDecimal fkinp1001;
	private String gubun;
	private String gubunUuid;
	private String gwa;
	private String hospCode;
	private String inpTransYn;
	private String jubsuGubun;
	private BigDecimal jubsuNo;
	private String jubsuTime;
	private String kensaYn;
	private Date naewonDate;
	private String naewonType;
	private String naewonYn;
	private Double pkout1001;
	private String pkout1001Ext;
	private String realNaewonYn;
	private String resChanggu;
	private String resGubun;
	private String resInputGubun;
	private BigDecimal resSeq;
	private String reserYn;
	private String sanjungGubun;
	private BigDecimal sujinNo;
	private String sunnabYn;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updFlg;
	private String updId;
	private String validYn;
	private String wonyoiOrderYn;
	private String outHospCode;
	private String paidYn;
	private String receptRefId;
	
	public Out1001() {
	}


	@Column(name="ARRIVE_TIME")
	public String getArriveTime() {
		return this.arriveTime;
	}

	public void setArriveTime(String arriveTime) {
		this.arriveTime = arriveTime;
	}


	public String getBigo() {
		return this.bigo;
	}

	public void setBigo(String bigo) {
		this.bigo = bigo;
	}


	public String getBunho() {
		return this.bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}


	public String getChojae() {
		return this.chojae;
	}

	public void setChojae(String chojae) {
		this.chojae = chojae;
	}


	public String getDoctor() {
		return this.doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}


	public BigDecimal getFkinp1001() {
		return this.fkinp1001;
	}

	public void setFkinp1001(BigDecimal fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}


	public String getGubun() {
		return this.gubun;
	}

	public void setGubun(String gubun) {
		this.gubun = gubun;
	}


	@Column(name="GUBUN_UUID")
	public String getGubunUuid() {
		return this.gubunUuid;
	}

	public void setGubunUuid(String gubunUuid) {
		this.gubunUuid = gubunUuid;
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


	@Column(name="INP_TRANS_YN")
	public String getInpTransYn() {
		return this.inpTransYn;
	}

	public void setInpTransYn(String inpTransYn) {
		this.inpTransYn = inpTransYn;
	}


	@Column(name="JUBSU_GUBUN")
	public String getJubsuGubun() {
		return this.jubsuGubun;
	}

	public void setJubsuGubun(String jubsuGubun) {
		this.jubsuGubun = jubsuGubun;
	}


	@Column(name="JUBSU_NO")
	public BigDecimal getJubsuNo() {
		return this.jubsuNo;
	}

	public void setJubsuNo(BigDecimal jubsuNo) {
		this.jubsuNo = jubsuNo;
	}


	@Column(name="JUBSU_TIME")
	public String getJubsuTime() {
		return this.jubsuTime;
	}

	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
	}


	@Column(name="KENSA_YN")
	public String getKensaYn() {
		return this.kensaYn;
	}

	public void setKensaYn(String kensaYn) {
		this.kensaYn = kensaYn;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="NAEWON_DATE")
	public Date getNaewonDate() {
		return this.naewonDate;
	}

	public void setNaewonDate(Date naewonDate) {
		this.naewonDate = naewonDate;
	}


	@Column(name="NAEWON_TYPE")
	public String getNaewonType() {
		return this.naewonType;
	}

	public void setNaewonType(String naewonType) {
		this.naewonType = naewonType;
	}


	@Column(name="NAEWON_YN")
	public String getNaewonYn() {
		return this.naewonYn;
	}

	public void setNaewonYn(String naewonYn) {
		this.naewonYn = naewonYn;
	}

	@Column(name="REAL_NAEWON_YN")
	public String getRealNaewonYn() {
		return this.realNaewonYn;
	}

	public void setRealNaewonYn(String realNaewonYn) {
		this.realNaewonYn = realNaewonYn;
	}


	@Column(name="RES_CHANGGU")
	public String getResChanggu() {
		return this.resChanggu;
	}

	public void setResChanggu(String resChanggu) {
		this.resChanggu = resChanggu;
	}


	@Column(name="RES_GUBUN")
	public String getResGubun() {
		return this.resGubun;
	}

	public void setResGubun(String resGubun) {
		this.resGubun = resGubun;
	}


	@Column(name="RES_INPUT_GUBUN")
	public String getResInputGubun() {
		return this.resInputGubun;
	}

	public void setResInputGubun(String resInputGubun) {
		this.resInputGubun = resInputGubun;
	}


	@Column(name="RES_SEQ")
	public BigDecimal getResSeq() {
		return this.resSeq;
	}

	public void setResSeq(BigDecimal resSeq) {
		this.resSeq = resSeq;
	}


	@Column(name="RESER_YN")
	public String getReserYn() {
		return this.reserYn;
	}

	public void setReserYn(String reserYn) {
		this.reserYn = reserYn;
	}


	@Column(name="SANJUNG_GUBUN")
	public String getSanjungGubun() {
		return this.sanjungGubun;
	}

	public void setSanjungGubun(String sanjungGubun) {
		this.sanjungGubun = sanjungGubun;
	}


	@Column(name="SUJIN_NO")
	public BigDecimal getSujinNo() {
		return this.sujinNo;
	}

	public void setSujinNo(BigDecimal sujinNo) {
		this.sujinNo = sujinNo;
	}


	@Column(name="SUNNAB_YN")
	public String getSunnabYn() {
		return this.sunnabYn;
	}

	public void setSunnabYn(String sunnabYn) {
		this.sunnabYn = sunnabYn;
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


	@Column(name="UPD_FLG")
	public String getUpdFlg() {
		return this.updFlg;
	}

	public void setUpdFlg(String updFlg) {
		this.updFlg = updFlg;
	}


	@Column(name="UPD_ID")
	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}


	@Column(name="VALID_YN")
	public String getValidYn() {
		return this.validYn;
	}

	public void setValidYn(String validYn) {
		this.validYn = validYn;
	}


	@Column(name="WONYOI_ORDER_YN")
	public String getWonyoiOrderYn() {
		return this.wonyoiOrderYn;
	}

	public void setWonyoiOrderYn(String wonyoiOrderYn) {
		this.wonyoiOrderYn = wonyoiOrderYn;
	}


	public Double getPkout1001() {
		return pkout1001;
	}


	public void setPkout1001(Double pkout1001) {
		this.pkout1001 = pkout1001;
	}
	
	
	@Column(name="PKOUT1001_EXT")
	public String getPkout1001Ext() {
		return pkout1001Ext;
	}


	public void setPkout1001Ext(String pkout1001Ext) {
		this.pkout1001Ext = pkout1001Ext;
	}
	
	
	@Column(name="OUT_HOSP_CODE")
	public String getOutHospCode() {
		return outHospCode;
	}

	public void setOutHospCode(String outHospCode) {
		this.outHospCode = outHospCode;
	}

	
	@Column(name="PAID_YN")
	public String getPaidYn() {
		return paidYn;
	}

	public void setPaidYn(String paidYn) {
		this.paidYn = paidYn;
	}
	
	@Column(name="RECEPT_REF_ID")
	public String getReceptRefId() {
		return receptRefId;
	}

	public void setReceptRefId(String receptRefId) {
		this.receptRefId = receptRefId;
	}


	public static long getSerialversionuid() {
		return serialVersionUID;
	}


	@Override
	public String toString() {
		return "Out1001 [arriveTime=" + arriveTime + ", bigo=" + bigo
				+ ", bunho=" + bunho + ", chojae=" + chojae + ", doctor="
				+ doctor + ", fkinp1001=" + fkinp1001 + ", gubun=" + gubun
				+ ", gubunUuid=" + gubunUuid + ", gwa=" + gwa + ", hospCode="
				+ hospCode + ", inpTransYn=" + inpTransYn + ", jubsuGubun="
				+ jubsuGubun + ", jubsuNo=" + jubsuNo + ", jubsuTime="
				+ jubsuTime + ", kensaYn=" + kensaYn + ", naewonDate="
				+ naewonDate + ", naewonType=" + naewonType + ", naewonYn="
				+ naewonYn + ", pkout1001=" + pkout1001 + ", realNaewonYn="
				+ realNaewonYn + ", resChanggu=" + resChanggu + ", resGubun="
				+ resGubun + ", resInputGubun=" + resInputGubun + ", resSeq="
				+ resSeq + ", reserYn=" + reserYn + ", sanjungGubun="
				+ sanjungGubun + ", sujinNo=" + sujinNo + ", sunnabYn="
				+ sunnabYn + ", sysDate=" + sysDate + ", sysId=" + sysId
				+ ", updDate=" + updDate + ", updFlg=" + updFlg + ", updId="
				+ updId + ", validYn=" + validYn + ", wonyoiOrderYn="
				+ wonyoiOrderYn + "]";
	}

}