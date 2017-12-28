package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR1001R07grdInp1001Info {

	private Double pkinp1001;
	private String ipwonDate;
	private String toiwonDate;
	private String hoDong1;
	private String hoCode1;

	public NUR1001R07grdInp1001Info(Double pkinp1001, String ipwonDate, String toiwonDate, String hoDong1, String hoCode1) {
		super();
		this.pkinp1001 = pkinp1001;
		this.ipwonDate = ipwonDate;
		this.toiwonDate = toiwonDate;
		this.hoDong1 = hoDong1;
		this.hoCode1 = hoCode1;
	}

	public Double getPkinp1001() {
		return pkinp1001;
	}

	public void setPkinp1001(Double pkinp1001) {
		this.pkinp1001 = pkinp1001;
	}

	public String getIpwonDate() {
		return ipwonDate;
	}

	public void setIpwonDate(String ipwonDate) {
		this.ipwonDate = ipwonDate;
	}

	public String getToiwonDate() {
		return toiwonDate;
	}

	public void setToiwonDate(String toiwonDate) {
		this.toiwonDate = toiwonDate;
	}

	public String getHoDong1() {
		return hoDong1;
	}

	public void setHoDong1(String hoDong1) {
		this.hoDong1 = hoDong1;
	}

	public String getHoCode1() {
		return hoCode1;
	}

	public void setHoCode1(String hoCode1) {
		this.hoCode1 = hoCode1;
	}

}
