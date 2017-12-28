package nta.med.data.dao.medi.inp;

import nta.med.core.domain.inp.Inp2006;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Inp2006Repository extends JpaRepository<Inp2006, Long>, Inp2006RepositoryCustom {
}

