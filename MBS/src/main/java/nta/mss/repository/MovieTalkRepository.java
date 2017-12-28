package nta.mss.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import nta.mss.entity.MtHistory;
import nta.mss.model.MtHistoryModel;

/**
 * 
 * @author TungLT
 * MovieTalkRepository
 * 
 */
@Repository
public interface MovieTalkRepository extends JpaRepository<MtHistory, Integer>,  MovieTalkRepositoryCustom{	
	

}
