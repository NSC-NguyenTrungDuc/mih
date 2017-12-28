package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm0600;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm0600Repository extends JpaRepository<Adm0600, Long>, Adm0600RepositoryCustom {
}

