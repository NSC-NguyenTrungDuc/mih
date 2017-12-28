package nta.med.data.dao.medi.out;

import nta.med.core.domain.out.Out1011;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Out1011Repository extends JpaRepository<Out1011, Long>, Out1011RepositoryCustom {
}

