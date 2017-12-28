package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl2910;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl2910Repository extends JpaRepository<Cpl2910, Long>, Cpl2910RepositoryCustom {
}

