package nta.med.data.dao.medi.nur;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur0110;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur0110Repository extends JpaRepository<Nur0110, Long>, Nur0110RepositoryCustom {

	@Query("SELECT T FROM Nur0110 T WHERE T.hospCode = :hospCode AND T.nurGrCode = :nurGrCode")
	public List<Nur0110> findByHospCodeNurGrCode(@Param("hospCode") String hospCode,
			@Param("nurGrCode") String nurGrCode);
	
	@Modifying
	@Query(   " UPDATE Nur0110                          "
			+ "    SET updId          = :q_user_id,     "
			+ "        updDate        = SYSDATE(),      "
			+ "        nurGrName      = :f_nur_gr_name, "
			+ "        vald           = :f_vald,        "
			+ "        sortKey        = :f_sort_key,    "
			+ "        ment           = :f_ment         "
			+ "  WHERE hospCode       = :f_hosp_code    "
			+ "    AND nurGrCode      = :f_nur_gr_code  ")
	public Integer updateByHospCodeNurGrCode(@Param("q_user_id") 	String userId,
											 @Param("f_nur_gr_name") String nurGrName,
											 @Param("f_vald") 		String vald,
											 @Param("f_sort_key") 	String sortKey,
											 @Param("f_ment") 		String ment,
											 @Param("f_hosp_code") 	String hospCode,
											 @Param("f_nur_gr_code") String nurGrCode);
	
	@Modifying
	@Query(   " UPDATE Nur0110                          "
			+ "    SET updId          = :q_user_id,     "
			+ "        updDate        = SYSDATE(),      "
			+ "        vald           = :f_vald         "
			+ "  WHERE hospCode       = :f_hosp_code    "
			+ "    AND nurGrCode      = :f_nur_gr_code  ")
	public Integer updateValByHospCodeNurGrCode(@Param("q_user_id") 	String userId,
												@Param("f_vald") 		String vald,
												@Param("f_hosp_code") 	String hospCode,
												@Param("f_nur_gr_code") String nurGrCode);

}
