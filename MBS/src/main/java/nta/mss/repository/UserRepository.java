package nta.mss.repository;

import java.util.List;

import nta.mss.entity.User;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

/**
 * The Interface SysUserRepository.
 *
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
@Repository
public interface UserRepository extends JpaRepository<User, Integer>{

	@Query("Select u from User u where u.email = :email and u.hospital.hospitalId = :hospitalId and u.activeFlg = 1")
	List<User> findByEmail(@Param("email") String email, @Param("hospitalId") Integer hospitalId);

	@Query("Select u from User u where u.email = :email and u.hospital.hospitalId = :hospitalId and u.activeFlg = 1 And u.loginId is null ")
	List<User> findByEmailAndLoginIdIsNull(@Param("email") String email, @Param("hospitalId") Integer hospitalId);

	@Query("Select u from User u where u.loginId = :loginId and u.hospital.hospitalId = :hospitalId and u.activeFlg = 1 ")
	List<User> findByLoginId(@Param("loginId") String loginId, @Param("hospitalId") Integer hospitalId);

	@Query("Select u from User u where u.loginId = :loginId and u.userStatus = :userStatus and u.hospital.hospitalId = :hospitalId and u.activeFlg = :activeFlg")
	List<User> findByLoginIdAndStatus (@Param("loginId") String loginId, @Param("userStatus") Integer userStatus, @Param("hospitalId") Integer hospitalId, @Param("activeFlg") Integer activeFlg);

	@Query("Select u from User u where u.email = :email and u.userStatus = :userStatus and u.hospital.hospitalId = :hospitalId and u.activeFlg = 1 ")
	List<User> findByEmailAndStatus (@Param("email") String email, @Param("userStatus") Integer userStatus, @Param("hospitalId") Integer hospitalId);

	@Query("Select u from User u where u.email = :email and u.userStatus = :userStatus and u.hospital.hospitalId = :hospitalId and u.activeFlg = 1  and u.loginId is null")
	List<User> findByEmailAndStatusAndLoginId (@Param("email") String email, @Param("userStatus") Integer userStatus, @Param("hospitalId") Integer hospitalIdd);

	@Query("Select u from User u where u.activeFlg = 1")
	List<User> getAllUser();

	@Query("Select u from User u where u.activeFlg = 1 and u.hospital.hospitalCode = :hospitalCode")
	List<User> getAllUserByHospitalCode(@Param("hospitalCode") String hospitalCode);

	@Query("SELECT u FROM User u, UserChild uc WHERE u.userId = uc.user.userId AND u.userId = :userId AND u.activeFlg = 1 AND uc.user.activeFlg = 1")
	public User findUserById(@Param("userId") Integer userId);

	@Query("SELECT u FROM User u WHERE u.activeFlg = 1 AND u.tokenId = :tokenId")
	public User findUserByToken(@Param("tokenId") String tokenId);


}
