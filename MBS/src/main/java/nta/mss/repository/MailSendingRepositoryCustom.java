package nta.mss.repository;

import java.util.Date;
import java.util.List;

import nta.mss.info.MailSendingInfo;


/**
 *
 * @author DinhNX
 * @CrtDate Jul 29, 2014
 *
 */
public interface MailSendingRepositoryCustom {
	
	List<Object[]> searchMailListHistory(Integer mailListId, Date fromDate, Date toDate, String hospitalId);
	
	public List<MailSendingInfo> searchKcckInfoScheduleMailHistory(Integer hospId,Integer deptId, Date fromDate, Date toDate);
	
	
}
