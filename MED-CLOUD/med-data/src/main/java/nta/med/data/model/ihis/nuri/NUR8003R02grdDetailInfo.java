package nta.med.data.model.ihis.nuri;

import java.util.Date;

public class NUR8003R02grdDetailInfo {

	private Date writeDate;
	private String bunho;
	private String pName;
	private String payloadCode;
	private String payloadCodeName;
	private String payloadNo;
	private String payloadNoName;
	private String payloadContent;

	public NUR8003R02grdDetailInfo(Date writeDate, String bunho, String pName, String payloadCode,
			String payloadCodeName, String payloadNo, String payloadNoName, String payloadContent) {
		super();
		this.writeDate = writeDate;
		this.bunho = bunho;
		this.pName = pName;
		this.payloadCode = payloadCode;
		this.payloadCodeName = payloadCodeName;
		this.payloadNo = payloadNo;
		this.payloadNoName = payloadNoName;
		this.payloadContent = payloadContent;
	}

	public Date getWriteDate() {
		return writeDate;
	}

	public void setWriteDate(Date writeDate) {
		this.writeDate = writeDate;
	}

	public String getBunho() {
		return bunho;
	}

	public void setBunho(String bunho) {
		this.bunho = bunho;
	}

	public String getpName() {
		return pName;
	}

	public void setpName(String pName) {
		this.pName = pName;
	}

	public String getPayloadCode() {
		return payloadCode;
	}

	public void setPayloadCode(String payloadCode) {
		this.payloadCode = payloadCode;
	}

	public String getPayloadCodeName() {
		return payloadCodeName;
	}

	public void setPayloadCodeName(String payloadCodeName) {
		this.payloadCodeName = payloadCodeName;
	}

	public String getPayloadNo() {
		return payloadNo;
	}

	public void setPayloadNo(String payloadNo) {
		this.payloadNo = payloadNo;
	}

	public String getPayloadNoName() {
		return payloadNoName;
	}

	public void setPayloadNoName(String payloadNoName) {
		this.payloadNoName = payloadNoName;
	}

	public String getPayloadContent() {
		return payloadContent;
	}

	public void setPayloadContent(String payloadContent) {
		this.payloadContent = payloadContent;
	}

}
