package nta.med.data.dao.medi.sch;

import nta.med.core.domain.sch.Sch0299;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Sch0299Repository extends JpaRepository<Sch0299, Long>, Sch0299RepositoryCustom {
}

