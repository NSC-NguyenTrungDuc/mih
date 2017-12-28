package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs4011;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs4011Repository extends JpaRepository<Ifs4011, Long>, Ifs4011RepositoryCustom {
}

