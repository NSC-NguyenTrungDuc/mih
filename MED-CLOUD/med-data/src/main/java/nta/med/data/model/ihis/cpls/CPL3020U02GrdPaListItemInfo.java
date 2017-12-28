package nta.med.data.model.ihis.cpls;

import java.sql.Timestamp;

public class CPL3020U02GrdPaListItemInfo {
	private String labNo;
    private String suname;
    private String specimenSer;
    private String labSort;
    private Timestamp partJubsuDate;
    private String jundalGubun;
    private String gubun;
    private String resultYn;
    private String confirmYn;
	public CPL3020U02GrdPaListItemInfo(String labNo, String suname,
			String specimenSer, String labSort, Timestamp partJubsuDate,
			String jundalGubun, String gubun, String resultYn, String confirmYn) {
		super();
		this.labNo = labNo;
		this.suname = suname;
		this.specimenSer = specimenSer;
		this.labSort = labSort;
		this.partJubsuDate = partJubsuDate;
		this.jundalGubun = jundalGubun;
		this.gubun = gubun;
		this.resultYn = resultYn;
		this.confirmYn = confirmYn;
	}
	public String getLabNo() {
		return labNo;
	}
	public void setLabNo(String labNo) {
		this.labNo = labNo;
	}
	public String getSuname() {
		return suname;
	}
	public void setSuname(String suname) {
		this.suname = suname;
	}
	public String getSpecimenSer() {
		return specimenSer;
	}
	public void setSpecimenSer(String specimenSer) {
		this.specimenSer = specimenSer;
	}
	public String getLabSort() {
		return labSort;
	}
	public void setLabSort(String labSort) {
		this.labSort = labSort;
	}
	public Timestamp getPartJubsuDate() {
		return partJubsuDate;
	}
	public void setPartJubsuDate(Timestamp partJubsuDate) {
		this.partJubsuDate = partJubsuDate;
	}
	public String getJundalGubun() {
		return jundalGubun;
	}
	public void setJundalGubun(String jundalGubun) {
		this.jundalGubun = jundalGubun;
	}
	public String getGubun() {
		return gubun;
	}
	public void setGubun(String gubun) {
		this.gubun = gubun;
	}
	public String getResultYn() {
		return resultYn;
	}
	public void setResultYn(String resultYn) {
		this.resultYn = resultYn;
	}
	public String getConfirmYn() {
		return confirmYn;
	}
	public void setConfirmYn(String confirmYn) {
		this.confirmYn = confirmYn;
	}
}
