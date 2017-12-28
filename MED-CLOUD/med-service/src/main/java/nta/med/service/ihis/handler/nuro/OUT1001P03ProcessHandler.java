package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto.OUT1001P03PkKeyInfo;
import nta.med.service.ihis.proto.NuroServiceProto.OUT1001P03ProcessRequest;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")
@Transactional
public class OUT1001P03ProcessHandler extends ScreenHandler <OUT1001P03ProcessRequest,UpdateResponse>  {       
	private static final Log LOGGER = LogFactory.getLog(OUT1001P03ProcessHandler.class);
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;                                                                    
	                                                                                                                
	@Override                                                                                                       
	public UpdateResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			OUT1001P03ProcessRequest request) throws Exception{ 
		LOGGER.info(request.toString());
  	   	UpdateResponse.Builder response = UpdateResponse.newBuilder();
  	   	if(!callPr(request, getHospitalCode(vertx, sessionId))){
  	   		response.setResult(false);
			throw new ExecutionException(response.build());
  	   	}else{
  	   		response.setResult(true);
  	   	}
  	   	return response.build();
	}
	
	private boolean callPr(OUT1001P03ProcessRequest request, String hospCode){
		List<OUT1001P03PkKeyInfo> listPk = request.getPkKeyInfoList();
  	   	if(!CollectionUtils.isEmpty(listPk)){
  	   		for(OUT1001P03PkKeyInfo pkItem : listPk){
		   		String result = out1001Repository.callPrNurChangeBunho(hospCode,pkItem.getIoGubun(), request.getFromBunho(),
		   				CommonUtils.parseDouble(pkItem.getPkKey()), request.getToBunho(), request.getUserId());
				if(!"0".equalsIgnoreCase(result)){
					return false;
				}
  	   		}
  	   	}
  	  return true;
	}
}
