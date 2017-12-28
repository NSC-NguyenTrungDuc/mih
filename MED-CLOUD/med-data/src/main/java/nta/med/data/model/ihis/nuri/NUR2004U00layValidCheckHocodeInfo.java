package nta.med.data.model.ihis.nuri;

public class NUR2004U00layValidCheckHocodeInfo {
	
    private String hoCode;
    private String hoTotalBed;
    private String hoGrade;
	
    public NUR2004U00layValidCheckHocodeInfo(String hoCode, String hoTotalBed, String hoGrade) {
		super();
		this.hoCode = hoCode;
		this.hoTotalBed = hoTotalBed;
		this.hoGrade = hoGrade;
	}
	
	public String getHoCode() {
		return hoCode;
	}
	public void setHoCode(String hoCode) {
		this.hoCode = hoCode;
	}
	public String getHoTotalBed() {
		return hoTotalBed;
	}
	public void setHoTotalBed(String hoTotalBed) {
		this.hoTotalBed = hoTotalBed;
	}
	public String getHoGrade() {
		return hoGrade;
	}
	public void setHoGrade(String hoGrade) {
		this.hoGrade = hoGrade;
	}
    
}
