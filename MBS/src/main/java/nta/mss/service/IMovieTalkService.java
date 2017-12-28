package nta.mss.service;

import java.util.List;

import nta.mss.entity.MovieTalkHistory;
import nta.mss.entity.MtHistory;
import nta.mss.model.MtHistoryModel;

/**
 * 
 * @author TungLT
 * IMovieTalkService
 */
public interface IMovieTalkService {
	
	public List<MovieTalkHistory> getListMovieTalkHistory(Integer hospId, String cardNumber,Integer startIndex, Integer pageSize,String columnSort, String typeOrder);
	public Integer getTotalRecordMovieTalkHistoryByHospIdAndPatientId(Integer hospId, String cardNumber);
	public Integer deleteRecordMovieTalkHistoryById(Integer mtHistoryId);
	public boolean insertRecordMovieTalkHistoryById(MtHistoryModel mtHistory);
	
}
