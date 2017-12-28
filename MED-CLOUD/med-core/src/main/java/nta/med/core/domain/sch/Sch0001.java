package nta.med.core.domain.sch;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the SCH0001 database table.
 * 
 */
@Entity
@NamedQuery(name="Sch0001.findAll", query="SELECT s FROM Sch0001 s")
@Table(name= "SCH0001")
public class Sch0001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Double docDisplaySort;
	private String docDisplayYn;
	private String docPartName;
	private Double gumsaTime;
	private String gumsaja;
	private String gwaGubun;
	private String hospCode;
	private String jundalPart;
	private String jundalPartGroup;
	private String jundalPartName;
	private String jundalTable;
	private String jusaReserYn;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Sch0001() {
	}


	@Column(name="DOC_DISPLAY_SORT")
	public Double getDocDisplaySort() {
		return this.docDisplaySort;
	}

	public void setDocDisplaySort(Double docDisplaySort) {
		this.docDisplaySort = docDisplaySort;
	}


	@Column(name="DOC_DISPLAY_YN")
	public String getDocDisplayYn() {
		return this.docDisplayYn;
	}

	public void setDocDisplayYn(String docDisplayYn) {
		this.docDisplayYn = docDisplayYn;
	}


	@Column(name="DOC_PART_NAME")
	public String getDocPartName() {
		return this.docPartName;
	}

	public void setDocPartName(String docPartName) {
		this.docPartName = docPartName;
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


	@Column(name="GWA_GUBUN")
	public String getGwaGubun() {
		return this.gwaGubun;
	}

	public void setGwaGubun(String gwaGubun) {
		this.gwaGubun = gwaGubun;
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


	@Column(name="JUNDAL_PART_GROUP")
	public String getJundalPartGroup() {
		return this.jundalPartGroup;
	}

	public void setJundalPartGroup(String jundalPartGroup) {
		this.jundalPartGroup = jundalPartGroup;
	}


	@Column(name="JUNDAL_PART_NAME")
	public String getJundalPartName() {
		return this.jundalPartName;
	}

	public void setJundalPartName(String jundalPartName) {
		this.jundalPartName = jundalPartName;
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