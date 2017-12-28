package nta.med.data.model.ihis.nuro;

import java.util.Date;

public class NUR2016U02GrdListInfo {
	private String selectN;
	private String hospCodeLink;
	private String yoyangName;
	private String bunhoLink;
	private String suname;
	private String address1;
	private Date birth;
	public NUR2016U02GrdListInfo(String selectN, String hospCodeLink, String yoyangName, String bunhoLink,
			String suname, String address1, Date birth) {
		super();
		this.selectN = selectN;
		this.hospCodeLink = hospCodeLink;
		this.yoyangName = yoyangName;
		this.bunhoLink = bunhoLink;
		this.suname = suname;
		this.address1 = address1;
		this.birth = birth;
	}
	public String getSelectN() {
		return selectN;
	}
	public void setSelectN(String selectN) {
		this.selectN = selectN;
	}
	public String getHospCodeLink() {
		return hospCodeLink;
	}
	public void setHospCodeLink(String hospCodeLink) {
		this.hospCodeLink = hospCodeLink;
	}
	public String getYoyangName() {
		return yoyangName;
	}
	public void setYoyangName(String yoyangName) {
		this.yoyangName = yoyangName;
	}
	public String getBunhoLink() {
		return bunhoLink;
	}
	public void setBunhoLink(String bunhoLink) {
		this.bunhoLink = bunhoLink;
	}
	public String getSuname() {
		return suname;
	}
	public void setSuname(String suname) {
		this.suname = suname;
	}
	public String getAddress1() {
		return address1;
	}
	public void setAddress1(String address1) {
		this.address1 = address1;
	}
	public Date getBirth() {
		return birth;
	}
	public void setBirth(Date birth) {
		this.birth = birth;
	}
	

}
