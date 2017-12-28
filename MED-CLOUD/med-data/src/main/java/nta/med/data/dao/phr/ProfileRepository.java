package nta.med.data.dao.phr;

import java.math.BigDecimal;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.phr.PhrAccount;
import nta.med.core.domain.phr.PhrProfile;


@Repository
public interface ProfileRepository extends JpaRepository<PhrProfile, Long> , ProfileRepositoryCustom{

	@Query("select profile from PhrProfile profile where profile.account.id = :accountId and profile.activeFlg = 1 order by profile.id asc")
	public List<PhrProfile> getByAccountId(@Param("accountId") Long accountId);
	
	@Query("select profile from PhrProfile profile where profile.account.id = :accountId and profile.activeFlg = 1 and profile.babyFlg = :babyFlg order by profile.id asc")
	public List<PhrProfile> getByAccountIdAndBabyFlag(@Param("accountId") Long accountId,@Param("babyFlg") BigDecimal babyFlg);
	
	@Query("select profile from PhrProfile profile where profile.account.id = :accountId and profile.activeFlg = 1 and profile.activeProfileFlg =1 ")
	public List<PhrProfile> getProfilesByAccountIdAndActiveProfiles(@Param("accountId") Long accountId);

	@Query("select profile.id from PhrProfile profile where profile.account.id = :accountId and profile.activeFlg = 1 order by profile.id asc")
	public List<Long> getProfileIds(@Param("accountId") Long accountId);
	
	@Query("select a from PhrProfile a where a.account.id = :accountId and a.babyFlg = :babyFlg and a.activeFlg = 1 ")
	public List<PhrProfile> getProfileByToken(@Param("accountId") Long accountId, @Param("babyFlg") BigDecimal babyFlg);
	
	@Query("select P from PhrProfile P where P.id = :profileId and P.babyFlg = :babyFlg and  P.activeFlg = 1 ")
	public PhrProfile getProfileByProfileIdAndBabyFlgAndActiveProfileFlg(@Param("profileId") Long profileId, @Param("babyFlg") BigDecimal babyFlg);
	
	public PhrProfile findByIdAndActiveFlg(Long Id, Integer activeFlg);
	
	@Modifying
	@Query("UPDATE PhrProfile SET activeFlg = :activeFlg WHERE id = :profileId")
	public Integer updateActiveFlg(@Param("profileId") Long profileId, @Param("activeFlg") Integer activeFlg);

	@Modifying
	@Query("UPDATE PhrProfile profile SET syncFlg = 0 where profile.account.id = :accountId and profile.activeFlg = :activeFlg")
	public Integer updateSyncFlgFromAccountId(@Param("accountId") Long accountId, @Param("activeFlg") Integer activeFlg);

	public List<PhrProfile> findByAccountAndBabyFlg(PhrAccount account, BigDecimal bABY_FLG_INACTIVE);
	
	@Query("select profile from PhrProfile profile where profile.account.id = :accountId and profile.activeFlg = 1 and profile.babyFlg = :babyFlg and profile.activeProfileFlg = 1 order by profile.id asc")
	public List<PhrProfile> getActiveProfileByAccountIdAndBabyFlag(@Param("accountId") Long accountId,@Param("babyFlg") BigDecimal babyFlg);
	
	@Query("select profile from PhrProfile profile where profile.account.id = :accountId and profile.activeFlg = 1 and profile.familyMemberType = :familyMemberType  order by profile.id asc")
	public List<PhrProfile> getActiveProfileByAccountIdAndFamilyMemberType(@Param("accountId") Long accountId,@Param("familyMemberType") String familyMemberType);

	public List<PhrProfile> findByActiveProfileFlgAndBabyFlgAndUdid(BigDecimal activeProfileFlg, BigDecimal babyFlg, String udid);

}
