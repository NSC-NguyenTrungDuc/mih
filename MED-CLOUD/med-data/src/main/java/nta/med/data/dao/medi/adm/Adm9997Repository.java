package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm9997;

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
public interface Adm9997Repository extends JpaRepository<Adm9997, Long>, Adm9997RepositoryCustom, AdmRepository {
    @Modifying
    @Query("DELETE FROM Adm9997 WHERE a2 in (:a2)")
    public void deleteAdm(@Param("a2") Collection<String> a2List);
}

