package nta.med.data.dao.medi.pacs;

import nta.med.core.domain.pacs.PacsOp;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface PacsOpRepository extends JpaRepository<PacsOp, Long>, PacsOpRepositoryCustom {
}

