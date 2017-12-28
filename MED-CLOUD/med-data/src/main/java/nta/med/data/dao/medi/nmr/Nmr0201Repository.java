package nta.med.data.dao.medi.nmr;

import nta.med.core.domain.nmr.Nmr0201;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nmr0201Repository extends JpaRepository<Nmr0201, Long>, Nmr0201RepositoryCustom {
}

