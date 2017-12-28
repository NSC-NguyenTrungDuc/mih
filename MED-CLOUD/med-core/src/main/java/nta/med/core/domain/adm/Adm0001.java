package nta.med.core.domain.adm;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;


/**
 * The persistent class for the ADM0001 database table.
 * 
 */
@Entity
@NamedQuery(name="Adm0001.findAll", query="SELECT a FROM Adm0001 a")
public class Adm0001 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String langMode;

	public Adm0001() {
	}


	@Column(name="LANG_MODE")
	public String getLangMode() {
		return this.langMode;
	}

	public void setLangMode(String langMode) {
		this.langMode = langMode;
	}

}