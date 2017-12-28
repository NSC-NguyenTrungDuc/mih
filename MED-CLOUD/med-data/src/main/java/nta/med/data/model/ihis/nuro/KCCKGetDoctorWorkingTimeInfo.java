package nta.med.data.model.ihis.nuro;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.ArrayList;
import java.util.List;

public class KCCKGetDoctorWorkingTimeInfo {

    @JsonProperty("res_am_start_hhmm")
    private String resAmStart;

    @JsonProperty("res_am_end_hhmm")
    private String resAmEnd;

    @JsonProperty("res_pm_start_hhmm")
    private String resPmStart;

    @JsonProperty("res_pm_end_hhmm")
    private String resPmEnd;

    @JsonProperty("avg_time")
    private String avgTime;

    @JsonProperty("enable_slot")
    private List<KCCKGetEnableScheduleDoctorInfo> enableSlot = new ArrayList<>();
    
    @JsonIgnore
    private boolean doctorIsDifferentAvgTime;

    public KCCKGetDoctorWorkingTimeInfo() {
    }

    public KCCKGetDoctorWorkingTimeInfo(String resAmStart, String resAmEnd, String resPmStart, String resPmEnd,
                                        String avgTime) {
        super();
        this.resAmStart = resAmStart;
        this.resAmEnd = resAmEnd;
        this.resPmStart = resPmStart;
        this.resPmEnd = resPmEnd;
        this.avgTime = avgTime;
    }

    public String getResAmStart() {
        return resAmStart;
    }

    public void setResAmStart(String resAmStart) {
        this.resAmStart = resAmStart;
    }

    public String getResAmEnd() {
        return resAmEnd;
    }

    public void setResAmEnd(String resAmEnd) {
        this.resAmEnd = resAmEnd;
    }

    public String getResPmStart() {
        return resPmStart;
    }

    public void setResPmStart(String resPmStart) {
        this.resPmStart = resPmStart;
    }

    public String getResPmEnd() {
        return resPmEnd;
    }

    public void setResPmEnd(String resPmEnd) {
        this.resPmEnd = resPmEnd;
    }

    public String getAvgTime() {
        return avgTime;
    }

    public void setAvgTime(String avgTime) {
        this.avgTime = avgTime;
    }

    public List<KCCKGetEnableScheduleDoctorInfo> getEnableSlot() {
        return enableSlot;
    }

    public void setEnableSlot(List<KCCKGetEnableScheduleDoctorInfo> enableSlot) {
        this.enableSlot = enableSlot;
    }

	public boolean isDoctorIsDifferentAvgTime() {
		return doctorIsDifferentAvgTime;
	}

	public void setDoctorIsDifferentAvgTime(boolean doctorIsDifferentAvgTime) {
		this.doctorIsDifferentAvgTime = doctorIsDifferentAvgTime;
	}
}
