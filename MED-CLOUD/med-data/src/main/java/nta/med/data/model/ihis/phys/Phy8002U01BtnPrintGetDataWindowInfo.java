package nta.med.data.model.ihis.phys;

public class Phy8002U01BtnPrintGetDataWindowInfo {
	private String yoyangName;
	private String simpleYoyangName;
	private String tel;
	private String homepage;

	public Phy8002U01BtnPrintGetDataWindowInfo(String yoyangName,
			String simpleYoyangName, String tel, String homepage) {
		super();
		this.yoyangName = yoyangName;
		this.simpleYoyangName = simpleYoyangName;
		this.tel = tel;
		this.homepage = homepage;
	}

	public String getYoyangName() {
		return yoyangName;
	}

	public void setYoyangName(String yoyangName) {
		this.yoyangName = yoyangName;
	}

	public String getSimpleYoyangName() {
		return simpleYoyangName;
	}

	public void setSimpleYoyangName(String simpleYoyangName) {
		this.simpleYoyangName = simpleYoyangName;
	}

	public String getTel() {
		return tel;
	}

	public void setTel(String tel) {
		this.tel = tel;
	}

	public String getHomepage() {
		return homepage;
	}

	public void setHomepage(String homepage) {
		this.homepage = homepage;
	}

}
