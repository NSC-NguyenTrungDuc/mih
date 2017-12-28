package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs8052;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs8052Repository extends JpaRepository<Ifs8052, Long>, Ifs8052RepositoryCustom {
}

