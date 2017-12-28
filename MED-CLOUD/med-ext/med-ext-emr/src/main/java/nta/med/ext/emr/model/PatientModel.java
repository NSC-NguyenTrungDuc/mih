package nta.med.ext.emr.model;

/**
 * @author dainguyen.
 */
public class PatientModel {
    private String patientId;
    private String name;
    private String kanaName;
    private String birthday;
    private String gender;
    private String address;
    private String zip;
    private String telephone;
    private String hospCode;
    private String doctor;

    public PatientModel() {
    }

    public PatientModel(String patientId, String name, String kanaName, String birthday, String gender, String address, String zip, String telephone, String hospCode, String doctor) {
        this.patientId = patientId;
        this.name = name;
        this.kanaName = kanaName;
        this.birthday = birthday;
        this.gender = gender;
        this.address = address;
        this.zip = zip;
        this.telephone = telephone;
        this.hospCode = hospCode;
        this.doctor = doctor;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getKanaName() {
        return kanaName;
    }

    public void setKanaName(String kanaName) {
        this.kanaName = kanaName;
    }

    public String getBirthday() {
        return birthday;
    }

    public void setBirthday(String birthday) {
        this.birthday = birthday;
    }

    public String getGender() {
        return gender;
    }

    public void setGender(String gender) {
        this.gender = gender;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public String getZip() {
        return zip;
    }

    public void setZip(String zip) {
        this.zip = zip;
    }

    public String getTelephone() {
        return telephone;
    }

    public void setTelephone(String telephone) {
        this.telephone = telephone;
    }

    public String getHospCode() {
        return hospCode;
    }

    public void setHospCode(String hospCode) {
        this.hospCode = hospCode;
    }

    public String getDoctor() {
        return doctor;
    }

    public void setDoctor(String doctor) {
        this.doctor = doctor;
    }

    public String getPatientId() {
        return patientId;
    }

    public void setPatientId(String patientId) {
        this.patientId = patientId;
    }
}
