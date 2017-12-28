package nta.med.data.dao.medi.inp;

import nta.med.core.domain.inp.Inp3011;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Inp3011Repository extends JpaRepository<Inp3011, Long>, Inp3011RepositoryCustom {
}

