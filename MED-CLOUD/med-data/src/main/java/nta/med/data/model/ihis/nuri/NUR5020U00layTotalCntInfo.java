package nta.med.data.model.ihis.nuri;

public class NUR5020U00layTotalCntInfo {

	private String emkyesterday;
	private String emkipwon;
	private String emktoiwon;
	private String emkjaewon;
	private String emkmovein;
	private String emkmoveout;

	public NUR5020U00layTotalCntInfo(String emkyesterday, String emkipwon, String emktoiwon, String emkjaewon,
			String emkmovein, String emkmoveout) {
		super();
		this.emkyesterday = emkyesterday;
		this.emkipwon = emkipwon;
		this.emktoiwon = emktoiwon;
		this.emkjaewon = emkjaewon;
		this.emkmovein = emkmovein;
		this.emkmoveout = emkmoveout;
	}

	public String getEmkyesterday() {
		return emkyesterday;
	}

	public void setEmkyesterday(String emkyesterday) {
		this.emkyesterday = emkyesterday;
	}

	public String getEmkipwon() {
		return emkipwon;
	}

	public void setEmkipwon(String emkipwon) {
		this.emkipwon = emkipwon;
	}

	public String getEmktoiwon() {
		return emktoiwon;
	}

	public void setEmktoiwon(String emktoiwon) {
		this.emktoiwon = emktoiwon;
	}

	public String getEmkjaewon() {
		return emkjaewon;
	}

	public void setEmkjaewon(String emkjaewon) {
		this.emkjaewon = emkjaewon;
	}

	public String getEmkmovein() {
		return emkmovein;
	}

	public void setEmkmovein(String emkmovein) {
		this.emkmovein = emkmovein;
	}

	public String getEmkmoveout() {
		return emkmoveout;
	}

	public void setEmkmoveout(String emkmoveout) {
		this.emkmoveout = emkmoveout;
	}

}
