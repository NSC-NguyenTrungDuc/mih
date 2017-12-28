package nta.med.data.dao.medi.nur;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur0112;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur0112Repository extends JpaRepository<Nur0112, Long>, Nur0112RepositoryCustom {
	
	@Query("SELECT T FROM Nur0112 T WHERE T.hospCode = :hospCode AND T.nurGrCode = :nurGrCode AND T.nurMdCode = :nurMdCode AND T.nurSoCode = :nurSoCode")
	public List<Nur0112> findByHospCodeNurGrCodeNurMdCodeNurSoCode(@Param("hospCode") String hospCode,
			@Param("nurGrCode") String nurGrCode, 
			@Param("nurMdCode") String nurMdCode, 
			@Param("nurSoCode") String nurSoCode);
	
	
	@Modifying
	@Query(   " UPDATE Nur0112                         "
			+ " SET updId       = :q_user_id,          "
			+ "    updDate      = SYSDATE(),           "
			+ "    nurSoName   	= TRIM(:f_nur_so_name),"
			+ "    vald         = :f_vald,             "
			+ "    sortKey      = :f_sort_key,         "
			+ "    ment         = :f_ment              "
			+ " WHERE hospCode  = :f_hosp_code         "
			+ " AND nurGrCode   = :f_nur_gr_code       "
			+ " AND nurMdCode   = :f_nur_md_code       "
			+ " AND nurSoCode   = :f_nur_so_code       ")
	public Integer updateByHospCodeNurGrCodeNurMdCodeNurSoCode( @Param("q_user_id") String updId,
																@Param("f_nur_so_name") String nurSoName,
																@Param("f_vald") String vald,
																@Param("f_sort_key") Double sortKey,
																@Param("f_ment") String ment,
																@Param("f_hosp_code") String hospCode,
																@Param("f_nur_gr_code") String nurGrCode,
																@Param("f_nur_md_code") String nurMdCode,
																@Param("f_nur_so_code") String nurSoCode);
	
	@Modifying
	@Query(   " UPDATE Nur0112                         "
			+ " SET updId       = :q_user_id,          "
			+ "    updDate      = SYSDATE(),           "
			+ "    vald         = :f_vald              "
			+ " WHERE hospCode  = :f_hosp_code         "
			+ " AND nurGrCode   = :f_nur_gr_code       "
			+ " AND nurMdCode   = :f_nur_md_code       "
			+ " AND nurSoCode   = :f_nur_so_code       ")
	public Integer updateValdByHospCodeNurGrCodeNurMdCodeNurSoCode( @Param("q_user_id") String updId,
																@Param("f_vald") String vald,
																@Param("f_hosp_code") String hospCode,
																@Param("f_nur_gr_code") String nurGrCode,
																@Param("f_nur_md_code") String nurMdCode,
																@Param("f_nur_so_code") String nurSoCode);
}

