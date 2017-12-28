package nta.med.core.domain.emr;

import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

import java.util.Date;
import java.util.List;

/**
 * @author dainguyen.
 */
@Document(collection = "histories")
public class ExaminationHistory implements HistoryListItem {
    private long id;
    private String patientId;
    private String hospCode;
    private Integer revision;
    private String modifiedBy;
    private Date modifiedTime;
    private String doctor;
    private String comment;
    private List<ExaminationItemVo> examinations;

    public ExaminationHistory() {
    }

    public ExaminationHistory(long id, String patientId, String hospCode, Integer revision, String modifiedBy, Date modifiedTime, String doctor, String comment, List<ExaminationItemVo> examinations) {
        this.id = id;
        this.patientId = patientId;
        this.hospCode = hospCode;
        this.revision = revision;
        this.modifiedBy = modifiedBy;
        this.modifiedTime = modifiedTime;
        this.doctor = doctor;
        this.comment = comment;
        this.examinations = examinations;
    }

    @Id
    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public String getPatientId() {
        return patientId;
    }

    public void setPatientId(String patientId) {
        this.patientId = patientId;
    }

    public Integer getRevision() {
        return revision;
    }

    public void setRevision(Integer revision) {
        this.revision = revision;
    }

    public String getModifiedBy() {
        return modifiedBy;
    }

    public void setModifiedBy(String modifiedBy) {
        this.modifiedBy = modifiedBy;
    }

    public Date getModifiedTime() {
        return modifiedTime;
    }

    public void setModifiedTime(Date modifiedTime) {
        this.modifiedTime = modifiedTime;
    }

    public List<ExaminationItemVo> getExaminations() {
        return examinations;
    }

    public void setExaminations(List<ExaminationItemVo> examinations) {
        this.examinations = examinations;
    }

    public String getDoctor() {
        return doctor;
    }

    public void setDoctor(String doctor) {
        this.doctor = doctor;
    }

    public String getComment() {
        return comment;
    }

    public void setComment(String comment) {
        this.comment = comment;
    }

    public String getHospCode() {
        return hospCode;
    }

    public void setHospCode(String hospCode) {
        this.hospCode = hospCode;
    }
}
