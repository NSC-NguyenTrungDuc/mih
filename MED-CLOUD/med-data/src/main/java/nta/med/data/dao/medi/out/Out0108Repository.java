package nta.med.data.dao.medi.out;

import nta.med.core.domain.out.Out0108;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Out0108Repository extends JpaRepository<Out0108, Long>, Out0108RepositoryCustom {
}

