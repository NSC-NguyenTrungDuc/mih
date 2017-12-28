package nta.med.core.domain.event.vo;

/**
 * @author DEV-TiepNM
 */
public class DoctorScheduleVo {
    private String startDate;
    private String endEate;
    private String timeFrame;
    private String otherSlot;
    private String totalLot;
    private DoctorScheduleDetailVo details;

    public String getStartDate() {
        return startDate;
    }

    public void setStartDate(String startDate) {
        this.startDate = startDate;
    }

    public String getEndEate() {
        return endEate;
    }

    public void setEndEate(String endEate) {
        this.endEate = endEate;
    }

    public String getTimeFrame() {
        return timeFrame;
    }

    public void setTimeFrame(String timeFrame) {
        this.timeFrame = timeFrame;
    }

    public String getOtherSlot() {
        return otherSlot;
    }

    public void setOtherSlot(String otherSlot) {
        this.otherSlot = otherSlot;
    }

    public String getTotalLot() {
        return totalLot;
    }

    public void setTotalLot(String totalLot) {
        this.totalLot = totalLot;
    }

    public DoctorScheduleDetailVo getDetails() {
        return details;
    }

    public void setDetails(DoctorScheduleDetailVo details) {
        this.details = details;
    }
}
