package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs6005;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs6005Repository extends JpaRepository<Ocs6005, Long>, Ocs6005RepositoryCustom {
}

