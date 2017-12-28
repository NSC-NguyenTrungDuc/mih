package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0141;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0141Repository extends JpaRepository<Ocs0141, Long>, Ocs0141RepositoryCustom {
}

