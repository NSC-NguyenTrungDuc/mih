package nta.med.data.dao.medi.drg;

import java.util.Date;

import nta.med.core.domain.drg.DrgAtc;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * @author dainguyen.
 */
@Repository
public interface DrgAtcRepository extends JpaRepository<DrgAtc, Long>, DrgAtcRepositoryCustom {
	
	@Query(" SELECT MAX(SEQ) + 1 FROM DrgAtc WHERE hospCode = :hospCode AND jubsuDate = :jubsuDate AND drgBunho = :drgBunho AND inOutGubun = :inOutGubun ")
	public String getDrgsDRG5100P01MaxSeq(@Param("hospCode") String hospCode,
			@Param("jubsuDate") Date jubsuDate,
			@Param("drgBunho") Double drgBunho,
			@Param("inOutGubun") String inOutGubun);
	
}

