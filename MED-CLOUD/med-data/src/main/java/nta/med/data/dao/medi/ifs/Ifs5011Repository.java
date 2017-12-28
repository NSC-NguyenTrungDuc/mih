package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs5011;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs5011Repository extends JpaRepository<Ifs5011, Long>, Ifs5011RepositoryCustom {
}

