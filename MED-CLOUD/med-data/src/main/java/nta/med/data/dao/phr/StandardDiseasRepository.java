package nta.med.data.dao.phr;

import java.math.BigInteger;
import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.phr.PhrStandardDiseas;

@Repository
public interface StandardDiseasRepository extends JpaRepository<PhrStandardDiseas, Long>, StandardDiseasRepositoryCustom{

	@Query("select T from PhrStandardDiseas T where T.profileId = :profileId and T.activeFlg = 1 order by T.datetimeRecord desc")
	public List<PhrStandardDiseas> getLimitStandardDiseas(@Param("profileId") Long profileId, Pageable pageable);
	
	@Query("select T from PhrStandardDiseas T where T.syncId = :syncId ")
	public List<PhrStandardDiseas> getStandardDiseasBySyncId(@Param("syncId") BigInteger syncId);
}
