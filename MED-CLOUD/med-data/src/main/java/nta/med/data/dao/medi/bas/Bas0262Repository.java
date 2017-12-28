package nta.med.data.dao.medi.bas;

import nta.med.core.domain.bas.Bas0262;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0262Repository extends JpaRepository<Bas0262, Long>, Bas0262RepositoryCustom {
}

