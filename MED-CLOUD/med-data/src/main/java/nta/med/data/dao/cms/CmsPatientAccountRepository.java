package nta.med.data.dao.cms;

import org.springframework.data.jpa.repository.JpaRepository;

import nta.med.core.domain.cms.CmsPatientAccount;

public interface CmsPatientAccountRepository extends JpaRepository<CmsPatientAccount, Long>, CmsPatientAccountRepositoryCustom{

}
