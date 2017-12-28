package nta.med.data.model.ihis.ocso;

import java.io.Serializable;

public class GwaListItemInfo implements Serializable {
	private String gwa;
	private String buseoName;

	public GwaListItemInfo(String gwa, String buseoName) {
		super();
		this.gwa = gwa;
		this.buseoName = buseoName;
	}

	public String getGwa() {
		return gwa;
	}

	public void setGwa(String gwa) {
		this.gwa = gwa;
	}

	public String getBuseoName() {
		return buseoName;
	}

	public void setBuseoName(String buseoName) {
		this.buseoName = buseoName;
	}

}
