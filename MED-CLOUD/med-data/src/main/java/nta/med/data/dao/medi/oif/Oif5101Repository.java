package nta.med.data.dao.medi.oif;

import nta.med.core.domain.oif.Oif5101;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Oif5101Repository extends JpaRepository<Oif5101, Long>, Oif5101RepositoryCustom {
	@Modifying
	@Query(" UPDATE Oif5101 A  SET A.docUid = :f_doc_id "
			+ "  WHERE A.hospCode   = :f_hosp_code  "
			+ " AND A.fkoif1101   = :f_fkoif1101 "
			+ "  AND A.pkoif5101   = :pkoif5101 ")
	public Integer updateOIF5101ByFkoif1101AndPkoif5101(@Param("f_hosp_code") String hospCode,
			@Param("f_doc_id") String docUid,
			@Param("f_fkoif1101") Double fkoif1101,
			@Param("pkoif5101") Double pkoif5101);
}

