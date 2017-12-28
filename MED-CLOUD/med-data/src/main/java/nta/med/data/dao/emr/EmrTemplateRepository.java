package nta.med.data.dao.emr;

import nta.med.core.domain.emr.EmrTemplate;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

public interface EmrTemplateRepository  extends JpaRepository<EmrTemplate, Long>, EmrTemplateRepositoryCustom {
	
	@Modifying						    
	@Query("	UPDATE EmrTemplate 		      					    "
		 + "	    SET emrTemplateTypeId = :f_template_type_id     "
		 + "	    , description = :f_description		          	"
		 + "	    , templateName = :f_template_name          		"
		 + "	    , templateCode = :f_template_code               "
		 + "	    , defaultFlg = :f_default_flg                   "
		 + "	    , updId = :f_user_id     						"
		 + "	 WHERE emrTemplateId = :f_template_id          		")
	public Integer updateEmrTemplateUpdateTagListTemplate (
			@Param("f_template_type_id") Integer templateTypeId,
			@Param("f_description") String description,
			@Param("f_template_name") String templateName,
			@Param("f_template_code") String templateCode,
			@Param("f_default_flg") String defaultFlg,
			@Param("f_user_id") String updId,
			@Param("f_template_id") Integer templateId
			);
	
	@Modifying						    
	@Query("	UPDATE EmrTemplate       				   "
			+ "	SET activeFlg = '0'          			   "
			+ "	, updId = :f_udp_id          			   "
			+ "	WHERE emrTemplateId = :f_template_id       ")
	public Integer updateEmrTemplateRemoveTemplate (
			@Param("f_udp_id") String updId,
			@Param("f_template_id") Integer templateId
			);
	
	@Query(" select count(*) from EmrTemplate where templateCode = :templateCode and activeFlg = 1 and hosp_code = :hospCode and sabun = :sabun and gwa = :gwa and permissionType = :permissionType")
	public Integer checkIfExistsOCS2015U31EmrTemplate(@Param("templateCode") String templateCode, 
			@Param("hospCode") String hospCode, 
			@Param("sabun") String sabun, 
			@Param("gwa") String gwa,
			@Param("permissionType") String permissionType);
	
	@Query(" select T from EmrTemplate T where hosp_code = :hospCode and templateCode = :templateCode and activeFlg = 1 and sabun = :sabun and permissionType = :permissionType")
	public List<EmrTemplate> findByTemplateCodeUserId(@Param("templateCode") String templateCode, 
			@Param("hospCode") String hospCode, 
			@Param("sabun") String sabun, 
			@Param("permissionType") String permissionType);

	@Query(" select T from EmrTemplate T where hosp_code = :hospCode and emrTemplateId = :emrTemplateId and activeFlg = 1 ")
	public EmrTemplate findByIdHospCode(@Param("emrTemplateId") Integer emrTemplateId, @Param("hospCode") String hospCode);
}
