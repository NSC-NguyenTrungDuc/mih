package nta.med.data.dao.medi.inp;

import nta.med.core.domain.inp.Inp1010;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Inp1010Repository extends JpaRepository<Inp1010, Long>, Inp1010RepositoryCustom {
}

