package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs8053;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs8053Repository extends JpaRepository<Ifs8053, Long>, Ifs8053RepositoryCustom {
}

