package nta.med.data.model.ihis.nuri;

import java.math.BigInteger;
import java.util.Date;

public class NUR1020Q00layIpwonInfoInfo {

	private String fkinp1001;
	private Date ipwonDate;
	private BigInteger jaewonilsu;
	private String hoDong;

	public NUR1020Q00layIpwonInfoInfo(String fkinp1001, Date ipwonDate, BigInteger jaewonilsu, String hoDong) {
		super();
		this.fkinp1001 = fkinp1001;
		this.ipwonDate = ipwonDate;
		this.jaewonilsu = jaewonilsu;
		this.hoDong = hoDong;
	}

	public String getFkinp1001() {
		return fkinp1001;
	}

	public void setFkinp1001(String fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}

	public Date getIpwonDate() {
		return ipwonDate;
	}

	public void setIpwonDate(Date ipwonDate) {
		this.ipwonDate = ipwonDate;
	}

	public BigInteger getJaewonilsu() {
		return jaewonilsu;
	}

	public void setJaewonilsu(BigInteger jaewonilsu) {
		this.jaewonilsu = jaewonilsu;
	}

	public String getHoDong() {
		return hoDong;
	}

	public void setHoDong(String hoDong) {
		this.hoDong = hoDong;
	}

}
