package nta.mss.info;

import java.io.Serializable;
import java.util.List;

/**
 * The Class CalendarInfo. 
 *
 * @author MinhLS
 * @crtDate Sep 23, 2014
 */
public class CalendarInfo implements Serializable {

	private static final long serialVersionUID = 1L;

	private String checkedDate;
	private String formattedCheckedDate;
	private String title;
	private Integer status;
	private Integer month;
	private Integer year;
	private String startDateTime;
	private String formattedStartDateTime;
	private String endDateTime;
	private Boolean isWeekMode;
	private List<CalendarInfo> calendarInfoList;

	public String getCheckedDate() {
		return checkedDate;
	}

	public void setCheckedDate(String checkedDate) {
		this.checkedDate = checkedDate;
	}
	
	public String getFormattedCheckedDate() {
		return formattedCheckedDate;
	}

	public void setFormattedCheckedDate(String formattedCheckedDate) {
		this.formattedCheckedDate = formattedCheckedDate;
	}

	public String getTitle() {
		return title;
	}

	public void setTitle(String title) {
		this.title = title;
	}

	public Integer getStatus() {
		return status;
	}

	public void setStatus(Integer status) {
		this.status = status;
	}

	public Integer getMonth() {
		return month;
	}

	public void setMonth(Integer month) {
		this.month = month;
	}

	public Integer getYear() {
		return year;
	}

	public void setYear(Integer year) {
		this.year = year;
	}

	public String getStartDateTime() {
		return startDateTime;
	}

	public void setStartDateTime(String startDateTime) {
		this.startDateTime = startDateTime;
	}

	public String getFormattedStartDateTime() {
		return formattedStartDateTime;
	}

	public void setFormattedStartDateTime(String formattedStartDateTime) {
		this.formattedStartDateTime = formattedStartDateTime;
	}

	public String getEndDateTime() {
		return endDateTime;
	}

	public void setEndDateTime(String endDateTime) {
		this.endDateTime = endDateTime;
	}

	public Boolean getIsWeekMode() {
		return isWeekMode;
	}

	public void setIsWeekMode(Boolean isWeekMode) {
		this.isWeekMode = isWeekMode;
	}

	public List<CalendarInfo> getCalendarInfoList() {
		return calendarInfoList;
	}

	public void setCalendarInfoList(List<CalendarInfo> calendarInfoList) {
		this.calendarInfoList = calendarInfoList;
	}
}
