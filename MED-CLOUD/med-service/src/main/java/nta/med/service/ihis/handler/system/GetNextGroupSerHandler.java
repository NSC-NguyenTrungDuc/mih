package nta.med.service.ihis.handler.system;

import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.com.ComDupRepository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.GetNextGroupSerRequest;
import nta.med.service.ihis.proto.SystemServiceProto.GetNextGroupSerResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class GetNextGroupSerHandler
	extends ScreenHandler<SystemServiceProto.GetNextGroupSerRequest, SystemServiceProto.GetNextGroupSerResponse> {                     
	@Resource                                                                                                       
	private ComDupRepository comDupRepository;                                                                    
	                                                                                                                
	@Override
	@Transactional
	public GetNextGroupSerResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId, GetNextGroupSerRequest request)
			throws Exception {                                                               
  	   	SystemServiceProto.GetNextGroupSerResponse.Builder response = SystemServiceProto.GetNextGroupSerResponse.newBuilder();
  	   	String hospCode = getHospitalCode(vertx, sessionId);
		List<Double> list = comDupRepository.getNextGroupSer(hospCode, request.getKeyObj(), request.getBunho(),
				request.getPkKey(), request.getInputTab());
		String nextGroupSer="";
		if(!CollectionUtils.isEmpty(list)){
				nextGroupSer= String.format("%.0f", list.get(list.size()-1));
			String turnGrpupSer="";
			if(request.getInputTab().length() > 0){
				if(request.getInputTab().substring(0, 1).equals("0")){
					if(request.getInputTab().length() > 1){
						turnGrpupSer=Integer.toString(CommonUtils.parseInteger(request.getInputTab().substring(1,2)+"00")+100);
					}				
					}else{
						turnGrpupSer = Integer.toString(CommonUtils.parseInteger(request.getInputTab() + "00")+100);
					}
			}
			
			if(nextGroupSer.equals(turnGrpupSer)){
				nextGroupSer= Integer.toString(CommonUtils.parseInteger(nextGroupSer) - 99);
			}
		}else{
			if(request.getInputTab().length() > 0){
				if(request.getInputTab().substring(0, 1).equals("0")){
					if(request.getInputTab().length() > 1){
						nextGroupSer=request.getInputTab().substring(1, 2)+"01";
					}	
				}else{
					nextGroupSer=request.getInputTab() +"01";
				}
			}
			
		}
		String maxGroup=comDupRepository.callPrOcsSetGroupSer(hospCode,request.getPkKey(),request.getBunho(),request.getInputTab(),nextGroupSer,request.getKeyObj());
		if(!StringUtils.isEmpty(nextGroupSer)){
			response.setResult(nextGroupSer);
		}
		return response.build();
	}
}