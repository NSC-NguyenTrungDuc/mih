package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the IFS8004 database table.
 * 
 */
@Entity
@NamedQuery(name="Ifs8004.findAll", query="SELECT i FROM Ifs8004 i")
public class Ifs8004 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String dataKubun;
	private double fkOcsIrai;
	private double fkPhySyougai;
	private String hospCode;
	private double iSeq;
	private String kanjaNo;
	private double pkIfsSyougai;
	private String remark;
	private String syougaiId;
	private String syougaimei;
	private Date sysDate;
	private Date updDate;
	private String userId;

	public Ifs8004() {
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


	@Column(name="FK_PHY_SYOUGAI")
	public double getFkPhySyougai() {
		return this.fkPhySyougai;
	}

	public void setFkPhySyougai(double fkPhySyougai) {
		this.fkPhySyougai = fkPhySyougai;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="I_SEQ")
	public double getISeq() {
		return this.iSeq;
	}

	public void setISeq(double iSeq) {
		this.iSeq = iSeq;
	}


	@Column(name="KANJA_NO")
	public String getKanjaNo() {
		return this.kanjaNo;
	}

	public void setKanjaNo(String kanjaNo) {
		this.kanjaNo = kanjaNo;
	}


	@Column(name="PK_IFS_SYOUGAI")
	public double getPkIfsSyougai() {
		return this.pkIfsSyougai;
	}

	public void setPkIfsSyougai(double pkIfsSyougai) {
		this.pkIfsSyougai = pkIfsSyougai;
	}


	public String getRemark() {
		return this.remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}


	@Column(name="SYOUGAI_ID")
	public String getSyougaiId() {
		return this.syougaiId;
	}

	public void setSyougaiId(String syougaiId) {
		this.syougaiId = syougaiId;
	}


	public String getSyougaimei() {
		return this.syougaimei;
	}

	public void setSyougaimei(String syougaimei) {
		this.syougaimei = syougaimei;
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

}