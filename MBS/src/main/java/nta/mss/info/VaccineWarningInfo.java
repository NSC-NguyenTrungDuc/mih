package nta.mss.info;

import java.io.Serializable;

import org.apache.commons.lang.StringUtils;

import nta.mss.misc.common.MssContextHolder;
import nta.mss.misc.common.MssDateTimeUtil;
import nta.mss.misc.enums.DateTimeFormat;
import nta.mss.misc.enums.ReminderTime;

public class VaccineWarningInfo implements Serializable {

	private static final long serialVersionUID = 3626466091672251347L;

	private Integer warningType;
	private Integer remainingDays;
	
	public Integer getWarningType() {
		return warningType;
	}
	public void setWarningType(Integer warningType) {
		this.warningType = warningType;
	}
	public Integer getRemainingDays() {
		return remainingDays;
	}
	public void setRemainingDays(Integer remainingDays) {
		this.remainingDays = remainingDays;
	}
}
