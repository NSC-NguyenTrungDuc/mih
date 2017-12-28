package nta.med.data.dao.medi.adm;

import java.util.List;

import nta.med.data.model.ihis.system.UdpHelperSendInfo;

/**
 * @author dainguyen.
 */
public interface Adm0710RepositoryCustom {
	public List<UdpHelperSendInfo> getUdpHelperSendInfoInfo(String hospCode, String senderId, Double sendSeq);
	public String getOCS2003U99InsertAdm0710Request(String hospCode, String senderId, String sendSeq, String recvSpot, String receiveId);
}

