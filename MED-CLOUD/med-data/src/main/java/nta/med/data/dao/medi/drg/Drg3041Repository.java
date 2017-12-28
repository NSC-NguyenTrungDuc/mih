package nta.med.data.dao.medi.drg;

import java.util.Date;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.drg.Drg3041;

/**
 * @author dainguyen.
 */
@Repository
public interface Drg3041Repository extends JpaRepository<Drg3041, Long>, Drg3041RepositoryCustom {

	@Modifying
	@Query("DELETE FROM Drg3041 WHERE hospCode = :hospCode AND jubsuDate = :jubsuDate AND drgBunho = :drgBunho")
	public Integer deleteByHospCodeJubsuDateDrgBunho(@Param("hospCode") String hospCode,
			@Param("jubsuDate") Date jubsuDate, @Param("drgBunho") Double drgBunho);
	
}
