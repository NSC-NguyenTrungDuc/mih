package nta.med.data.dao.medi.ocs;

import java.util.Date;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.ocs.Ocs6015;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs6015Repository extends JpaRepository<Ocs6015, Long>, Ocs6015RepositoryCustom {
	
	@Modifying
	@Query("	UPDATE Ocs6015"
			+ " SET updId             = :f_user_id    ,       "
			+ "     updDate           = SYSDATE()     ,       "
			+ "     jaewonil          = :f_jaewonil   ,       "
			+ "     planFromDate      = :f_order_date ,       "
			+ "     planToDate        = :f_order_date ,       "
			+ "     inputGubun        = :f_input_gubun,       "
			+ "     pkSeq             = :f_pk_seq		      "
			+ " WHERE hospCode        = :f_hosp_code	      "
			+ "   AND fkocs6010       = :f_fkocs6010	      "
			+ "   AND inputGubun      = :f_origin_input_gubun "
			+ "   AND planFromDate    = :f_origin_order_date  "
			+ "   AND pkSeq           = :f_pk				  ")
	public Integer updateOcs6015InOCS6010U10Case01(
			@Param("f_user_id") 	String userId,
			@Param("f_jaewonil") 	Double jaewonil,
			@Param("f_order_date") 	Date orderDate,
			@Param("f_input_gubun") String inputGubun,
			@Param("f_pk_seq") 		Double pkSeq,
			@Param("f_hosp_code") 	String hospCode,
			@Param("f_fkocs6010") 	Double fkocs6010,
			@Param("f_origin_input_gubun") 	String originInputGubun,
			@Param("f_origin_order_date") 	Date originOrderDate,
			@Param("f_pk") 					Double pk);
	
	
	@Modifying
	@Query("	DELETE FROM Ocs6015				  "
			+ " WHERE hospCode   = :f_hosp_code	  "
			+ "   AND fkocs6010   = :f_fkocs6010  "
			+ "   AND jaewonil    = :f_jaewonil	  "
			+ "   AND inputGubun = :f_input_gubun "
			+ "   AND pkSeq      = :f_pk		  ")
	public Integer deleteOcs6015InOCS6010U10(
			@Param("f_hosp_code") 	String hospCode,
			@Param("f_fkocs6010") 	Double fkocs6010,
			@Param("f_jaewonil") 	Double jaewonil,
			@Param("f_input_gubun") String inputGubun,
			@Param("f_pk") 			Double pkSeq);
}
