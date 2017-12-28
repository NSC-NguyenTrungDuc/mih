package nta.med.core.domain.phy;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the PHY8004 database table.
 * 
 */
@Entity
@Table(name="PHY8004")
public class Phy8004 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String dataKubun;
	private Double fkOcsIrai;
	private Double fkcht0113;
	private String hospCode;
	private String kanjaNo;
	private Date ocsSaveDate;
	private String ocsSaveYn;
	private Double pkPhySyougai;
	private String syougaiId;
	private String syougaimei;
	private Date sysDate;
	private Date updDate;
	private String userId;

	public Phy8004() {
	}


	@Column(name="DATA_KUBUN")
	public String getDataKubun() {
		return this.dataKubun;
	}

	public void setDataKubun(String dataKubun) {
		this.dataKubun = dataKubun;
	}


	@Column(name="FK_OCS_IRAI")
	public Double getFkOcsIrai() {
		return this.fkOcsIrai;
	}

	public void setFkOcsIrai(Double fkOcsIrai) {
		this.fkOcsIrai = fkOcsIrai;
	}


	public Double getFkcht0113() {
		return this.fkcht0113;
	}

	public void setFkcht0113(Double fkcht0113) {
		this.fkcht0113 = fkcht0113;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="KANJA_NO")
	public String getKanjaNo() {
		return this.kanjaNo;
	}

	public void setKanjaNo(String kanjaNo) {
		this.kanjaNo = kanjaNo;
	}


	@Temporal(TemporalType.TIMESTAMP)
	@Column(name="OCS_SAVE_DATE")
	public Date getOcsSaveDate() {
		return this.ocsSaveDate;
	}

	public void setOcsSaveDate(Date ocsSaveDate) {
		this.ocsSaveDate = ocsSaveDate;
	}


	@Column(name="OCS_SAVE_YN")
	public String getOcsSaveYn() {
		return this.ocsSaveYn;
	}

	public void setOcsSaveYn(String ocsSaveYn) {
		this.ocsSaveYn = ocsSaveYn;
	}


	@Column(name="PK_PHY_SYOUGAI")
	public Double getPkPhySyougai() {
		return this.pkPhySyougai;
	}

	public void setPkPhySyougai(Double pkPhySyougai) {
		this.pkPhySyougai = pkPhySyougai;
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