
package nta.med.data.model.ihis.emr;

import java.io.Serializable;

public class OCS2015U00GetDataInsPersonInfo implements Serializable {
    private String insPersonNo;
    private String recipientNo;
    
	public OCS2015U00GetDataInsPersonInfo(String insPersonNo, String recipientNo) {
		super();
		this.insPersonNo = insPersonNo;
		this.recipientNo = recipientNo;
	}

	public String getInsPersonNo() {
		return insPersonNo;
	}

	public void setInsPersonNo(String insPersonNo) {
		this.insPersonNo = insPersonNo;
	}

	public String getRecipientNo() {
		return recipientNo;
	}

	public void setRecipientNo(String recipientNo) {
		this.recipientNo = recipientNo;
	}
    
}
