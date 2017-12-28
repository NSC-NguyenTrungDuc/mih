package nta.med.data.dao.medi.bas;

import nta.med.core.domain.bas.Bas0232;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0232Repository extends JpaRepository<Bas0232, Long>, Bas0232RepositoryCustom {
}

