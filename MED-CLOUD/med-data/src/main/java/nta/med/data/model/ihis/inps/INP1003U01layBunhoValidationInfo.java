package nta.med.data.model.ihis.inps;

public class INP1003U01layBunhoValidationInfo {
	
	private String suname;
	private String tel;
	private String tel2;
	private String deleteYn;
	private String jubsuBreak;
	private String codeName;
	private String sex;
	private String flag;
	
	public INP1003U01layBunhoValidationInfo(String suname, String tel, String tel2, String deleteYn, String jubsuBreak,
							String codeName, String sex, String flag){
		this.suname = suname;
		this.tel = tel;
		this.tel2 = tel2;
		this.deleteYn = deleteYn;
		this.jubsuBreak = jubsuBreak;
		this.codeName = codeName;
		this.sex = sex;
		this.flag = flag;
	}

	public String getSuname() {
		return suname;
	}

	public void setSuname(String suname) {
		this.suname = suname;
	}

	public String getTel() {
		return tel;
	}

	public void setTel(String tel) {
		this.tel = tel;
	}

	public String getTel2() {
		return tel2;
	}

	public void setTel2(String tel2) {
		this.tel2 = tel2;
	}

	public String getDeleteYn() {
		return deleteYn;
	}

	public void setDeleteYn(String deleteYn) {
		this.deleteYn = deleteYn;
	}

	public String getJubsuBreak() {
		return jubsuBreak;
	}

	public void setJubsuBreak(String jubsuBreak) {
		this.jubsuBreak = jubsuBreak;
	}

	public String getCodeName() {
		return codeName;
	}

	public void setCodeName(String codeName) {
		this.codeName = codeName;
	}

	public String getSex() {
		return sex;
	}

	public void setSex(String sex) {
		this.sex = sex;
	}

	public String getFlag() {
		return flag;
	}

	public void setFlag(String flag) {
		this.flag = flag;
	}
	
	
}
