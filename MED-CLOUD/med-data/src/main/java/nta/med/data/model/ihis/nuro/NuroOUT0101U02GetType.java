package nta.med.data.model.ihis.nuro;

import java.io.Serializable;

public class NuroOUT0101U02GetType implements Serializable {
	 private String type;
	 private String typeName;
	public NuroOUT0101U02GetType(String type, String typeName) {
		super();
		this.type = type;
		this.typeName = typeName;
	}
	public String getType() {
		return type;
	}
	public void setType(String type) {
		this.type = type;
	}
	public String getTypeName() {
		return typeName;
	}
	public void setTypeName(String typeName) {
		this.typeName = typeName;
	}
	 
	 
}
