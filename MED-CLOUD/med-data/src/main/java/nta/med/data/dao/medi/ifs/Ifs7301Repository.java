package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs7301;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs7301Repository extends JpaRepository<Ifs7301, Long>, Ifs7301RepositoryCustom {
}

