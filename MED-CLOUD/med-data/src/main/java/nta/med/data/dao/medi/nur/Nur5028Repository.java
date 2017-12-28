package nta.med.data.dao.medi.nur;

import nta.med.core.domain.nur.Nur5028;

import java.util.Date;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur5028Repository extends JpaRepository<Nur5028, Long>, Nur5028RepositoryCustom {
	
	@Modifying
	@Query(   " UPDATE Nur5028                   "
			+ "    SET updDate    = SYSDATE()    "
			+ "      , updId      = :f_user_id   "
			+ "      , buwi       = :f_buwi      "
			+ "  WHERE hospCode   = :f_hosp_code "
			+ "    AND hoDong     = :f_ho_dong   "
			+ "    AND nurWrdt    = :f_nur_wrdt  "
			+ "    AND bunho      = :f_bunho     "
			+ "    AND fromDate   = :f_from_date ")
	public Integer updByHospCodeHoDongNurWrdtBunhoFromDate(@Param("f_user_id") 		String updId   ,
														   @Param("f_buwi") 		String buwi    ,
														   @Param("f_hosp_code") 	String hospCode,
														   @Param("f_ho_dong") 		String hoDong  ,
														   @Param("f_nur_wrdt") 	Date nurWrdt ,
														   @Param("f_bunho") 		String bunho   ,
														   @Param("f_from_date") 	Date fromDate);
	
	
	@Modifying
	@Query(   " DELETE Nur5028                   "
			+ "  WHERE hospCode   = :f_hosp_code "
			+ "    AND hoDong     = :f_ho_dong   "
			+ "    AND nurWrdt    = :f_nur_wrdt  "
			+ "    AND bunho      = :f_bunho     "
			+ "    AND fromDate   = :f_from_date ")
	public Integer deleteByHospCodeHoDongNurWrdtBunhoFromDate( @Param("f_hosp_code") 	String hospCode,
															   @Param("f_ho_dong") 		String hoDong  ,
															   @Param("f_nur_wrdt") 	Date nurWrdt ,
															   @Param("f_bunho") 		String bunho   ,
															   @Param("f_from_date") 	Date fromDate);
	
}

