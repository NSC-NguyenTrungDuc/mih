package nta.med.data.dao.medi.out;

import nta.med.core.domain.out.Out2011;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Out2011Repository extends JpaRepository<Out2011, Long>, Out2011RepositoryCustom {
}

