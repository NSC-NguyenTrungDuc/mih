package nta.med.data.dao.medi.out;

import nta.med.core.domain.out.Out1003;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Out1003Repository extends JpaRepository<Out1003, Long>, Out1003RepositoryCustom {
}

