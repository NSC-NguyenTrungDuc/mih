package nta.med.data.dao.medi.bas;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.bas.SysPropertyS;

@Repository
public interface SysPropertySRepository extends JpaRepository<SysPropertyS, Long>, SysPropertySRepositoryCustom {
}
