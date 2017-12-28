package nta.med.data.dao.phr;

import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.phr.PhrBabyDiaper;

public interface BabyDiaperRepository extends JpaRepository<PhrBabyDiaper, Long>, BabyDiaperRepositoryCustom {
	
	@Query("select T from PhrBabyDiaper T where T.profileId = :profileId and T.activeFlg = 1 order by T.timePeePoo desc")
	public List<PhrBabyDiaper> getLimitBabyDiaper(@Param("profileId") Long profileId, Pageable pageable);
}
