package nta.med.data.dao.medi.inp;

import nta.med.core.domain.inp.Inp0106;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Inp0106Repository extends JpaRepository<Inp0106, Long>, Inp0106RepositoryCustom {
}

