package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs6014;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs6014Repository extends JpaRepository<Ocs6014, Long>, Ocs6014RepositoryCustom {
}

