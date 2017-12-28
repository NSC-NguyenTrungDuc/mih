package nta.med.data.model.phr;

import java.math.BigInteger;

/**
 * @author DEV-TiepNM
 */
public class AccountClinicInfo {
    private BigInteger id;
    private String hospCode;
    private String patientCode;
    private Integer profileId;

    public AccountClinicInfo(BigInteger id, String hospCode, String patientCode, Integer profileId) {
        super();
        this.id = id;
        this.hospCode = hospCode;
        this.patientCode = patientCode;
        this.profileId = profileId;
    }

    public BigInteger getId() {
        return id;
    }

    public void setId(BigInteger id) {
        this.id = id;
    }

    public String getHospCode() {
        return hospCode;
    }

    public void setHospCode(String hospCode) {
        this.hospCode = hospCode;
    }

    public String getPatientCode() {
        return patientCode;
    }

    public void setPatientCode(String patientCode) {
        this.patientCode = patientCode;
    }

    public Integer getProfileId() {
        return profileId;
    }

    public void setProfileId(Integer profileId) {
        this.profileId = profileId;
    }
}
