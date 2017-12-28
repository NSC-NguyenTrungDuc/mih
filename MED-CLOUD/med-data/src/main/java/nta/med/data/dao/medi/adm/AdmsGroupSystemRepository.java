package nta.med.data.dao.medi.adm;

import nta.med.core.domain.adm.AdmsGroupSystem;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface AdmsGroupSystemRepository extends JpaRepository<AdmsGroupSystem, Long>, AdmsGroupSystemRepositoryCustom {
	@Modifying	
	@Query("	UPDATE AdmsGroupSystem SET	      	     "
		 + "	    systemSeq = :systemSeq               "
		 + "	,selectFlg = :selectFlg               "
		+ "	WHERE hospCode =:hospCode and grpId = :grpId and systemId = :systemId    ")
	public Integer updateAdmsGroupSystemItem (
			@Param("systemSeq") Integer grpSeq,
			@Param("selectFlg") Integer selectFlg,
			@Param("hospCode") String hospCode,
			@Param("grpId") String grpId,
			@Param("systemId") String systemId
			);
}

