package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs1011;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs1011Repository extends JpaRepository<Ifs1011, Long> ,Ifs1011RepositoryCustom {
}

