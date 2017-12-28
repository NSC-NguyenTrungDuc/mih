package nta.med.data.dao.medi.com;

import nta.med.core.domain.com.ComSeq;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface ComSeqRepository extends JpaRepository<ComSeq, Long>, ComSeqRepositoryCustom {
}

