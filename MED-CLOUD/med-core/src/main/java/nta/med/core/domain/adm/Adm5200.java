package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the ADM5200 database table.
 * 
 */
@Entity
@NamedQuery(name="Adm5200.findAll", query="SELECT a FROM Adm5200 a")
public class Adm5200 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String comments;
	private String deleteYn;
	private String insertYn;
	private String multiYn;
	private String packageCode;
	private String pgmId;
	private String readYn;
	private Date sysDate;
	private String sysId;
	private String tblId;
	private Date updDate;
	private String updId;
	private String updateYn;

	public Adm5200() {
	}


	public String getComments() {
		return this.comments;
	}

	public void setComments(String comments) {
		this.comments = comments;
	}


	@Column(name="DELETE_YN")
	public String getDeleteYn() {
		return this.deleteYn;
	}

	public void setDeleteYn(String deleteYn) {
		this.deleteYn = deleteYn;
	}


	@Column(name="INSERT_YN")
	public String getInsertYn() {
		return this.insertYn;
	}

	public void setInsertYn(String insertYn) {
		this.insertYn = insertYn;
	}


	@Column(name="MULTI_YN")
	public String getMultiYn() {
		return this.multiYn;
	}

	public void setMultiYn(String multiYn) {
		this.multiYn = multiYn;
	}


	@Column(name="PACKAGE_CODE")
	public String getPackageCode() {
		return this.packageCode;
	}

	public void setPackageCode(String packageCode) {
		this.packageCode = packageCode;
	}


	@Column(name="PGM_ID")
	public String getPgmId() {
		return this.pgmId;
	}

	public void setPgmId(String pgmId) {
		this.pgmId = pgmId;
	}


	@Column(name="READ_YN")
	public String getReadYn() {
		return this.readYn;
	}

	public void setReadYn(String readYn) {
		this.readYn = readYn;
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


	@Column(name="TBL_ID")
	public String getTblId() {
		return this.tblId;
	}

	public void setTblId(String tblId) {
		this.tblId = tblId;
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


	@Column(name="UPDATE_YN")
	public String getUpdateYn() {
		return this.updateYn;
	}

	public void setUpdateYn(String updateYn) {
		this.updateYn = updateYn;
	}

}