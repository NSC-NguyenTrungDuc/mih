package nta.med.data.model.ihis.ocso;

public class OCS1003R02DTHospListItemInfo {
	 private String jaedanName ;
	 private String simpleYoyangName ;
	 private String tel ;
	 private String homepage ;
	public OCS1003R02DTHospListItemInfo(String jaedanName,
			String simpleYoyangName, String tel, String homepage) {
		super();
		this.jaedanName = jaedanName;
		this.simpleYoyangName = simpleYoyangName;
		this.tel = tel;
		this.homepage = homepage;
	}
	public String getJaedanName() {
		return jaedanName;
	}
	public void setJaedanName(String jaedanName) {
		this.jaedanName = jaedanName;
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
