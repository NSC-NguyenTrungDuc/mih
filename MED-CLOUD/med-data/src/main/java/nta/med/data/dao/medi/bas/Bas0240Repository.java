package nta.med.data.dao.medi.bas;

import nta.med.core.domain.bas.Bas0240;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0240Repository extends JpaRepository<Bas0240, Long>, Bas0240RepositoryCustom {
}
