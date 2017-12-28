package nta.med.data.dao.phr;

import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import nta.med.core.domain.phr.PhrBabySleep;

public interface BabySleepRepository extends JpaRepository<PhrBabySleep, Long>, BabySleepRepositoryCustom {
	
	@Query("select H from PhrBabySleep H where H.profileId = :profileId and H.activeFlg = 1 order by H.timeStartSleep desc")
	public List<PhrBabySleep> getListBabySleepByProfileId(@Param("profileId") Long profileId, Pageable pageable);
	
	@Query("select H from PhrBabySleep H where H.id = :babySleepId and H.profileId = :profileId and H.activeFlg = 1")
	public PhrBabySleep getBabySleepByProfileId(@Param("babySleepId") Long babySleepId, @Param("profileId") Long profileId);

	@Modifying
	@Query("UPDATE PhrBabySleep SET activeFlg = :activeFlg WHERE id = :babySleepId and profileId =:profileId")
	public Integer updateActiveFlg(@Param("babySleepId") Long babySleepId, @Param("profileId") Long profileId, @Param("activeFlg") Integer activeFlg);
}
