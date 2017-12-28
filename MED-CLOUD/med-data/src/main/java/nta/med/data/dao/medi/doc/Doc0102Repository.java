package nta.med.data.dao.medi.doc;

import nta.med.core.domain.doc.Doc0102;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc0102Repository extends JpaRepository<Doc0102, Long>, Doc0102RepositoryCustom {
}

