package nta.med.data.model.ihis.nuro;

public class NuroOUT1001U01LayoutBarCodeInfo {
	 private String bunho;
     private String suname;
     private String sex;
     private String birth;
     private String bunho2;
     

	public NuroOUT1001U01LayoutBarCodeInfo(String bunho, String suname,
			String sex, String birth, String bunho2) {
		super();
		this.bunho = bunho;
		this.suname = suname;
		this.sex = sex;
		this.birth = birth;
		this.bunho2 = bunho2;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getSuname() {
		return suname;
	}
	public void setSuname(String suname) {
		this.suname = suname;
	}
	public String getSex() {
		return sex;
	}
	public void setSex(String sex) {
		this.sex = sex;
	}
	public String getBunho2() {
		return bunho2;
	}
	public void setBunho2(String bunho2) {
		this.bunho2 = bunho2;
	}
	public String getBirth() {
		return birth;
	}
	public void setBirth(String birth) {
		this.birth = birth;
	}
     
     
}
