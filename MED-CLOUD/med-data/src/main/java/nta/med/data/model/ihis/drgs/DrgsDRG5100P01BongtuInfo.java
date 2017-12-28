package nta.med.data.model.ihis.drgs;

/**
 * @author THUYVT
 *
 */
public class DrgsDRG5100P01BongtuInfo {
	private String jubsuDateWareki;
	private String actDateWareki;
	private String donbokYn;
	private String pattern;
	public DrgsDRG5100P01BongtuInfo(String jubsuDateWareki,
			String actDateWareki, String donbokYn, String pattern) {
		super();
		this.jubsuDateWareki = jubsuDateWareki;
		this.actDateWareki = actDateWareki;
		this.donbokYn = donbokYn;
		this.pattern = pattern;
	}
	public String getJubsuDateWareki() {
		return jubsuDateWareki;
	}
	public void setJubsuDateWareki(String jubsuDateWareki) {
		this.jubsuDateWareki = jubsuDateWareki;
	}
	public String getActDateWareki() {
		return actDateWareki;
	}
	public void setActDateWareki(String actDateWareki) {
		this.actDateWareki = actDateWareki;
	}
	public String getDonbokYn() {
		return donbokYn;
	}
	public void setDonbokYn(String donbokYn) {
		this.donbokYn = donbokYn;
	}
	public String getPattern() {
		return pattern;
	}
	public void setPattern(String pattern) {
		this.pattern = pattern;
	}
	
}
