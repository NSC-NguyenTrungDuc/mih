package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs1053;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs1053Repository extends JpaRepository<Ocs1053, Long>, Ocs1053RepositoryCustom {
}

