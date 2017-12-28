package nta.med.ext.emr.model;

import nta.med.core.domain.emr.HistoryListItem;

import java.util.Date;

/**
 * @author dainguyen.
 */
public class HistoryListModel implements HistoryListItem {
    private String patientId;
    private String hospCode;
    private Integer revision;
    private String doctor;
    private String comment;

    public HistoryListModel() {
    }

    public HistoryListModel(String patientId, String hospCode, Integer revision, String modifiedBy, Date modifiedTime, String doctor, String comment) {
        this.patientId = patientId;
        this.hospCode = hospCode;
        this.revision = revision;
        this.doctor = doctor;
        this.comment = comment;
    }

    @Override
    public String getPatientId() {
        return patientId;
    }

    @Override
    public void setPatientId(String patientId) {
        this.patientId = patientId;
    }

    @Override
    public String getHospCode() {
        return hospCode;
    }

    @Override
    public void setHospCode(String hospCode) {
        this.hospCode = hospCode;
    }

    @Override
    public Integer getRevision() {
        return revision;
    }

    @Override
    public void setRevision(Integer revision) {
        this.revision = revision;
    }

    @Override
    public String getDoctor() {
        return doctor;
    }

    @Override
    public void setDoctor(String doctor) {
        this.doctor = doctor;
    }

    @Override
    public String getComment() {
        return comment;
    }

    @Override
    public void setComment(String comment) {
        this.comment = comment;
    }
}
