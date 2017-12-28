package nta.med.ext.phr.model;

import com.fasterxml.jackson.annotation.JsonFormat;
import com.fasterxml.jackson.annotation.JsonProperty;

import java.math.BigDecimal;
import java.sql.Timestamp;

/**
 * @author DEV-TiepNM
 */
public class StandardTempBpChartViewModel {

    @JsonProperty("temperature_id")
    private Long id;

    @JsonProperty("datetime_record")
    @JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "yyyy-MM-dd'T'HH:mm:ss'Z'", timezone = "UTC")
    private Timestamp dateMeasure;

    @JsonProperty("profile_id")
    private Long profileId;

    @JsonProperty("min_low_blood_pressure")
    private BigDecimal minBpFrom;

    @JsonProperty("max_low_blood_pressure")
    private BigDecimal maxBpFrom;

    @JsonProperty("min_high_blood_pressure")
    private BigDecimal minBpTo;

    @JsonProperty("max_high_blood_pressure")
    private BigDecimal maxBpTo;

    @JsonProperty("note")
    private String note;

    public StandardTempBpChartViewModel() {
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

    public BigDecimal getMinBpFrom() {
        return minBpFrom;
    }

    public void setMinBpFrom(BigDecimal minBpFrom) {
        this.minBpFrom = minBpFrom;
    }

    public BigDecimal getMaxBpFrom() {
        return maxBpFrom;
    }

    public void setMaxBpFrom(BigDecimal maxBpFrom) {
        this.maxBpFrom = maxBpFrom;
    }

    public BigDecimal getMinBpTo() {
        return minBpTo;
    }

    public void setMinBpTo(BigDecimal minBpTo) {
        this.minBpTo = minBpTo;
    }

    public BigDecimal getMaxBpTo() {
        return maxBpTo;
    }

    public void setMaxBpTo(BigDecimal maxBpTo) {
        this.maxBpTo = maxBpTo;
    }

    public String getNote() {
        return note;
    }

    public void setNote(String note) {
        this.note = note;
    }
}
