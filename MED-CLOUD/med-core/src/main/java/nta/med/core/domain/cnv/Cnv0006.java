package nta.med.core.domain.cnv;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;


/**
 * The persistent class for the CNV0006 database table.
 * 
 */
@Entity
@NamedQuery(name="Cnv0006.findAll", query="SELECT c FROM Cnv0006 c")
public class Cnv0006 extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String dummy1;
	private String dummy2;
	private String dummy3;
	private String dummy4;
	private String sgCode;
	private String sgName;

	public Cnv0006() {
	}


	public String getDummy1() {
		return this.dummy1;
	}

	public void setDummy1(String dummy1) {
		this.dummy1 = dummy1;
	}


	public String getDummy2() {
		return this.dummy2;
	}

	public void setDummy2(String dummy2) {
		this.dummy2 = dummy2;
	}


	public String getDummy3() {
		return this.dummy3;
	}

	public void setDummy3(String dummy3) {
		this.dummy3 = dummy3;
	}


	public String getDummy4() {
		return this.dummy4;
	}

	public void setDummy4(String dummy4) {
		this.dummy4 = dummy4;
	}


	@Column(name="SG_CODE")
	public String getSgCode() {
		return this.sgCode;
	}

	public void setSgCode(String sgCode) {
		this.sgCode = sgCode;
	}


	@Column(name="SG_NAME")
	public String getSgName() {
		return this.sgName;
	}

	public void setSgName(String sgName) {
		this.sgName = sgName;
	}

}