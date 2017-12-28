package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur0901;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur0901Repository extends JpaRepository<Nur0901, Long>, Nur0901RepositoryCustom {
}

