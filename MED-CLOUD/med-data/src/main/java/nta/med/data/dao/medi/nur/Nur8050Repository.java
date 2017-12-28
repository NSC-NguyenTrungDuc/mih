package nta.med.data.dao.medi.nur;

import java.util.Date;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur8050;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur8050Repository extends JpaRepository<Nur8050, Long>, Nur8050RepositoryCustom {
	
	@Modifying
	@Query(   " UPDATE Nur8050                       "
			+ "    SET updId        = :q_user_id     "
			+ "      , updDate      = SYSDATE()      "
			+ "      , detail       = :f_detail      "
			+ "      , writeUser    = :f_write_user  "
			+ "      , confirmUser  = :f_confirm_user"
			+ "  WHERE hospCode     = :f_hosp_code   "
			+ "    AND bunho        = :f_bunho       "
			+ "    AND fkinp1001    = :f_fkinp1001   "
			+ "    AND gubun        = :f_gubun       "
			+ "    AND writeDate    = :f_write_date  ")
	public Integer updateNUR8050U00(
			@Param("q_user_id") 		String userId,
			@Param("f_detail") 			String detail     ,
			@Param("f_write_user") 		String writeUser  ,
			@Param("f_confirm_user") 	String confirmUser,
			@Param("f_hosp_code") 		String hospCode   ,
			@Param("f_bunho") 			String bunho      ,
			@Param("f_fkinp1001") 		Double fkinp1001  ,
			@Param("f_gubun") 			String gubun      ,
			@Param("f_write_date") 		Date writeDate  );
	
	@Modifying
	@Query(   " DELETE Nur8050                       "
			+ "  WHERE hospCode     = :f_hosp_code   "
			+ "    AND bunho        = :f_bunho       "
			+ "    AND fkinp1001    = :f_fkinp1001   "
			+ "    AND gubun        = :f_gubun       "
			+ "    AND writeDate    = :f_write_date  ")
	public Integer deleteNUR8050U00(@Param("f_hosp_code") 		String hospCode   ,
									@Param("f_bunho") 			String bunho      ,
									@Param("f_fkinp1001") 		Double fkinp1001  ,
									@Param("f_gubun") 			String gubun      ,
									@Param("f_write_date") 		Date writeDate    );
}
