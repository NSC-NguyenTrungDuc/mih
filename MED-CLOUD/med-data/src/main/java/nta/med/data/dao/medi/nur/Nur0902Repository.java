package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur0902;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur0902Repository extends JpaRepository<Nur0902, Long>, Nur0902RepositoryCustom {
}

