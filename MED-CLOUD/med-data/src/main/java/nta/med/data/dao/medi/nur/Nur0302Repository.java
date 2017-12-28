package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur0302;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur0302Repository extends JpaRepository<Nur0302, Long>, Nur0302RepositoryCustom {
}

