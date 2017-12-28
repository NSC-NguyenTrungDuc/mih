package nta.med.data.dao.emr;

import java.math.BigDecimal;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.emr.EmrTag;

public interface EmrTagRepository  extends JpaRepository<EmrTag, Long>, EmrTagRepositoryCustom {
	
	@Modifying
	@Query("	UPDATE EmrTag       "
			+ " set tagCode = :f_tag_code	"
			+ " , tagName = :f_tag_name		"
			+ " , tagDisplayText = :f_tag_display_text		"
			+ " , description = :f_description    		"
			+ " , filterFlg = :f_filter_flag				"
			+ " Where emrTagId = :f_tag_id				")
	public Integer updateEmrTagRootInfo (
			@Param("f_tag_code") String tagCode,
			@Param("f_tag_name") String tagName,
			@Param("f_tag_display_text") String tagDisplayText,
			@Param("f_description") String description,
			@Param("f_filter_flag") BigDecimal filterFlg,
			@Param("f_tag_id") Integer emrTagId
			);

	@Modifying
	@Query("	UPDATE EmrTag       "
			+ " set tagCode = :f_tag_code	"
			+ " , tagName = :f_tag_name		"
			+ " , tagDisplayText = :f_tag_display_text		"
			+ " , description = :f_description    		"
			+ " , filterFlg = :f_filter_flag				"
			+ " , tagParent = :f_tag_parent				"
			+ " Where emrTagId = :f_tag_id				")
	public Integer updateEmrTagNodeInfo (
			@Param("f_tag_code") String tagCode,
			@Param("f_tag_name") String tagName,
			@Param("f_tag_display_text") String tagDisplayText,
			@Param("f_description") String description,
			@Param("f_filter_flag") BigDecimal filterFlg,
			@Param("f_tag_parent") String tagParent,
			@Param("f_tag_id") Integer emrTagId
	);
	
	@Modifying
	@Query("	UPDATE EmrTag       "
			+ " set updId = :f_udp_id	"
			+ " , activeFlg = '0'		"
			+ " where emrTagId = :f_tag_id		")
	public Integer updateEmrTagRemoveATag (
			@Param("f_udp_id") String updId,
			@Param("f_tag_id") Integer emrTagId
			);
	
	
	@Modifying
	@Query("	UPDATE EmrTag      				            "
		 + "    set tagCode = :f_tag_code	                "
		 + "    , tagName = :f_tag_name		                "
		 + "    , tagDisplayText = :f_tag_display_text		"
		 + "    , description = :f_description    		    "
		 + "    , filterFlg = :f_filter_flag				"
		 + "    , tagParent = :f_tag_parent				    "
		 + "    , tagLevel = :f_tag_level 					"
		 + "    Where emrTagId = :f_tag_id				   ")
	public Integer updateEmrTagNodeInfo (
			@Param("f_tag_code") String tagCode,
			@Param("f_tag_name") String tagName,
			@Param("f_tag_display_text") String tagDisplayText,
			@Param("f_description") String description,
			@Param("f_filter_flag") BigDecimal filterFlg,
			@Param("f_tag_parent") String tagParent,
			@Param("f_tag_level") String tagLevel,
			@Param("f_tag_id") Integer emrTagId
			);
	
	@Query("SELECT E FROM EmrTag  E WHERE E.hospCode = :hospCode AND E.activeFlg = 1") 
	List<EmrTag> getByActiveHospital(
			@Param("hospCode") String hospCode);
}
