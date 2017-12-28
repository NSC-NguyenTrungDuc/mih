package nta.med.core.domain.sch;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;

import javax.persistence.*;

import java.util.Date;


/**
 * The persistent class for the SCH0002 database table.
 * 
 */
@Entity
//@NamedQuery(name="Sch0002.findAll", query="SELECT s FROM Sch0002 s")
@Table(name= "SCH0002")
public class Sch0002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String comments;
	private String dispYn;
	private Double gumsaTime;
	private String gumsaja;
	private String hangmogCode;
	private String hangmogName;
	private String hospCode;
	private String jundalPart;
	private String jundalTable;
	private String jusaReserYn;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Sch0002() {
	}


	public String getComments() {
		return this.comments;
	}

	public void setComments(String comments) {
		this.comments = comments;
	}


	@Column(name="DISP_YN")
	public String getDispYn() {
		return this.dispYn;
	}

	public void setDispYn(String dispYn) {
		this.dispYn = dispYn;
	}


	@Column(name="GUMSA_TIME")
	public Double getGumsaTime() {
		return this.gumsaTime;
	}

	public void setGumsaTime(Double gumsaTime) {
		this.gumsaTime = gumsaTime;
	}


	public String getGumsaja() {
		return this.gumsaja;
	}

	public void setGumsaja(String gumsaja) {
		this.gumsaja = gumsaja;
	}


	@Column(name="HANGMOG_CODE")
	public String getHangmogCode() {
		return this.hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}


	@Column(name="HANGMOG_NAME")
	public String getHangmogName() {
		return this.hangmogName;
	}

	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="JUNDAL_PART")
	public String getJundalPart() {
		return this.jundalPart;
	}

	public void setJundalPart(String jundalPart) {
		this.jundalPart = jundalPart;
	}


	@Column(name="JUNDAL_TABLE")
	public String getJundalTable() {
		return this.jundalTable;
	}

	public void setJundalTable(String jundalTable) {
		this.jundalTable = jundalTable;
	}


	@Column(name="JUSA_RESER_YN")
	public String getJusaReserYn() {
		return this.jusaReserYn;
	}

	public void setJusaReserYn(String jusaReserYn) {
		this.jusaReserYn = jusaReserYn;
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