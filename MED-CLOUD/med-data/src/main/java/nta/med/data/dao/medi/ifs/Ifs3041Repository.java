package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs3041;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs3041Repository extends JpaRepository<Ifs3041, Long>, Ifs3041RepositoryCustom {
}

