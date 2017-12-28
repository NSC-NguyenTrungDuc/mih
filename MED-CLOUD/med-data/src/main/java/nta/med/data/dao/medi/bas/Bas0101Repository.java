package nta.med.data.dao.medi.bas;

import java.util.Date;

import nta.med.core.domain.bas.Bas0101;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Bas0101Repository extends JpaRepository<Bas0101, Long>, Bas0101RepositoryCustom {
	@Modifying
	@Query("	UPDATE Bas0101						    "
			+"	  SET updId         = :updId            "
			+"	    , updDate       = :updDate          "
			+"	    , codeTypeName = :codeTypeName      "
			+"	WHERE	codeType      = :codeType    AND language = :language   ")
	public Integer updateBas0101U00TransactionModified(
			@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("codeTypeName") String codeTypeName,
			@Param("codeType") String codeType,
			@Param("language") String language);
	
	@Modifying
	@Query("	DELETE FROM Bas0101			"
		  +"	WHERE codeType = :codeType AND language = :language   ")
	public Integer deleteBas0101U00TransactionDeleted(
			@Param("codeType") String codeType,
			@Param("language") String language);
	
	@Query("SELECT DISTINCT 'Y' FROM Bas0101 WHERE  codeType = :codeType AND language = :language ")
	public String checkExitsByCodeType(
			@Param("codeType") String codeType,
			@Param("language") String language);
	
	@Modifying
	@Query(  " UPDATE Bas0101						    "
			+"	  SET updId         = :updId            "
			+"	    , updDate       = :updDate          "
			+"	    , codeTypeName  = :codeTypeName     "
			+"	    , adminGubun    = :adminGubun       "
			+"	WHERE codeType      = :codeType   AND language = :language     " )
	public Integer updateBAS0101U04XSavePerformer(
			@Param("updId") String updId,
			@Param("updDate") Date updDate,
			@Param("codeTypeName") String codeTypeName,
			@Param("adminGubun") String adminGubun,
			@Param("codeType") String codeType,
			@Param("language") String language);
}

