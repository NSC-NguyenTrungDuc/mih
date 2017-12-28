package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm9991;
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
public interface Adm9991Repository extends JpaRepository<Adm9991, Long>, Adm9991RepositoryCustom, AdmRepository {


    @Modifying
    @Query("DELETE FROM Adm9991 WHERE a3 in (:a3)")
    public void deleteAdm(@Param("a3")Collection<String> a3List);
}

