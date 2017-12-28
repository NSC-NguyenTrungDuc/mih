package nta.med.data.dao.medi.nut;

import nta.med.core.domain.nut.Nut0002;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Nut0002Repository extends JpaRepository<Nut0002, Long>, Nut0002RepositoryCustom {
	
	@Modifying
	@Query("	DELETE Nut0002  				"
		 + "	WHERE hospCode = :hospCode  "
		 + "	AND pknut0002 = :f_pknut0002     ")
	public Integer deleteNut0001U00Nut0002SaveLayout(
			@Param("hospCode") String hospCode,
			@Param("f_pknut0002") Double pknut0002);
}

