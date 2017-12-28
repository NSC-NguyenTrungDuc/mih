package nta.med.data.model.ihis.nuri;

public class NUR1010Q00SelectHosexInfo {
	private String hoSex;
	private String hoSpecialYn;
	private String totalBed;
	private String usedBed;
	
	public NUR1010Q00SelectHosexInfo(String hoSex, String hoSpecialYn, String totalBed, String usedBed) {
		super();
		this.hoSex = hoSex;
		this.hoSpecialYn = hoSpecialYn;
		this.totalBed = totalBed;
		this.usedBed = usedBed;
	}

	public String getHoSex() {
		return hoSex;
	}

	public void setHoSex(String hoSex) {
		this.hoSex = hoSex;
	}

	public String getHoSpecialYn() {
		return hoSpecialYn;
	}

	public void setHoSpecialYn(String hoSpecialYn) {
		this.hoSpecialYn = hoSpecialYn;
	}

	public String getTotalBed() {
		return totalBed;
	}

	public void setTotalBed(String totalBed) {
		this.totalBed = totalBed;
	}

	public String getUsedBed() {
		return usedBed;
	}

	public void setUsedBed(String usedBed) {
		this.usedBed = usedBed;
	}
		
}
