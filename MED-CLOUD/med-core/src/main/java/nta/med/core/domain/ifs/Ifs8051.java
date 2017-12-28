package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS8051 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs8051.findAll", query="SELECT i FROM Ifs8051 i")
public class Ifs8051 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String dataKubun;
	private double fkOcsIrai;
	private String hospCode;
	private String ioKubun;
	private String kanjaNo;
	private double pkIfsYoyaku;
	private String remark;
	private String syoriFlag;
	private Date sysDate;
	private Date updDate;
	private String userId;
	private double ySeq;
	private String yoyakuComment;
	private String yoyakuDate;
	private String yoyakuGroupCode;
	private String yoyakuId;
	private String yoyakuTimeFrom;
	private String yoyakuTimeTo;

	public Ifs8051() {
	}


	@Column(name="DATA_KUBUN")
	public String getDataKubun() {
		return this.dataKubun;
	}

	public void setDataKubun(String dataKubun) {
		this.dataKubun = dataKubun;
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


	@Column(name="KANJA_NO")
	public String getKanjaNo() {
		return this.kanjaNo;
	}

	public void setKanjaNo(String kanjaNo) {
		this.kanjaNo = kanjaNo;
	}


	@Column(name="PK_IFS_YOYAKU")
	public double getPkIfsYoyaku() {
		return this.pkIfsYoyaku;
	}

	public void setPkIfsYoyaku(double pkIfsYoyaku) {
		this.pkIfsYoyaku = pkIfsYoyaku;
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


	@Column(name="Y_SEQ")
	public double getYSeq() {
		return this.ySeq;
	}

	public void setYSeq(double ySeq) {
		this.ySeq = ySeq;
	}


	@Column(name="YOYAKU_COMMENT")
	public String getYoyakuComment() {
		return this.yoyakuComment;
	}

	public void setYoyakuComment(String yoyakuComment) {
		this.yoyakuComment = yoyakuComment;
	}


	@Column(name="YOYAKU_DATE")
	public String getYoyakuDate() {
		return this.yoyakuDate;
	}

	public void setYoyakuDate(String yoyakuDate) {
		this.yoyakuDate = yoyakuDate;
	}


	@Column(name="YOYAKU_GROUP_CODE")
	public String getYoyakuGroupCode() {
		return this.yoyakuGroupCode;
	}

	public void setYoyakuGroupCode(String yoyakuGroupCode) {
		this.yoyakuGroupCode = yoyakuGroupCode;
	}


	@Column(name="YOYAKU_ID")
	public String getYoyakuId() {
		return this.yoyakuId;
	}

	public void setYoyakuId(String yoyakuId) {
		this.yoyakuId = yoyakuId;
	}


	@Column(name="YOYAKU_TIME_FROM")
	public String getYoyakuTimeFrom() {
		return this.yoyakuTimeFrom;
	}

	public void setYoyakuTimeFrom(String yoyakuTimeFrom) {
		this.yoyakuTimeFrom = yoyakuTimeFrom;
	}


	@Column(name="YOYAKU_TIME_TO")
	public String getYoyakuTimeTo() {
		return this.yoyakuTimeTo;
	}

	public void setYoyakuTimeTo(String yoyakuTimeTo) {
		this.yoyakuTimeTo = yoyakuTimeTo;
	}

}