package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm0001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm0001Repository extends JpaRepository<Adm0001, Long>, Adm0001RepositoryCustom {
}

