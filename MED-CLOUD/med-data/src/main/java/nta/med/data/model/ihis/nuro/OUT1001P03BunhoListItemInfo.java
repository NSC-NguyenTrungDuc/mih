package nta.med.data.model.ihis.nuro;

public class OUT1001P03BunhoListItemInfo {
	private String bunho;
	private String suname;
	private String sex;

	public OUT1001P03BunhoListItemInfo(String bunho, String suname, String sex) {
		super();
		this.bunho = bunho;
		this.suname = suname;
		this.sex = sex;
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

}
