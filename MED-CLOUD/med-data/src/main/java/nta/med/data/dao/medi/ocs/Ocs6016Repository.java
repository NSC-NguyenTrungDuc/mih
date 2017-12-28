package nta.med.data.dao.medi.ocs;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.ocs.Ocs6016;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs6016Repository extends JpaRepository<Ocs6016, Long>, Ocs6016RepositoryCustom {
	
	@Modifying
	@Query("	DELETE FROM Ocs6015				   "
			+ " WHERE hospCode    = :f_hosp_code   "
			+ "   AND fkocs6010   = :f_fkocs6010   "
			+ "   AND jaewonil    = :f_jaewonil	   "
			+ "   AND inputGubun  = :f_input_gubun "
			+ "   AND pkSeq       = :f_pk		   ")
	public Integer deleteOcs6016InOCS6010U10(
			@Param("f_hosp_code") 	String hospCode,
			@Param("f_fkocs6010") 	Double fkocs6010,
			@Param("f_jaewonil") 	Double jaewonil,
			@Param("f_input_gubun") String inputGubun,
			@Param("f_pk") 			Double pkSeq);
	
}

