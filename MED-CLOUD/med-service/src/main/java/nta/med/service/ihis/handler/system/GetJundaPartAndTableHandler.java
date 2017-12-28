package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0115Repository;
import nta.med.data.model.ihis.system.PrOcsLoadJundalInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.GetJundaPartAndTableRequest;
import nta.med.service.ihis.proto.SystemServiceProto.GetJundaPartAndTableResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class GetJundaPartAndTableHandler
	extends ScreenHandler<SystemServiceProto.GetJundaPartAndTableRequest, SystemServiceProto.GetJundaPartAndTableResponse> {                     
	@Resource                                                                                                       
	private Ocs0115Repository ocs0115Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional
	public GetJundaPartAndTableResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			GetJundaPartAndTableRequest request) throws Exception {                                                                 
  	   	SystemServiceProto.GetJundaPartAndTableResponse.Builder response = SystemServiceProto.GetJundaPartAndTableResponse.newBuilder();                      
		CommonModelProto.GetJundaPartAndTableRequestInfo.Builder item = CommonModelProto.GetJundaPartAndTableRequestInfo.newBuilder();
		if(item != null){
			PrOcsLoadJundalInfo info = ocs0115Repository.callPrOcsLoadJundalInfo(getHospitalCode(vertx, sessionId), item.getHangmogCode(), item.getInputPart(), item.getInputGwa(),
					DateUtil.toDate(item.getAppDate(), DateUtil.PATTERN_YYMMDD),"", "", "", "", "", "", "");
			if(info != null){
				if(info.getIoFlag().equalsIgnoreCase("O")){
					response.setExeResult(true);
					response.setJundalPartOut(info.getIoJundalPartOut() == null ? info.getIoJundalPartOut() : "");
					response.setJundalPartInp(info.getIoJundalPartInp() == null ? info.getIoJundalPartInp() : "");
					response.setJundalTableOut(info.getIoJundalTableOut() == null ? info.getIoJundalTableOut() : "");
					response.setJundalTableInp(info.getIoJundalTableInp() == null ? info.getIoJundalTableInp() : "");
					response.setMovePart(info.getIoMovePart() == null ? info.getIoMovePart() : "");
					response.setFlag(info.getIoFlag() == null ? info.getIoFlag() : "");
					response.setMsg(info.getIoMsg() == null ? info.getIoMsg() : "");
				}else{
					response.setExeResult(false);
				}
			}
		}
		return response.build();
	}
}