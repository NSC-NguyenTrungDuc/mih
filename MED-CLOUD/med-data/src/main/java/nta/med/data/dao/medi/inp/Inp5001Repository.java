package nta.med.data.dao.medi.inp;

import java.util.Date;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.inp.Inp5001;

/**
 * @author dainguyen.
 */
@Repository
public interface Inp5001Repository extends JpaRepository<Inp5001, Long>, Inp5001RepositoryCustom {
	
	@Modifying
	@Query("UPDATE Inp5001 SET nutJoMagamYn = :f_yn WHERE hospCode = :f_hosp_code AND magamDate = :f_magam_date")
	public Integer updateNutJoMagamYnInNUT9001U00(@Param("f_hosp_code")  String hospCode,
												  @Param("f_yn") 		 String yn,
												  @Param("f_magam_date") Date magamDate);
	
	@Modifying
	@Query("UPDATE Inp5001 SET nutJuMagamYn = :f_yn WHERE hospCode = :f_hosp_code AND magamDate = :f_magam_date")
	public Integer updateNutJuMagamYnInNUT9001U00(@Param("f_hosp_code")  String hospCode,
												  @Param("f_yn") 		 String yn,
												  @Param("f_magam_date") Date magamDate);
	
	@Modifying
	@Query("UPDATE Inp5001 SET nutSeokMagamYn = :f_yn WHERE hospCode = :f_hosp_code AND magamDate = :f_magam_date")
	public Integer updateNutSeokMagamYnInNUT9001U00(@Param("f_hosp_code")  String hospCode,
												  @Param("f_yn") 		 String yn,
												  @Param("f_magam_date") Date magamDate);
}

