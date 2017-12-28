package nta.med.data.dao.medi.bas;

import nta.med.core.domain.bas.Bas0280;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0280Repository extends JpaRepository<Bas0280, Long>, Bas0280RepositoryCustom {
}

