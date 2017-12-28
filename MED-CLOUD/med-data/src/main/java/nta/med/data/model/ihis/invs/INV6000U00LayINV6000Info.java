package nta.med.data.model.ihis.invs;

import java.util.Date;

import org.joda.time.DateTime;

public class INV6000U00LayINV6000Info {
	private Double pkinv6001       ;
	private String magamMonth     ;
	private String inputDate      ;
	private String userName       ;
	private String remark          ;
	private String processTime ;
	public INV6000U00LayINV6000Info(Double pkinv6001, String magamMonth, String inputDate, String userName,
			String remark, String processTime) {
		super();
		this.pkinv6001 = pkinv6001;
		this.magamMonth = magamMonth;
		this.inputDate = inputDate;
		this.userName = userName;
		this.remark = remark;
		this.processTime = processTime;
	}
	public Double getPkinv6001() {
		return pkinv6001;
	}
	public void setPkinv6001(Double pkinv6001) {
		this.pkinv6001 = pkinv6001;
	}
	public String getMagamMonth() {
		return magamMonth;
	}
	public void setMagamMonth(String magamMonth) {
		this.magamMonth = magamMonth;
	}
	public String getInputDate() {
		return inputDate;
	}
	public void setInputDate(String inputDate) {
		this.inputDate = inputDate;
	}
	public String getUserName() {
		return userName;
	}
	public void setUserName(String userName) {
		this.userName = userName;
	}
	public String getRemark() {
		return remark;
	}
	public void setRemark(String remark) {
		this.remark = remark;
	}
	public String getProcessTime() {
		return processTime;
	}
	public void setProcessTime(String processTime) {
		this.processTime = processTime;
	}
	
}
