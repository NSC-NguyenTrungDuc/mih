package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm9595;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm9595Repository extends JpaRepository<Adm9595, Long>, Adm9595RepositoryCustom {
}

