package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm5200;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm5200Repository extends JpaRepository<Adm5200, Long>, Adm5200RepositoryCustom {
}

