package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs6010;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs6010Repository extends JpaRepository<Ocs6010, Long>, Ocs6010RepositoryCustom {
}

