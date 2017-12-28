package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS8052 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs8052.findAll", query="SELECT i FROM Ifs8052 i")
public class Ifs8052 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String actDate;
	private String actTime;
	private double amount;
	private String chiryouTani;
	private String dataKubun;
	private double fkIfsSyoubyou;
	private String fkJissekiId;
	private double fkOcsIrai;
	private String hospCode;
	private String ioKubun;
	private double jSeq;
	private String jissekiComment;
	private String jissekiId;
	private String kaikeiFlag;
	private String kaikeiSyoriFlag;
	private String kanjaNo;
	private String kasanDataYn;
	private String koumokuCode;
	private double nissuu;
	private String nocount;
	private double pkIfsJisseki;
	private String remark;
	private String syoriFlag;
	private Date sysDate;
	private String tantouMainId;
	private String tiryoukaisibi;
	private Date updDate;
	private String userId;
	private String yoyakuId;

	public Ifs8052() {
	}


	@Column(name="ACT_DATE")
	public String getActDate() {
		return this.actDate;
	}

	public void setActDate(String actDate) {
		this.actDate = actDate;
	}


	@Column(name="ACT_TIME")
	public String getActTime() {
		return this.actTime;
	}

	public void setActTime(String actTime) {
		this.actTime = actTime;
	}


	public double getAmount() {
		return this.amount;
	}

	public void setAmount(double amount) {
		this.amount = amount;
	}


	@Column(name="CHIRYOU_TANI")
	public String getChiryouTani() {
		return this.chiryouTani;
	}

	public void setChiryouTani(String chiryouTani) {
		this.chiryouTani = chiryouTani;
	}


	@Column(name="DATA_KUBUN")
	public String getDataKubun() {
		return this.dataKubun;
	}

	public void setDataKubun(String dataKubun) {
		this.dataKubun = dataKubun;
	}


	@Column(name="FK_IFS_SYOUBYOU")
	public double getFkIfsSyoubyou() {
		return this.fkIfsSyoubyou;
	}

	public void setFkIfsSyoubyou(double fkIfsSyoubyou) {
		this.fkIfsSyoubyou = fkIfsSyoubyou;
	}


	@Column(name="FK_JISSEKI_ID")
	public String getFkJissekiId() {
		return this.fkJissekiId;
	}

	public void setFkJissekiId(String fkJissekiId) {
		this.fkJissekiId = fkJissekiId;
	}


	@Column(name="FK_OCS_IRAI")
	public double getFkOcsIrai() {
		return this.fkOcsIrai;
	}

	public void setFkOcsIrai(double fkOcsIrai) {
		this.fkOcsIrai = fkOcsIrai;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="IO_KUBUN")
	public String getIoKubun() {
		return this.ioKubun;
	}

	public void setIoKubun(String ioKubun) {
		this.ioKubun = ioKubun;
	}


	@Column(name="J_SEQ")
	public double getJSeq() {
		return this.jSeq;
	}

	public void setJSeq(double jSeq) {
		this.jSeq = jSeq;
	}


	@Column(name="JISSEKI_COMMENT")
	public String getJissekiComment() {
		return this.jissekiComment;
	}

	public void setJissekiComment(String jissekiComment) {
		this.jissekiComment = jissekiComment;
	}


	@Column(name="JISSEKI_ID")
	public String getJissekiId() {
		return this.jissekiId;
	}

	public void setJissekiId(String jissekiId) {
		this.jissekiId = jissekiId;
	}


	@Column(name="KAIKEI_FLAG")
	public String getKaikeiFlag() {
		return this.kaikeiFlag;
	}

	public void setKaikeiFlag(String kaikeiFlag) {
		this.kaikeiFlag = kaikeiFlag;
	}


	@Column(name="KAIKEI_SYORI_FLAG")
	public String getKaikeiSyoriFlag() {
		return this.kaikeiSyoriFlag;
	}

	public void setKaikeiSyoriFlag(String kaikeiSyoriFlag) {
		this.kaikeiSyoriFlag = kaikeiSyoriFlag;
	}


	@Column(name="KANJA_NO")
	public String getKanjaNo() {
		return this.kanjaNo;
	}

	public void setKanjaNo(String kanjaNo) {
		this.kanjaNo = kanjaNo;
	}


	@Column(name="KASAN_DATA_YN")
	public String getKasanDataYn() {
		return this.kasanDataYn;
	}

	public void setKasanDataYn(String kasanDataYn) {
		this.kasanDataYn = kasanDataYn;
	}


	@Column(name="KOUMOKU_CODE")
	public String getKoumokuCode() {
		return this.koumokuCode;
	}

	public void setKoumokuCode(String koumokuCode) {
		this.koumokuCode = koumokuCode;
	}


	public double getNissuu() {
		return this.nissuu;
	}

	public void setNissuu(double nissuu) {
		this.nissuu = nissuu;
	}


	public String getNocount() {
		return this.nocount;
	}

	public void setNocount(String nocount) {
		this.nocount = nocount;
	}


	@Column(name="PK_IFS_JISSEKI")
	public double getPkIfsJisseki() {
		return this.pkIfsJisseki;
	}

	public void setPkIfsJisseki(double pkIfsJisseki) {
		this.pkIfsJisseki = pkIfsJisseki;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	@Column(name="SYORI_FLAG")
	public String getSyoriFlag() {
		return this.syoriFlag;
	}

	public void setSyoriFlag(String syoriFlag) {
		this.syoriFlag = syoriFlag;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="SYS_DATE")
	public Date getSysDate() {
		return this.sysDate;
	}

	public void setSysDate(Date sysDate) {
		this.sysDate = sysDate;
	}


	@Column(name="TANTOU_MAIN_ID")
	public String getTantouMainId() {
		return this.tantouMainId;
	}

	public void setTantouMainId(String tantouMainId) {
		this.tantouMainId = tantouMainId;
	}


	public String getTiryoukaisibi() {
		return this.tiryoukaisibi;
	}

	public void setTiryoukaisibi(String tiryoukaisibi) {
		this.tiryoukaisibi = tiryoukaisibi;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="UPD_DATE")
	public Date getUpdDate() {
		return this.updDate;
	}

	public void setUpdDate(Date updDate) {
		this.updDate = updDate;
	}


	@Column(name="USER_ID")
	public String getUserId() {
		return this.userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}


	@Column(name="YOYAKU_ID")
	public String getYoyakuId() {
		return this.yoyakuId;
	}

	public void setYoyakuId(String yoyakuId) {
		this.yoyakuId = yoyakuId;
	}

}