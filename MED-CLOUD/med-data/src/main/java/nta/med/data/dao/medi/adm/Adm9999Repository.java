package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm9999;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm9999Repository extends JpaRepository<Adm9999, Long>, Adm9999RepositoryCustom {
}

