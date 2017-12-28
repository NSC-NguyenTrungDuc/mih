package nta.med.data.dao.medi.bas;

import nta.med.core.domain.bas.Bas0353;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0353Repository extends JpaRepository<Bas0353, Long>, Bas0353RepositoryCustom {
}

