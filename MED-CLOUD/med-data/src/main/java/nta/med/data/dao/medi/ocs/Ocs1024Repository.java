package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs1024;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs1024Repository extends JpaRepository<Ocs1024, Long>, Ocs1024RepositoryCustom {
	@Modifying
	@Query("DELETE FROM Ocs1024 WHERE hospCode  = :hosp_code  AND pkocs1024 = :pkocs1024 ")
	public Integer deleteOcs1024ByPkocs1024(@Param("hosp_code") String hospCode,@Param("pkocs1024") Double pkocs1024);
	
	@Modifying
	@Query("UPDATE Ocs1024 SET updId  = :f_user_id , updDate = SYSDATE()   ,"
			+ "seq = :f_seq   , suryang = :f_suryang , ordDanui = :f_ord_danui, "
			+ "dvTime  = :f_dv_time , dv = :f_dv, nalsu  = :f_nalsu  , "
			+ "drgComment = :f_drg_comment , bogyongCode = :f_bogyong_code , "
			+ "totalSuryang = :f_total_suryang, currentSuryang  = :f_current_suryang,"
			+ " inputUserId  = :f_input_user_id, jusa = :f_jusa, jusaSpdGubun = :f_jusa_spd_gubun"
			+ " WHERE pkocs1024 = :f_pkocs1024 AND hospCode  = :f_hosp_code  ")
	public Integer updateOcs1024ByPkocs1024(@Param("f_hosp_code") String hospCode
			,@Param("f_pkocs1024") Double pkocs1024
			,@Param("f_user_id") String updId
			,@Param("f_seq") Double seq
			,@Param("f_suryang") Double suryang
			,@Param("f_ord_danui") String ordDanui
			,@Param("f_dv_time") String dvTime
			,@Param("f_dv") Double dv
			,@Param("f_nalsu") Double nalsu
			,@Param("f_drg_comment") String drgComment
			,@Param("f_bogyong_code") String bogyongCode
			,@Param("f_total_suryang") Double totalSuryang
			,@Param("f_current_suryang") Double currentSuryang
			,@Param("f_input_user_id") String inputUserId
			,@Param("f_jusa") String jusa
			,@Param("f_jusa_spd_gubun") String jusaSpdGubun
			);
}

