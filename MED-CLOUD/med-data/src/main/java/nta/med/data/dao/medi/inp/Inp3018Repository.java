package nta.med.data.dao.medi.inp;

import nta.med.core.domain.inp.Inp3018;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Inp3018Repository extends JpaRepository<Inp3018, Long>, Inp3018RepositoryCustom {
}

