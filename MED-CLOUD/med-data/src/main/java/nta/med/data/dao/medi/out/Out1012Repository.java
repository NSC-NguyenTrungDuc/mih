package nta.med.data.dao.medi.out;

import nta.med.core.domain.out.Out1012;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Out1012Repository extends JpaRepository<Out1012, Long>, Out1012RepositoryCustom {
}

