package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm0710;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm0710Repository extends JpaRepository<Adm0710, Long>, Adm0710RepositoryCustom {
}

