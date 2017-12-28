package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.AdmHotcode;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;


@Repository
public interface AdmHotCodeRepository extends JpaRepository<AdmHotcode, Long>, AdmHotCodeRepositoryCustom {

}
