package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifs7202;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ifs7202Repository extends JpaRepository<Ifs7202, Long>, Ifs7202RepositoryCustom {
}

