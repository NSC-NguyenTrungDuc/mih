package nta.med.data.model.ihis.cpls;

public class CPL3010U00DsvUrineListItemInfo {
	private Double pkcpl1000;
    private String urineRyang;
    private String height;
    private String weight;
    private String stabilityYn;
    private String specimenSer;
	public CPL3010U00DsvUrineListItemInfo(Double pkcpl1000, String urineRyang,
			String height, String weight, String stabilityYn, String specimenSer) {
		super();
		this.pkcpl1000 = pkcpl1000;
		this.urineRyang = urineRyang;
		this.height = height;
		this.weight = weight;
		this.stabilityYn = stabilityYn;
		this.specimenSer = specimenSer;
	}
	public Double getPkcpl1000() {
		return pkcpl1000;
	}
	public void setPkcpl1000(Double pkcpl1000) {
		this.pkcpl1000 = pkcpl1000;
	}
	public String getUrineRyang() {
		return urineRyang;
	}
	public void setUrineRyang(String urineRyang) {
		this.urineRyang = urineRyang;
	}
	public String getHeight() {
		return height;
	}
	public void setHeight(String height) {
		this.height = height;
	}
	public String getWeight() {
		return weight;
	}
	public void setWeight(String weight) {
		this.weight = weight;
	}
	public String getStabilityYn() {
		return stabilityYn;
	}
	public void setStabilityYn(String stabilityYn) {
		this.stabilityYn = stabilityYn;
	}
	public String getSpecimenSer() {
		return specimenSer;
	}
	public void setSpecimenSer(String specimenSer) {
		this.specimenSer = specimenSer;
	}
}
