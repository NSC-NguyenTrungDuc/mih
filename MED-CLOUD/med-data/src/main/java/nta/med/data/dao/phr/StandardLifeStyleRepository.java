package nta.med.data.dao.phr;

import java.math.BigInteger;
import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.phr.PhrStandardLifeStyle;

public interface StandardLifeStyleRepository extends JpaRepository<PhrStandardLifeStyle, Long>, StandardLifeStyleRepositoryCustom{
	
	@Query("select L from PhrStandardLifeStyle L where L.profileId = :profileId and L.activeFlg = 1 order by L.timeWakeUp desc")
	public List<PhrStandardLifeStyle> getTotalSleepTimeByProfileId(@Param("profileId") Long profileId);

	@Query("select L from PhrStandardLifeStyle L where L.profileId = :profileId and L.activeFlg = 1 order by L.timeStartSleep desc")
	public List<PhrStandardLifeStyle> getLimitStandardLifeStyle(@Param("profileId") Long profileId, Pageable pageable);

	@Query("select SUM(S.totalHourSleep) from PhrStandardLifeStyle S where S.profileId = :profileId and S.activeFlg = 1 and DATE_FORMAT(S.timeStartSleep, '%Y%m%d') = DATE_FORMAT(SYSDATE(), '%Y%m%d') ")
	public BigInteger getLastestTotalHoursSleepByProfileId(@Param("profileId") Long profileId);
}
