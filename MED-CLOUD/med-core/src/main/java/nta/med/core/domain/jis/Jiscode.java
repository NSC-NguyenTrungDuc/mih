package nta.med.core.domain.jis;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.NamedQuery;

import nta.med.core.domain.BaseEntity;


/**
 * The persistent class for the JISCODE database table.
 * 
 */
@Entity
@NamedQuery(name="Jiscode.findAll", query="SELECT j FROM Jiscode j")
public class Jiscode extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String jisCode;
	private String jisName;

	public Jiscode() {
	}


	@Column(name="JIS_CODE")
	public String getJisCode() {
		return this.jisCode;
	}

	public void setJisCode(String jisCode) {
		this.jisCode = jisCode;
	}


	@Column(name="JIS_NAME")
	public String getJisName() {
		return this.jisName;
	}

	public void setJisName(String jisName) {
		this.jisName = jisName;
	}

}