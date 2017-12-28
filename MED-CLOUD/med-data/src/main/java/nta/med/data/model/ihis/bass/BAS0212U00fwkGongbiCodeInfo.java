package nta.med.data.model.ihis.bass;

import java.io.Serializable;

public class BAS0212U00fwkGongbiCodeInfo implements Serializable{
	private String gongbiCode;
	private String gongbiName;
	public BAS0212U00fwkGongbiCodeInfo(String gongbiCode, String gongbiName) {
		super();
		this.gongbiCode = gongbiCode;
		this.gongbiName = gongbiName;
	}
	public String getGongbiCode() {
		return gongbiCode;
	}
	public void setGongbiCode(String gongbiCode) {
		this.gongbiCode = gongbiCode;
	}
	public String getGongbiName() {
		return gongbiName;
	}
	public void setGongbiName(String gongbiName) {
		this.gongbiName = gongbiName;
	}
	
}
