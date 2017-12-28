package nta.mss.repository;

import java.util.List;

import nta.mss.entity.InsuranceHistory;
import nta.mss.entity.MovieTalkHistory;
import nta.mss.model.MtHistoryModel;

/**
 * 
 * @author TungLT
 * MovieTalkRepositoryCustom
 */
public interface MovieTalkRepositoryCustom {
	
	public List<MovieTalkHistory> getListMovieTalkHistory(Integer hospId, String cardNumber,Integer startIndex, Integer pageSize,String columnSort, String typeOrder);
		
	public Integer getTotalRecordMovieTalkHistoryByHospIdAndPatientId(Integer hospId, String cardNumber) ;
	
	public Integer deleteRecordMovieTalkHistoryById(Integer mtHistoryId);	
	

}
