package nta.med.data.dao.phr;

import nta.med.core.domain.phr.PhrBabyDiaper;
import nta.med.data.model.phr.AccountClinicInfo;

import java.util.List;

/**
 * @author DEV-TiepNM
 */
public interface AccountClinicRepositoryCustom {
    public List<AccountClinicInfo> getAccountClinic(Long accountId);
    public List<AccountClinicInfo> getAccountClinic(String patientCode, String hospCode) ;
    public Integer addPhrAccountClinic(Long profileId, String username, String hospCode, String hospName,String patientCode,String sysId);
}
