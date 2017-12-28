package nta.med.data.model.ihis.nuro;

import java.math.BigInteger;
import java.util.Date;

public class ORDERTRANSGrdWoichulInfo {
	private Double fkinp1001        ;
	private Date fkOutDate      ;
	private String bunho            ;
	private Date outDate         ;
	private String outTime         ;
	private Date inHopeDate     ;
	private String inHopeTime     ;
	private Date inTrueDate     ;
	private String inTrueTime     ;
	private String outObjectText  ;
	private Date startDate       ;
	private Date endDate         ;
	private String actingYn        ;
	private String selectYn        ;
	private String sendYn          ;
	private BigInteger seq              ;
	public ORDERTRANSGrdWoichulInfo(Double fkinp1001, Date fkOutDate,
			String bunho, Date outDate, String outTime, Date inHopeDate,
			String inHopeTime, Date inTrueDate, String inTrueTime,
			String outObjectText, Date startDate, Date endDate,
			String actingYn, String selectYn, String sendYn, BigInteger seq) {
		super();
		this.fkinp1001 = fkinp1001;
		this.fkOutDate = fkOutDate;
		this.bunho = bunho;
		this.outDate = outDate;
		this.outTime = outTime;
		this.inHopeDate = inHopeDate;
		this.inHopeTime = inHopeTime;
		this.inTrueDate = inTrueDate;
		this.inTrueTime = inTrueTime;
		this.outObjectText = outObjectText;
		this.startDate = startDate;
		this.endDate = endDate;
		this.actingYn = actingYn;
		this.selectYn = selectYn;
		this.sendYn = sendYn;
		this.seq = seq;
	}
	public Double getFkinp1001() {
		return fkinp1001;
	}
	public void setFkinp1001(Double fkinp1001) {
		this.fkinp1001 = fkinp1001;
	}
	public Date getFkOutDate() {
		return fkOutDate;
	}
	public void setFkOutDate(Date fkOutDate) {
		this.fkOutDate = fkOutDate;
	}
	public String getBunho() {
		return bunho;
	}
	public void setBunho(String bunho) {
		this.bunho = bunho;
	}
	public Date getOutDate() {
		return outDate;
	}
	public void setOutDate(Date outDate) {
		this.outDate = outDate;
	}
	public String getOutTime() {
		return outTime;
	}
	public void setOutTime(String outTime) {
		this.outTime = outTime;
	}
	public Date getInHopeDate() {
		return inHopeDate;
	}
	public void setInHopeDate(Date inHopeDate) {
		this.inHopeDate = inHopeDate;
	}
	public String getInHopeTime() {
		return inHopeTime;
	}
	public void setInHopeTime(String inHopeTime) {
		this.inHopeTime = inHopeTime;
	}
	public Date getInTrueDate() {
		return inTrueDate;
	}
	public void setInTrueDate(Date inTrueDate) {
		this.inTrueDate = inTrueDate;
	}
	public String getInTrueTime() {
		return inTrueTime;
	}
	public void setInTrueTime(String inTrueTime) {
		this.inTrueTime = inTrueTime;
	}
	public String getOutObjectText() {
		return outObjectText;
	}
	public void setOutObjectText(String outObjectText) {
		this.outObjectText = outObjectText;
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
	public String getActingYn() {
		return actingYn;
	}
	public void setActingYn(String actingYn) {
		this.actingYn = actingYn;
	}
	public String getSelectYn() {
		return selectYn;
	}
	public void setSelectYn(String selectYn) {
		this.selectYn = selectYn;
	}
	public String getSendYn() {
		return sendYn;
	}
	public void setSendYn(String sendYn) {
		this.sendYn = sendYn;
	}
	public BigInteger getSeq() {
		return seq;
	}
	public void setSeq(BigInteger seq) {
		this.seq = seq;
	}
	
}
