package nta.med.data.dao.medi.nur;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.nur.Nur1094;

@Repository
public interface Nur1094Repository extends JpaRepository<Nur1094, Long>, Nur1094RepositoryCustom {

	@Modifying
	@Query(	  " UPDATE Nur1094       A               "
			+ "  SET A.updId        = :f_user_id     "
			+ "    , A.updDate      = SYSDATE()      "
			+ "    , A.inputId      = :f_input_id    "
			+ "    , A.sumScore     = :f_sum_score   "
			+ "    , A.levelScore   = :f_level_score "
			+ "    , A.remark       = :f_remark      "
			+ " WHERE A.hospCode    = :f_hosp_code   "
			+ "  AND A.pknur1094    = :f_pknur1094   ")
	public Integer updateByHospCodePknur1094(
			@Param("f_user_id") String updId     ,
			@Param("f_input_id") String inputId   ,
			@Param("f_sum_score") Double sumScore  ,
			@Param("f_level_score") String levelScore,
			@Param("f_remark") String remark    ,
			@Param("f_hosp_code") String hospCode  ,
			@Param("f_pknur1094") Double pknur1094);
	
	@Modifying
	@Query(	  " DELETE Nur1094					   "
			+ " WHERE hospCode    = :f_hosp_code   "
			+ "  AND pknur1094    = :f_pknur1094   ")
	public Integer deleteByHospCodePknur1094(@Param("f_hosp_code") String hospCode,
			@Param("f_pknur1094") Double pknur1094);
	
}
