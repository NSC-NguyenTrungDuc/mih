package nta.med.data.dao.medi.cpl;



import nta.med.core.domain.cpl.Cpl0104;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Cpl0104Repository extends JpaRepository<Cpl0104, Long>, Cpl0104RepositoryCustom {
	
	@Modifying	
	@Query("       UPDATE Cpl0104									"
			+ "		SET updId = :f_user_id ,                        "
			+ "     updDate = SYSDATE(),                            "
			+ "     fromStandard = :f_from_standard ,               "
			+ "      toStandard = :f_to_standard                    "
			+ "      , modifyFlg     	  = :modifyFlg	            "
			+ "     WHERE hangmogCode = :f_hangmog_code             "
			+ "     AND specimenCode = :f_specimen_code             "
			+ "     AND emergency = :f_emergency                    "
			+ "     AND sex  = :f_sex                               "
			+ "     AND fromAge  = :f_from_age                      "
			+ "      AND toAge = :f_to_age                          "
			+ "     AND naiFrom = :f_nai_from                       "
			+ "     AND naiTo  = :f_nai_to                          "
			+ "     AND hospCode = :f_hosp_code                   ")
	public Integer updateCpl0104(@Param("f_hosp_code") String hospCode,
			@Param("f_user_id") String userId,
			@Param("f_from_standard") String fromStandard,
			@Param("f_to_standard") String toStandard, 
			@Param("modifyFlg") String modifyFlg,
			@Param("f_hangmog_code") String hangmogCode,
			@Param("f_specimen_code") String specimenCode,
			@Param("f_emergency") String emergency,
			@Param("f_sex") String sex,
			@Param("f_from_age") Double fromAge,
			@Param("f_to_age") Double toAge, 
			@Param("f_nai_from") String naiFrom,
			@Param("f_nai_to") String naiTo);
	
	@Modifying
	@Query("DELETE Cpl0104 WHERE hangmogCode = :f_hangmog_code AND specimenCode = :f_specimen_code "
			+ "AND emergency  = :f_emergency AND sex = :f_sex AND fromAge = :f_from_age "
			+ "AND toAge = :f_to_age AND naiFrom = :f_nai_from AND naiTo = :f_nai_to AND hospCode  = :f_hosp_code")
	public Integer deleteCpl0104(@Param("f_hosp_code") String hospCode,@Param("f_hangmog_code") String hangmogCode,
			@Param("f_specimen_code") String specimenCode,@Param("f_emergency") String emergency,@Param("f_sex") String sex,
			@Param("f_from_age") Double fromAge,@Param("f_to_age") Double toAge, @Param("f_nai_from") String naiFrom,@Param("f_nai_to") String naiTo);
}

