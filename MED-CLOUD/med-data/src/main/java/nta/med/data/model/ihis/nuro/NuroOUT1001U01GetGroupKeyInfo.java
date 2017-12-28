package nta.med.data.model.ihis.nuro;

import java.io.Serializable;

public class NuroOUT1001U01GetGroupKeyInfo implements Serializable{
	private String groupKey;

	public NuroOUT1001U01GetGroupKeyInfo(String groupKey) {
		super();
		this.groupKey = groupKey;
	}

	public String getGroupKey() {
		return groupKey;
	}

	public void setGroupKey(String groupKey) {
	}
	
	
}
