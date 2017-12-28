package nta.med.data.dao.medi.nur;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.nur.Nur1017;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nur1017Repository extends JpaRepository<Nur1017, Long>, Nur1017RepositoryCustom {
	
	@Modifying
	@Query("SELECT a FROM Nur1017 a                         					   "
			  +"WHERE a.hospCode = :hospCode  AND a.bunho = :bunho                     "
			  +"AND :queryDate BETWEEN a.startDate AND IFNULL(a.endDate,'9998/12/31')  "
			  +"AND IFNULL(a.cancelYn, 'N') = 'N'                                      "
			  +"ORDER BY a.startDate DESC                                              ")
		public List<Nur1017> getInjsINJ1001U01InfectionListItemInfo(@Param("hospCode") String hospCode,
				@Param("bunho") String bunho,
				@Param("queryDate") Date queryDate);
	
	@Modifying
	@Query(  " UPDATE Nur1017					   "
			+"   SET updId      = :q_user_id,      "
			+"       updDate    = SYSDATE(),       "
			+"       endDate    = :f_end_date,     "
			+"       endSayu    = :f_end_sayu,     "
			+"       inputText  = :f_input_text,   "
			+"       infeJaeryo = :f_infe_jaeryo,  "
			+"       cancelYn   = 'N'              "
			+" WHERE hospCode   = :f_hosp_code     "
			+"   AND pknur1017   = :f_pknur1017     ")
	public Integer updateNuriNUR1017U00UpdateManageInfection(@Param("q_user_id") String userId,
			@Param("f_end_date") Date endDate,
			@Param("f_end_sayu") String endSayu,
			@Param("f_input_text") String inputText,
			@Param("f_infe_jaeryo") String infeJaeryo,
			@Param("f_hosp_code") String hospCode,
			@Param("f_pknur1017") Double pknur1017);
	
	@Modifying
	@Query(  " UPDATE Nur1017							"
			+"     SET updId      = :q_user_id,         "
			+"         updDate    = SYSDATE(),          "
			+"         cancelYn   = 'Y'                 "
			+"   WHERE hospCode   = :f_hosp_code        "
			+"     AND pknur1017   = :f_pknur1017       ")
	public Integer deleteNuriNUR1017U00ManageInfection(@Param("q_user_id") String userId,
			@Param("f_hosp_code") String hospCode,
			@Param("f_pknur1017") Double pnknur1017);
}

