package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs1004;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs1004Repository extends JpaRepository<Ifs1004, Long>, Ifs1004RepositoryCustom {
}

