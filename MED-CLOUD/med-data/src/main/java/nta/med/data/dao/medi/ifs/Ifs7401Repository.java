package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs7401;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs7401Repository extends JpaRepository<Ifs7401, Long>, Ifs7401RepositoryCustom {
}

