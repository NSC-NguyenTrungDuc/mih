package nta.med.data.model.ihis.ocsa;

public class OCS0311U00grdSetCodeListInfo {
	  private String setPart ;
	  private String hangmogCode ;
	  private String setCode ;
	  private String comments ;
	  private String setCodeName ;
	public OCS0311U00grdSetCodeListInfo(String setPart, String hangmogCode,
			String setCode, String comments, String setCodeName) {
		super();
		this.setPart = setPart;
		this.hangmogCode = hangmogCode;
		this.setCode = setCode;
		this.comments = comments;
		this.setCodeName = setCodeName;
	}
	public String getSetPart() {
		return setPart;
	}
	public void setSetPart(String setPart) {
		this.setPart = setPart;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getSetCode() {
		return setCode;
	}
	public void setSetCode(String setCode) {
		this.setCode = setCode;
	}
	public String getComments() {
		return comments;
	}
	public void setComments(String comments) {
		this.comments = comments;
	}
	public String getSetCodeName() {
		return setCodeName;
	}
	public void setSetCodeName(String setCodeName) {
		this.setCodeName = setCodeName;
	}
	  
}
