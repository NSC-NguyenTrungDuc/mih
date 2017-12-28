package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs6007;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs6007Repository extends JpaRepository<Ocs6007, Long>, Ocs6007RepositoryCustom {
}

