package nta.med.data.model.ihis.ocso;

public class OCS2016U00LoadDiscussionInfo {

	private String doctor;
	private String doctorName;
	private String content;
	private String updated;
	private String editedFlg;
	private String grpQuestionId;
	private String discussionId;

	public OCS2016U00LoadDiscussionInfo(String doctor, String doctorName, String content, String updated,
			String editedFlg, String grpQuestionId, String discussionId) {
		super();
		this.doctor = doctor;
		this.doctorName = doctorName;
		this.content = content;
		this.updated = updated;
		this.editedFlg = editedFlg;
		this.grpQuestionId = grpQuestionId;
		this.discussionId = discussionId;
	}

	public String getDoctor() {
		return doctor;
	}

	public void setDoctor(String doctor) {
		this.doctor = doctor;
	}

	public String getDoctorName() {
		return doctorName;
	}

	public void setDoctorName(String doctorName) {
		this.doctorName = doctorName;
	}

	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public String getUpdated() {
		return updated;
	}

	public void setUpdated(String updated) {
		this.updated = updated;
	}

	public String getEditedFlg() {
		return editedFlg;
	}

	public void setEditedFlg(String editedFlg) {
		this.editedFlg = editedFlg;
	}

	public String getGrpQuestionId() {
		return grpQuestionId;
	}

	public void setGrpQuestionId(String grpQuestionId) {
		this.grpQuestionId = grpQuestionId;
	}

	public String getDiscussionId() {
		return discussionId;
	}

	public void setDiscussionId(String discussionId) {
		this.discussionId = discussionId;
	}

}
