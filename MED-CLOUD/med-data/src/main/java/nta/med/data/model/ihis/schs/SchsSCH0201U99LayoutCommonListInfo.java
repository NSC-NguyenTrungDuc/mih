package nta.med.data.model.ihis.schs;

public class SchsSCH0201U99LayoutCommonListInfo {
	private String doctorName;
	private String reserYn;

	public SchsSCH0201U99LayoutCommonListInfo(String doctorName, String reserYn) {
		super();
		this.doctorName = doctorName;
		this.reserYn = reserYn;
	}

	public String getDoctorName() {
		return doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}

	public String getReserYn() {
		return reserYn;
	}

	public void setReserYn(String reserYn) {
		this.reserYn = reserYn;
	}

}
