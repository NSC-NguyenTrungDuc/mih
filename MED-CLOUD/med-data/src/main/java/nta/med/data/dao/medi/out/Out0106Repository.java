package nta.med.data.dao.medi.out;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.out.Out0106;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Out0106Repository extends JpaRepository<Out0106, Long>, Out0106RepositoryCustom {
	@Query("SELECT comments FROM Out0106 entity WHERE entity.hospCode = :hospCode AND entity.bunho = :bunho "
			+ "AND entity.cmmtGubun = :cmmtGubun ORDER BY updDate DESC")
	public List<String> findCommentsByBunhoAndCmmtGubun(@Param("hospCode") String hospCode, @Param("bunho") String bunho, @Param("cmmtGubun") String cmmtGubun);
	
	@Modifying
	@Query("UPDATE Out0106 SET updId = :f_user_id, updDate = :f_sys_date, comments = :f_comments, displayYn = :f_display_yn "
			+ " WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND ser = :f_ser")
	public Integer updateOUT0106U00SaveComments(@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_comments") String comments,
			@Param("f_display_yn") String displayYn,
			@Param("f_hosp_code") String hospCode,
			@Param("f_bunho") String bunho,
			@Param("f_ser") Double ser);
	
	@Modifying
	@Query("DELETE Out0106 WHERE hospCode = :f_hosp_code AND bunho = :f_bunho AND ser = :f_ser")
	public Integer deleteOUT0106U00SaveComments(@Param("f_hosp_code") String hospCode,
			@Param("f_bunho") String bunho,
			@Param("f_ser") Double ser);
	
	@Query("SELECT T FROM Out0106 T WHERE T.hospCode = :hospCode AND T.bunho = :bunho ORDER BY ser DESC")
	public List<Out0106> findByHospCodeBunho(@Param("hospCode") String hospCode, 
											 @Param("bunho") String bunho);
	
}

