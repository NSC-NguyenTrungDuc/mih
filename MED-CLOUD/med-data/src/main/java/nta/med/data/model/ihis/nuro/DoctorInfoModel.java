package nta.med.data.model.ihis.nuro;

import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

/**
 * @author DEV-TiepNM
 */
public class DoctorInfoModel {
    private Date startDate;
    private Date endDate;
    private String startAm;
    private String endAm;
    private String startPm;
    private String endPm;
    private String avgTime;

    private String doctorCode;
    private Map<String, List<ScheduleInfo>>  scheduleInfo = new HashMap<>();
    private String departmentCode;

    public DoctorInfoModel(String doctorCode, String departmentCode, Map<String, List<ScheduleInfo>> scheduleInfo, Date startDate, Date endDate, String startAm, String startPm, String endAm, String endPm, String avgTime) {
        this.doctorCode = doctorCode;
        this.departmentCode = departmentCode;
        this.scheduleInfo = scheduleInfo;
        this.startDate = startDate;
        this.endDate = endDate;
        this.startAm = startAm;
        this.startPm = startPm;
        this.endAm = endAm;
        this.endPm = endPm;
        this.avgTime = avgTime;
    }
    public DoctorInfoModel(String doctorCode, String departmentCode, Date startDate, Date endDate, String startAm, String startPm, String endAm, String endPm, String avgTime) {
        this.doctorCode = doctorCode;
        this.departmentCode = departmentCode;

        this.startDate = startDate;
        this.endDate = endDate;
        this.startAm = startAm;
        this.startPm = startPm;
        this.endAm = endAm;
        this.endPm = endPm;
        this.avgTime = avgTime;
    }
    public String getDoctorCode() {
        return doctorCode;
    }

    public void setDoctorCode(String doctorCode) {
        this.doctorCode = doctorCode;
    }

    public Map<String, List<ScheduleInfo>> getScheduleInfo() {
        return scheduleInfo;
    }

    public void setScheduleInfo(Map<String, List<ScheduleInfo>> scheduleInfo) {
        this.scheduleInfo = scheduleInfo;
    }

    public String getDepartmentCode() {
        return departmentCode;
    }

    public void setDepartmentCode(String departmentCode) {
        this.departmentCode = departmentCode;
    }

    public String getStartAm() {
        return startAm;
    }

    public void setStartAm(String startAm) {
        this.startAm = startAm;
    }

    public String getEndAm() {
        return endAm;
    }

    public void setEndAm(String endAm) {
        this.endAm = endAm;
    }

    public String getStartPm() {
        return startPm;
    }

    public void setStartPm(String startPm) {
        this.startPm = startPm;
    }

    public String getEndPm() {
        return endPm;
    }

    public void setEndPm(String endPm) {
        this.endPm = endPm;
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

    public String getAvgTime() {
        return avgTime;
    }

    public void setAvgTime(String avgTime) {
        this.avgTime = avgTime;
    }
}
