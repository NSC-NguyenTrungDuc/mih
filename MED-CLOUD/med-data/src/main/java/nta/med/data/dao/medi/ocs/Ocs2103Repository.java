package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs2103;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs2103Repository extends JpaRepository<Ocs2103, Long>, Ocs2103RepositoryCustom {
}
