package nta.med.data.model.ihis.cpls;

import java.sql.Timestamp;

public class CPL0000Q00LaySubHangmogListItemInfo {
	private String gumsaName;
    private Timestamp resultDate;
    private String cplResult;
	public CPL0000Q00LaySubHangmogListItemInfo(String gumsaName,
			Timestamp resultDate, String cplResult) {
		super();
		this.gumsaName = gumsaName;
		this.resultDate = resultDate;
		this.cplResult = cplResult;
	}
	public String getGumsaName() {
		return gumsaName;
	}
	public void setGumsaName(String gumsaName) {
		this.gumsaName = gumsaName;
	}
	public Timestamp getResultDate() {
		return resultDate;
	}
	public void setResultDate(Timestamp resultDate) {
		this.resultDate = resultDate;
	}
	public String getCplResult() {
		return cplResult;
	}
	public void setCplResult(String cplResult) {
		this.cplResult = cplResult;
	}
}
