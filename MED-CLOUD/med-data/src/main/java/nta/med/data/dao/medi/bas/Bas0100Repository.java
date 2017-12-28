package nta.med.data.dao.medi.bas;

import nta.med.core.domain.bas.Bas0100;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0100Repository extends JpaRepository<Bas0100, Long>, Bas0100RepositoryCustom {
}

