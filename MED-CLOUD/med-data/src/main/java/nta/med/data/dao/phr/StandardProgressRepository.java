package nta.med.data.dao.phr;

import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.phr.PhrStandardProgress;

public interface StandardProgressRepository extends JpaRepository<PhrStandardProgress, Long>{
	
	@Query("select H from PhrStandardProgress H where H.profileId = :profileId and H.activeFlg = 1 order by H.datetimeRecord desc")
	public List<PhrStandardProgress> getListProgressByProfileId(@Param("profileId") Long profileId, Pageable pageable);
	
	@Query("select H from PhrStandardProgress H where H.id = :progressId and H.profileId = :profileId and H.activeFlg = 1")
	public PhrStandardProgress getProgressByProfileId(@Param("progressId") Long progressId, @Param("profileId") Long profileId);

	@Modifying
	@Query("UPDATE PhrStandardProgress SET activeFlg = :activeFlg WHERE id = :progressId and profileId =:profileId")
	public Integer updateActiveFlg(@Param("progressId") Long progressId, @Param("profileId") Long profileId, @Param("activeFlg") Integer activeFlg);
	
	
}
