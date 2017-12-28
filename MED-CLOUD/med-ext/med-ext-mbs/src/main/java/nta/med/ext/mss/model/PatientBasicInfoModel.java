package nta.med.ext.mss.model;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.io.Serializable;

/**
 * @author DEV-TiepNM
 */
public class PatientBasicInfoModel implements Serializable {
    @JsonProperty("patient_code")
    private String patientCode;
    @JsonProperty("patient_name_kanji")
    private String patientNameKanji;
    @JsonProperty("patient_name_kana")
    private String patientNameKana;
    @JsonProperty("patient_tel")
    private String patientTel;
    @JsonProperty("patient_email")
    private String patientEmail;
    @JsonProperty("patient_sex")
    private String patientSex;
    @JsonProperty("patient_birthday")
    private String patientBirthday;

    public String getPatientCode() {
        return patientCode;
    }

    public void setPatientCode(String patientCode) {
        this.patientCode = patientCode;
    }

    public String getPatientNameKanji() {
        return patientNameKanji;
    }

    public void setPatientNameKanji(String patientNameKanji) {
        this.patientNameKanji = patientNameKanji;
    }

    public String getPatientNameKana() {
        return patientNameKana;
    }

    public void setPatientNameKana(String patientNameKana) {
        this.patientNameKana = patientNameKana;
    }

    public String getPatientTel() {
        return patientTel;
    }

    public void setPatientTel(String patientTel) {
        this.patientTel = patientTel;
    }

    public String getPatientEmail() {
        return patientEmail;
    }

    public void setPatientEmail(String patientEmail) {
        this.patientEmail = patientEmail;
    }

    public String getPatientSex() {
        return patientSex;
    }

    public void setPatientSex(String patientSex) {
        this.patientSex = patientSex;
    }

    public String getPatientBirthday() {
        return patientBirthday;
    }

    public void setPatientBirthday(String patientBirthday) {
        this.patientBirthday = patientBirthday;
    }
}
