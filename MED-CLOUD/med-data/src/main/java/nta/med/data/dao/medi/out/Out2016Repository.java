package nta.med.data.dao.medi.out;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.out.Out2016;

@Repository
public interface Out2016Repository extends JpaRepository<Out2016, Long>, Out2016RepositoryCustom {
	@Modifying
	@Query("UPDATE Out2016 SET activeFlg = 0 WHERE hospCode = :f_hosp_code AND hospCodeLink = :hospCodeLink AND bunho = :bunho AND bunhoLink = :bunhoLink ")
	public Integer updateOCSACTOcs1003ChangeNurSeRemarkAndUpdId(@Param("f_hosp_code") String hospCode, 
			@Param("hospCodeLink") String hospCodeLink,
			@Param("bunho") String bunho,
			@Param("bunhoLink") String bunhoLink);

	@Modifying
	@Query("	 UPDATE Out2016								        "
			+"	   SET emrLinkFlg           = 1,   				 	"
			+"	       linkType           	= :linkType             "
			+"	 WHERE hospCode             = :hospCode             "
			+"	   AND bunho                = :bunho                "
			+"	   AND hospCodeLink         = :hospCodeLink        	"
			+"	   AND bunhoLink            = :bunhoLink AND activeFlg = 1")
	public int  updateExistingLinkOUT2016(@Param("linkType") String linkType, 
			@Param("hospCode") String hospCode, 
			@Param("bunho") String bunho,
			@Param("hospCodeLink") String hospCodeLink,
			@Param("bunhoLink") String bunhoLink);
	
	@Modifying
	@Query("	 UPDATE Out2016								        "
			+"	   SET activeFlg           = 0   				 	"
			+"	   , emrLinkFlg           = 0   				    "
			+"	   WHERE id                = :patientId             ")
	public int  deleteEMRLink(@Param("patientId") Long patientId );	
	
	@Modifying
	@Query("	 UPDATE Out2016								        "
			+"	   SET emrLinkFlg          = 1   				 	"
			+"	   WHERE id                = :patientId             ")
	public int  activeEMRLink(@Param("patientId") Long patientId );	
	
	@Modifying
	@Query("	 UPDATE Out2016								        "
			+"	   SET emrLinkFlg           = 0   				 	"
			+"	   WHERE id                = :patientId             ")
	public int  deactiveEMRLink(@Param("patientId") Long patientId );	
	
	@Query("SELECT o FROM Out2016 o WHERE o.id  = :patientId   ")
	public Out2016 getOut2016ById(@Param("patientId") Long patientId );	
	
}


