package nta.med.data.dao.phr;

import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.phr.PhrStandardHealth;

public interface StandardHealthRepository extends JpaRepository<PhrStandardHealth, Long>{
	
	@Query("select H from PhrStandardHealth H where H.profileId = :profileId and H.activeFlg = 1 order by H.datetimeRecord desc")
	public List<PhrStandardHealth> getHealthByProfileId(@Param("profileId") Long profileId);
	
	@Query("select H from PhrStandardHealth H where H.profileId = :profileId and H.activeFlg = 1 order by H.datetimeRecord desc")
	public List<PhrStandardHealth> getHealthByProfileId(@Param("profileId") Long profileId, Pageable pageable);
	
	@Query("select H from PhrStandardHealth H where H.id = :healthId and H.profileId = :profileId and H.activeFlg = 1")
	public PhrStandardHealth getHealthByProfileId(@Param("healthId") Long healthId, @Param("profileId") Long profileId);

	@Modifying
	@Query("UPDATE PhrStandardHealth SET activeFlg = :activeFlg WHERE id = :healthId and profileId =:profileId")
	public Integer updateActiveFlg(@Param("healthId") Long healthId, @Param("profileId") Long profileId, @Param("activeFlg") Integer activeFlg);
}
