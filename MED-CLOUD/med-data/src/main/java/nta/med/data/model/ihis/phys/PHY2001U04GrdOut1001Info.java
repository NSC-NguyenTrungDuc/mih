package nta.med.data.model.ihis.phys;

public class PHY2001U04GrdOut1001Info {
	private String bunho                  ;
	private String naewonDate            ;
	private String jubsuGubun            ;
	private String next                   ;
	public PHY2001U04GrdOut1001Info(String bunho, String naewonDate,
			String jubsuGubun, String next) {
		super();
		this.bunho = bunho;
		this.naewonDate = naewonDate;
		this.jubsuGubun = jubsuGubun;
		this.next = next;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public String getNaewonDate() {
		return naewonDate;
	}
	public void setNaewonDate(String naewonDate) {
		this.naewonDate = naewonDate;
	}
	public String getJubsuGubun() {
		return jubsuGubun;
	}
	public void setJubsuGubun(String jubsuGubun) {
		this.jubsuGubun = jubsuGubun;
	}
	public String getNext() {
		return next;
	}
	public void setNext(String next) {
		this.next = next;
	}
	

}
