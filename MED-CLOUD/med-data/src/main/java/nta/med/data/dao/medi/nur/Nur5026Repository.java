package nta.med.data.dao.medi.nur;

import java.util.Date;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur5026;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur5026Repository extends JpaRepository<Nur5026, Long>, Nur5026RepositoryCustom {
	
	@Modifying
	@Query(   " UPDATE Nur5026                   "
			+ "    SET updDate    = SYSDATE()    "
			+ "      , updId      = :f_user_id   "
			+ "      , paCnt      = :f_pa_cnt    "
			+ "  WHERE hospCode   = :f_hosp_code "
			+ "    AND hoDong     = :f_ho_dong   "
			+ "    AND nurWrdt    = :f_nur_wrdt  "
			+ "    AND gwa        = :f_gwa       ")
	public Integer updByHospCodeHoDongNurWrdtGwa(@Param("f_user_id") String updId   ,
												 @Param("f_pa_cnt") Double paCnt   ,
												 @Param("f_hosp_code") String hospCode,
												 @Param("f_ho_dong") String hoDong  ,
												 @Param("f_nur_wrdt") Date nurWrdt ,
												 @Param("f_gwa") String gwa     );
	
	@Modifying
	@Query(   " DELETE Nur5026                   "
			+ "  WHERE hospCode   = :f_hosp_code "
			+ "    AND hoDong     = :f_ho_dong   "
			+ "    AND nurWrdt    = :f_nur_wrdt  "
			+ "    AND gwa        = :f_gwa       ")
	public Integer deleteByHospCodeHoDongNurWrdtGwa(@Param("f_hosp_code") String hospCode,
													@Param("f_ho_dong") String hoDong  ,
													@Param("f_nur_wrdt") Date nurWrdt ,
													@Param("f_gwa") String gwa     );
	
}

