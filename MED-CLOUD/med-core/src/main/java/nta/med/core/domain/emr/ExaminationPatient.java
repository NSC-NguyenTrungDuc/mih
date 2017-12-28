package nta.med.core.domain.emr;

import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.mapping.Document;

import java.util.ArrayList;
import java.util.List;

/**
 * @author dainguyen.
 */
@Document(collection = "patients")
public class ExaminationPatient {
    private String id;
    private String name;
    private String kanaName;
    private String birthday;
    private String gender;
    private String address;
    private String zip;
    private String telephone;
    private String hospCode;
    private String patientId;
    private String doctor;
    private List<ExaminationItemVo> examinations;

    public ExaminationPatient() {
        examinations = new ArrayList<>();
    }

    public ExaminationPatient(String hospCode, String id, String name, String kanaName, String birthday, String gender, String address, String zip, String telephone, String patientId, String doctor, List<ExaminationItemVo> examinations) {
        this.id = id;
        this.name = name;
        this.kanaName = kanaName;
        this.birthday = birthday;
        this.gender = gender;
        this.address = address;
        this.zip = zip;
        this.telephone = telephone;
        this.hospCode = hospCode;
        this.patientId = patientId;
        this.doctor = doctor;
        this.examinations = examinations;
    }

    @Id
    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
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

    public List<ExaminationItemVo> getExaminations() {
        return examinations;
    }

    public void setExaminations(List<ExaminationItemVo> examinations) {
        this.examinations = examinations;
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
