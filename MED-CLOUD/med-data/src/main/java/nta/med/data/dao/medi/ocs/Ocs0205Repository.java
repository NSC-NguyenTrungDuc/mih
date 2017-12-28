package nta.med.data.dao.medi.ocs;

import java.util.Date;

import nta.med.core.domain.ocs.Ocs0205;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0205Repository extends JpaRepository<Ocs0205, Long>, Ocs0205RepositoryCustom {
	
	@Query("SELECT IFNULL(MAX(pkSeq), 0) + 1 FROM Ocs0205 WHERE memb = :f_memb "
			+ "AND membGubun = '1' AND sangGubun = :f_sang_gubun AND hospCode  = :f_hosp_code")
	public Double getPkSeqOcsaOCS0204U00InsertIntoOCS0205(@Param("f_memb") String memb,
			@Param("f_sang_gubun") String sangGubun,
			@Param("f_hosp_code") String hospCode); 
	
	@Modifying
	@Query("UPDATE Ocs0205 SET updId = :f_user_id, updDate = :f_sys_date, ser = :f_ser, sangName = :f_sang_name, "
			+ "preModifier1 = :f_pre_modifier1, preModifier2 = :f_pre_modifier2, preModifier3 = :f_pre_modifier3, "
			+ "preModifier4 = :f_pre_modifier4, preModifier5 = :f_pre_modifier5, preModifier6 = :f_pre_modifier6, "
			+ "preModifier7 = :f_pre_modifier7, preModifier8 = :f_pre_modifier8, preModifier9 = :f_pre_modifier9, "
			+ "preModifier10 = :f_pre_modifier10, preModifierName = :f_pre_modifier_name, postModifier1 = :f_post_modifier1, "
			+ "postModifier2 = :f_post_modifier2, postModifier3 = :f_post_modifier3, postModifier4 = :f_post_modifier4, "
			+ "postModifier5 = :f_post_modifier5, postModifier6 = :f_post_modifier6, postModifier7 = :f_post_modifier7, "
			+ "postModifier8 = :f_post_modifier8, postModifier9 = :f_post_modifier9, postModifier10 = :f_post_modifier10, "
			+ "postModifierName = :f_post_modifier_name  WHERE memb = :f_memb AND membGubun = '1' "
			+ "AND sangGubun = :f_sang_gubun AND pkSeq = :f_pk_seq AND hospCode  = :f_hosp_code")
	public Integer updateOcsaOCS0204U00UpdateOCS0205Request(@Param("f_user_id") String updId,
			@Param("f_sys_date") Date updDate,
			@Param("f_ser") Double ser,
			@Param("f_sang_name") String sangName,
			@Param("f_pre_modifier1") String preModifier1,
			@Param("f_pre_modifier2") String preModifier2,
			@Param("f_pre_modifier3") String preModifier3,
			@Param("f_pre_modifier4") String preModifier4,
			@Param("f_pre_modifier5") String preModifier5,
			@Param("f_pre_modifier6") String preModifier6,
			@Param("f_pre_modifier7") String preModifier7,
			@Param("f_pre_modifier8") String preModifier8,
			@Param("f_pre_modifier9") String preModifier9,
			@Param("f_pre_modifier10") String preModifier10,
			@Param("f_pre_modifier_name") String preModifierName,
			@Param("f_post_modifier1") String postModifier1,
			@Param("f_post_modifier2") String postModifier2,
			@Param("f_post_modifier3") String postModifier3,
			@Param("f_post_modifier4") String postModifier4,
			@Param("f_post_modifier5") String postModifier5,
			@Param("f_post_modifier6") String postModifier6,
			@Param("f_post_modifier7") String postModifier7,
			@Param("f_post_modifier8") String postModifier8,
			@Param("f_post_modifier9") String postModifier9,
			@Param("f_post_modifier10") String postModifier10,
			@Param("f_post_modifier_name") String postModifierName,
			@Param("f_memb") String memb,
			@Param("f_sang_gubun") String sangGubun,
			@Param("f_pk_seq") Double pkSeq,
			@Param("f_hosp_code") String hospCode);
	
	@Modifying
	@Query("DELETE Ocs0205 WHERE memb = :f_memb AND membGubun = '1' AND sangGubun = :f_sang_gubun AND pkSeq = :f_pk_seq AND hospCode  = :f_hosp_code")
	public Integer deleteOcsaOCS0204U00DeleteOCS0205(@Param("f_memb") String memb,
			@Param("f_sang_gubun") String sangGubun,
			@Param("f_pk_seq") Double pkSeq,
			@Param("f_hosp_code") String hospCode);
}

