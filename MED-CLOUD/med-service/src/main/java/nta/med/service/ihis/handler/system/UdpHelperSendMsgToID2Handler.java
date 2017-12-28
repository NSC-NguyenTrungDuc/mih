package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.adm.Adm0710Repository;
import nta.med.data.dao.medi.adm.Adm3400Repository;
import nta.med.data.model.ihis.system.UdpHelperSendInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UdpHelperSendMsgToID2Request;
import nta.med.service.ihis.proto.SystemServiceProto.UdpHelperSendMsgToID2Response;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")   
public class UdpHelperSendMsgToID2Handler extends ScreenHandler <SystemServiceProto.UdpHelperSendMsgToID2Request, SystemServiceProto.UdpHelperSendMsgToID2Response> {                      
	@Resource
	private Adm0710Repository adm0710Repository;
	
	@Resource
	private Adm3400Repository adm3400Repository;
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public UdpHelperSendMsgToID2Response handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			UdpHelperSendMsgToID2Request request) throws Exception {                                                                   
  	   	SystemServiceProto.UdpHelperSendMsgToID2Response.Builder response = SystemServiceProto.UdpHelperSendMsgToID2Response.newBuilder();  
  	   	String hospCode = getHospitalCode(vertx, sessionId);
		Double sendSeq = CommonUtils.parseDouble(request.getSendSeq());
		List<UdpHelperSendInfo> listInfo = adm0710Repository.getUdpHelperSendInfoInfo(hospCode, request.getSenderId(), sendSeq);
		if(!CollectionUtils.isEmpty(listInfo)){
			for(UdpHelperSendInfo info : listInfo){
				SystemModelProto.UdpHelperSendInfo.Builder builder = SystemModelProto.UdpHelperSendInfo.newBuilder();
				BeanUtils.copyProperties(info, builder, getLanguage(vertx, sessionId));
				
				
				List<String> listIpAddr = adm3400Repository.getListIpAddr(hospCode, info.getRecverId());
				if(!CollectionUtils.isEmpty(listIpAddr)){
					for(String ipAddr : listIpAddr){
						builder.setIpAddr(ipAddr);
						response.addInfo1(builder);
					}
				}
			}
		}
		return response.build();
	}
}
