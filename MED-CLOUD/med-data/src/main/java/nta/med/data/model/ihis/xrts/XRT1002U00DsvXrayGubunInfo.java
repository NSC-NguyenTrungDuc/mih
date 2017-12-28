package nta.med.data.model.ihis.xrts;

import java.io.Serializable;

public class XRT1002U00DsvXrayGubunInfo implements Serializable{
	private String xrayGubun   ;
	private String xrayName    ;
	private String requestYn   ;
	public XRT1002U00DsvXrayGubunInfo(String xrayGubun, String xrayName,
			String requestYn) {
		super();
		this.xrayGubun = xrayGubun;
		this.xrayName = xrayName;
		this.requestYn = requestYn;
	}
	public String getXrayGubun() {
		return xrayGubun;
	}
	public void setXrayGubun(String xrayGubun) {
		this.xrayGubun = xrayGubun;
	}
	public String getXrayName() {
		return xrayName;
	}
	public void setXrayName(String xrayName) {
		this.xrayName = xrayName;
	}
	public String getRequestYn() {
		return requestYn;
	}
	public void setRequestYn(String requestYn) {
		this.requestYn = requestYn;
	}
}
