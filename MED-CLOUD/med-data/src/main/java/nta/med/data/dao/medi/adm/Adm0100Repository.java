package nta.med.data.dao.medi.adm;

import java.util.List;

import nta.med.core.domain.adm.Adm0100;
import nta.med.data.model.ihis.common.ComboListItemInfo;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Adm0100Repository extends JpaRepository<Adm0100, Long>, Adm0100RepositoryCustom {
	@Query(" select  grpNm from Adm0100 where language =:f_language AND grpId = 'OUT' ")
	public String getADM101UGrpNmButton1(@Param("f_language") String language);
	
	@Modifying
	@Query("UPDATE Adm0100 SET grpSeq  = :f_grp_seq ,grpNm  = :f_grp_nm , "
			+ "grpDesc = :f_grp_desc ,dispGrpId = :f_disp_grp_id , "
			+ "upMemb  = :f_user_id ,upTime  = SYSDATE() WHERE language = :f_language AND grpId  = :f_grp_id ")
	public Integer updateADM101USavePerformerCase1(@Param("f_language") String language,
			@Param("f_grp_seq") Double grpSeq,@Param("f_grp_nm") String grpNm,
			@Param("f_grp_desc") String grpDesc,@Param("f_disp_grp_id") String dispGrpId,
			@Param("f_user_id") String userId,@Param("f_grp_id") String grpId);
	
	@Modifying
	@Query("DELETE Adm0100 WHERE language =:f_language AND grpId = :f_grp_id")
	public Integer deleteADM101USavePerformerCase1(@Param("f_language") String language,@Param("f_grp_id") String grdId);

	@Query(" SELECT adm  FROM Adm0100 adm  where adm.language = :f_language ORDER BY adm.grpId ")
	public List<Adm0100> getADM401UGrdGrp(@Param("f_language") String language);
}

