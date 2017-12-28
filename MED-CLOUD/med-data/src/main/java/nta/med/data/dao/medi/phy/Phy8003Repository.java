package nta.med.data.dao.medi.phy;

import nta.med.core.domain.phy.Phy8003;
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
public interface Phy8003Repository extends JpaRepository<Phy8003, Long>, Phy8003RepositoryCustom {
	
	@Query("SELECT COUNT(*) FROM Phy8003 WHERE hospCode = :hospCode AND fkoutsang = :fkoutsang AND dataKubun != 'D'")
	public String getOcsoOCS1003P01CheckUsedSang(@Param("hospCode") String hospCode,
			@Param("fkoutsang") Double fkoutsang);
	
	
	@Query("SELECT a FROM Phy8003 a WHERE hospCode = :hospCode AND kanjaNo = :kanjaNo AND fkOcsIrai = :fkOcsIrai ")
	public List<Phy8003> getByKanjaNoAndFkOcsIrai(@Param("hospCode") String hospCode,
			@Param("kanjaNo") String kanjaNo,
			@Param("fkOcsIrai") Double fkOcsIrai);
	
	@Modifying
	@Query("	 UPDATE Phy8003 									"								
			+"	  SET  userId 		    = :userId 		            "
			+"	      , dataKubun         = :dataKubun              "
			+"	      , ioKubun           = :ioKubun                "
			+"	      , iraiDate          = :iraiDate               "
			+"	      , syoubyoumeiCode   = :syoubyoumeiCode        "
			+"	      , preModifier1      = :preModifier1           "
			+"	      , preModifier2      = :preModifier2           "
			+"	      , preModifier3      = :preModifier3           "
			+"	      , preModifier4      = :preModifier4           "
			+"	      , preModifier5      = :preModifier5           "
			+"	      , preModifier6      = :preModifier6           "
			+"	      , preModifier7      = :preModifier7           "
			+"	      , preModifier8      = :preModifier8           "
			+"	      , preModifier9      = :preModifier9           "
			+"	      , preModifier10     = :preModifier10          "
			+"	      , postModifier1     = :postModifier1          "
			+"	      , postModifier2     = :postModifier2          "
			+"	      , postModifier3     = :postModifier3          "
			+"	      , postModifier4     = :postModifier4          "
			+"	      , postModifier5     = :postModifier5          "
			+"	      , postModifier6     = :postModifier6          "
			+"	      , postModifier7     = :postModifier7          "
			+"	      , postModifier8     = :postModifier8          "
			+"	      , postModifier9     = :postModifier9          "
			+"	      , postModifier10    = :postModifier10         "
			+"	      , hassyoubi         = :hassyoubi              "
			+"	      , sindanbi          = :sindanbi               "
			+"	      , preModifierName   = :preModifierName        "
			+"	      , postModifierName  = :postModifierName       "
			+"	      , syoubyoumei       = :syoubyoumei            "
			+"	WHERE hospCode          = :hospCode                 "
			+"	  AND pkPhySyoubyou     = :pkPhySyoubyou            ")
	public Integer updatePhy8002U01Phy8003(
			@Param("userId") String userId,
			@Param("dataKubun") String dataKubun,
			@Param("ioKubun") String ioKubun,
			@Param("iraiDate") String iraiDate,
			@Param("syoubyoumeiCode") String syoubyoumeiCode,
			@Param("preModifier1") String preModifier1,
			@Param("preModifier2") String preModifier2,
			@Param("preModifier3") String preModifier3,
			@Param("preModifier4") String preModifier4,
			@Param("preModifier5") String preModifier5,
			@Param("preModifier6") String preModifier6,
			@Param("preModifier7") String preModifier7,
			@Param("preModifier8") String preModifier8,
			@Param("preModifier9") String preModifier9,
			@Param("preModifier10") String preModifier10,
			@Param("postModifier1") String postModifier1,
			@Param("postModifier2") String postModifier2,
			@Param("postModifier3") String postModifier3,
			@Param("postModifier4") String postModifier4,
			@Param("postModifier5") String postModifier5,
			@Param("postModifier6") String postModifier6,
			@Param("postModifier7") String postModifier7,
			@Param("postModifier8") String postModifier8,
			@Param("postModifier9") String postModifier9,
			@Param("postModifier10") String postModifier10,
			@Param("hassyoubi") String hassyoubi,
			@Param("sindanbi") String sindanbi,
			@Param("preModifierName") String preModifierName,
			@Param("postModifierName") String postModifierName,
			@Param("syoubyoumei") String syoubyoumei,
			@Param("hospCode") String hospCode,
			@Param("pkPhySyoubyou") String pkPhySyoubyou);
	
	@Modifying
	@Query("	DELETE Phy8003 					     "
           +"   WHERE pkPhySyoubyou =:pkPhySyoubyou  "
           +" 	AND hospCode   = :hospCode           ")
	public Integer deletePhy8002U01Phy8003(
			@Param("hospCode") String hospCode,
			@Param("pkPhySyoubyou") String pkPhySyoubyou);
}

