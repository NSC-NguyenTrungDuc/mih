package nta.med.data.model.ihis.cpls;

public class CPL3020U02DsvNoteListItemInfo {
	private String jundalPart;
    private String specimenSer;
    private String note;
    private String code;
    private String etcComment;
	public CPL3020U02DsvNoteListItemInfo(String jundalPart, String specimenSer,
			String note, String code, String etcComment) {
		super();
		this.jundalPart = jundalPart;
		this.specimenSer = specimenSer;
		this.note = note;
		this.code = code;
		this.etcComment = etcComment;
	}
	public String getJundalPart() {
		return jundalPart;
	}
	public void setJundalPart(String jundalPart) {
		this.jundalPart = jundalPart;
	}
	public String getSpecimenSer() {
		return specimenSer;
	}
	public void setSpecimenSer(String specimenSer) {
		this.specimenSer = specimenSer;
	}
	public String getNote() {
		return note;
	}
	public void setNote(String note) {
		this.note = note;
	}
	public String getCode() {
		return code;
	}
	public void setCode(String code) {
		this.code = code;
	}
	public String getEtcComment() {
		return etcComment;
	}
	public void setEtcComment(String etcComment) {
		this.etcComment = etcComment;
	}
}
