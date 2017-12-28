package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm3210;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm3210Repository extends JpaRepository<Adm3210, Long>, Adm3210RepositoryCustom {
}

