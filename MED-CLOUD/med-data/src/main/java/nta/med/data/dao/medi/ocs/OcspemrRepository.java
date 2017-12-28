package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocspemr;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface OcspemrRepository extends JpaRepository<Ocspemr, Long>, OcspemrRepositoryCustom {
}

