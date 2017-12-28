package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.Adm3500;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm3500Repository extends JpaRepository<Adm3500, Long>, Adm3500RepositoryCustom {
	@Modifying
	@Query(" DELETE FROM Adm3500 WHERE hospCode = :f_hosp_code AND userId = :f_user_id")
	public Integer deleteAdm3500(@Param("f_hosp_code") String hospCode,@Param("f_user_id") String userId);
}

