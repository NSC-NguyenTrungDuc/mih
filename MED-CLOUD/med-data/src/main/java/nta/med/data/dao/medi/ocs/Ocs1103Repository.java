package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs1103;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs1103Repository extends JpaRepository<Ocs1103, Long>, Ocs1103RepositoryCustom {
}

