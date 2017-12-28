package nta.med.data.dao.medi.doc;

import nta.med.core.domain.doc.Doc0101;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc0101Repository extends JpaRepository<Doc0101, Long>, Doc0101RepositoryCustom {
}

