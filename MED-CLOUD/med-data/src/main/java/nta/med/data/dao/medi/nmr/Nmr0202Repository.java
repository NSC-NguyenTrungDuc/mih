package nta.med.data.dao.medi.nmr;

import nta.med.core.domain.nmr.Nmr0202;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nmr0202Repository extends JpaRepository<Nmr0202, Long>, Nmr0202RepositoryCustom {
}

