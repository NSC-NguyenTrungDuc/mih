package nta.mss.repository;

import nta.mss.entity.Session;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

/**
 * The Interface SessionRepository.
 * 
 * @author DinhNX
 * @CrtDate Jul 23, 2014
 */
@Repository
public interface SessionRepository extends JpaRepository<Session, String>{
}
