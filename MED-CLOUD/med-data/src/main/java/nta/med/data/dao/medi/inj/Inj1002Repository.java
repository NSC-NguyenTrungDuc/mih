package nta.med.data.dao.medi.inj;

import java.util.Date;
import java.util.List;

import nta.med.core.domain.inj.Inj1002;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Inj1002Repository extends JpaRepository<Inj1002, Long>, Inj1002RepositoryCustom {
	@Modifying
	@Query(  "		UPDATE Inj1002															   "	
			 +"		  SET reserDate               = STR_TO_DATE(:reserDate,'%Y/%m/%d')   		"
			 +"		WHERE hospCode                = :hospCode                              		"
			 +"		  AND pkinj1002               IN :pkinj1002                              	"
			 +"		  AND IFNULL(actingFlag, 'N')    = 'N'                                   ")
	public Integer updatReserDate(@Param("reserDate") String reserDate,
			@Param("hospCode") String hospCode,
			@Param("pkinj1002") List<Double> pkinj1002);
	
	@Modifying
	@Query(" UPDATE Inj1002 SET actingFlag = :actingFlag, "
			+ " actingDate =  :actingDate, "
			+ " jubsuDate =  :actingDate, "
			+ " actingTime =  :actingTime, "
			+ " actingJangso = 'IR', "
			+ " tonggyeCode = :tonggyeCode, "
			+ " mixGroup = :mixGroup, "
			+ " updId = IFNULL(:jujongja, :updId), "
			+ " updDate = :updDate, "
			+ " jujongja =  :jujongja, "
			+ " silsiRemark = :silsiRemark "
			+ " WHERE hospCode = :hospCode "
			+ " AND pkinj1002  = :pkinj1002 ")
	public Integer updateINJ1001U01(
			@Param("actingFlag") String actingFlag,
			@Param("actingDate") Date actingDate,
			@Param("actingTime") String actingTime,
			@Param("tonggyeCode") String tonggyeCode,
			@Param("mixGroup") String mixGroup,
			@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("jujongja") String jujongja,
			@Param("silsiRemark") String silsiRemark,			
			@Param("hospCode") String hospCode,
			@Param("pkinj1002") Double pkinj1002);
	
}

