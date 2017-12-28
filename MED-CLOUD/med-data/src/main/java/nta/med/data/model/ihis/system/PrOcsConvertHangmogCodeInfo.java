package nta.med.data.model.ihis.system;

public class PrOcsConvertHangmogCodeInfo {
	private String ioHangmogCode;
	private String ioMsgYn;
	private String ioRemark;

	public PrOcsConvertHangmogCodeInfo(String ioHangmogCode, String ioMsgYn,
			String ioRemark) {
		super();
		this.ioHangmogCode = ioHangmogCode;
		this.ioMsgYn = ioMsgYn;
		this.ioRemark = ioRemark;
	}

	public String getIoHangmogCode() {
		return ioHangmogCode;
	}

	public void setIoHangmogCode(String ioHangmogCode) {
		this.ioHangmogCode = ioHangmogCode;
	}

	public String getIoMsgYn() {
		return ioMsgYn;
	}

	public void setIoMsgYn(String ioMsgYn) {
		this.ioMsgYn = ioMsgYn;
	}

	public String getIoRemark() {
		return ioRemark;
	}

	public void setIoRemark(String ioRemark) {
		this.ioRemark = ioRemark;
	}

}
