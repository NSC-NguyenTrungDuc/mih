package nta.med.data.dao.medi.ifs;

import nta.med.core.domain.ifs.Ifstemp;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface IfstempRepository extends JpaRepository<Ifstemp, Long>, IfstempRepositoryCustom {
}

