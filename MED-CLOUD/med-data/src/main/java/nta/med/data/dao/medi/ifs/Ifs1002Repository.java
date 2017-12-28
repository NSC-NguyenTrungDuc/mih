package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs1002;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs1002Repository extends JpaRepository<Ifs1002, Long>, Ifs1002RepositoryCustom {
}

