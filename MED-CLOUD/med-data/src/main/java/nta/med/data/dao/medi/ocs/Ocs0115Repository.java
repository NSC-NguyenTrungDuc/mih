package nta.med.data.dao.medi.ocs;

import java.util.Date;

import nta.med.core.domain.ocs.Ocs0115;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs0115Repository extends JpaRepository<Ocs0115, Long>, Ocs0115RepositoryCustom {
	
	@Query("SELECT 'Y'  FROM Ocs0115 WHERE hospCode = :f_hosp_code  "
			+ "AND hangmogCode = :f_hangmog_code   AND inputPart   = :f_input_part "
			+ "AND inputGwa    = :f_input_gwa  AND hangmogStartDate = :f_hangmog_start_date  AND startDate   = :f_start_date")
	public String checkExistYOcs0115(@Param("f_hosp_code") String hospCode,@Param("f_hangmog_code") String hangmogCode,
			@Param("f_input_part") String inputPart,@Param("f_input_gwa") String inputGwa,@Param("f_hangmog_start_date") Date hangmogStartDate,
			@Param("f_start_date") Date startDate);
	
	@Modifying
	@Query("DELETE FROM Ocs0115  WHERE hospCode   = :f_hosp_code  AND hangmogCode  = :f_hangmog_code "
			+ " AND inputPart  = :f_input_part AND inputGwa   = :f_input_gwa  "
			+ " AND hangmogStartDate = :f_hangmog_start_date  AND startDate   = :f_start_date ")
	public Integer deleleOCS0103U00SaveLayout(@Param("f_hosp_code") String hospCode,@Param("f_hangmog_code") String hangmogCode,
			@Param("f_input_part") String inputPart,@Param("f_input_gwa") String inputGwa,@Param("f_hangmog_start_date") Date hangmogStartDate,
			@Param("f_start_date") Date startDate);
	
	//END_DATE = TO_DATE(:f_start_date) - 1
	@Modifying
	@Query("UPDATE Ocs0115  SET updId = :f_user_id, updDate = SYSDATE() ,endDate = STR_TO_DATE('9998/12/31', '%Y/%m/%d')   "
			+ "WHERE hospCode  = :f_hosp_code  AND hangmogCode  = :f_hangmog_code  AND inputPart = :f_input_part "
			+ "AND inputGwa   = :f_input_gwa  AND hangmogStartDate = :f_hangmog_start_date "
			+ "AND endDate   = :f_start_date  ")
	public Integer updateOcs0103U00Case3Deleted(@Param("f_hosp_code") String hospCode,@Param("f_user_id") String updId,
			@Param("f_hangmog_code") String hangmogCode,@Param("f_input_part") String inputPart,
			@Param("f_input_gwa") String inputGwa,@Param("f_hangmog_start_date") Date hangmogStartDate,
			@Param("f_start_date") Date startDateMinus1);
	
	@Modifying
	@Query("UPDATE Ocs0115  SET updId   = :f_user_id , updDate   = SYSDATE()  , "
			+ "jundalTableOut = :f_jundal_table_out ,  jundalPartOut  = :f_jundal_part_out , "
			+ "jundalTableInp = :f_jundal_table_inp  , jundalPartInp = :f_jundal_part_inp  , "
			+ " movePart   = :f_move_part   , endDate   = :f_end_date , "
			+ "hangmogStartDate = :f_hangmog_start_date "
			+ "WHERE hospCode  = :f_hosp_code AND hangmogCode  = :f_hangmog_code AND inputPart  = :f_input_part "
			+ " AND inputGwa   = :f_input_gwa  AND hangmogStartDate = :f_hangmog_start_date  AND startDate   = :f_start_date ")
	public Integer updateOcs0103U00Case3Modify(@Param("f_hosp_code") String hospCode,@Param("f_user_id") String updId,
			@Param("f_jundal_table_out") String jundalTableOut,@Param("f_jundal_part_out") String jundalPartOut,
			@Param("f_jundal_table_inp") String jundalTableInp,@Param("f_jundal_part_inp") String jundalPartInp,
			@Param("f_move_part") String movePart,@Param("f_end_date") Date endDate,@Param("f_hangmog_start_date") Date hangmogStartDate,
			@Param("f_hangmog_code") String hangmogCode,@Param("f_input_part") String inputPart,
			@Param("f_input_gwa") String inputGwa,@Param("f_start_date") Date startDate);
	
	//END_DATE = TO_DATE(:f_start_date) - 1
	@Modifying
	@Query("UPDATE Ocs0115  SET endDate = :f_start_date_minus1  , "
			+ "updId= :f_user_id ,updDate = SYSDATE() "
			+ "WHERE hospCode    = :f_hosp_code "
			+ "AND hangmogCode   = :f_hangmog_code  "
			+ " AND startDate   <= :f_start_date AND inputPart  = :f_input_part "
			+ " AND inputGwa     = :f_input_gwa  AND hangmogStartDate = :f_hangmog_start_date "
			+ " AND endDate      = STR_TO_DATE('9998/12/31', '%Y/%m/%d') ")
	public Integer updateOcs0103U00Case3Add(@Param("f_hosp_code") String hospCode,
			@Param("f_start_date_minus1") Date startDateMinus1,
			@Param("f_start_date") Date startDate,
			@Param("f_user_id") String updId,
			@Param("f_hangmog_code") String hangmogCode,
			@Param("f_input_part") String inputPart,
			@Param("f_input_gwa") String inputGwa,
			@Param("f_hangmog_start_date") Date hangmogStartDate);
}

