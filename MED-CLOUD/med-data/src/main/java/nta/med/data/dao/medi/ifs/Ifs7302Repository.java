package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs7302;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs7302Repository extends JpaRepository<Ifs7302, Long>, Ifs7302RepositoryCustom {
}

