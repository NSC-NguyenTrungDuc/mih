package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm9998;

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
public interface Adm9998Repository extends JpaRepository<Adm9998, Long>, Adm9998RepositoryCustom, AdmRepository {
    @Modifying
    @Query("DELETE FROM Adm9998 WHERE a6 in (:a6)")
    public void deleteAdm(@Param("a6") Collection<String> a6);
}

