package nta.med.data.dao.medi.out;

import nta.med.core.domain.out.Out0103;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Out0103Repository extends JpaRepository<Out0103, Long>, Out0103RepositoryCustom {
	
}

