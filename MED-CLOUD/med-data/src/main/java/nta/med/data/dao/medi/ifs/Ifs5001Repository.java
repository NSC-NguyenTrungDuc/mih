package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs5001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs5001Repository extends JpaRepository<Ifs5001, Long>, Ifs5001RepositoryCustom {
}

