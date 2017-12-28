package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs2011;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs2011Repository extends JpaRepository<Ifs2011, Long>, Ifs2011RepositoryCustom {
}

