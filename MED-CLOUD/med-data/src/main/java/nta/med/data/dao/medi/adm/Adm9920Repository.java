package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm9920;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm9920Repository extends JpaRepository<Adm9920, Long>, Adm9920RepositoryCustom {
}

