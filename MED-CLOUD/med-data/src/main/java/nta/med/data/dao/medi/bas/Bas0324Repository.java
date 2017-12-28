package nta.med.data.dao.medi.bas;

import nta.med.core.domain.bas.Bas0324;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0324Repository extends JpaRepository<Bas0324, Long>, Bas0324RepositoryCustom {
}

