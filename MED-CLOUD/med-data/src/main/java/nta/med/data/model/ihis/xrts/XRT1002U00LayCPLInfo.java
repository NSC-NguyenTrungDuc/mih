package nta.med.data.model.ihis.xrts;

import java.io.Serializable;

public class XRT1002U00LayCPLInfo{
	private String hangmogName;
	private String hangmogResult;
	private String hangmogResultDate;

	public XRT1002U00LayCPLInfo(String hangmogName, String hangmogResult,
			String hangmogResultDate) {
		super();
		this.hangmogName = hangmogName;
		this.hangmogResult = hangmogResult;
		this.hangmogResultDate = hangmogResultDate;
	}

	public String getHangmogName() {
		return hangmogName;
	}

	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}

	public String getHangmogResult() {
		return hangmogResult;
	}

	public void setHangmogResult(String hangmogResult) {
		this.hangmogResult = hangmogResult;
	}

	public String getHangmogResultDate() {
		return hangmogResultDate;
	}

	public void setHangmogResultDate(String hangmogResultDate) {
		this.hangmogResultDate = hangmogResultDate;
	}

}
