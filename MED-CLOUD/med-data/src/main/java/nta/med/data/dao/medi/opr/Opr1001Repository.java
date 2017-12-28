package nta.med.data.dao.medi.opr;

import nta.med.core.domain.opr.Opr1001;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Opr1001Repository extends JpaRepository<Opr1001, Long>, Opr1001RepositoryCustom {
}

