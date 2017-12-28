package nta.med.data.model.ihis.cpls;

public class CPL3010U01MaxInfoListItemInfo {
	private String specimenSer ;
     private String partJubsuDate;
     private String partJubsuTime ;
	public CPL3010U01MaxInfoListItemInfo(String specimenSer,
			String partJubsuDate, String partJubsuTime) {
		super();
		this.specimenSer = specimenSer;
		this.partJubsuDate = partJubsuDate;
		this.partJubsuTime = partJubsuTime;
	}
	public String getSpecimenSer() {
		return specimenSer;
	}
	public void setSpecimenSer(String specimenSer) {
		this.specimenSer = specimenSer;
	}
	public String getPartJubsuDate() {
		return partJubsuDate;
	}
	public void setPartJubsuDate(String partJubsuDate) {
		this.partJubsuDate = partJubsuDate;
	}
	public String getPartJubsuTime() {
		return partJubsuTime;
	}
	public void setPartJubsuTime(String partJubsuTime) {
		this.partJubsuTime = partJubsuTime;
	}
     
     

}
