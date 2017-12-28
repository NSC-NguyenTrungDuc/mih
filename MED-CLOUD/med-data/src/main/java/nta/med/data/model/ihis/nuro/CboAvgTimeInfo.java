package nta.med.data.model.ihis.nuro;

public class CboAvgTimeInfo {
	private String timeTerm;
	private String timeTerm2;

	public CboAvgTimeInfo(String timeTerm, String timeTerm2) {
		super();
		this.timeTerm = timeTerm;
		this.timeTerm2 = timeTerm2;
	}

	public String getTimeTerm() {
		return timeTerm;
	}

	public void setTimeTerm(String timeTerm) {
		this.timeTerm = timeTerm;
	}

	public String getTimeTerm2() {
		return timeTerm2;
	}

	public void setTimeTerm2(String timeTerm2) {
		this.timeTerm2 = timeTerm2;
	}

}