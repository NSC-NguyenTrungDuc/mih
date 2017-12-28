package nta.med.data.dao.medi.bas;

import nta.med.core.domain.bas.Bas0103;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0103Repository extends JpaRepository<Bas0103, Long>, Bas0103RepositoryCustom {
}

