package nta.med.data.model.ihis.system;

public class PrOcsLoadJundalInfo {
	private String ioJundalPartOut;
	private String ioJundalPartInp;
	private String ioJundalTableOut;
	private String ioJundalTableInp;
	private String ioMovePart;
	private String ioFlag;
	private String ioMsg;

	public PrOcsLoadJundalInfo(String ioJundalPartOut, String ioJundalPartInp,
			String ioJundalTableOut, String ioJundalTableInp,
			String ioMovePart, String ioFlag, String ioMsg) {
		super();
		this.ioJundalPartOut = ioJundalPartOut;
		this.ioJundalPartInp = ioJundalPartInp;
		this.ioJundalTableOut = ioJundalTableOut;
		this.ioJundalTableInp = ioJundalTableInp;
		this.ioMovePart = ioMovePart;
		this.ioFlag = ioFlag;
		this.ioMsg = ioMsg;
	}

	public PrOcsLoadJundalInfo() {
	}

	public String getIoJundalPartOut() {
		return ioJundalPartOut;
	}

	public void setIoJundalPartOut(String ioJundalPartOut) {
		this.ioJundalPartOut = ioJundalPartOut;
	}

	public String getIoJundalPartInp() {
		return ioJundalPartInp;
	}

	public void setIoJundalPartInp(String ioJundalPartInp) {
		this.ioJundalPartInp = ioJundalPartInp;
	}

	public String getIoJundalTableOut() {
		return ioJundalTableOut;
	}

	public void setIoJundalTableOut(String ioJundalTableOut) {
		this.ioJundalTableOut = ioJundalTableOut;
	}

	public String getIoJundalTableInp() {
		return ioJundalTableInp;
	}

	public void setIoJundalTableInp(String ioJundalTableInp) {
		this.ioJundalTableInp = ioJundalTableInp;
	}

	public String getIoMovePart() {
		return ioMovePart;
	}

	public void setIoMovePart(String ioMovePart) {
		this.ioMovePart = ioMovePart;
	}

	public String getIoFlag() {
		return ioFlag;
	}

	public void setIoFlag(String ioFlag) {
		this.ioFlag = ioFlag;
	}

	public String getIoMsg() {
		return ioMsg;
	}

	public void setIoMsg(String ioMsg) {
		this.ioMsg = ioMsg;
	}

}
