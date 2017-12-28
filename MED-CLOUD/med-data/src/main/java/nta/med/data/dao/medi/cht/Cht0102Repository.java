package nta.med.data.dao.medi.cht;

import nta.med.core.domain.cht.Cht0102;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cht0102Repository extends JpaRepository<Cht0102, Long>, Cht0102RepositoryCustom {
}

