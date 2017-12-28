package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur5012;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur5012Repository extends JpaRepository<Nur5012, Long>, Nur5012RepositoryCustom {
}
