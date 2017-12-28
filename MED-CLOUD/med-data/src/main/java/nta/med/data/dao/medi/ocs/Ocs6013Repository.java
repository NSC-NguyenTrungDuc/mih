package nta.med.data.dao.medi.ocs;

import nta.med.core.domain.ocs.Ocs6013;

import java.util.Date;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Ocs6013Repository extends JpaRepository<Ocs6013, Long>, Ocs6013RepositoryCustom {
	
	@Modifying
	@Query("	UPDATE Ocs6013"
			+ " SET updId           = :f_user_id          , "
			+ "     updDate         = SYSDATE()           , "
			+ "     jaewonil        = :f_jaewonil         , "
			+ "     planOrderDate   = :f_order_date       , "
			+ "     inputGubun      = :f_input_gubun      , "
			+ "     groupSer        = :f_group_ser			"
			+ " WHERE hospCode      = :f_hosp_code			"
			+ "   AND pkocs6013     = :f_pk					")
	public Integer updateOcs6013InOcs6010U01(
			@Param("f_hosp_code") String hospCode,
			@Param("f_pk") Double pkocs6013,
			@Param("f_user_id") String userId,
			@Param("f_jaewonil") Double jaewonil,
			@Param("f_order_date") Date orderDate,
			@Param("f_input_gubun") String inputGubun,
			@Param("f_group_ser") Double groupSer);
	
	@Query(" SELECT T FROM Ocs6013 T WHERE hospCode = :f_hosp_code AND pkocs6013 = :f_pkocs6013 ")
	public List<Ocs6013> findByHospCodePkocs6013(@Param("f_hosp_code") String hospCode, @Param("f_pkocs6013") Double pkocs6013);
	
	@Modifying
	@Query("DELETE FROM Ocs6013 WHERE hospCode = :hospCode AND pkocs6013 = :pkocs6013 ")
	public Integer deleteByHospCodePkocs6013(@Param("hospCode") String hospCode,
											 @Param("pkocs6013") Double pkocs6013);
}
