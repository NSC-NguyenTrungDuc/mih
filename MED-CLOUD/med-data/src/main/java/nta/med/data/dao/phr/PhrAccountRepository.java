package nta.med.data.dao.phr;

import java.math.BigInteger;
import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import nta.med.core.domain.phr.PhrAccount;

@Repository
public interface PhrAccountRepository extends JpaRepository<PhrAccount, Long>, PhrAccountRepositoryCustom {

	@Query("select a from PhrAccount a where a.email = :f_email and a.password = :password and a.activeFlg = 1")
	public List<PhrAccount> getByEmailsAndPassword(@Param("f_email") String email, @Param("password") String password);
	
	@Modifying
	@Query("SELECT a FROM PhrAccount a WHERE email = :f_email and loginType = 0 ")
	public List<PhrAccount> getAccountByEmail(@Param("f_email") String email);

	@Query
	public List<PhrAccount> findByEmail(String email);
	
	public PhrAccount findByIdAndActiveFlg(Long Id, Integer activeFlg);
	
	@Query("select a from PhrAccount a where a.facebookId = :facebookId and a.activeFlg = 1 and a.status = 1 and a.loginType = 1")
	public List<PhrAccount> getAccountByFacebookId(@Param("facebookId") BigInteger facebookId);
	
	@Query("select a from PhrAccount a where a.id = :id and a.type = 0 ")
	public PhrAccount getAccountByIdAndType(@Param("id") Long id);
}
