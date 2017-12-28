package nta.med.data.model.ihis.bass;

public class HoGradeInfo {

	private String hoGrade;
	private String hoGradeName;

	public HoGradeInfo(String hoGrade, String hoGradeName) {
		super();
		this.hoGrade = hoGrade;
		this.hoGradeName = hoGradeName;
	}

	public String getHoGrade() {
		return hoGrade;
	}

	public void setHoGrade(String hoGrade) {
		this.hoGrade = hoGrade;
	}

	public String getHoGradeName() {
		return hoGradeName;
	}

	public void setHoGradeName(String hoGradeName) {
		this.hoGradeName = hoGradeName;
	}

}
