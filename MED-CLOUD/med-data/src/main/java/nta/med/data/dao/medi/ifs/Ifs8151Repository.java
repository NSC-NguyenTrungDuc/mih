package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs8151;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs8151Repository extends JpaRepository<Ifs8151, Long>, Ifs8151RepositoryCustom {
}

