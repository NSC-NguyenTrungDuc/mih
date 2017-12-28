package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;

import javax.persistence.*;


/**
 * The persistent class for the ADM0003 database table.
 * 
 */
@Entity
@Table(name="ADM0003")
public class Adm0003 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Double adm0003Pk;
	private String grpId;
	private String regiMemb;
	private String msgSource;
	private String msg;
	private String language;

	public Adm0003() {
	}


	@Column(name="ADM0003_PK")
	public Double getAdm0003Pk() {
		return this.adm0003Pk;
	}

	public void setAdm0003Pk(Double adm0003Pk) {
		this.adm0003Pk = adm0003Pk;
	}


	@Column(name="GRP_ID")
	public String getGrpId() {
		return this.grpId;
	}

	public void setGrpId(String grpId) {
		this.grpId = grpId;
	}


	@Column(name="MSG")
	public String getMsg() {
		return this.msg;
	}

	public void setMsg(String msg) {
		this.msg = msg;
	}


	@Column(name="LANGUAGE")
	public String getLanguage() {
		return this.language;
	}
	
	public void setLanguage(String language) {
		this.language = language;
	}


	@Column(name="MSG_SOURCE")
	public String getMsgSource() {
		return this.msgSource;
	}

	public void setMsgSource(String msgSource) {
		this.msgSource = msgSource;
	}


	@Column(name="REGI_MEMB")
	public String getRegiMemb() {
		return this.regiMemb;
	}

	public void setRegiMemb(String regiMemb) {
		this.regiMemb = regiMemb;
	}

}