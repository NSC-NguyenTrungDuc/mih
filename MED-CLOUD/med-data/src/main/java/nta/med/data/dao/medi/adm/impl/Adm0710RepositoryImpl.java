package nta.med.data.dao.medi.adm.impl;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import org.springframework.util.StringUtils;

import nta.med.core.infrastructure.mapper.JpaResultMapper;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm0710RepositoryCustom;
import nta.med.data.model.ihis.system.UdpHelperSendInfo;

/**
 * @author dainguyen.
 */
public class Adm0710RepositoryImpl implements Adm0710RepositoryCustom {
	@PersistenceContext
	private EntityManager entityManager;
	
	@Override
	public List<UdpHelperSendInfo> getUdpHelperSendInfoInfo(String hospCode, String senderId, Double sendSeq){
		StringBuilder sql = new StringBuilder();
		sql.append("SELECT A.SENDER_ID                                                        ");
		sql.append("     , A.MSG_TITLE                                                        ");
		sql.append("     , A.MSG_CONTENTS                                                     ");
		sql.append("     , B.RECVER_ID                                                        ");
		sql.append("     , A.SEND_SEQ, A.SEND_DT                                              ");
		sql.append("  FROM ADM0710 B                                                          ");
		sql.append("     , ADM0700 A                                                          ");
		sql.append(" WHERE A.HOSP_CODE = :f_hosp_code                                         ");
		sql.append("   AND A.SEND_DT = STR_TO_DATE(DATE_FORMAT(SYSDATE(),'%Y%m%d'),'%Y%m%d')  ");
		sql.append("   AND A.SENDER_ID = :f_sender_id                                         ");
		sql.append("   AND A.SEND_SEQ = :f_send_seq                                           ");
		sql.append("   AND B.HOSP_CODE = A.HOSP_CODE                                          ");
		sql.append("   AND B.SEND_DT = A.SEND_DT                                              ");
		sql.append("   AND B.SENDER_ID = A.SENDER_ID                                          ");
		sql.append("   AND B.SEND_SEQ = A.SEND_SEQ                                            ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_sender_id", senderId);
		query.setParameter("f_send_seq", sendSeq);
		
		List<UdpHelperSendInfo> list = new JpaResultMapper().list(query, UdpHelperSendInfo.class);
		return list;
	}

	@Override
	public String getOCS2003U99InsertAdm0710Request(String hospCode, String senderId, String sendSeq, String recvSpot,
			String receiveId) {
		StringBuilder sql = new StringBuilder();
		
		sql.append(" SELECT 'X'   						");
		sql.append("   FROM ADM0710 X 					");
		sql.append("  WHERE SEND_DT = DATE(SYSDATE())  	");
		sql.append("    AND HOSP_CODE = :f_hosp_code	");
		sql.append("    AND SENDER_ID = :f_user_id 		");
		sql.append("    AND SEND_SEQ  = :f_send_seq    	");
		sql.append("    AND RECV_SPOT = :f_recv_spot	");
		sql.append("    AND RECVER_ID = :f_reciever_id  ");
		
		Query query = entityManager.createNativeQuery(sql.toString());
		query.setParameter("f_hosp_code", hospCode);
		query.setParameter("f_user_id", senderId);
		query.setParameter("f_send_seq", CommonUtils.parseDouble(sendSeq));
		query.setParameter("f_recv_spot", recvSpot);
		query.setParameter("f_reciever_id", receiveId);
		
		List<String> list = query.getResultList();
		if(!StringUtils.isEmpty(list)){
			return list.get(0);
		}
		return null;
	}
}

