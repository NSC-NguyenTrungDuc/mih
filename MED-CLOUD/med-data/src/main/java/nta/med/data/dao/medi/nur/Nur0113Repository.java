package nta.med.data.dao.medi.nur;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur0113;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur0113Repository extends JpaRepository<Nur0113, Long>, Nur0113RepositoryCustom {
	
	@Query("SELECT T FROM Nur0113 T WHERE T.hospCode = :hospCode AND T.nurGrCode = :nurGrCode AND T.nurMdCode = :nurMdCode AND T.nurActCode = :nurActCode")
	public List<Nur0113> findByHospCodeNurGrCodeNurMdCodeNurActCode(@Param("hospCode") String hospCode,
			@Param("nurGrCode") String nurGrCode,
			@Param("nurMdCode") String nurMdCode,
			@Param("nurActCode") String nurActCode);
	
	@Modifying
	@Query(   " UPDATE Nur0113                            "
			+ " SET updId        = :q_user_id,            "
			+ "     updDate      = SYSDATE(),             "
			+ "     nurActName   = TRIM(:f_nur_act_name), "
			+ "     vald         = :f_vald,               "
			+ "     sortKey      = :f_sort_key,           "
			+ "     ment         = :f_ment                "
			+ " WHERE hospCode   = :f_hosp_code           "
			+ " AND nurGrCode    = :f_nur_gr_code         "
			+ " AND nurMdCode    = :f_nur_md_code         "
			+ " AND nurActCode   = :f_nur_act_code        ")
	public Integer updateByHospCodeNurGrCodeNurMdCodeNurActCode(@Param("q_user_id") String userId ,
																@Param("f_nur_act_name") String nurActName,
																@Param("f_vald") String vald,
																@Param("f_sort_key") Double sortKey ,
																@Param("f_ment") String ment,
																@Param("f_hosp_code") String hospCode,
																@Param("f_nur_gr_code") String nurGrCode,
																@Param("f_nur_md_code") String nurMdCode,
																@Param("f_nur_act_code") String nurActCode);
	
	@Modifying
	@Query(   " UPDATE Nur0113                            "
			+ " SET updId        = :q_user_id,            "
			+ "     updDate      = SYSDATE(),             "
			+ "     vald         = :f_vald                "
			+ " WHERE hospCode   = :f_hosp_code           "
			+ " AND nurGrCode    = :f_nur_gr_code         "
			+ " AND nurMdCode    = :f_nur_md_code         "
			+ " AND nurActCode   = :f_nur_act_code        ")
	public Integer updateValdByHospCodeNurGrCodeNurMdCodeNurActCode(@Param("q_user_id") String userId ,
																	@Param("f_vald") String vald,
																	@Param("f_hosp_code") String hospCode,
																	@Param("f_nur_gr_code") String nurGrCode,
																	@Param("f_nur_md_code") String nurMdCode,
																	@Param("f_nur_act_code") String nurActCode);
}

