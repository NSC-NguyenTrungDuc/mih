package nta.med.core.domain.ifs;

import nta.med.core.domain.BaseEntity;

import java.io.Serializable;
import javax.persistence.*;


/**
 * The persistent class for the IFSTEMP database table.
 * 
 */
@Entity
@NamedQuery(name="Ifstemp.findAll", query="SELECT i FROM Ifstemp i")
public class Ifstemp extends BaseEntity {
	private static final long serialVersionUID = 1L;
	private String a1;
	private String a2;
	private String a3;

	public Ifstemp() {
	}


	public String getA1() {
		return this.a1;
	}

	public void setA1(String a1) {
		this.a1 = a1;
	}


	public String getA2() {
		return this.a2;
	}

	public void setA2(String a2) {
		this.a2 = a2;
	}


	public String getA3() {
		return this.a3;
	}

	public void setA3(String a3) {
		this.a3 = a3;
	}

}