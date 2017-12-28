package nta.med.ext.registration.service;

import nta.med.core.domain.hp.HospitalRegister;
import nta.med.ext.registration.model.HospitalRegisterModel;

/**
 * @author DEV-TiepNM
 */
public interface hospitalRegisterService {
    boolean isUniqueEmail(String email);

    public HospitalRegister createClinic(HospitalRegisterModel model);

    HospitalRegisterModel findBySessionId(String sessionId);

    void updateHospitalRegister(HospitalRegisterModel hospital);
}
