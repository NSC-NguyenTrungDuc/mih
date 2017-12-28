package nta.med.data.dao.medi.cpl;

import nta.med.core.domain.cpl.Cpl0111;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl0111Repository extends JpaRepository<Cpl0111, Long>, Cpl0111RepositoryCustom {
	@Query("SELECT note FROM Cpl0111 WHERE hospCode = :f_hosp_code AND jundalGubun = :f_jundal_gubun AND code = :f_code")
	public String getCPL3020U02InitializeVsvNote(@Param("f_hosp_code") String hospCode,
			@Param("f_jundal_gubun") String jundalGubun,
			@Param("f_code") String code); 
}

