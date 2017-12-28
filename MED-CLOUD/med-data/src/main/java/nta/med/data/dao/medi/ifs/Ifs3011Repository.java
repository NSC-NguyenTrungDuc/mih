package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs3011;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs3011Repository extends JpaRepository<Ifs3011, Long>, Ifs3011RepositoryCustom {
}

