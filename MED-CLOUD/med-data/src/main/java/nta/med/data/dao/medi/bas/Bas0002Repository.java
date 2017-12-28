package nta.med.data.dao.medi.bas;

import nta.med.core.domain.bas.Bas0002;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0002Repository extends JpaRepository<Bas0002, Long>, Bas0002RepositoryCustom {
}

