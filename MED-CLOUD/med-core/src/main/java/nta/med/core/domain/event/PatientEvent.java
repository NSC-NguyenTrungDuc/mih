package nta.med.core.domain.event;

import nta.med.core.domain.event.vo.AcceptInformationVo;
import nta.med.core.domain.event.vo.PatientProfileVo;
import nta.med.core.domain.event.vo.PrivateInsuranceVo;
import nta.med.core.domain.event.vo.PublicInsuranceVo;
import org.springframework.data.mongodb.core.mapping.Document;

import java.util.ArrayList;
import java.util.List;

/**
 * @author dainguyen.
 */
@Document(collection = "patient_events")
public class PatientEvent extends AbstractEvent {
    private String type;
    private String hospCode;
    private String patientCode;
    private PatientProfileVo profile;
    private List<PublicInsuranceVo> publicInsuranceVos = new ArrayList<>();
    private List<PrivateInsuranceVo> privateInsuranceVos = new ArrayList<>();;
    private AcceptInformationVo acceptInfo;

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
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

    public PatientProfileVo getProfile() {
        return profile;
    }

    public void setProfile(PatientProfileVo profile) {
        this.profile = profile;
    }

    public List<PublicInsuranceVo> getPublicInsuranceVos() {
        return publicInsuranceVos;
    }

    public void setPublicInsuranceVos(List<PublicInsuranceVo> publicInsuranceVos) {
        this.publicInsuranceVos = publicInsuranceVos;
    }

    public List<PrivateInsuranceVo> getPrivateInsuranceVos() {
        return privateInsuranceVos;
    }

    public void setPrivateInsuranceVos(List<PrivateInsuranceVo> privateInsuranceVos) {
        this.privateInsuranceVos = privateInsuranceVos;
    }

    public AcceptInformationVo getAcceptInfo() {
        return acceptInfo;
    }

    public void setAcceptInfo(AcceptInformationVo acceptInfo) {
        this.acceptInfo = acceptInfo;
    }

}
