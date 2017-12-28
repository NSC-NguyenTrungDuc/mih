package nta.med.data.dao.medi.nur;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur1032;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1032Repository extends JpaRepository<Nur1032, Long>, Nur1032RepositoryCustom {
	
}

