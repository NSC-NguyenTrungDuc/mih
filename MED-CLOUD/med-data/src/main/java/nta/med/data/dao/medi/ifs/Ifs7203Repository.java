package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs7203;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs7203Repository extends JpaRepository<Ifs7203, Long>, Ifs7203RepositoryCustom {
}

