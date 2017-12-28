package nta.med.data.model.ihis.nuro;

import java.math.BigInteger;

/**
 * @author DEV-TiepNM
 */
public class BookingLabInfo {
    private BigInteger id;
    private String doctor;
    private String gwa;
    private Double fkOut1001;
    private String hospCode;
    private String bunho;
    private String jubsuTime;
    public BookingLabInfo(BigInteger id, String doctor, String gwa, Double fkOut1001, String hospCode, String bunho, String jubsuTime) {
        this.id = id;
        this.doctor = doctor;
        this.gwa = gwa;
        this.fkOut1001 = fkOut1001;
        this.hospCode = hospCode;
        this.bunho = bunho;
        this.jubsuTime = jubsuTime;
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

    public Double getFkOut1001() {
        return fkOut1001;
    }

    public void setFkOut1001(Double fkOut1001) {
        this.fkOut1001 = fkOut1001;
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

    public BigInteger getId() {
        return id;
    }

    public void setId(BigInteger id) {
        this.id = id;
    }

    public String getJubsuTime() {
        return jubsuTime;
    }

    public void setJubsuTime(String jubsuTime) {
        this.jubsuTime = jubsuTime;
    }
}
