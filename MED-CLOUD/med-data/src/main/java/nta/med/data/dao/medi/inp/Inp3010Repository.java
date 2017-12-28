package nta.med.data.dao.medi.inp;

import nta.med.core.domain.inp.Inp3010;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Inp3010Repository extends JpaRepository<Inp3010, Long>, Inp3010RepositoryCustom {
}

