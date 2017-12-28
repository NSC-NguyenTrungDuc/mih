package nta.med.data.dao.medi.inp;

import nta.med.core.domain.inp.Inp2001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Inp2001Repository extends JpaRepository<Inp2001, Long>, Inp2001RepositoryCustom {
}

