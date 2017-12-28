package nta.med.data.model.ihis.cpls;

import java.sql.Timestamp;

public class CPL0000Q00LayJungboListItemInfo {
	private Timestamp orderDate;
    private String orderTime;
    private Timestamp jubsuDate;
    private String jubsuTime;
    private Timestamp partJubsuDate;
    private String partJubsuTime;
    private Timestamp resultDate;
    private String resultTime;
    private String specimenSer;
    private String specimenCode;
    private String specimenName;
    private String note;
    private String gwaName;
    private String doctorName;
    private String comment;
    private String fixNote;
    private String hangmogComment;
    private String paComment;
	public CPL0000Q00LayJungboListItemInfo(Timestamp orderDate,
			String orderTime, Timestamp jubsuDate, String jubsuTime,
			Timestamp partJubsuDate, String partJubsuTime,
			Timestamp resultDate, String resultTime, String specimenSer,
			String specimenCode, String specimenName, String note,
			String gwaName, String doctorName, String comment, String fixNote,
			String hangmogComment, String paComment) {
		super();
		this.orderDate = orderDate;
		this.orderTime = orderTime;
		this.jubsuDate = jubsuDate;
		this.jubsuTime = jubsuTime;
		this.partJubsuDate = partJubsuDate;
		this.partJubsuTime = partJubsuTime;
		this.resultDate = resultDate;
		this.resultTime = resultTime;
		this.specimenSer = specimenSer;
		this.specimenCode = specimenCode;
		this.specimenName = specimenName;
		this.note = note;
		this.gwaName = gwaName;
		this.doctorName = doctorName;
		this.comment = comment;
		this.fixNote = fixNote;
		this.hangmogComment = hangmogComment;
		this.paComment = paComment;
	}
	public Timestamp getOrderDate() {
		return orderDate;
	}
	public void setOrderDate(Timestamp orderDate) {
		this.orderDate = orderDate;
	}
	public String getOrderTime() {
		return orderTime;
	}
	public void setOrderTime(String orderTime) {
		this.orderTime = orderTime;
	}
	public Timestamp getJubsuDate() {
		return jubsuDate;
	}
	public void setJubsuDate(Timestamp jubsuDate) {
		this.jubsuDate = jubsuDate;
	}
	public String getJubsuTime() {
		return jubsuTime;
	}
	public void setJubsuTime(String jubsuTime) {
		this.jubsuTime = jubsuTime;
	}
	public Timestamp getPartJubsuDate() {
		return partJubsuDate;
	}
	public void setPartJubsuDate(Timestamp partJubsuDate) {
		this.partJubsuDate = partJubsuDate;
	}
	public String getPartJubsuTime() {
		return partJubsuTime;
	}
	public void setPartJubsuTime(String partJubsuTime) {
		this.partJubsuTime = partJubsuTime;
	}
	public Timestamp getResultDate() {
		return resultDate;
	}
	public void setResultDate(Timestamp resultDate) {
		this.resultDate = resultDate;
	}
	public String getResultTime() {
		return resultTime;
	}
	public void setResultTime(String resultTime) {
		this.resultTime = resultTime;
	}
	public String getSpecimenSer() {
		return specimenSer;
	}
	public void setSpecimenSer(String specimenSer) {
		this.specimenSer = specimenSer;
	}
	public String getSpecimenCode() {
		return specimenCode;
	}
	public void setSpecimenCode(String specimenCode) {
		this.specimenCode = specimenCode;
	}
	public String getSpecimenName() {
		return specimenName;
	}
	public void setSpecimenName(String specimenName) {
		this.specimenName = specimenName;
	}
	public String getNote() {
		return note;
	}
	public void setNote(String note) {
		this.note = note;
	}
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}
	public String getDoctorName() {
		return doctorName;
	}
	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}
	public String getComment() {
		return comment;
	}
	public void setComment(String comment) {
		this.comment = comment;
	}
	public String getFixNote() {
		return fixNote;
	}
	public void setFixNote(String fixNote) {
		this.fixNote = fixNote;
	}
	public String getHangmogComment() {
		return hangmogComment;
	}
	public void setHangmogComment(String hangmogComment) {
		this.hangmogComment = hangmogComment;
	}
	public String getPaComment() {
		return paComment;
	}
	public void setPaComment(String paComment) {
		this.paComment = paComment;
	}
    
}