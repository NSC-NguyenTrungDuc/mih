package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur0108;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur0108Repository extends JpaRepository<Nur0108, Long>, Nur0108RepositoryCustom {
}

