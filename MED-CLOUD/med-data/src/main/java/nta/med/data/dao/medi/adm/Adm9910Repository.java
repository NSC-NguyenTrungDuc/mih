package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm9910;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm9910Repository extends JpaRepository<Adm9910, Long>, Adm9910RepositoryCustom {
}

