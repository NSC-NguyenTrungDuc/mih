package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;
import java.util.Date;


/**
 * The persistent class for the ADM0000 database table.
 * 
 */
@Entity
@NamedQuery(name="Adm0000.findAll", query="SELECT a FROM Adm0000 a")
public class Adm0000 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String gatakanaFull;
	private String gatakanaHalf;
	private String hiragana;

	private Date sysDate;
	private String sysId;
	private Date updDate;
	private String userId;

	public Adm0000() {
	}


	@Column(name="GATAKANA_FULL")
	public String getGatakanaFull() {
		return this.gatakanaFull;
	}

	public void setGatakanaFull(String gatakanaFull) {
		this.gatakanaFull = gatakanaFull;
	}


	@Column(name="GATAKANA_HALF")
	public String getGatakanaHalf() {
		return this.gatakanaHalf;
	}

	public void setGatakanaHalf(String gatakanaHalf) {
		this.gatakanaHalf = gatakanaHalf;
	}


	public String getHiragana() {
		return this.hiragana;
	}

	public void setHiragana(String hiragana) {
		this.hiragana = hiragana;
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


	@Column(name="USER_ID")
	public String getUserId() {
		return this.userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

}