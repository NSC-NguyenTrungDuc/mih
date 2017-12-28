package nta.med.data.dao.medi.inp;

import nta.med.core.domain.inp.Inp1003;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Inp1003Repository extends JpaRepository<Inp1003, Long>, Inp1003RepositoryCustom {
	@Query("SELECT DISTINCT 'Y' FROM Inp1003 A WHERE A.hospCode = :f_hosp_code  AND (SUBSTR(A.doctor, LENGTH(A.doctor) - 4) = :f_doctor "
			+ " OR SUBSTR(A.jisiDoctor, LENGTH(A.jisiDoctor) - 4) = :f_doctor) AND A.bunho = :f_bunho AND A.reserDate IS NOT NULL "
			+ " AND A.reserEndType = '0' AND A.reserFkinp1001 IS NOT NULL")
	public String getIpwonReserStatus(
			@Param("f_hosp_code") String hospCode,
			@Param("f_doctor") String doctor,
			@Param("f_bunho") String bunho);
	
	
	@Modifying
	@Query(	"UPDATE Inp1003 " +
			"SET " +
				"updId 			= :f_user_id, 			updDate 	= SYSDATE(), 		junpyoDate 	= STR_TO_DATE(:f_junpyo_date, '%Y/%m/%d'), " + 
				"tel1 			= :f_tel1, 				tel2 		= :f_tel2, 			reserDate 	= STR_TO_DATE(:f_reser_date, '%Y/%m/%d'), " + 
				"gwa 			= :f_gwa, 				doctor 		= :f_doctor, 		hoCode 		= :f_ho_code, " + 
				"reserEndType 	= :f_reser_end_type, 	remark 		= :f_remark, 		susulReserYn = :f_susul_reser_yn, " + 
				"ipwonRtn2 		= :f_ipwon_rtn2, 		hoDong 		= :f_ho_dong, 		bedNo 		= :f_bed_no, " + 
				"ipwonMokjuk 	= :f_ipwon_mokjuk, 		jisiDoctor 	= :f_jisi_doctor, 	sangBigo 	= :f_sang_bigo, " + 
				"sogyeYn 		= :f_sogye_yn, 			hopeRoom 	= :f_hope_room " + 
			"WHERE hospCode = :f_hosp_code AND pkinp1003 = :f_pkinp1003")
	public Integer updateInp1001(	
			@Param("f_user_id") String updId, @Param("f_junpyo_date") String junpyoDate, 
			@Param("f_tel1") String tel1, @Param("f_tel2") String tel2, @Param("f_reser_date") String reserDate,
			@Param("f_gwa") String gwa, @Param("f_doctor") String doctor, @Param("f_ho_code") String hoCode,
			@Param("f_reser_end_type") String reserEndType, @Param("f_remark") String remark, @Param("f_susul_reser_yn") String susulReserYn,
			@Param("f_ipwon_rtn2") String ipwonRtn2, @Param("f_ho_dong") String hoDong, @Param("f_bed_no") String bedNo,
			@Param("f_ipwon_mokjuk") String ipwonMokjuk, @Param("f_jisi_doctor") String jisiDoctor, @Param("f_sang_bigo") String sangBigo,
			@Param("f_sogye_yn") String sogyeYn, @Param("f_hope_room") String hopeRoom,
			@Param("f_hosp_code") String hospCode, @Param("f_pkinp1003") Double pkinp1003
		);
	
	@Modifying
	@Query("DELETE FROM Inp1003 WHERE hospCode = :f_hosp_code AND pkinp1003 = :f_pkinp1003")
	public Integer deleteInp1003(@Param("f_hosp_code") String hospCode, @Param("f_pkinp1003") Double pkinp1003);
	
	@Query("SELECT reserFkinp1001 FROM Inp1003 WHERE bunho = :bunho  AND reserEndType = '0' AND hospCode = :hosp_code ")
	public List<Double> getReserFkinp1001ByBunho(@Param("hosp_code") String hospCode, @Param("bunho") String bunho);
	

}

