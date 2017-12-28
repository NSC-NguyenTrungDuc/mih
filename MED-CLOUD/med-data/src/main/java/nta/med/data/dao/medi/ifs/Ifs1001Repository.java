package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs1001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs1001Repository extends JpaRepository<Ifs1001, Long>, Ifs1001RepositoryCustom {
}

