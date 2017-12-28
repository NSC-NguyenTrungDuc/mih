package nta.med.data.dao.medi.doc;

import java.util.List;

import nta.med.core.domain.doc.Doc4003;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface Doc4003Repository extends JpaRepository<Doc4003, Long>, Doc4003RepositoryCustom {
	@Modifying
	@Query("DELETE FROM Doc4003 WHERE hospCode = :hospCode AND pkdoc4003 = :pkdoc4003")
	public Integer deleteDoc4003ByPkdoc4003(@Param("hospCode") String hospCode, @Param("pkdoc4003") String pkdoc4003);
	
	@Query("SELECT IFNULL(MAX(seq), 1)+1 FROM Doc4003 WHERE hospCode = :hospCode AND bunho = :bunho")
	public String getMaxSeqByHospCodeAndBunho(@Param("hospCode") String hospCode, @Param("bunho") String bunho);
	
	public List<Doc4003> findByHospCodeAndBunhoAndPkdoc4003(@Param("hospCode") String hospCode, @Param("bunho") String bunho, @Param("pkdoc4003") Double pkdoc4003 );
	
	public List<Doc4003> findByHospCodeAndPkdoc4003(@Param("hospCode") String hospCode,  @Param("pkdoc4003") Double pkdoc4003);
	
	
}

