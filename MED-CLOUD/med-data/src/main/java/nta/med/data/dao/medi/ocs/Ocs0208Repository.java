package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs0208;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0208Repository extends JpaRepository<Ocs0208, Long>, Ocs0208RepositoryCustom {
	
	@Modifying
	@Query("UPDATE Ocs0208 A SET seq = :f_seq WHERE A.hospCode = :f_hosp_code AND A.bogyongCode = :f_bogyong_code")
	public Integer updateOcsaOCS0208U00UpdateOCS0208(@Param("f_seq") Double seq,
			@Param("f_hosp_code") String hospCode,
			@Param("f_bogyong_code") String bogyongCode);
	
	@Modifying
	@Query("DELETE Ocs0208 WHERE doctor = :f_doctor AND bogyongCode = :f_bogyong_code AND hospCode = :f_hosp_code")
	public Integer deleteOcsaOCS0208U00DeleteOCS0208(@Param("f_doctor") String doctor,
			@Param("f_hosp_code") String hospCode,
			@Param("f_bogyong_code") String bogyongCode);
}

