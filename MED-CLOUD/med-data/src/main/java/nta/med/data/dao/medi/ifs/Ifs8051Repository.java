package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs8051;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs8051Repository extends JpaRepository<Ifs8051, Long>, Ifs8051RepositoryCustom {
}

