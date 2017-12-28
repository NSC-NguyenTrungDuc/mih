package nta.med.data.model.ihis.chts;

import java.io.Serializable;

public class CHT0115Q00GrdScInfo implements Serializable {
	private String susikCode ;
	private String susikName ;
	private String susikNameGana ;
	private String susikDetailGubun ;
	public CHT0115Q00GrdScInfo(String susikCode, String susikName,
			String susikNameGana, String susikDetailGubun) {
		super();
		this.susikCode = susikCode;
		this.susikName = susikName;
		this.susikNameGana = susikNameGana;
		this.susikDetailGubun = susikDetailGubun;
	}
	public String getSusikCode() {
		return susikCode;
	}
	public void setSusikCode(String susikCode) {
		this.susikCode = susikCode;
	}
	public String getSusikName() {
		return susikName;
	}
	public void setSusikName(String susikName) {
		this.susikName = susikName;
	}
	public String getSusikNameGana() {
		return susikNameGana;
	}
	public void setSusikNameGana(String susikNameGana) {
		this.susikNameGana = susikNameGana;
	}
	public String getSusikDetailGubun() {
		return susikDetailGubun;
	}
	public void setSusikDetailGubun(String susikDetailGubun) {
		this.susikDetailGubun = susikDetailGubun;
	}
}
