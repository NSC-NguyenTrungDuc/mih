package nta.med.data.dao.medi.doc;

import nta.med.core.domain.doc.Doc0103;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc0103Repository extends JpaRepository<Doc0103, Long>, Doc0103RepositoryCustom {
}

