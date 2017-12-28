package nta.med.core.domain.event.vo;

/**
 * @author DEV-TiepNM
 */
public class DoctorScheduleDetailVo {


    private String startAm;
    private String endAm;
    private String startPm;
    private String endPm;

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
}
