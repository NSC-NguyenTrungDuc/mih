package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl1002;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl1002Repository extends JpaRepository<Cpl1002, Long>, Cpl1002RepositoryCustom {
}

