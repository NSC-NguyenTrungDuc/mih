package nta.med.orca.gw.api.contracts.service;

/**
 * @author dainguyen.
 */
public class ShunouRequest {

    private String patientId;
    private String performDate;
    private String performMonth;
    private String performYear;

    public ShunouRequest() {
    }

    public ShunouRequest(String patientId) {
        this.patientId = patientId;
    }

    public ShunouRequest(String patientId, String performDate, String performMonth, String performYear) {
        this.patientId = patientId;
        this.performDate = performDate;
        this.performMonth = performMonth;
        this.performYear = performYear;
    }

    public String getPatientId() {
        return patientId;
    }

    public void setPatientId(String patientId) {
        this.patientId = patientId;
    }

    public String getPerformDate() {
        return performDate;
    }

    public void setPerformDate(String performDate) {
        this.performDate = performDate;
    }

    public String getPerformMonth() {
        return performMonth;
    }

    public void setPerformMonth(String performMonth) {
        this.performMonth = performMonth;
    }

    public String getPerformYear() {
        return performYear;
    }

    public void setPerformYear(String performYear) {
        this.performYear = performYear;
    }
}
