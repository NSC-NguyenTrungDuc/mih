package nta.med.data.model.ihis.system;

import java.io.Serializable;

public class TripleListItemInfo implements Serializable {
	private String item1;
	private String item2;
	private String item3;
	
	public TripleListItemInfo(String item1, String item2, String item3) {
		this.item1 = item1;
		this.item2 = item2;
		this.item3 = item3;
	}
	
	public String getItem1() {
		return item1;
	}
	public void setItem1(String item1) {
		this.item1 = item1;
	}
	public String getItem2() {
		return item2;
	}
	public void setItem2(String item2) {
		this.item2 = item2;
	}
	public String getItem3() {
		return item3;
	}
	public void setItem3(String item3) {
		this.item3 = item3;
	}
}
