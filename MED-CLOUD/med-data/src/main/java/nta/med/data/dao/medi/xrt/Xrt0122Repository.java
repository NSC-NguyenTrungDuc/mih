package nta.med.data.dao.medi.xrt;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.xrt.Xrt0122;

/**
 * @author dainguyen.
 */
@Repository
public interface Xrt0122Repository extends JpaRepository<Xrt0122, Long>, Xrt0122RepositoryCustom {
	
	@Modifying
	@Query("	DELETE FROM Xrt0122						  "
		  +"	WHERE hospCode       = :hospCode      "
		  +"	  AND buwiBunryu     = :buwiBunryu    "
		  +"      AND language = :language")
	public Integer deleteXrt0121TransactionXrt0122(@Param("hospCode") String hospCode,
	@Param("buwiBunryu") String buwiBunryu,
	@Param("language") String language);
	
	@Modifying
	@Query("	DELETE FROM Xrt0122						  "
		  +"	WHERE hospCode       = :hospCode      "
		  +"	  AND buwiBunryu     = :buwiBunryu  AND buwiCode     = :buwiCode   "
		  +"      AND language = :language ")
	public Integer deleteXrt0121TransactionXrt0122Case2(@Param("hospCode") String hospCode,
	@Param("buwiBunryu") String buwiBunryu,@Param("buwiCode") String buwiCode,
	@Param("language") String language);
	
	@Modifying
	@Query("     UPDATE Xrt0122                         "
           +"      SET updId      = :updId              "
           +"      , updDate    = SYSDATE()             "
           +"      , buwiName   = :buwiName             "
           +"      , sortSeq    = IFNULL(:sortSeq,0)    "
           +"  WHERE hospCode   = :hospCode             "
           +"    AND buwiBunryu = :buwiBunryu           "
           +"    AND buwiCode   = :buwiCode             "
           +"    AND language = :language               ")
	public Integer updateXrt0121TransactionXrt0122(@Param("updId") String updId,
	@Param("buwiName") String buwiName,
	@Param("sortSeq") String sortSeq,
	@Param("hospCode") String hospCode,
	@Param("buwiBunryu") String buwiBunryu,
	@Param("buwiCode") String buwiCode,
	@Param("language") String language);
	
}

