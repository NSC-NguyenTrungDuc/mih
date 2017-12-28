package nta.med.service.ihis.handler.phys;

import java.util.Date;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.phys.PHY2001U04PrOutMakeAutoJubsuInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.PhysServiceProto;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04CreateAutoJubsuRequest;
import nta.med.service.ihis.proto.PhysServiceProto.PHY2001U04CreateAutoJubsuResponse;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")  
@Transactional
public class PHY2001U04CreateAutoJubsuHandler
	extends ScreenHandler<PhysServiceProto.PHY2001U04CreateAutoJubsuRequest, PhysServiceProto.PHY2001U04CreateAutoJubsuResponse> {                     
	@Resource                                                                                                       
	private Out1001Repository out1001Repository;   
	@Resource
	private Ocs1003Repository ocs1003Repository;
	                                                                                                                
	@Override                                                                                                       
	public PHY2001U04CreateAutoJubsuResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			PHY2001U04CreateAutoJubsuRequest request) throws Exception {                                                                   
  	   	PhysServiceProto.PHY2001U04CreateAutoJubsuResponse.Builder response = PhysServiceProto.PHY2001U04CreateAutoJubsuResponse.newBuilder(); 
  	   	String hospCode = getHospitalCode(vertx, sessionId);
  	   	String language = getLanguage(vertx, sessionId);
  	   	String list0 = null;
  	   	String list1 = null;
  	   	String sin0 = null;
  	   	String sin1 = null;
		//Call PR_OUT_MAKE_AUTO_JUBSU
		 Double pkOut1001 = CommonUtils.parseDouble(request.getPkout1001());
		 PHY2001U04PrOutMakeAutoJubsuInfo outMakeResult = out1001Repository.callPrOutMakeAutoJubsuInfo(hospCode, pkOut1001, request.getGwa(),
				 request.getDoctor(), request.getJubsuGubun(), request.getUserId());
		 if(outMakeResult != null){
			 if(!"0".equalsIgnoreCase(outMakeResult.getIoErr())){
				 throw new ExecutionException(response.build());
			 }
			 if(outMakeResult.getIoNewPkout1001() != null){
				 list0 = String.valueOf(outMakeResult.getIoNewPkout1001());
			 }
			 list1 = outMakeResult.getIoErr();
		 }
		 //Call PR_REH_ADD_REHASINRYOURYOU
		 Date orderDate = DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD);
		 Double fkOut1001 = CommonUtils.parseDouble(request.getFkout1001());
		 ComboListItemInfo rehResult = ocs1003Repository.callPrRehAddRehasinryouryou(hospCode, language,
				 orderDate, request.getBunho(),  fkOut1001, request.getDoctor(), request.getSinryouryouGubun(), request.getInputId(), request.getInputTab(), request.getIudGubun());
		 if(rehResult != null){
			if(!"1".equalsIgnoreCase(rehResult.getCode())){
				throw new ExecutionException(response.build());
			}
			sin0 = rehResult.getCode();
			sin1 = rehResult.getCodeName();
		 }
			if(!StringUtils.isEmpty(list0)){
				response.setOutputList0(list0);
			}
			if(!StringUtils.isEmpty(list1)){
				response.setOutputList1(list1);
			}
			if(!StringUtils.isEmpty(sin0)){
				response.setOutputSin0(sin0);
			}
			if(!StringUtils.isEmpty(sin1)){
				response.setOutputSin1(sin1);
			}
			return response.build();
	}
}