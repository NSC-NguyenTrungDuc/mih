package nta.med.data.dao.emr;

import nta.med.core.domain.emr.SysProperty;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface SysPropertyRepository extends JpaRepository<SysProperty, Long>, SysPropertyRepositoryCustom {
}
