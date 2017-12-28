package nta.med.data.dao.medi.bas;

import nta.med.core.domain.bas.Bas0319;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0319Repository extends JpaRepository<Bas0319, Long>, Bas0319RepositoryCustom {
}

