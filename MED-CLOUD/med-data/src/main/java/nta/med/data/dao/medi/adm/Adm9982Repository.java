package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm9982;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.Collection;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm9982Repository extends JpaRepository<Adm9982, Long>, Adm9982RepositoryCustom, AdmRepository {
    @Modifying
    @Query("DELETE FROM Adm9982 WHERE a1 in (:a1)")
    public void deleteAdm(@Param("a1") Collection<String> a1List);
}

