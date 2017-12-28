package nta.med.data.model.ihis.ocsa;

import java.util.Date;

public class OCS0118U00GrdOCS0118Info {
	private String convCls;
	private String convGubun;
	private String hangmogCode;
	private String hangmogName;
	private String convHangmog;
	private String convHangmogName;
	private String remark;
	private Date startDate;

	public OCS0118U00GrdOCS0118Info(String convCls, String convGubun,
			String hangmogCode, String hangmogName, String convHangmog,
			String convHangmogName, String remark, Date startDate) {
		super();
		this.convCls = convCls;
		this.convGubun = convGubun;
		this.hangmogCode = hangmogCode;
		this.hangmogName = hangmogName;
		this.convHangmog = convHangmog;
		this.convHangmogName = convHangmogName;
		this.remark = remark;
		this.startDate = startDate;
	}

	public String getConvCls() {
		return convCls;
	}

	public void setConvCls(String convCls) {
		this.convCls = convCls;
	}

	public String getConvGubun() {
		return convGubun;
	}

	public void setConvGubun(String convGubun) {
		this.convGubun = convGubun;
	}

	public String getHangmogCode() {
		return hangmogCode;
	}

	public void setHangmogCode(String hangmogCode) {
		this.hangmogCode = hangmogCode;
	}

	public String getHangmogName() {
		return hangmogName;
	}

	public void setHangmogName(String hangmogName) {
		this.hangmogName = hangmogName;
	}

	public String getConvHangmog() {
		return convHangmog;
	}

	public void setConvHangmog(String convHangmog) {
		this.convHangmog = convHangmog;
	}

	public String getConvHangmogName() {
		return convHangmogName;
	}

	public void setConvHangmogName(String convHangmogName) {
		this.convHangmogName = convHangmogName;
	}

	public String getRemark() {
		return remark;
	}

	public void setRemark(String remark) {
		this.remark = remark;
	}

	public Date getStartDate() {
		return startDate;
	}

	public void setStartDate(Date startDate) {
		this.startDate = startDate;
	}

}
