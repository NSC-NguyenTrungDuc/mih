package nta.med.ext.registration.service.impl;

import nta.med.core.domain.hp.HospitalRegister;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.regis.HospitalRegisterRepository;
import nta.med.ext.registration.model.HospitalRegisterModel;
import nta.med.ext.registration.service.hospitalRegisterService;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import javax.annotation.Resource;

/**
 * @author DEV-TiepNM
 */
@Service("hospitalRegisterService")
@Transactional
public class hospitalRegisterServiceImpl implements hospitalRegisterService {
    @Resource
    private HospitalRegisterRepository hospitalRegisterRepository;
    @Override
    public boolean isUniqueEmail(String email) {
        Integer count = hospitalRegisterRepository.countHospitalRegisterIdByEmail(email);
        return count == 0 ? true : false;
    }
    public HospitalRegister createClinic(HospitalRegisterModel model)
    {
        HospitalRegister hospitalRegister = new HospitalRegister();
        BeanUtils.copyProperties(model, hospitalRegister, model.getLanguage());
        hospitalRegisterRepository.save(hospitalRegister);
        return hospitalRegister;
    }
    @Override
    public HospitalRegisterModel findBySessionId(String sessionId) {
        HospitalRegisterModel hospitalRegisterModel = new HospitalRegisterModel();
        HospitalRegister hospitalRegister = this.hospitalRegisterRepository.findBySessionId(sessionId);
        if (hospitalRegister == null) {
            return null;
        }
        BeanUtils.copyProperties(hospitalRegister, hospitalRegisterModel, "JA");
        return hospitalRegisterModel;
    }
    @Override
    public void updateHospitalRegister(HospitalRegisterModel model) {
        HospitalRegister entity = hospitalRegisterRepository.findOne(model.getHospitalRegisterId());
        // update hospital
        entity.setSessionId(model.getSessionId());
        entity.setStatus(model.getStatus());
        this.hospitalRegisterRepository.save(entity);
    }
}
