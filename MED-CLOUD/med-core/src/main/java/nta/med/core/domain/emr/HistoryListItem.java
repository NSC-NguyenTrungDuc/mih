package nta.med.core.domain.emr;

/**
 * @author dainguyen.
 */
public interface HistoryListItem {
    String getPatientId();

    void setPatientId(String patientId);

    String getHospCode();

    void setHospCode(String hospCode);

    Integer getRevision();

    void setRevision(Integer revision);

    String getDoctor();

    void setDoctor(String doctor);

    String getComment();

    void setComment(String comment);
}
