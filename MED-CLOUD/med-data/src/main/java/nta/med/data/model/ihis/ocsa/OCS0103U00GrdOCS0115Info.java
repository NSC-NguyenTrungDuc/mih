package nta.med.data.model.ihis.ocsa;

import java.util.Date;

public class OCS0103U00GrdOCS0115Info {
	private String hangmogCode            ;                                         
	private String inputGwa               ;                                         
	private String inputPart              ;                                         
	private String gwaName                ;
	private String jundalTableOut        ;                                         
	private String jundalPartOut         ;                                         
	private String movePart               ;                                         
	private String jundalTableInp        ;                                         
	private String jundalPartInp         ;                                         
	private String gwaNameOut            ;
	private String gwaNameInp            ;
	private String movePartName          ;
	private Date startDate              ;                                          
	private Date endDate                ;                                          
	private String hospCode               ;
	private Date hangmogStartDate      ;
	public OCS0103U00GrdOCS0115Info(String hangmogCode, String inputGwa,
			String inputPart, String gwaName, String jundalTableOut,
			String jundalPartOut, String movePart, String jundalTableInp,
			String jundalPartInp, String gwaNameOut, String gwaNameInp,
			String movePartName, Date startDate, Date endDate, String hospCode,
			Date hangmogStartDate) {
		super();
		this.hangmogCode = hangmogCode;
		this.inputGwa = inputGwa;
		this.inputPart = inputPart;
		this.gwaName = gwaName;
		this.jundalTableOut = jundalTableOut;
		this.jundalPartOut = jundalPartOut;
		this.movePart = movePart;
		this.jundalTableInp = jundalTableInp;
		this.jundalPartInp = jundalPartInp;
		this.gwaNameOut = gwaNameOut;
		this.gwaNameInp = gwaNameInp;
		this.movePartName = movePartName;
		this.startDate = startDate;
		this.endDate = endDate;
		this.hospCode = hospCode;
		this.hangmogStartDate = hangmogStartDate;
	}
	public String getHangmogCode() {
		return hangmogCode;
	}
	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}
	public String getInputGwa() {
		return inputGwa;
	}
	public void setInputGwa(String inputGwa) {
		this.inputGwa = inputGwa;
	}
	public String getInputPart() {
		return inputPart;
	}
	public void setInputPart(String inputPart) {
		this.inputPart = inputPart;
	}
	public String getGwaName() {
		return gwaName;
	}
	public void setGwaName(String gwaName) {
		this.gwaName = gwaName;
	}
	public String getJundalTableOut() {
		return jundalTableOut;
	}
	public void setJundalTableOut(String jundalTableOut) {
		this.jundalTableOut = jundalTableOut;
	}
	public String getJundalPartOut() {
		return jundalPartOut;
	}
	public void setJundalPartOut(String jundalPartOut) {
		this.jundalPartOut = jundalPartOut;
	}
	public String getMovePart() {
		return movePart;
	}
	public void setMovePart(String movePart) {
		this.movePart = movePart;
	}
	public String getJundalTableInp() {
		return jundalTableInp;
	}
	public void setJundalTableInp(String jundalTableInp) {
		this.jundalTableInp = jundalTableInp;
	}
	public String getJundalPartInp() {
		return jundalPartInp;
	}
	public void setJundalPartInp(String jundalPartInp) {
		this.jundalPartInp = jundalPartInp;
	}
	public String getGwaNameOut() {
		return gwaNameOut;
	}
	public void setGwaNameOut(String gwaNameOut) {
		this.gwaNameOut = gwaNameOut;
	}
	public String getGwaNameInp() {
		return gwaNameInp;
	}
	public void setGwaNameInp(String gwaNameInp) {
		this.gwaNameInp = gwaNameInp;
	}
	public String getMovePartName() {
		return movePartName;
	}
	public void setMovePartName(String movePartName) {
		this.movePartName = movePartName;
	}
	public Date getStartDate() {
		return startDate;
	}
	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}
	public Date getEndDate() {
		return endDate;
	}
	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}
	public String getHospCode() {
		return hospCode;
	}
	public void setHospCode(String hospCode) {
		this.hospCode = hospCode;
	}
	public Date getHangmogStartDate() {
		return hangmogStartDate;
	}
	public void setHangmogStartDate(Date hangmogStartDate) {
		this.hangmogStartDate = hangmogStartDate;
	}
	
	

}
