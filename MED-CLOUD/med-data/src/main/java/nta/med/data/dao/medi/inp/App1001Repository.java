package nta.med.data.dao.medi.inp;

import java.math.BigDecimal;
import java.util.Date;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.inp.App1001;

@Repository
public interface App1001Repository extends JpaRepository<App1001, Long>, App1001RepositoryCustom {
	@Modifying
	@Query("UPDATE App1001 									"
			+ "SET updId = :f_user_id,						"
			+ " updDate = SYSDATE(),		    				"
			+ " insteadYn = :f_insteadYn,		    		"
			+ " insteadId = :f_insteadId,		    		"
			+ " insteadDate = :f_insteadDate,		    	"
			+ " insteadTime = :f_insteadTime,		    	"
			+ " approveYn = :f_approveYn,		    		"
			+ " approveId = :f_approveId,		    		"
			+ " approveDate = :f_approveDate,		    	"
			+ " approveTime = :f_approveTime,		    	"
			+ " postapproveYn = :f_postapproveYn,		    "
			+ " sangStartDate = :f_sangStartDate,		    "
			+ " sangEndDate = :f_sangEndDate,		    	"
			+ " sangEndSayu = :f_sangEndSayu,		    	"
			+ " sangJindanDate = :f_sangJindanDate,		    "
			+ " juSangYn = :f_juSangYn,		    			"
			+ " preModifier1 = :f_preModifier1,		    	"
			+ " preModifier2 = :f_preModifier2,		    	"
			+ " preModifier3 = :f_preModifier3,		    	"
			+ " preModifier4 = :f_preModifier4,		    	"
			+ " preModifier5 = :f_preModifier5,		    	"
			+ " preModifier6 = :f_preModifier6,		    	"
			+ " preModifier7 = :f_preModifier7,		    	"
			+ " preModifier8 = :f_preModifier8,		    	"
			+ " preModifier9 = :f_preModifier9,		    	"
			+ " preModifier10 = :f_preModifier10,		    "
			+ " preModifierName = :f_preModifierName,		"
			+ " postModifier1 = :f_postModifier1,		    	"
			+ " postModifier2 = :f_postModifier2,		    	"
			+ " postModifier3 = :f_postModifier3,		    	"
			+ " postModifier4 = :f_postModifier4,		    	"
			+ " postModifier5 = :f_postModifier5,		    	"
			+ " postModifier6 = :f_postModifier6,		    	"
			+ " postModifier7 = :f_postModifier7,		    	"
			+ " postModifier8 = :f_postModifier8,		    	"
			+ " postModifier9 = :f_postModifier9,		    	"
			+ " postModifier10 = :f_postModifier10,		    	"
			+ " postModifierName = :f_postModifierName	    	"
			+ "WHERE hospCode = :f_hosp_code          		"
			+ "AND pkapp1001 = :f_pkapp1001 		    	")
	public Integer updateApp1001(@Param("f_user_id") String updId,
			@Param("f_insteadYn") String insteadYn,
			@Param("f_insteadId") String insteadId,
			@Param("f_insteadDate") Date insteadDate,
			@Param("f_insteadTime") String insteadTime,
			@Param("f_approveYn") String approveYn,
			@Param("f_approveId") String approveId,
			@Param("f_approveDate") Date approveDate,
			@Param("f_approveTime") String approveTime,
			@Param("f_postapproveYn") String postapproveYn,
			@Param("f_sangStartDate") Date sangStartDate,
			@Param("f_sangEndDate") Date sangEndDate,
			@Param("f_sangEndSayu") String sangEndSayu,
			@Param("f_sangJindanDate") Date sangJindanDate,
			@Param("f_juSangYn") String juSangYn,
			@Param("f_preModifier1") String preModifier1,
			@Param("f_preModifier2") String preModifier2,
			@Param("f_preModifier3") String preModifier3,
			@Param("f_preModifier4") String preModifier4,
			@Param("f_preModifier5") String preModifier5,
			@Param("f_preModifier6") String preModifier6,
			@Param("f_preModifier7") String preModifier7,
			@Param("f_preModifier8") String preModifier8,
			@Param("f_preModifier9") String preModifier9,
			@Param("f_preModifier10") String preModifier10,
			@Param("f_preModifierName") String preModifierName,
			@Param("f_postModifier1") String postModifier1,
			@Param("f_postModifier2") String postModifier2,
			@Param("f_postModifier3") String postModifier3,
			@Param("f_postModifier4") String postModifier4,
			@Param("f_postModifier5") String postModifier5,
			@Param("f_postModifier6") String postModifier6,
			@Param("f_postModifier7") String postModifier7,
			@Param("f_postModifier8") String postModifier8,
			@Param("f_postModifier9") String postModifier9,
			@Param("f_postModifier10") String postModifier10,			
			@Param("f_postModifierName") String postModifierName,			
			@Param("f_hosp_code") String hospCode,
			@Param("f_pkapp1001") Double pkapp1001);
	
	@Modifying
	@Query(" DELETE App1001 								"
			+ "WHERE hospCode = :f_hosp_code          		"
			+ "AND pkapp1001 = :f_pkapp1001 		    	")
	public Integer deleteApp1001(@Param("f_hosp_code") String hospCode,
			@Param("f_pkapp1001") Double pkapp1001);
}
