package nta.med.core.domain.apl;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the APL0103 database table.
 * 
 */
@Entity
@NamedQuery(name="Apl0103.findAll", query="SELECT a FROM Apl0103 a")
public class Apl0103 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String cbYn;
	private String euryoRtn;
	private String frozenYn;
	private String grossYn;
	private String gumsaGubun;
	private String hangmogCode;
	private String hangmogName;
	private String hospCode;
	private String immunityYn;
	private String itemUseYn;
	private String orGubun;
	private String pathnoYn;
	private String reserved01;
	private String reserved02;
	private String reserved03;
	private String reserved04;
	private String reserved05;
	private String reserved06;
	private String reserved07;
	private String reserved08;
	private String reserved09;
	private String reserved10;
	private String stain;
	private String stainYn;
	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String updId;

	public Apl0103() {
	}


	@Column(name="CB_YN")
	public String getCbYn() {
		return this.cbYn;
	}

	public void setCbYn(String cbYn) {
		this.cbYn = cbYn;
	}


	@Column(name="EURYO_RTN")
	public String getEuryoRtn() {
		return this.euryoRtn;
	}

	public void setEuryoRtn(String euryoRtn) {
		this.euryoRtn = euryoRtn;
	}


	@Column(name="FROZEN_YN")
	public String getFrozenYn() {
		return this.frozenYn;
	}

	public void setFrozenYn(String frozenYn) {
		this.frozenYn = frozenYn;
	}


	@Column(name="GROSS_YN")
	public String getGrossYn() {
		return this.grossYn;
	}

	public void setGrossYn(String grossYn) {
		this.grossYn = grossYn;
	}


	@Column(name="GUMSA_GUBUN")
	public String getGumsaGubun() {
		return this.gumsaGubun;
	}

	public void setGumsaGubun(String gumsaGubun) {
		this.gumsaGubun = gumsaGubun;
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


	@Column(name="IMMUNITY_YN")
	public String getImmunityYn() {
		return this.immunityYn;
	}

	public void setImmunityYn(String immunityYn) {
		this.immunityYn = immunityYn;
	}


	@Column(name="ITEM_USE_YN")
	public String getItemUseYn() {
		return this.itemUseYn;
	}

	public void setItemUseYn(String itemUseYn) {
		this.itemUseYn = itemUseYn;
	}


	@Column(name="OR_GUBUN")
	public String getOrGubun() {
		return this.orGubun;
	}

	public void setOrGubun(String orGubun) {
		this.orGubun = orGubun;
	}


	@Column(name="PATHNO_YN")
	public String getPathnoYn() {
		return this.pathnoYn;
	}

	public void setPathnoYn(String pathnoYn) {
		this.pathnoYn = pathnoYn;
	}


	public String getReserved01() {
		return this.reserved01;
	}

	public void setReserved01(String reserved01) {
		this.reserved01 = reserved01;
	}


	public String getReserved02() {
		return this.reserved02;
	}

	public void setReserved02(String reserved02) {
		this.reserved02 = reserved02;
	}


	public String getReserved03() {
		return this.reserved03;
	}

	public void setReserved03(String reserved03) {
		this.reserved03 = reserved03;
	}


	public String getReserved04() {
		return this.reserved04;
	}

	public void setReserved04(String reserved04) {
		this.reserved04 = reserved04;
	}


	public String getReserved05() {
		return this.reserved05;
	}

	public void setReserved05(String reserved05) {
		this.reserved05 = reserved05;
	}


	public String getReserved06() {
		return this.reserved06;
	}

	public void setReserved06(String reserved06) {
		this.reserved06 = reserved06;
	}


	public String getReserved07() {
		return this.reserved07;
	}

	public void setReserved07(String reserved07) {
		this.reserved07 = reserved07;
	}


	public String getReserved08() {
		return this.reserved08;
	}

	public void setReserved08(String reserved08) {
		this.reserved08 = reserved08;
	}


	public String getReserved09() {
		return this.reserved09;
	}

	public void setReserved09(String reserved09) {
		this.reserved09 = reserved09;
	}


	public String getReserved10() {
		return this.reserved10;
	}

	public void setReserved10(String reserved10) {
		this.reserved10 = reserved10;
	}


	public String getStain() {
		return this.stain;
	}

	public void setStain(String stain) {
		this.stain = stain;
	}


	@Column(name="STAIN_YN")
	public String getStainYn() {
		return this.stainYn;
	}

	public void setStainYn(String stainYn) {
		this.stainYn = stainYn;
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