package nta.med.data.model.ihis.inps;

public class INP1001U01GrdOut0103Info {

	private String gwaName;
	private String doctor;
	private String gubunName;
	private String naewonDate;
	private String toiwonDate;

	public INP1001U01GrdOut0103Info(String gwaName, String doctor, String gubunName, String naewonDate,
			String toiwonDate) {
		super();
		this.gwaName = gwaName;
		this.doctor = doctor;
		this.gubunName = gubunName;
		this.naewonDate = naewonDate;
		this.toiwonDate = toiwonDate;
	}

	public String getGwaName() {
		return gwaName;
	}

	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}

	public String getDoctor() {
		return doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}

	public String getGubunName() {
		return gubunName;
	}

	public void setGubunName(String gubunName) {
		this.gubunName = gubunName;
	}

	public String getNaewonDate() {
		return naewonDate;
	}

	public void setNaewonDate(String naewonDate) {
		this.naewonDate = naewonDate;
	}

	public String getToiwonDate() {
		return toiwonDate;
	}

	public void setToiwonDate(String toiwonDate) {
		this.toiwonDate = toiwonDate;
	}

}
