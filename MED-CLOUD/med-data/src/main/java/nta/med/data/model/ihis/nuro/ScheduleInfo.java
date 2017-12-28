package nta.med.data.model.ihis.nuro;

import nta.med.core.utils.DateUtil;
import org.apache.commons.lang3.StringUtils;

/**
 * @author DEV-TiepNM
 */
public class ScheduleInfo {

    private String startTime;
    private String endTime;
    private boolean enableSlot;

    private Integer limitOther;
    private Integer limitDoctor;
    private Integer totalBookIn;
    private Integer totalBookFromOut;
    private Integer totalBookOutHosp;


    public ScheduleInfo() {
    }

    public ScheduleInfo(String startTime, boolean enableSlot, String avgTime, Integer limitDoctor, Integer limitOther) {
        this.startTime = StringUtils.leftPad(startTime.toString(), 4, "0");
        this.enableSlot = enableSlot;


        if(!StringUtils.isEmpty(avgTime))
        {
            this.endTime = DateUtil.addTimeHHmm(StringUtils.leftPad(startTime.toString(), 4, "0"), StringUtils.leftPad(avgTime.toString(), 4, "0"));
        }
        this.limitDoctor = limitDoctor;
        this.limitOther = limitOther;

    }

    public Integer getTotalBookIn() {
        return totalBookIn;
    }

    public void setTotalBookIn(Integer totalBookIn) {
        this.totalBookIn = totalBookIn;
    }

    public Integer getTotalBookOutHosp() {
        return totalBookOutHosp;
    }

    public void setTotalBookOutHosp(Integer totalBookOutHosp) {
        this.totalBookOutHosp = totalBookOutHosp;
    }

    public Integer getTotalBookFromOut() {
        return totalBookFromOut;
    }

    public void setTotalBookFromOut(Integer totalBookFromOut) {
        this.totalBookFromOut = totalBookFromOut;
    }

    public String getStartTime() {
        return startTime;
    }

    public void setStartTime(String startTime) {
        this.startTime = startTime;
    }

    public boolean isEnableSlot() {
        return enableSlot;
    }

    public void setEnableSlot(boolean enableSlot) {
        this.enableSlot = enableSlot;
    }


    public Integer getLimitOther() {
        return limitOther;
    }

    public void setLimitOther(Integer limitOther) {
        this.limitOther = limitOther;
    }

    public Integer getLimitDoctor() {
        return limitDoctor;
    }

    public void setLimitDoctor(Integer limitDoctor) {
        this.limitDoctor = limitDoctor;
    }

    public String getEndTime() {
        return endTime;
    }

    public void setEndTime(String endTime) {
        this.endTime = endTime;
    }
}
