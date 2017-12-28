package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;


/**
 * The persistent class for the ADM4310 database table.
 * 
 */
@Entity
@Table(name="ADM4310")
public class Adm4310 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String hospCode;
	private String menuGenYn;
	private String sysId;
	private String userId;

	public Adm4310() {
	}


	@Column(name="HOSP_CODE")
	public String getHospCode() {
		return this.hospCode;
	}

	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}


	@Column(name="MENU_GEN_YN")
	public String getMenuGenYn() {
		return this.menuGenYn;
	}

	public void setMenuGenYn(String menuGenYn) {
		this.menuGenYn = menuGenYn;
	}


	@Column(name="SYS_ID")
	public String getSysId() {
		return this.sysId;
	}

	public void setSysId(String sysId) {
		this.sysId = sysId;
	}


	@Column(name="USER_ID")
	public String getUserId() {
		return this.userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

}