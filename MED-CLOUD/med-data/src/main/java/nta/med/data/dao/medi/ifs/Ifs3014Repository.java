package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs3014;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs3014Repository extends JpaRepository<Ifs3014, Long>, Ifs3014RepositoryCustom {
}

