package nta.med.ext.phr.model;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonProperty;

import java.math.BigDecimal;
import java.sql.Timestamp;

/**
 * @author DEV-TiepNM
 */
public class StandardTempHeartRateChartViewModel {

    @JsonProperty("temperature_id")
    private Long id;

    @JsonProperty("datetime_record")
    @JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "yyyy-MM-dd'T'HH:mm:ss'Z'", timezone = "UTC")
    private Timestamp dateMeasure;

    @JsonProperty("profile_id")
    private Long profileId;

    @JsonProperty("min_pulse")
    private BigDecimal minHeartrate;
    @JsonProperty("max_pulse")
    private BigDecimal maxHeartrate;

    @JsonProperty("note")
    private String note;

    public StandardTempHeartRateChartViewModel() {
        super();
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public Timestamp getDateMeasure() {
        return dateMeasure;
    }

    public void setDateMeasure(Timestamp dateMeasure) {
        this.dateMeasure = dateMeasure;
    }

    public Long getProfileId() {
        return profileId;
    }

    public void setProfileId(Long profileId) {
        this.profileId = profileId;
    }

    public BigDecimal getMaxHeartrate() {
        return maxHeartrate;
    }

    public void setMaxHeartrate(BigDecimal maxHeartrate) {
        this.maxHeartrate = maxHeartrate;
    }

    public BigDecimal getMinHeartrate() {
        return minHeartrate;
    }

    public void setMinHeartrate(BigDecimal minHeartrate) {
        this.minHeartrate = minHeartrate;
    }

    public String getNote() {
        return note;
    }

    public void setNote(String note) {
        this.note = note;
    }
}
