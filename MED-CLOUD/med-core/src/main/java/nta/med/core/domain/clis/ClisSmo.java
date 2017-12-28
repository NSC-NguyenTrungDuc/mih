package nta.med.core.domain.clis;

import java.io.Serializable;
import java.math.BigDecimal;
import java.sql.Timestamp;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;


/**
 * The persistent class for the CLIS_SMO database table.
 * 
 */
@Entity
@Table(name="CLIS_SMO")
public class ClisSmo implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@Column(name="CLIS_SMO_ID")
	private int clisSmoId;

	@Column(name="ACTIVE_FLG")
	private BigDecimal activeFlg;

	private String address;

	private String address1;

	@Column(name="CREATED")
	private Date created;

	@Column(name="DODOBUHYEUN_NO")
	private String dodobuhyeunNo;

	private String email;

	private String fax;

	private String homepage;

	@Column(name="HOSP_CODE")
	private String hospCode;

	@Column(name="SMO_CODE")
	private String smoCode;

	@Column(name="SMO_NAME")
	private String smoName;

	@Column(name="SMO_NAME1")
	private String smoName1;

	@Column(name="SYS_ID")
	private String sysId;

	private String tel;

	private String tel1;

	@Column(name="UPD_ID")
	private String updId;

	@Column(name="UPDATED")
	private Date updated;

	@Column(name="ZIP_CODE1")
	private String zipCode1;

	@Column(name="ZIP_CODE2")
	private String zipCode2;
	
	@Column(name="START_DATE")
	private Date startDate;
	
	@Column(name="END_DATE")
	private Date endDate;

	public ClisSmo() {
	}

	public int getClisSmoId() {
		return this.clisSmoId;
	}

	public void setClisSmoId(int clisSmoId) {
		this.clisSmoId = clisSmoId;
	}

	public BigDecimal getActiveFlg() {
		return this.activeFlg;
	}

	public void setActiveFlg(BigDecimal activeFlg) {
		this.activeFlg = activeFlg;
	}

	public String getAddress() {
		return this.address;
	}

	public void setAddress(String address) {
		this.address = address;
	}

	public String getAddress1() {
		return this.address1;
	}

	public void setAddress1(String address1) {
		this.address1 = address1;
	}

	public Date getCreated() {
		return this.created;
	}

	public void setCreated(Date created) {
		this.created = created;
	}

	public String getDodobuhyeunNo() {
		return this.dodobuhyeunNo;
	}

	public void setDodobuhyeunNo(String dodobuhyeunNo) {
		this.dodobuhyeunNo = dodobuhyeunNo;
	}

	public String getEmail() {
		return this.email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getFax() {
		return this.fax;
	}

	public void setFax(String fax) {
		this.fax = fax;
	}

	public String getHomepage() {
		return this.homepage;
	}

	public void setHomepage(String homepage) {
		this.homepage = homepage;
	}

	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}

	public String getSmoCode() {
		return this.smoCode;
	}

	public void setSmoCode(String smoCode) {
		this.smoCode = smoCode;
	}

	public String getSmoName() {
		return this.smoName;
	}

	public void setSmoName(String smoName) {
		this.smoName = smoName;
	}

	public String getSmoName1() {
		return this.smoName1;
	}

	public void setSmoName1(String smoName1) {
		this.smoName1 = smoName1;
	}

	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}

	public String getTel() {
		return this.tel;
	}

	public void setTel(String tel) {
		this.tel = tel;
	}

	public String getTel1() {
		return this.tel1;
	}

	public void setTel1(String tel1) {
		this.tel1 = tel1;
	}

	public String getUpdId() {
		return this.updId;
	}

	public void setUpdId(String updId) {
		this.updId = updId;
	}

	public Date getUpdated() {
		return this.updated;
	}

	public void setUpdated(Date updated) {
		this.updated = updated;
	}

	public String getZipCode1() {
		return this.zipCode1;
	}

	public void setZipCode1(String zipCode1) {
		this.zipCode1 = zipCode1;
	}

	public String getZipCode2() {
		return this.zipCode2;
	}

	public void setZipCode2(String zipCode2) {
		this.zipCode2 = zipCode2;
	}

	public Date getStartDate() {
		return startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}

	public Date getEndDate() {
		return endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

}