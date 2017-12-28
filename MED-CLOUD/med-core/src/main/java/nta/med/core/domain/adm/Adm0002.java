package nta.med.core.domain.adm;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the ADM0002 database table.
 * 
 */
@Entity
//@NamedQuery(name="Adm0002.findAll", query="SELECT a FROM Adm0002 a")
@Table(name = "ADM0002")
public class Adm0002 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private Double adm0002Pk;
	private String japanMsg;
	private String koreaMsg;
	private String msgGubun;
	private String speakMsg;

	public Adm0002() {
	}


	@Column(name="ADM0002_PK")
	public Double getAdm0002Pk() {
		return this.adm0002Pk;
	}

	public void setAdm0002Pk(Double adm0002Pk) {
		this.adm0002Pk = adm0002Pk;
	}


	@Column(name="JAPAN_MSG")
	public String getJapanMsg() {
		return this.japanMsg;
	}

	public void setJapanMsg(String japanMsg) {
		this.japanMsg = japanMsg;
	}


	@Column(name="KOREA_MSG")
	public String getKoreaMsg() {
		return this.koreaMsg;
	}

	public void setKoreaMsg(String koreaMsg) {
		this.koreaMsg = koreaMsg;
	}


	@Column(name="MSG_GUBUN")
	public String getMsgGubun() {
		return this.msgGubun;
	}

	public void setMsgGubun(String msgGubun) {
		this.msgGubun = msgGubun;
	}


	@Column(name="SPEAK_MSG")
	public String getSpeakMsg() {
		return this.speakMsg;
	}

	public void setSpeakMsg(String speakMsg) {
		this.speakMsg = speakMsg;
	}

}