package nta.med.data.dao.mss;

import nta.med.core.domain.mss.MailTemplate;
import nta.med.core.domain.mss.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;

import java.util.List;

/**
 * @author DEV-TiepNM
 */
public interface UserRepository extends JpaRepository<User, Integer>  {
    @Query("Select u from User u where u.email = :email and  u.activeFlg = 1")
    List<User> findByEmail(@Param("email") String email) ;
   
    @Query("Select u from User u where u.email = :email and u.loginId = :loginId and u.hospitalId = :hospitalId and  u.activeFlg = 1 ")
    List<User> findByEmailAndFacebookIdAndHospId(@Param("email") String email , @Param("loginId") String loginId, @Param("hospitalId") Integer hospitalId) ;
   
    @Query("Select u from User u where u.email = :email and u.loginId is null and u.hospitalId = :hospitalId and  u.activeFlg = 1 ")
    List<User> findByEmailAndFacebookIdEmptyAndHospId(@Param("email") String email , @Param("hospitalId") Integer hospitalId) ;
   

    @Query("Select u from User u where u.email = :email and u.hospitalId = :hospitalId and u.activeFlg = 1")
    List<User> findByEmail(@Param("email") String email, @Param("hospitalId") Integer hospitalId);
}
