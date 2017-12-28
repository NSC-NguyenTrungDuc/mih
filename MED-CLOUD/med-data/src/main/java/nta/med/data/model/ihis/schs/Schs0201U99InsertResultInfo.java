package nta.med.data.model.ihis.schs;

/**
 * @author DEV-TiepNM
 */
public class Schs0201U99InsertResultInfo {
    private String doctor;
    private String gwa;
    private String hospCode;
    private String bunho;

    public Schs0201U99InsertResultInfo()
    {
        this.doctor = doctor;
        this.gwa = gwa;
        this.hospCode = hospCode;
        this.bunho = bunho;
    }

    public String getDoctor() {
        return doctor;
    }

    public void setDoctor(String doctor) {
        this.doctor = doctor;
    }

    public String getGwa() {
        return gwa;
    }

    public void setGwa(String gwa) {
        this.gwa = gwa;
    }

    public String getHospCode() {
        return hospCode;
    }

    public void setHospCode(String hospCode) {
        this.hospCode = hospCode;
    }

    public String getBunho() {
        return bunho;
    }

    public void setBunho(String bunho) {
        this.bunho = bunho;
    }
}

